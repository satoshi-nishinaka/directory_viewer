namespace DirectoryViewer.View {
    partial class MainForm {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースが破棄される場合 true、破棄されない場合は false です。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxBrowseDirectories = new System.Windows.Forms.CheckedListBox();
            this.btnRemoveBrowseDirectory = new System.Windows.Forms.Button();
            this.btnAddBrowseDirectory = new System.Windows.Forms.Button();
            this.pictureBoxPreview = new System.Windows.Forms.PictureBox();
            this.statusStripImageInformation = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelImageSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileSize = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnClearListView = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmbDenyCondition = new System.Windows.Forms.ComboBox();
            this.cmbAllowCondition = new System.Windows.Forms.ComboBox();
            this.cmbDeny = new System.Windows.Forms.ComboBox();
            this.cmbAllow = new System.Windows.Forms.ComboBox();
            this.cbxIgnoreCase = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.listViewFileList = new System.Windows.Forms.ListView();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpenDirectory = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenByApplication = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStripFileInformation = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabelFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelFileCount = new System.Windows.Forms.ToolStripStatusLabel();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_File = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_AddDirectoryByDirectly = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_SaveSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_ReloadSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem_Close = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).BeginInit();
            this.statusStripImageInformation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip.SuspendLayout();
            this.statusStripFileInformation.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnClearListView);
            this.splitContainer1.Panel2.Controls.Add(this.button1);
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Panel2.Controls.Add(this.btnSearch);
            this.splitContainer1.Panel2.Controls.Add(this.listViewFileList);
            this.splitContainer1.Panel2.Controls.Add(this.statusStripFileInformation);
            this.splitContainer1.Size = new System.Drawing.Size(787, 608);
            this.splitContainer1.SplitterDistance = 262;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBoxPreview);
            this.splitContainer2.Panel2.Controls.Add(this.statusStripImageInformation);
            this.splitContainer2.Size = new System.Drawing.Size(262, 608);
            this.splitContainer2.SplitterDistance = 275;
            this.splitContainer2.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.checkedListBoxBrowseDirectories);
            this.groupBox1.Controls.Add(this.btnRemoveBrowseDirectory);
            this.groupBox1.Controls.Add(this.btnAddBrowseDirectory);
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.MinimumSize = new System.Drawing.Size(248, 234);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(248, 234);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "検索対象ディレクトリ";
            // 
            // checkedListBoxBrowseDirectories
            // 
            this.checkedListBoxBrowseDirectories.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.checkedListBoxBrowseDirectories.FormattingEnabled = true;
            this.checkedListBoxBrowseDirectories.Location = new System.Drawing.Point(8, 24);
            this.checkedListBoxBrowseDirectories.Name = "checkedListBoxBrowseDirectories";
            this.checkedListBoxBrowseDirectories.Size = new System.Drawing.Size(232, 158);
            this.checkedListBoxBrowseDirectories.TabIndex = 0;
            this.checkedListBoxBrowseDirectories.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.checkedListBoxBrowseDirectories_ItemCheck);
            // 
            // btnRemoveBrowseDirectory
            // 
            this.btnRemoveBrowseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBrowseDirectory.Location = new System.Drawing.Point(168, 202);
            this.btnRemoveBrowseDirectory.Name = "btnRemoveBrowseDirectory";
            this.btnRemoveBrowseDirectory.Size = new System.Drawing.Size(67, 23);
            this.btnRemoveBrowseDirectory.TabIndex = 2;
            this.btnRemoveBrowseDirectory.Text = "削除";
            this.btnRemoveBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnRemoveBrowseDirectory.Click += new System.EventHandler(this.btnRemoveBrowseDirectory_Click);
            // 
            // btnAddBrowseDirectory
            // 
            this.btnAddBrowseDirectory.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBrowseDirectory.Location = new System.Drawing.Point(96, 202);
            this.btnAddBrowseDirectory.Name = "btnAddBrowseDirectory";
            this.btnAddBrowseDirectory.Size = new System.Drawing.Size(67, 23);
            this.btnAddBrowseDirectory.TabIndex = 1;
            this.btnAddBrowseDirectory.Text = "追加";
            this.btnAddBrowseDirectory.UseVisualStyleBackColor = true;
            this.btnAddBrowseDirectory.Click += new System.EventHandler(this.btnAddBrowseDirectory_Click);
            // 
            // pictureBoxPreview
            // 
            this.pictureBoxPreview.BackColor = System.Drawing.Color.Black;
            this.pictureBoxPreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPreview.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxPreview.Name = "pictureBoxPreview";
            this.pictureBoxPreview.Size = new System.Drawing.Size(262, 307);
            this.pictureBoxPreview.TabIndex = 0;
            this.pictureBoxPreview.TabStop = false;
            this.pictureBoxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxPreview_Paint);
            this.pictureBoxPreview.DoubleClick += new System.EventHandler(this.pictureBoxPreview_DoubleClick);
            this.pictureBoxPreview.Resize += new System.EventHandler(this.pictureBoxPreview_Resize);
            // 
            // statusStripImageInformation
            // 
            this.statusStripImageInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelImageSize,
            this.toolStripStatusLabelFileSize});
            this.statusStripImageInformation.Location = new System.Drawing.Point(0, 307);
            this.statusStripImageInformation.Name = "statusStripImageInformation";
            this.statusStripImageInformation.Size = new System.Drawing.Size(262, 22);
            this.statusStripImageInformation.TabIndex = 1;
            this.statusStripImageInformation.Text = "statusStrip2";
            // 
            // toolStripStatusLabelImageSize
            // 
            this.toolStripStatusLabelImageSize.Name = "toolStripStatusLabelImageSize";
            this.toolStripStatusLabelImageSize.Size = new System.Drawing.Size(0, 17);
            // 
            // toolStripStatusLabelFileSize
            // 
            this.toolStripStatusLabelFileSize.Name = "toolStripStatusLabelFileSize";
            this.toolStripStatusLabelFileSize.Size = new System.Drawing.Size(0, 17);
            // 
            // btnClearListView
            // 
            this.btnClearListView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearListView.Location = new System.Drawing.Point(432, 488);
            this.btnClearListView.Name = "btnClearListView";
            this.btnClearListView.Size = new System.Drawing.Size(75, 23);
            this.btnClearListView.TabIndex = 7;
            this.btnClearListView.Text = "クリア";
            this.btnClearListView.UseVisualStyleBackColor = true;
            this.btnClearListView.Click += new System.EventHandler(this.btnClearListView_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(432, 552);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "ファイル集約";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.cmbDenyCondition);
            this.groupBox2.Controls.Add(this.cmbAllowCondition);
            this.groupBox2.Controls.Add(this.cmbDeny);
            this.groupBox2.Controls.Add(this.cmbAllow);
            this.groupBox2.Controls.Add(this.cbxIgnoreCase);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(8, 480);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(280, 96);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "フィルター";
            // 
            // cmbDenyCondition
            // 
            this.cmbDenyCondition.FormattingEnabled = true;
            this.cmbDenyCondition.Location = new System.Drawing.Point(200, 48);
            this.cmbDenyCondition.Name = "cmbDenyCondition";
            this.cmbDenyCondition.Size = new System.Drawing.Size(72, 20);
            this.cmbDenyCondition.TabIndex = 8;
            // 
            // cmbAllowCondition
            // 
            this.cmbAllowCondition.FormattingEnabled = true;
            this.cmbAllowCondition.Location = new System.Drawing.Point(200, 16);
            this.cmbAllowCondition.Name = "cmbAllowCondition";
            this.cmbAllowCondition.Size = new System.Drawing.Size(72, 20);
            this.cmbAllowCondition.TabIndex = 8;
            // 
            // cmbDeny
            // 
            this.cmbDeny.FormattingEnabled = true;
            this.cmbDeny.Location = new System.Drawing.Point(16, 48);
            this.cmbDeny.Name = "cmbDeny";
            this.cmbDeny.Size = new System.Drawing.Size(121, 20);
            this.cmbDeny.TabIndex = 7;
            this.cmbDeny.TextUpdate += new System.EventHandler(this.cmbDeny_TextUpdate);
            this.cmbDeny.TextChanged += new System.EventHandler(this.cmbDeny_TextChanged);
            this.cmbDeny.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbDeny_KeyDown);
            // 
            // cmbAllow
            // 
            this.cmbAllow.FormattingEnabled = true;
            this.cmbAllow.Location = new System.Drawing.Point(16, 16);
            this.cmbAllow.Name = "cmbAllow";
            this.cmbAllow.Size = new System.Drawing.Size(121, 20);
            this.cmbAllow.TabIndex = 6;
            this.cmbAllow.TextUpdate += new System.EventHandler(this.cmbAllow_TextUpdate);
            this.cmbAllow.TextChanged += new System.EventHandler(this.cmbAllow_TextChanged);
            this.cmbAllow.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cmbAllow_KeyDown);
            // 
            // cbxIgnoreCase
            // 
            this.cbxIgnoreCase.AutoSize = true;
            this.cbxIgnoreCase.Location = new System.Drawing.Point(32, 72);
            this.cbxIgnoreCase.Name = "cbxIgnoreCase";
            this.cbxIgnoreCase.Size = new System.Drawing.Size(158, 16);
            this.cbxIgnoreCase.TabIndex = 5;
            this.cbxIgnoreCase.Text = "大文字小文字を区別しない";
            this.cbxIgnoreCase.UseVisualStyleBackColor = true;
            this.cbxIgnoreCase.CheckedChanged += new System.EventHandler(this.cbxIgnoreCase_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(144, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "を含まない";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(144, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "を含む";
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(352, 488);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "検索";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // listViewFileList
            // 
            this.listViewFileList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewFileList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listViewFileList.ContextMenuStrip = this.contextMenuStrip;
            this.listViewFileList.GridLines = true;
            this.listViewFileList.Location = new System.Drawing.Point(8, 32);
            this.listViewFileList.MultiSelect = false;
            this.listViewFileList.Name = "listViewFileList";
            this.listViewFileList.Size = new System.Drawing.Size(504, 440);
            this.listViewFileList.TabIndex = 0;
            this.listViewFileList.UseCompatibleStateImageBehavior = false;
            this.listViewFileList.View = System.Windows.Forms.View.Details;
            this.listViewFileList.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewFileList_ColumnClick);
            this.listViewFileList.SelectedIndexChanged += new System.EventHandler(this.listViewFileList_SelectedIndexChanged);
            this.listViewFileList.DoubleClick += new System.EventHandler(this.listViewFileList_DoubleClick);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpenDirectory,
            this.toolStripMenuItemOpenByApplication});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(317, 48);
            // 
            // toolStripMenuItemOpenDirectory
            // 
            this.toolStripMenuItemOpenDirectory.Name = "toolStripMenuItemOpenDirectory";
            this.toolStripMenuItemOpenDirectory.Size = new System.Drawing.Size(316, 22);
            this.toolStripMenuItemOpenDirectory.Text = "フォルダを開く";
            this.toolStripMenuItemOpenDirectory.Click += new System.EventHandler(this.toolStripMenuItemOpenDirectory_Click);
            // 
            // toolStripMenuItemOpenByApplication
            // 
            this.toolStripMenuItemOpenByApplication.Name = "toolStripMenuItemOpenByApplication";
            this.toolStripMenuItemOpenByApplication.Size = new System.Drawing.Size(316, 22);
            this.toolStripMenuItemOpenByApplication.Text = "関連付けされているアプリケーションで開く";
            this.toolStripMenuItemOpenByApplication.Click += new System.EventHandler(this.toolStripMenuItemOpenByApplication_Click);
            // 
            // statusStripFileInformation
            // 
            this.statusStripFileInformation.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.statusStripFileInformation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabelFileName,
            this.toolStripStatusLabelFileCount});
            this.statusStripFileInformation.Location = new System.Drawing.Point(0, 586);
            this.statusStripFileInformation.Name = "statusStripFileInformation";
            this.statusStripFileInformation.Size = new System.Drawing.Size(521, 22);
            this.statusStripFileInformation.TabIndex = 1;
            // 
            // toolStripStatusLabelFileName
            // 
            this.toolStripStatusLabelFileName.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelFileName.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelFileName.Name = "toolStripStatusLabelFileName";
            this.toolStripStatusLabelFileName.Size = new System.Drawing.Size(4, 17);
            // 
            // toolStripStatusLabelFileCount
            // 
            this.toolStripStatusLabelFileCount.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.toolStripStatusLabelFileCount.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripStatusLabelFileCount.Name = "toolStripStatusLabelFileCount";
            this.toolStripStatusLabelFileCount.Size = new System.Drawing.Size(4, 17);
            this.toolStripStatusLabelFileCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_File});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(787, 26);
            this.menuStrip.TabIndex = 2;
            this.menuStrip.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_File
            // 
            this.ToolStripMenuItem_File.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog,
            this.toolStripMenuItem_AddDirectoryByDirectly,
            this.toolStripMenuItem_SaveSettings,
            this.toolStripMenuItem_ReloadSettings,
            this.toolStripMenuItem_Close});
            this.ToolStripMenuItem_File.Name = "ToolStripMenuItem_File";
            this.ToolStripMenuItem_File.Size = new System.Drawing.Size(68, 22);
            this.ToolStripMenuItem_File.Text = "ファイル";
            // 
            // toolStripMenuItem_AddDirectoryByFolderBrowseDialog
            // 
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog.Name = "toolStripMenuItem_AddDirectoryByFolderBrowseDialog";
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog.Size = new System.Drawing.Size(292, 22);
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog.Text = "検索対象ディレクトリを追加";
            this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog.Click += new System.EventHandler(this.toolStripMenuItem_AddDirectoryByFolderBrowseDialog_Click);
            // 
            // toolStripMenuItem_AddDirectoryByDirectly
            // 
            this.toolStripMenuItem_AddDirectoryByDirectly.Name = "toolStripMenuItem_AddDirectoryByDirectly";
            this.toolStripMenuItem_AddDirectoryByDirectly.Size = new System.Drawing.Size(292, 22);
            this.toolStripMenuItem_AddDirectoryByDirectly.Text = "直接入力で検索対象ディレクトリを追加";
            this.toolStripMenuItem_AddDirectoryByDirectly.Click += new System.EventHandler(this.toolStripMenuItem_AddDirectoryByDirectly_Click);
            // 
            // toolStripMenuItem_SaveSettings
            // 
            this.toolStripMenuItem_SaveSettings.Name = "toolStripMenuItem_SaveSettings";
            this.toolStripMenuItem_SaveSettings.Size = new System.Drawing.Size(292, 22);
            this.toolStripMenuItem_SaveSettings.Text = "設定ファイル保存";
            this.toolStripMenuItem_SaveSettings.Click += new System.EventHandler(this.toolStripMenuItem_SaveSettings_Click);
            // 
            // toolStripMenuItem_ReloadSettings
            // 
            this.toolStripMenuItem_ReloadSettings.Name = "toolStripMenuItem_ReloadSettings";
            this.toolStripMenuItem_ReloadSettings.Size = new System.Drawing.Size(292, 22);
            this.toolStripMenuItem_ReloadSettings.Text = "設定ファイル再読み込み";
            this.toolStripMenuItem_ReloadSettings.Click += new System.EventHandler(this.toolStripMenuItem_ReloadSettings_Click);
            // 
            // toolStripMenuItem_Close
            // 
            this.toolStripMenuItem_Close.Name = "toolStripMenuItem_Close";
            this.toolStripMenuItem_Close.Size = new System.Drawing.Size(292, 22);
            this.toolStripMenuItem_Close.Text = "終了";
            this.toolStripMenuItem_Close.Click += new System.EventHandler(this.toolStripMenuItem_Close_Click);
            // 
            // MainForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 608);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.splitContainer1);
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "DirectoryViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.MainForm_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.MainForm_DragOver);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPreview)).EndInit();
            this.statusStripImageInformation.ResumeLayout(false);
            this.statusStripImageInformation.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip.ResumeLayout(false);
            this.statusStripFileInformation.ResumeLayout(false);
            this.statusStripFileInformation.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.CheckedListBox checkedListBoxBrowseDirectories;
        private System.Windows.Forms.PictureBox pictureBoxPreview;
        private System.Windows.Forms.ListView listViewFileList;
        private System.Windows.Forms.StatusStrip statusStripFileInformation;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.Button btnAddBrowseDirectory;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveBrowseDirectory;
        private System.Windows.Forms.StatusStrip statusStripImageInformation;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_File;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_Close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnClearListView;
        private System.Windows.Forms.CheckBox cbxIgnoreCase;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelImageSize;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileName;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileSize;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenDirectory;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenByApplication;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_SaveSettings;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_ReloadSettings;
        private System.Windows.Forms.ComboBox cmbDeny;
        private System.Windows.Forms.ComboBox cmbAllow;
        private System.Windows.Forms.ComboBox cmbDenyCondition;
        private System.Windows.Forms.ComboBox cmbAllowCondition;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelFileCount;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddDirectoryByFolderBrowseDialog;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem_AddDirectoryByDirectly;
    }
}

