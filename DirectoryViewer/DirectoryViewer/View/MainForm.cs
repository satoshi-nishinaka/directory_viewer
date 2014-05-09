using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using DirectoryViewer.Controll;
using DirectoryViewer.Model;
using DirectoryViewer.Utility;
using DirectoryViewer.Utility.Image;
using DirectoryViewer.Utility.IO;
using DirectoryViewer.View.Dialog;

namespace DirectoryViewer.View
{
    public partial class MainForm : Form
    {

        private const string SettingFilePath = "settings.xml";

        #region メンバ変数

        private DataModel _dataModel = new DataModel();
        private string _currentImageFilePath = "";
        private Image _memorizedImage;
        private string _imagePath;
        private bool _storeImage = true;
        private readonly DirectorySearch _directorySearch = new DirectorySearch();

        //ListViewItemSorterに指定するフィールド
        private ListViewItemComparer listViewItemSorter;

        #endregion

        public MainForm()
        {
            InitializeComponent();

            _dataModel = FileSerializer.DesirializeDataModel(SettingFilePath);

            InitializeForm();

            // リストビューのColumnを設定
            listViewFileList.Columns.AddRange(FileModel.listViewColumnHeaders);
            listViewFileList.FullRowSelect = true;

            //ListViewItemComparerの作成と設定
            listViewItemSorter = new ListViewItemComparer();
            listViewItemSorter.ColumnModes =
                new ListViewItemComparer.ComparerMode[]
                    {

                        ListViewItemComparer.ComparerMode.String,
                        ListViewItemComparer.ComparerMode.String,
                        ListViewItemComparer.ComparerMode.Integer,
                        ListViewItemComparer.ComparerMode.String,
                        ListViewItemComparer.ComparerMode.String,
                        ListViewItemComparer.ComparerMode.String,
                    };
            //ListViewItemSorterを指定する
            listViewFileList.ListViewItemSorter = listViewItemSorter;
        }

        #region フォーム基本イベント

        /// <summary>
        /// フォームを閉じる時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Console.WriteLine(@"form closing");

            FileSerializer.SerializeDataModel(SettingFilePath, _dataModel);
        }

        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {

            if (e.Data.GetDataPresent(DataFormats.Text))
            {
                var temp = e.Data.GetData(DataFormats.Text);
                var uri = new UriBuilder((string) temp);
                var u = new Uri(uri.ToString());
            }
            else if (e.Data.GetDataPresent(DataFormats.FileDrop) == false)
            {
                return;
            }

            var dropFiles = (string[]) e.Data.GetData(DataFormats.FileDrop);

            var needRefresh = false;
            foreach (var path in dropFiles.Where(Directory.Exists))
            {
                var model = new BrowseDirectoryModel {DirectoryPath = path, IsBrowse = true};
                if (_dataModel.AddBrowseDirectory(model))
                {
                    needRefresh = true;
                }
            }
            if (needRefresh)
            {
                RefleshBrowseDirectories();
            }
        }

        private void MainForm_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }

        #endregion

        #region ボタンクリックイベント

        /// <summary>
        /// 追加ボタンをおした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAddBrowseDirectory_Click(object sender, EventArgs e)
        {
            AddBrowseDirectory();
        }

        /// <summary>
        /// 削除ボタンをおした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnRemoveBrowseDirectory_Click(object sender, EventArgs e)
        {
            var selectedIndexies = checkedListBoxBrowseDirectories.SelectedIndices;

            // メンバ変数から削除
            for (var i = selectedIndexies.Count; 0 < i; i--)
            {
                _dataModel.BrowseDirectories.RemoveAt(checkedListBoxBrowseDirectories.SelectedIndices[i - 1]);
            }

            RefleshBrowseDirectories();
        }

        /// <summary>
        /// 検索ボタンをおした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSearch_Click(object sender, EventArgs e)
        {
            SearchFiles();
        }

        /// <summary>
        /// クリアボタンをおした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnClearListView_Click(object sender, EventArgs e)
        {
            listViewFileList.Items.Clear();
        }

        #endregion

        #region チェックボックスリスト
        /// <summary>
        /// チェックボックスリストの値に変更があった時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void checkedListBoxBrowseDirectories_ItemCheck(object sender, ItemCheckEventArgs e)
        {
#if DEBUG
            Console.WriteLine("checkedListBoxBrowseDirectories_ItemCheck {0} {1} {2}", e.Index, e.CurrentValue, e.NewValue);
#endif
            _dataModel.BrowseDirectories[e.Index].IsBrowse = (e.NewValue == CheckState.Checked);
        }
        #endregion

        #region リストビューのイベント

        /// <summary>
        /// リストビューの選択アイテムに変更があった場合
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewFileList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selectedIndices = listViewFileList.SelectedIndices;
            if (selectedIndices.Count == 0)
                return;

            var selectedItem = listViewFileList.SelectedItems[0];
            var fileName = selectedItem.Text;
            var directory = selectedItem.SubItems[selectedItem.SubItems.Count - 1].Text;

            var fileModel =
                _dataModel.FileList.FirstOrDefault(r => r.FileName == fileName && r.DirectoryPath == directory);
            if(fileModel == null)
                return;

            toolStripStatusLabelFileName.Text = fileModel.FullPath;
            toolStripStatusLabelFileCount.Text = string.Format("{0} / {1}", selectedIndices[0] + 1,
                                                               _dataModel.FileList.Count);

            if (!fileModel.IsImageFile)
                return;

            Console.WriteLine(@"画像ファイル？");
            if (!File.Exists(fileModel.FullPath))
                return;

            _currentImageFilePath = fileModel.FullPath;

            var image = Image.FromFile(fileModel.FullPath, true);

            // ファイルの画像サイズ
            toolStripStatusLabelImageSize.Text = string.Format("{0} x {1}", image.Width, image.Height);
            toolStripStatusLabelFileSize.Text = fileModel.FileSize.ToString("#,0 バイト");
            image.Dispose();


            pictureBoxPreview.Invalidate();
        }

        /// <summary>
        /// リストビュー内でダブルクリックを行った時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewFileList_DoubleClick(object sender, EventArgs e)
        {
            var selectedIndicies = listViewFileList.SelectedIndices;
            if (selectedIndicies.Count == 0)
                return;

            var model = _dataModel.FileList[selectedIndicies[0]];
            if (!File.Exists(model.FullPath))
                return;

            Process.Start(model.FullPath);
        }

        /// <summary>
        /// リストビューの列をクリックした時のイベント
        /// http://dobon.net/vb/dotnet/control/lvitemsort.html
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listViewFileList_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //クリックされた列を設定
            listViewItemSorter.Column = e.Column;
            //並び替える
            listViewFileList.Sort();
        }

        #endregion

        #region プレビュー領域のイベント
        private void pictureBoxPreview_Resize(object sender, EventArgs e)
        {
            pictureBoxPreview.Invalidate();
        }

        private void pictureBoxPreview_Paint(object sender, PaintEventArgs e)
        {
            DrawImage(e.Graphics);
        }

        private void pictureBoxPreview_DoubleClick(object sender, EventArgs e)
        {
            if (!File.Exists(_currentImageFilePath))
                return;

            Process.Start(_currentImageFilePath);
        }
        #endregion

        #region フォームのフィルター関連のイベント

        private void cmbAllow_TextUpdate(object sender, EventArgs e)
        {
            _dataModel.Allow = cmbAllow.Text;
        }

        private void cmbAllow_TextChanged(object sender, EventArgs e)
        {
            _dataModel.Allow = cmbAllow.Text;
        }

        private void cmbAllow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchFiles();
        }

        private void cmbDeny_TextUpdate(object sender, EventArgs e)
        {
            _dataModel.Deny = cmbDeny.Text;
        }

        private void cmbDeny_TextChanged(object sender, EventArgs e)
        {
            _dataModel.Deny = cmbDeny.Text;
        }

        private void cmbDeny_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
                SearchFiles();
        }

        private void cbxIgnoreCase_CheckedChanged(object sender, EventArgs e)
        {
            _dataModel.IgnoreCase = cbxIgnoreCase.Checked;
        }

        #endregion

        #region メニューバー


        private void toolStripMenuItem_AddDirectoryByFolderBrowseDialog_Click(object sender, EventArgs e)
        {
            AddBrowseDirectory();
        }

        private void toolStripMenuItem_AddDirectoryByDirectly_Click(object sender, EventArgs e)
        {
            var textForm = new SimpleTextForm("検索対象のディレクトリパスを入力してください");
            var result = textForm.ShowDialog();

            if (result == DialogResult.OK)
            {
                var directoryPath = textForm.GetText();
                if (Directory.Exists(directoryPath))
                {
                    var model = new BrowseDirectoryModel { DirectoryPath = directoryPath, IsBrowse = true };

                    if (_dataModel.AddBrowseDirectory(model))
                    {
                        RefleshBrowseDirectories();
                    }
                }
                else
                {
                    MessageBox.Show(@"入力されたディレクトリは存在しません", @"エラー", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            textForm.Dispose();
        }

        private void toolStripMenuItem_SaveSettings_Click(object sender, EventArgs e)
        {
            FileSerializer.SerializeDataModel(SettingFilePath, _dataModel);
        }

        private void toolStripMenuItem_ReloadSettings_Click(object sender, EventArgs e)
        {
            _dataModel = FileSerializer.DesirializeDataModel(SettingFilePath);
            InitializeForm();
        }

        private void toolStripMenuItem_Close_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region コンテキストメニュー

        /// <summary>
        /// コンテキストメニューのフォルダを開くをクリックした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpenDirectory_Click(object sender, EventArgs e)
        {
            var selectedIndicies = listViewFileList.SelectedIndices;
            if (selectedIndicies.Count == 0)
                return;

            var model = _dataModel.FileList[selectedIndicies[0]];
            Process.Start(model.DirectoryPath);
        }

        /// <summary>
        /// コンテキストメニューの関連付けされているアプリケーションで開くをクリックした時のイベント
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItemOpenByApplication_Click(object sender, EventArgs e)
        {
            var selectedIndicies = listViewFileList.SelectedIndices;
            if (selectedIndicies.Count == 0)
                return;

            var model = _dataModel.FileList[selectedIndicies[0]];
            if (!File.Exists(model.FullPath))
                return;

            Process.Start(model.FullPath);
        }

        #endregion

        #region フォーム内操作メソッド

        /// <summary>
        /// 設定ファイルのデータモデルを元にフォームの値を設定します
        /// </summary>
        private void InitializeForm()
        {
            RefleshBrowseDirectories();

            cmbAllow.Items.Clear();
            if (_dataModel.AllowHistory != null)
            {
                foreach (var text in _dataModel.AllowHistory)
                {
                    cmbAllow.Items.Add(text);
                }
                var allow = _dataModel.AllowHistory.FirstOrDefault();
                if (allow != null)
                    cmbAllow.Text = allow;
            }

            cmbDeny.Items.Clear();
            if (_dataModel.DenyHistory != null)
            {
                foreach (var text in _dataModel.DenyHistory)
                {
                    cmbDeny.Items.Add(text);
                }
                var deny = _dataModel.DenyHistory.FirstOrDefault();
                if (deny != null)
                    cmbDeny.Text = deny;
            }

            cbxIgnoreCase.Checked = _dataModel.IgnoreCase;

            cmbAllowCondition.Items.Clear();
            foreach (var text in FileNameFilter.filterCase)
            {
                cmbAllowCondition.Items.Add(text);
            }
            cmbAllowCondition.Text = FileNameFilter.filterCase[(int) _dataModel.AllowFilter];

            cmbDenyCondition.Items.Clear();
            foreach (var text in FileNameFilter.filterCase)
            {
                cmbDenyCondition.Items.Add(text);
            }
            cmbDenyCondition.Text = FileNameFilter.filterCase[(int) _dataModel.DenyFilter];
        }

        /// <summary>
        /// チェックボックスリストの再描画を行います
        /// </summary>
        private void RefleshBrowseDirectories()
        {
            checkedListBoxBrowseDirectories.Items.Clear();
            foreach (var item in _dataModel.BrowseDirectories)
            {
                checkedListBoxBrowseDirectories.Items.Add(item.DirectoryPath, item.IsBrowse);
            }
        }

        /// <summary>
        /// 画像の描画実処理
        /// </summary>
        /// <param name="g"></param>
        private void DrawImage(Graphics g)
        {
            if (File.Exists(_currentImageFilePath) == false)
            {
                //// ファイルが存在しない場合
                if (string.IsNullOrEmpty(_currentImageFilePath))
                {
                    return;
                }
            }
            try
            {
                if (_storeImage == true && (_memorizedImage == null || _currentImageFilePath != _imagePath))
                {
                    if (_memorizedImage != null)
                    {
                        // 画像オブジェクトを開放して新しい画像を読み込み
                        _memorizedImage.Dispose();
                        _memorizedImage = null;
                    }
                    _memorizedImage = Image.FromFile(_currentImageFilePath, true);
                    _imagePath = _currentImageFilePath;

                }
                var image = (_memorizedImage != null ? _memorizedImage : Image.FromFile(_currentImageFilePath, true));

                // フォームのサイズに合わせる場合
                var nImageWidth = image.Width;
                var nImageHeight = image.Height;

                // サイズ計算
                var imageSize = ImageUtility.CulcScreenSize(pictureBoxPreview, nImageWidth, nImageHeight);

                var width = imageSize.Width;
                var height = imageSize.Height;

                try
                {
                    var left = (pictureBoxPreview.Width - width)/2;
                    g.DrawImage(image, left, 0, width, height);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.Source);
                    Console.WriteLine(e.StackTrace);
                }

                // 画像オブジェクトを開放
                if (_storeImage == false && _memorizedImage != null)
                {
                    _memorizedImage.Dispose();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    string.Format("エラーが発生しています\n\n{0}", ex.Message),
                    @"エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            // ガベージコレクション実行
            GC.Collect();
        }

        #endregion

        private void AddBrowseDirectory()
        {
            var result = folderBrowserDialog.ShowDialog();
            if (result != DialogResult.OK)
                return;

            var directoryPath = folderBrowserDialog.SelectedPath;
            var model = new BrowseDirectoryModel {DirectoryPath = directoryPath, IsBrowse = true};

            if (_dataModel.AddBrowseDirectory(model))
            {
                RefleshBrowseDirectories();
            }
        }

        private void SearchFiles()
        {
            _dataModel.AddAllowHistory(cmbAllow.Text);
            _dataModel.AddDenyHistory(cmbDeny.Text);
            _dataModel.AllowFilter = (FileNameFilter.FilterCase) cmbAllowCondition.SelectedIndex;
            _dataModel.DenyFilter = (FileNameFilter.FilterCase) cmbDenyCondition.SelectedIndex;

            // 強制的に再検索処理(ディレクトリが同じ時のみ使用する)
            var forceSearch = false;

            if (_directorySearch.IsSameCondition(_dataModel) && 0 < listViewFileList.Items.Count)
            {
                // 検索条件が同じ場合、再検索を行うか確認
                var result = MessageBox.Show(
                    "前回と同じ条件です。\r\n再検索を行いますか?",
                    @"ファイル検索",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.No)
                    return;

                forceSearch = true;
            }
            // データ初期化
            _dataModel.FileList = new List<FileModel>();

            var startTime = new TimeSpan(DateTime.Now.Ticks);

            var comparison = _dataModel.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
            var previousCursor = Cursor;
            Cursor = Cursors.WaitCursor;

            _directorySearch.Search(_dataModel, comparison, forceSearch);
            _dataModel.FileList = _directorySearch.GetFiles();

            listViewFileList.Items.Clear();
            listViewFileList.Items.AddRange(_dataModel.FileList.Select(r => r.ToListViewItem()).ToArray());

            Cursor = previousCursor;

            var endTime = new TimeSpan(DateTime.Now.Ticks) - startTime;

            MessageBox.Show(
                string.Format("検索終了\r\n{0} 秒\r\n\r\nファイル数: {1}", (endTime.Minutes*60 + endTime.Seconds),
                              _dataModel.FileList.Count),
                @"ファイル検索",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
    }
}