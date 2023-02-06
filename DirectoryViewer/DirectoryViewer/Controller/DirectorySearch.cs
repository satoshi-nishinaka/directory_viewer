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
        private string allow;
        private FileNameFilter.FilterCase allowFilter;
        private string deny;
        private FileNameFilter.FilterCase denyFilter;
        private bool ignoreCase;

        private string[] directories;
        private List<string> files;

        public string Status { get; private set; }
        #endregion

        /// <summary>
        /// ファイルのフルパスをキーとしたFileのDictionary
        /// </summary>
        private Dictionary<string, Model.File> fileList;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        public DirectorySearch()
        {
            // メンバ変数初期化
            directories = new string[0];
            files = new List<string>();
            allow = string.Empty;
            deny = string.Empty;
            ignoreCase = false;
        }

        /// <summary>
        /// ファイルリストにファイルを追加します
        /// </summary>
        /// <param name="files"></param>
        private void AddFiles(IEnumerable<string> files)
        {
            foreach (var file in files.Where(file => !this.files.Contains(file)))
            {
                this.files.Add(file);
            }
        }

        /// <summary>
        /// 前回と検索条件が同じかどうかをチェックします
        /// 同じ場合はTrue、異なる場合はFalseを返します
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool IsSameCondition(SearchCondition condition)
        {
            // 前回のディレクトリをチェック
            if (!IsSameDirectories(condition))
                return false;

            // フィルタリング文字列の比較
            return allow == condition.Allow && deny == condition.Deny && ignoreCase == condition.IgnoreCase;
        }

        /// <summary>
        /// 前回と検索条件が同じかどうかをチェックします
        /// 同じ場合はTrue、異なる場合はFalseを返します
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public bool IsSameDirectories(SearchCondition condition)
        {
            // 前回のディレクトリをチェック
            if (condition.Directories.Count != directories.Length)
                return false;

            // ReSharper disable LoopCanBeConvertedToQuery
            // LinQにすると読みづらいのでForeachのまま
            foreach (var directory in directories)
            // ReSharper restore LoopCanBeConvertedToQuery
            {
                var isMatch = condition.Directories.Any(condition => condition.DirectoryPath == directory);
                if (!isMatch)
                    return false;
            }

            return true;
        }

        /// <summary>
        /// ファイルの検索を行います
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="comparison"></param>
        /// <param name="isForceSearch"></param>
        public void Search(SearchCondition condition, StringComparison comparison, bool isForceSearch)
        {
            // メンバ変数をリセット
            allow = condition.Allow;
            allowFilter = condition.AllowFilter;
            deny = condition.Deny;
            denyFilter = condition.DenyFilter;
            ignoreCase = condition.IgnoreCase;

            fileList = new Dictionary<string, Model.File>();
            var filter = new FileNameFilter(allow, allowFilter, deny, denyFilter, ignoreCase);

            if (!isForceSearch && IsSameDirectories(condition))
            {
                Status = "メモリ内検索開始";

                // 前回とディレクトリが同じであれば再検索せず、メンバ変数に格納しておいたファイルパスのリストを元にフィルタリングかける
                Parallel.ForEach(
                    files, 
                    new ParallelOptions {MaxDegreeOfParallelism = MaxDegree}, 
                    file =>
                    {
                        var fileInfo = new FileInfo(file);
                        if (!filter.AllowFileName(fileInfo.Name))
                            return;

                        var _file = new Model.File
                        {
                            FullPath = file,
                            DirectoryPath = fileInfo.DirectoryName,
                            FileName = fileInfo.Name,
                            Extention = fileInfo.Extension,
                            FileSize = fileInfo.Length,
                            CreatedDate = fileInfo.CreationTime,
                            UpdatedDate = fileInfo.LastWriteTime
                        };
                        lock (fileList)
                        {
                            if (!fileList.ContainsKey(file))
                            {
                                fileList.Add(file, _file);
                            }
                        }
                    });

                Status = "検索終了";

                return;
            }


            directories = condition.Directories.Where(r => r.IsBrowse).Select(r => r.DirectoryPath).ToArray();
            files = new List<string>();

            // ディレクトリリストからファイルを抽出
            Parallel.ForEach(
                directories,
                new ParallelOptions { MaxDegreeOfParallelism = MaxDegree },
                directory =>
                {
                    try
                    {
                        var files = System.IO.Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
                        lock (this.files)
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
            Parallel.ForEach(files, new ParallelOptions {MaxDegreeOfParallelism = MaxDegree}, file =>
                {
                    // 内部的に全ファイルパスは所持しておく
                    // フィルターかけますよ
                    var fileInfo = new FileInfo(file);
                    if (!filter.AllowFileName(fileInfo.Name))
                        return;

                    //Console.WriteLine(file);
                    var _file = new Model.File
                        {
                            FullPath = file,
                            DirectoryPath = fileInfo.DirectoryName,
                            FileName = fileInfo.Name,
                            Extention = fileInfo.Extension,
                            FileSize = fileInfo.Length,
                            CreatedDate = fileInfo.CreationTime,
                            UpdatedDate = fileInfo.LastWriteTime
                        };
                    lock (fileList)
                    {
                        if (!fileList.ContainsKey(file))
                        {
                            fileList.Add(file, _file);
                        }
                    }
                });
        }

        /// <summary>
        /// 検索結果を返却します
        /// </summary>
        /// <returns></returns>
        public List<Model.File> GetFiles()
        {
            // 並び替え実行
            return fileList.Values
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
