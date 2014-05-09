using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using DirectoryViewer.Model;
using DirectoryViewer.Utility;

namespace DirectoryViewer.Controll
{
    public class DirectorySearch
    {
        private const int MaxDegree = 8;

        #region メンバ変数
        private string _allow;
        private FileNameFilter.FilterCase _allowFilter;
        private string _deny;
        private FileNameFilter.FilterCase _denyFilter;
        private bool _ignoreCase;

        private string[] _directories;
        private List<string> _files;

        public string Status { get; private set; }
        #endregion

        /// <summary>
        /// ファイルのフルパスをキーとしたFileModelのDictionary
        /// </summary>
        private Dictionary<string, FileModel> _fileModelList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DirectorySearch()
        {
            // メンバ変数初期化
            _directories = new string[0];
            _files = new List<string>();
            _allow = string.Empty;
            _deny = string.Empty;
            _ignoreCase = false;
        }

        /// <summary>
        /// ファイルリストにファイルを追加します
        /// </summary>
        /// <param name="files"></param>
        private void AddFiles(IEnumerable<string> files)
        {
            foreach (var file in files.Where(file => !_files.Contains(file)))
            {
                _files.Add(file);
            }
        }

        /// <summary>
        /// 前回と検索条件が同じかどうかをチェックします
        /// 同じ場合はTrue、異なる場合はFalseを返します
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public bool IsSameCondition(DataModel dataModel)
        {
            // 前回のディレクトリをチェック
            if (!IsSameDirectories(dataModel))
                return false;

            // フィルタリング文字列の比較
            return _allow == dataModel.Allow && _deny == dataModel.Deny && _ignoreCase == dataModel.IgnoreCase;
        }

        /// <summary>
        /// 前回と検索条件が同じかどうかをチェックします
        /// 同じ場合はTrue、異なる場合はFalseを返します
        /// </summary>
        /// <param name="dataModel"></param>
        /// <returns></returns>
        public bool IsSameDirectories(DataModel dataModel)
        {
            // 前回のディレクトリをチェック
            if (dataModel.BrowseDirectories.Count != _directories.Length)
                return false;

            // ReSharper disable LoopCanBeConvertedToQuery
            // LinQにすると読みづらいのでForeachのまま
            foreach (var directory in _directories)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                var isMatch = dataModel.BrowseDirectories.Any(model => model.DirectoryPath == directory);
                if (!isMatch)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// ファイルの検索を行います
        /// </summary>
        /// <param name="dataModel"></param>
        /// <param name="comparison"></param>
        /// <param name="isForceSearch"></param>
        public void Search(DataModel dataModel, StringComparison comparison, bool isForceSearch)
        {
            // メンバ変数をリセット
            _allow = dataModel.Allow;
            _allowFilter = dataModel.AllowFilter;
            _deny = dataModel.Deny;
            _denyFilter = dataModel.DenyFilter;
            _ignoreCase = dataModel.IgnoreCase;

            _fileModelList = new Dictionary<string, FileModel>();
            var filter = new FileNameFilter(_allow, _allowFilter, _deny, _denyFilter, _ignoreCase);

            if (!isForceSearch && IsSameDirectories(dataModel))
            {
                Status = "メモリ内検索開始";

                // 前回とディレクトリが同じであれば再検索せず、メンバ変数に格納しておいたファイルパスのリストを元にフィルタリングかける
                Parallel.ForEach(
                    _files, 
                    new ParallelOptions {MaxDegreeOfParallelism = MaxDegree}, 
                    file =>
                    {
                        var fileInfo = new FileInfo(file);
                        if (!filter.AllowFileName(fileInfo.Name))
                            return;

                        var fileModel = new FileModel
                        {
                            FullPath = file,
                            DirectoryPath = fileInfo.DirectoryName,
                            FileName = fileInfo.Name,
                            Extention = fileInfo.Extension,
                            FileSize = fileInfo.Length,
                            CreationDate = fileInfo.CreationTime,
                            UpdateDate = fileInfo.LastWriteTime
                        };
                        lock (_fileModelList)
                        {
                            if (!_fileModelList.ContainsKey(file))
                            {
                                _fileModelList.Add(file, fileModel);
                            }
                        }
                    });

                Status = "検索終了";

                return;
            }


            _directories = dataModel.BrowseDirectories.Where(r => r.IsBrowse).Select(r => r.DirectoryPath).ToArray();
            _files = new List<string>();

            // ディレクトリリストからファイルを抽出
            Parallel.ForEach(
                _directories,
                new ParallelOptions { MaxDegreeOfParallelism = MaxDegree },
                directory =>
                {
                    try
                    {
                        var files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
                        lock (_files)
                        {
                            AddFiles(files);
                        }
                    }
                    catch (UnauthorizedAccessException)
                    {
                        Console.WriteLine(@"アクセス不能　許可がありません {0}", directory);
                    }

                });

            // ファイルリストを元にフィルタリング
            Parallel.ForEach(_files, new ParallelOptions {MaxDegreeOfParallelism = MaxDegree}, file =>
                {
                    // 内部的に全ファイルパスは所持しておく
                    // フィルターかけますよ
                    var fileInfo = new FileInfo(file);
                    if (!filter.AllowFileName(fileInfo.Name))
                        return;

                    //Console.WriteLine(file);
                    var fileModel = new FileModel
                        {
                            FullPath = file,
                            DirectoryPath = fileInfo.DirectoryName,
                            FileName = fileInfo.Name,
                            Extention = fileInfo.Extension,
                            FileSize = fileInfo.Length,
                            CreationDate = fileInfo.CreationTime,
                            UpdateDate = fileInfo.LastWriteTime
                        };
                    lock (_fileModelList)
                    {
                        if (!_fileModelList.ContainsKey(file))
                        {
                            _fileModelList.Add(file, fileModel);
                        }
                    }
                });
        }

        /// <summary>
        /// 検索結果を返却します
        /// </summary>
        /// <returns></returns>
        public List<FileModel> GetFiles()
        {
            // 並び替え実行
            return _fileModelList.Values
                .OrderBy(r => r.DirectoryPath)
                .ThenBy(r => r.FileName)
                .ToList();
        }
    }

    public enum TaskStatus 
    {
        Waiting = 0,
        Running = 1,
        Finish = 2,
    }
}
