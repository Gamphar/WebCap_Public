
namespace WebCapV2
{
    partial class Form_Downloader
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("url");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("alias");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Mangadex", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("url");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("alias");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Mangalife", new System.Windows.Forms.TreeNode[] {
            treeNode4,
            treeNode5});
            System.Windows.Forms.TreeNode treeNode7 = new System.Windows.Forms.TreeNode("Title1", new System.Windows.Forms.TreeNode[] {
            treeNode3,
            treeNode6});
            System.Windows.Forms.TreeNode treeNode8 = new System.Windows.Forms.TreeNode("https://mangadex.org/title/52ede55c-1584-4019-b85b-3902a423c3ab/fairy-tail-100-ye" +
        "ars-quest");
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Fairy Tail 100 Years Quest");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Feari Teiru: Hyaku-nen Kuesuto");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Mangadex", new System.Windows.Forms.TreeNode[] {
            treeNode8,
            treeNode9,
            treeNode10});
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Fairy Tail: 100 Years Quest", new System.Windows.Forms.TreeNode[] {
            treeNode11});
            System.Windows.Forms.TreeNode treeNode13 = new System.Windows.Forms.TreeNode("Mangadex");
            System.Windows.Forms.TreeNode treeNode14 = new System.Windows.Forms.TreeNode("Title3", new System.Windows.Forms.TreeNode[] {
            treeNode13});
            this.tabControl_TitleList = new System.Windows.Forms.TabControl();
            this.tabPage_Title_Read = new System.Windows.Forms.TabPage();
            this.btnX_saveroot = new System.Windows.Forms.Button();
            this.btnXSearch1 = new System.Windows.Forms.Button();
            this.btn_searchReadList = new System.Windows.Forms.Button();
            this.textBox_seaarchReadList = new System.Windows.Forms.TextBox();
            this.btn_deleteSelectedReadList = new System.Windows.Forms.Button();
            this.btn_LoadTitleList = new System.Windows.Forms.Button();
            this.btn_SaveTitleList = new System.Windows.Forms.Button();
            this.textBox_title_rootDir = new System.Windows.Forms.TextBox();
            this.btn_title_saveKomikRootDir = new System.Windows.Forms.Button();
            this.TV_ReadList = new System.Windows.Forms.TreeView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.titleNameInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mangaSiteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.openChapterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sendTitleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.onHoldListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabPage_Title_OnHold = new System.Windows.Forms.TabPage();
            this.TV_OnHoldList = new System.Windows.Forms.TreeView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Title = new System.Windows.Forms.TabPage();
            this.panel13 = new System.Windows.Forms.Panel();
            this.btn_Trim_Alias = new System.Windows.Forms.Button();
            this.btn_clearNewTitleListInputDialog = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_addAsReadList = new System.Windows.Forms.Button();
            this.textBox_addReadList_Alias = new System.Windows.Forms.TextBox();
            this.textBox_addReadList_SiteSource = new System.Windows.Forms.TextBox();
            this.textBox_addReadList_ChapterListPageURL = new System.Windows.Forms.TextBox();
            this.textBox_addReadList_TitleName = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.splitter3 = new System.Windows.Forms.Splitter();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel9 = new System.Windows.Forms.Panel();
            this.tabControl_chapterSelection = new System.Windows.Forms.TabControl();
            this.tabPage7 = new System.Windows.Forms.TabPage();
            this.textBox_titleDesc = new System.Windows.Forms.TextBox();
            this.tabPage8 = new System.Windows.Forms.TabPage();
            this.panel_cart = new System.Windows.Forms.Panel();
            this.DGV_ChapterCartList = new System.Windows.Forms.DataGridView();
            this.Col_cart_chapterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_timeAddedToDList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterImageCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterAttVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterAttChapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterImageHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterIsObsolute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_scanGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_uploader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_cart_chapterTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel11 = new System.Windows.Forms.Panel();
            this.btn_cart_checkNumbering = new System.Windows.Forms.Button();
            this.btn_cart_delete = new System.Windows.Forms.Button();
            this.label_cart_count = new System.Windows.Forms.Label();
            this.btn_cartClear = new System.Windows.Forms.Button();
            this.btn_cart_addAsNewTask = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.btn_cart_x = new System.Windows.Forms.Button();
            this.splitter4 = new System.Windows.Forms.Splitter();
            this.panel8 = new System.Windows.Forms.Panel();
            this.labelPerc_cover = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_loadChapterList = new System.Windows.Forms.Button();
            this.btn_saveChapterList = new System.Windows.Forms.Button();
            this.DGV_ChapterList = new System.Windows.Forms.DataGridView();
            this.Col_chapter_chapterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_timeAddedToDList = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterHash = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterImageCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterAttVolume = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterAttChapter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterImageHost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_isObsolute = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_scanGroup = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_uploader = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Col_chapter_chapterTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CMS_DGV_Chapter = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.saveLoadUpdateChapterListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkAddStartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bulkAddEndToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addAllToCartToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeTimeAddedToDListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitter2 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_getChapterList = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ChapterSource = new System.Windows.Forms.TextBox();
            this.textBox_ChapterTitleName = new System.Windows.Forms.TextBox();
            this.textBox_ChapterURL = new System.Windows.Forms.TextBox();
            this.tabPage_Image_Download = new System.Windows.Forms.TabPage();
            this.panel5 = new System.Windows.Forms.Panel();
            this.tabControl3 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btn_delSelectedTaskIdle = new System.Windows.Forms.Button();
            this.panel12 = new System.Windows.Forms.Panel();
            this.btn_stopDownloadQueue = new System.Windows.Forms.Button();
            this.btn_moveRunningToIdle = new System.Windows.Forms.Button();
            this.btn_loadTaskListFromJson = new System.Windows.Forms.Button();
            this.btn_taskListToJson = new System.Windows.Forms.Button();
            this.btn_startDownloadQueue = new System.Windows.Forms.Button();
            this.TV_taskDone = new System.Windows.Forms.TreeView();
            this.TV_taskRunning = new System.Windows.Forms.TreeView();
            this.TV_taskList = new System.Windows.Forms.TreeView();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.progressBar_ChapterList = new System.Windows.Forms.ProgressBar();
            this.progressBar_ImageList = new System.Windows.Forms.ProgressBar();
            this.labelDownloaded = new System.Windows.Forms.Label();
            this.labelPerc = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.labelSpeed = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_testDownloadFile = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_testJsonWebClient = new System.Windows.Forms.Button();
            this.btn_takeScreenShot = new System.Windows.Forms.Button();
            this.btn_addRowChapter = new System.Windows.Forms.Button();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btn_getJson = new System.Windows.Forms.Button();
            this.btn_test_listImgUrls = new System.Windows.Forms.Button();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.panel_login = new System.Windows.Forms.Panel();
            this.CWB_login = new CefSharp.WinForms.ChromiumWebBrowser();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btn_setIsNSFW = new System.Windows.Forms.Button();
            this.textBox_login = new System.Windows.Forms.TextBox();
            this.panel_log = new System.Windows.Forms.Panel();
            this.textBox_global_log = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer_updateCover = new System.Windows.Forms.Timer(this.components);
            this.tabPage_Title_Completed = new System.Windows.Forms.TabPage();
            this.tabPage_Title_Drop = new System.Windows.Forms.TabPage();
            this.TV_CompletedList = new System.Windows.Forms.TreeView();
            this.TV_DropList = new System.Windows.Forms.TreeView();
            this.completedListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dropListToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl_TitleList.SuspendLayout();
            this.tabPage_Title_Read.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.tabPage_Title_OnHold.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage_Title.SuspendLayout();
            this.panel13.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panel9.SuspendLayout();
            this.tabControl_chapterSelection.SuspendLayout();
            this.tabPage7.SuspendLayout();
            this.tabPage8.SuspendLayout();
            this.panel_cart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ChapterCartList)).BeginInit();
            this.panel11.SuspendLayout();
            this.panel10.SuspendLayout();
            this.panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ChapterList)).BeginInit();
            this.CMS_DGV_Chapter.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabPage_Image_Download.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tabControl3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel12.SuspendLayout();
            this.tabPage3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.tabPage5.SuspendLayout();
            this.tabPage6.SuspendLayout();
            this.panel_login.SuspendLayout();
            this.panel14.SuspendLayout();
            this.panel_log.SuspendLayout();
            this.tabPage_Title_Completed.SuspendLayout();
            this.tabPage_Title_Drop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_TitleList
            // 
            this.tabControl_TitleList.Controls.Add(this.tabPage_Title_Read);
            this.tabControl_TitleList.Controls.Add(this.tabPage_Title_OnHold);
            this.tabControl_TitleList.Controls.Add(this.tabPage_Title_Completed);
            this.tabControl_TitleList.Controls.Add(this.tabPage_Title_Drop);
            this.tabControl_TitleList.Dock = System.Windows.Forms.DockStyle.Right;
            this.tabControl_TitleList.Location = new System.Drawing.Point(637, 3);
            this.tabControl_TitleList.Name = "tabControl_TitleList";
            this.tabControl_TitleList.SelectedIndex = 0;
            this.tabControl_TitleList.Size = new System.Drawing.Size(367, 584);
            this.tabControl_TitleList.TabIndex = 1;
            this.tabControl_TitleList.SelectedIndexChanged += new System.EventHandler(this.tabControl_TitleList_SelectedIndexChanged);
            // 
            // tabPage_Title_Read
            // 
            this.tabPage_Title_Read.Controls.Add(this.btnX_saveroot);
            this.tabPage_Title_Read.Controls.Add(this.btnXSearch1);
            this.tabPage_Title_Read.Controls.Add(this.btn_searchReadList);
            this.tabPage_Title_Read.Controls.Add(this.textBox_seaarchReadList);
            this.tabPage_Title_Read.Controls.Add(this.btn_deleteSelectedReadList);
            this.tabPage_Title_Read.Controls.Add(this.btn_LoadTitleList);
            this.tabPage_Title_Read.Controls.Add(this.btn_SaveTitleList);
            this.tabPage_Title_Read.Controls.Add(this.textBox_title_rootDir);
            this.tabPage_Title_Read.Controls.Add(this.btn_title_saveKomikRootDir);
            this.tabPage_Title_Read.Controls.Add(this.TV_ReadList);
            this.tabPage_Title_Read.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Title_Read.Name = "tabPage_Title_Read";
            this.tabPage_Title_Read.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Title_Read.Size = new System.Drawing.Size(359, 558);
            this.tabPage_Title_Read.TabIndex = 0;
            this.tabPage_Title_Read.Text = "Read List";
            this.tabPage_Title_Read.UseVisualStyleBackColor = true;
            // 
            // btnX_saveroot
            // 
            this.btnX_saveroot.Location = new System.Drawing.Point(6, 406);
            this.btnX_saveroot.Name = "btnX_saveroot";
            this.btnX_saveroot.Size = new System.Drawing.Size(26, 23);
            this.btnX_saveroot.TabIndex = 9;
            this.btnX_saveroot.Text = "X";
            this.btnX_saveroot.UseVisualStyleBackColor = true;
            this.btnX_saveroot.Click += new System.EventHandler(this.btnX_saveroot_Click);
            // 
            // btnXSearch1
            // 
            this.btnXSearch1.Location = new System.Drawing.Point(6, 377);
            this.btnXSearch1.Name = "btnXSearch1";
            this.btnXSearch1.Size = new System.Drawing.Size(26, 23);
            this.btnXSearch1.TabIndex = 8;
            this.btnXSearch1.Text = "X";
            this.btnXSearch1.UseVisualStyleBackColor = true;
            this.btnXSearch1.Click += new System.EventHandler(this.btnXSearch1_Click);
            // 
            // btn_searchReadList
            // 
            this.btn_searchReadList.Location = new System.Drawing.Point(278, 375);
            this.btn_searchReadList.Name = "btn_searchReadList";
            this.btn_searchReadList.Size = new System.Drawing.Size(75, 23);
            this.btn_searchReadList.TabIndex = 7;
            this.btn_searchReadList.Text = "Seach";
            this.btn_searchReadList.UseVisualStyleBackColor = true;
            this.btn_searchReadList.Click += new System.EventHandler(this.btn_searchReadList_Click);
            // 
            // textBox_seaarchReadList
            // 
            this.textBox_seaarchReadList.Location = new System.Drawing.Point(38, 377);
            this.textBox_seaarchReadList.Name = "textBox_seaarchReadList";
            this.textBox_seaarchReadList.Size = new System.Drawing.Size(238, 20);
            this.textBox_seaarchReadList.TabIndex = 6;
            // 
            // btn_deleteSelectedReadList
            // 
            this.btn_deleteSelectedReadList.Location = new System.Drawing.Point(3, 432);
            this.btn_deleteSelectedReadList.Name = "btn_deleteSelectedReadList";
            this.btn_deleteSelectedReadList.Size = new System.Drawing.Size(350, 23);
            this.btn_deleteSelectedReadList.TabIndex = 5;
            this.btn_deleteSelectedReadList.Text = "Delete Selected Title";
            this.btn_deleteSelectedReadList.UseVisualStyleBackColor = true;
            this.btn_deleteSelectedReadList.Click += new System.EventHandler(this.btn_deleteSelectedReadList_Click);
            // 
            // btn_LoadTitleList
            // 
            this.btn_LoadTitleList.Location = new System.Drawing.Point(6, 500);
            this.btn_LoadTitleList.Name = "btn_LoadTitleList";
            this.btn_LoadTitleList.Size = new System.Drawing.Size(75, 23);
            this.btn_LoadTitleList.TabIndex = 4;
            this.btn_LoadTitleList.Text = "Load";
            this.btn_LoadTitleList.UseVisualStyleBackColor = true;
            this.btn_LoadTitleList.Click += new System.EventHandler(this.btn_LoadTitleList_Click);
            // 
            // btn_SaveTitleList
            // 
            this.btn_SaveTitleList.Location = new System.Drawing.Point(6, 529);
            this.btn_SaveTitleList.Name = "btn_SaveTitleList";
            this.btn_SaveTitleList.Size = new System.Drawing.Size(75, 23);
            this.btn_SaveTitleList.TabIndex = 3;
            this.btn_SaveTitleList.Text = "Save";
            this.btn_SaveTitleList.UseVisualStyleBackColor = true;
            this.btn_SaveTitleList.Click += new System.EventHandler(this.btn_SaveReadList_Click);
            // 
            // textBox_title_rootDir
            // 
            this.textBox_title_rootDir.Location = new System.Drawing.Point(38, 406);
            this.textBox_title_rootDir.Name = "textBox_title_rootDir";
            this.textBox_title_rootDir.Size = new System.Drawing.Size(238, 20);
            this.textBox_title_rootDir.TabIndex = 2;
            // 
            // btn_title_saveKomikRootDir
            // 
            this.btn_title_saveKomikRootDir.Location = new System.Drawing.Point(278, 404);
            this.btn_title_saveKomikRootDir.Name = "btn_title_saveKomikRootDir";
            this.btn_title_saveKomikRootDir.Size = new System.Drawing.Size(75, 23);
            this.btn_title_saveKomikRootDir.TabIndex = 1;
            this.btn_title_saveKomikRootDir.Text = "save root";
            this.btn_title_saveKomikRootDir.UseVisualStyleBackColor = true;
            this.btn_title_saveKomikRootDir.Click += new System.EventHandler(this.btn_title_saveKomikRootDir_Click);
            // 
            // TV_ReadList
            // 
            this.TV_ReadList.ContextMenuStrip = this.contextMenuStrip1;
            this.TV_ReadList.HideSelection = false;
            this.TV_ReadList.HotTracking = true;
            this.TV_ReadList.Location = new System.Drawing.Point(6, 6);
            this.TV_ReadList.Name = "TV_ReadList";
            treeNode1.Name = "Node10";
            treeNode1.Text = "url";
            treeNode2.Name = "Node11";
            treeNode2.Text = "alias";
            treeNode3.Name = "Node1";
            treeNode3.Text = "Mangadex";
            treeNode4.Name = "Node12";
            treeNode4.Text = "url";
            treeNode5.Name = "Node13";
            treeNode5.Text = "alias";
            treeNode6.Name = "Node8";
            treeNode6.Text = "Mangalife";
            treeNode7.Name = "Node0";
            treeNode7.Text = "Title1";
            treeNode8.Name = "Node6";
            treeNode8.Text = "https://mangadex.org/title/52ede55c-1584-4019-b85b-3902a423c3ab/fairy-tail-100-ye" +
    "ars-quest";
            treeNode9.Name = "Node14";
            treeNode9.Text = "Fairy Tail 100 Years Quest";
            treeNode10.Name = "Node15";
            treeNode10.Text = "Feari Teiru: Hyaku-nen Kuesuto";
            treeNode11.Name = "Node4";
            treeNode11.Text = "Mangadex";
            treeNode12.Name = "Node2";
            treeNode12.Text = "Fairy Tail: 100 Years Quest";
            treeNode13.Name = "Node7";
            treeNode13.Text = "Mangadex";
            treeNode14.Name = "Node3";
            treeNode14.Text = "Title3";
            this.TV_ReadList.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode7,
            treeNode12,
            treeNode14});
            this.TV_ReadList.Size = new System.Drawing.Size(347, 365);
            this.TV_ReadList.TabIndex = 0;
            this.TV_ReadList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.titleNameInfoToolStripMenuItem,
            this.mangaSiteToolStripMenuItem,
            this.toolStripSeparator1,
            this.openChapterToolStripMenuItem,
            this.editTitleToolStripMenuItem,
            this.sortTitleToolStripMenuItem,
            this.sendTitleToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(181, 164);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // titleNameInfoToolStripMenuItem
            // 
            this.titleNameInfoToolStripMenuItem.Name = "titleNameInfoToolStripMenuItem";
            this.titleNameInfoToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.titleNameInfoToolStripMenuItem.Text = "Title Name Info";
            // 
            // mangaSiteToolStripMenuItem
            // 
            this.mangaSiteToolStripMenuItem.Name = "mangaSiteToolStripMenuItem";
            this.mangaSiteToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.mangaSiteToolStripMenuItem.Text = "Manga Site";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // openChapterToolStripMenuItem
            // 
            this.openChapterToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.openChapterToolStripMenuItem.Name = "openChapterToolStripMenuItem";
            this.openChapterToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openChapterToolStripMenuItem.Text = "Open Chapter";
            this.openChapterToolStripMenuItem.Click += new System.EventHandler(this.openChapterToolStripMenuItem_Click);
            // 
            // editTitleToolStripMenuItem
            // 
            this.editTitleToolStripMenuItem.Name = "editTitleToolStripMenuItem";
            this.editTitleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.editTitleToolStripMenuItem.Text = "Edit Title";
            this.editTitleToolStripMenuItem.Click += new System.EventHandler(this.editTitleToolStripMenuItem_Click);
            // 
            // sortTitleToolStripMenuItem
            // 
            this.sortTitleToolStripMenuItem.Name = "sortTitleToolStripMenuItem";
            this.sortTitleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sortTitleToolStripMenuItem.Text = "Sort Title";
            this.sortTitleToolStripMenuItem.Click += new System.EventHandler(this.sortTitleToolStripMenuItem_Click);
            // 
            // sendTitleToolStripMenuItem
            // 
            this.sendTitleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readListToolStripMenuItem,
            this.onHoldListToolStripMenuItem,
            this.completedListToolStripMenuItem,
            this.dropListToolStripMenuItem});
            this.sendTitleToolStripMenuItem.Name = "sendTitleToolStripMenuItem";
            this.sendTitleToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.sendTitleToolStripMenuItem.Text = "Send Title To";
            this.sendTitleToolStripMenuItem.DropDownOpening += new System.EventHandler(this.sendTitleToolStripMenuItem_DropDownOpening);
            // 
            // onHoldListToolStripMenuItem
            // 
            this.onHoldListToolStripMenuItem.Name = "onHoldListToolStripMenuItem";
            this.onHoldListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.onHoldListToolStripMenuItem.Text = "On-Hold List";
            this.onHoldListToolStripMenuItem.Click += new System.EventHandler(this.onHoldToolStripMenuItem_Click);
            // 
            // readListToolStripMenuItem
            // 
            this.readListToolStripMenuItem.Name = "readListToolStripMenuItem";
            this.readListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.readListToolStripMenuItem.Text = "Read List";
            this.readListToolStripMenuItem.Click += new System.EventHandler(this.readListToolStripMenuItem_Click);
            // 
            // tabPage_Title_OnHold
            // 
            this.tabPage_Title_OnHold.Controls.Add(this.TV_OnHoldList);
            this.tabPage_Title_OnHold.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Title_OnHold.Name = "tabPage_Title_OnHold";
            this.tabPage_Title_OnHold.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Title_OnHold.Size = new System.Drawing.Size(359, 558);
            this.tabPage_Title_OnHold.TabIndex = 1;
            this.tabPage_Title_OnHold.Text = "On-Hold List";
            this.tabPage_Title_OnHold.UseVisualStyleBackColor = true;
            // 
            // TV_OnHoldList
            // 
            this.TV_OnHoldList.ContextMenuStrip = this.contextMenuStrip1;
            this.TV_OnHoldList.HideSelection = false;
            this.TV_OnHoldList.HotTracking = true;
            this.TV_OnHoldList.Location = new System.Drawing.Point(6, 6);
            this.TV_OnHoldList.Name = "TV_OnHoldList";
            this.TV_OnHoldList.Size = new System.Drawing.Size(347, 365);
            this.TV_OnHoldList.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tabControl1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1015, 616);
            this.panel1.TabIndex = 2;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Title);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage_Image_Download);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1015, 616);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabControl1.TabIndexChanged += new System.EventHandler(this.tabControl1_TabIndexChanged);
            // 
            // tabPage_Title
            // 
            this.tabPage_Title.Controls.Add(this.panel13);
            this.tabPage_Title.Controls.Add(this.tabControl_TitleList);
            this.tabPage_Title.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Title.Name = "tabPage_Title";
            this.tabPage_Title.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Title.Size = new System.Drawing.Size(1007, 590);
            this.tabPage_Title.TabIndex = 0;
            this.tabPage_Title.Text = "Title Selection";
            this.tabPage_Title.UseVisualStyleBackColor = true;
            // 
            // panel13
            // 
            this.panel13.Controls.Add(this.btn_Trim_Alias);
            this.panel13.Controls.Add(this.btn_clearNewTitleListInputDialog);
            this.panel13.Controls.Add(this.label7);
            this.panel13.Controls.Add(this.label6);
            this.panel13.Controls.Add(this.label5);
            this.panel13.Controls.Add(this.label4);
            this.panel13.Controls.Add(this.btn_addAsReadList);
            this.panel13.Controls.Add(this.textBox_addReadList_Alias);
            this.panel13.Controls.Add(this.textBox_addReadList_SiteSource);
            this.panel13.Controls.Add(this.textBox_addReadList_ChapterListPageURL);
            this.panel13.Controls.Add(this.textBox_addReadList_TitleName);
            this.panel13.Location = new System.Drawing.Point(38, 31);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(569, 334);
            this.panel13.TabIndex = 2;
            // 
            // btn_Trim_Alias
            // 
            this.btn_Trim_Alias.Location = new System.Drawing.Point(509, 134);
            this.btn_Trim_Alias.Name = "btn_Trim_Alias";
            this.btn_Trim_Alias.Size = new System.Drawing.Size(57, 23);
            this.btn_Trim_Alias.TabIndex = 10;
            this.btn_Trim_Alias.Text = "Trim";
            this.btn_Trim_Alias.UseVisualStyleBackColor = true;
            this.btn_Trim_Alias.Click += new System.EventHandler(this.btn_Trim_Alias_Click);
            // 
            // btn_clearNewTitleListInputDialog
            // 
            this.btn_clearNewTitleListInputDialog.Location = new System.Drawing.Point(18, 300);
            this.btn_clearNewTitleListInputDialog.Name = "btn_clearNewTitleListInputDialog";
            this.btn_clearNewTitleListInputDialog.Size = new System.Drawing.Size(75, 23);
            this.btn_clearNewTitleListInputDialog.TabIndex = 9;
            this.btn_clearNewTitleListInputDialog.Text = "Clear";
            this.btn_clearNewTitleListInputDialog.UseVisualStyleBackColor = true;
            this.btn_clearNewTitleListInputDialog.Click += new System.EventHandler(this.btn_clearNewTitleListInputDialog_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 118);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Alias";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(394, 10);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Site Source";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Chapter List Page URL";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Title Name";
            // 
            // btn_addAsReadList
            // 
            this.btn_addAsReadList.Location = new System.Drawing.Point(397, 300);
            this.btn_addAsReadList.Name = "btn_addAsReadList";
            this.btn_addAsReadList.Size = new System.Drawing.Size(106, 23);
            this.btn_addAsReadList.TabIndex = 4;
            this.btn_addAsReadList.Text = "Add As Read List";
            this.btn_addAsReadList.UseVisualStyleBackColor = true;
            this.btn_addAsReadList.Click += new System.EventHandler(this.btn_addAsReadList_Click);
            // 
            // textBox_addReadList_Alias
            // 
            this.textBox_addReadList_Alias.Location = new System.Drawing.Point(18, 134);
            this.textBox_addReadList_Alias.Multiline = true;
            this.textBox_addReadList_Alias.Name = "textBox_addReadList_Alias";
            this.textBox_addReadList_Alias.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_addReadList_Alias.Size = new System.Drawing.Size(485, 160);
            this.textBox_addReadList_Alias.TabIndex = 3;
            this.textBox_addReadList_Alias.WordWrap = false;
            // 
            // textBox_addReadList_SiteSource
            // 
            this.textBox_addReadList_SiteSource.Location = new System.Drawing.Point(397, 26);
            this.textBox_addReadList_SiteSource.Name = "textBox_addReadList_SiteSource";
            this.textBox_addReadList_SiteSource.Size = new System.Drawing.Size(106, 20);
            this.textBox_addReadList_SiteSource.TabIndex = 2;
            // 
            // textBox_addReadList_ChapterListPageURL
            // 
            this.textBox_addReadList_ChapterListPageURL.Location = new System.Drawing.Point(18, 80);
            this.textBox_addReadList_ChapterListPageURL.Name = "textBox_addReadList_ChapterListPageURL";
            this.textBox_addReadList_ChapterListPageURL.Size = new System.Drawing.Size(485, 20);
            this.textBox_addReadList_ChapterListPageURL.TabIndex = 1;
            this.textBox_addReadList_ChapterListPageURL.TextChanged += new System.EventHandler(this.textBox_addReadList_ChapterListPageURL_TextChanged);
            // 
            // textBox_addReadList_TitleName
            // 
            this.textBox_addReadList_TitleName.Location = new System.Drawing.Point(18, 26);
            this.textBox_addReadList_TitleName.Name = "textBox_addReadList_TitleName";
            this.textBox_addReadList_TitleName.Size = new System.Drawing.Size(373, 20);
            this.textBox_addReadList_TitleName.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1007, 590);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Chapter Selection";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.panel6);
            this.panel3.Controls.Add(this.splitter2);
            this.panel3.Controls.Add(this.panel4);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1001, 584);
            this.panel3.TabIndex = 0;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.splitter3);
            this.panel6.Controls.Add(this.panel7);
            this.panel6.Controls.Add(this.DGV_ChapterList);
            this.panel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel6.Location = new System.Drawing.Point(0, 66);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1001, 518);
            this.panel6.TabIndex = 4;
            // 
            // splitter3
            // 
            this.splitter3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter3.Location = new System.Drawing.Point(0, 365);
            this.splitter3.Name = "splitter3";
            this.splitter3.Size = new System.Drawing.Size(1001, 3);
            this.splitter3.TabIndex = 6;
            this.splitter3.TabStop = false;
            // 
            // panel7
            // 
            this.panel7.Controls.Add(this.panel9);
            this.panel7.Controls.Add(this.splitter4);
            this.panel7.Controls.Add(this.panel8);
            this.panel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel7.Location = new System.Drawing.Point(0, 0);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1001, 368);
            this.panel7.TabIndex = 5;
            // 
            // panel9
            // 
            this.panel9.Controls.Add(this.tabControl_chapterSelection);
            this.panel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel9.Location = new System.Drawing.Point(0, 0);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(757, 368);
            this.panel9.TabIndex = 2;
            // 
            // tabControl_chapterSelection
            // 
            this.tabControl_chapterSelection.Controls.Add(this.tabPage7);
            this.tabControl_chapterSelection.Controls.Add(this.tabPage8);
            this.tabControl_chapterSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl_chapterSelection.Location = new System.Drawing.Point(0, 0);
            this.tabControl_chapterSelection.Name = "tabControl_chapterSelection";
            this.tabControl_chapterSelection.SelectedIndex = 0;
            this.tabControl_chapterSelection.Size = new System.Drawing.Size(757, 368);
            this.tabControl_chapterSelection.TabIndex = 1;
            // 
            // tabPage7
            // 
            this.tabPage7.Controls.Add(this.textBox_titleDesc);
            this.tabPage7.Location = new System.Drawing.Point(4, 22);
            this.tabPage7.Name = "tabPage7";
            this.tabPage7.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage7.Size = new System.Drawing.Size(749, 342);
            this.tabPage7.TabIndex = 0;
            this.tabPage7.Text = "Title Info";
            this.tabPage7.UseVisualStyleBackColor = true;
            // 
            // textBox_titleDesc
            // 
            this.textBox_titleDesc.Location = new System.Drawing.Point(15, 6);
            this.textBox_titleDesc.Multiline = true;
            this.textBox_titleDesc.Name = "textBox_titleDesc";
            this.textBox_titleDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_titleDesc.Size = new System.Drawing.Size(653, 179);
            this.textBox_titleDesc.TabIndex = 0;
            // 
            // tabPage8
            // 
            this.tabPage8.Controls.Add(this.panel_cart);
            this.tabPage8.Location = new System.Drawing.Point(4, 22);
            this.tabPage8.Name = "tabPage8";
            this.tabPage8.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage8.Size = new System.Drawing.Size(749, 342);
            this.tabPage8.TabIndex = 1;
            this.tabPage8.Text = "Cart";
            this.tabPage8.UseVisualStyleBackColor = true;
            // 
            // panel_cart
            // 
            this.panel_cart.BackColor = System.Drawing.Color.DarkOrange;
            this.panel_cart.Controls.Add(this.DGV_ChapterCartList);
            this.panel_cart.Controls.Add(this.panel11);
            this.panel_cart.Controls.Add(this.panel10);
            this.panel_cart.Location = new System.Drawing.Point(15, 6);
            this.panel_cart.Name = "panel_cart";
            this.panel_cart.Size = new System.Drawing.Size(477, 325);
            this.panel_cart.TabIndex = 0;
            // 
            // DGV_ChapterCartList
            // 
            this.DGV_ChapterCartList.AllowUserToAddRows = false;
            this.DGV_ChapterCartList.AllowUserToDeleteRows = false;
            this.DGV_ChapterCartList.AllowUserToResizeRows = false;
            this.DGV_ChapterCartList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ChapterCartList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_cart_chapterNo,
            this.Col_cart_chapterName,
            this.Col_cart_chapterStatus,
            this.Col_cart_timeAddedToDList,
            this.Col_cart_chapterID,
            this.Col_cart_chapterHash,
            this.Col_cart_chapterImageCount,
            this.Col_cart_chapterAttVolume,
            this.Col_cart_chapterAttChapter,
            this.Col_cart_chapterImageHost,
            this.Col_cart_chapterIsObsolute,
            this.Col_cart_scanGroup,
            this.Col_cart_uploader,
            this.Col_cart_chapterTitle});
            this.DGV_ChapterCartList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV_ChapterCartList.Location = new System.Drawing.Point(0, 43);
            this.DGV_ChapterCartList.Name = "DGV_ChapterCartList";
            this.DGV_ChapterCartList.ReadOnly = true;
            this.DGV_ChapterCartList.RowHeadersVisible = false;
            this.DGV_ChapterCartList.Size = new System.Drawing.Size(477, 163);
            this.DGV_ChapterCartList.TabIndex = 2;
            this.DGV_ChapterCartList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ChapterCartList_CellContentClick);
            this.DGV_ChapterCartList.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.DGV_ChapterCartList_RowsAdded);
            this.DGV_ChapterCartList.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.DGV_ChapterCartList_RowsRemoved);
            // 
            // Col_cart_chapterNo
            // 
            this.Col_cart_chapterNo.HeaderText = "No.";
            this.Col_cart_chapterNo.Name = "Col_cart_chapterNo";
            this.Col_cart_chapterNo.ReadOnly = true;
            // 
            // Col_cart_chapterName
            // 
            this.Col_cart_chapterName.HeaderText = "Chapter Name";
            this.Col_cart_chapterName.Name = "Col_cart_chapterName";
            this.Col_cart_chapterName.ReadOnly = true;
            // 
            // Col_cart_chapterStatus
            // 
            this.Col_cart_chapterStatus.HeaderText = "Status";
            this.Col_cart_chapterStatus.Name = "Col_cart_chapterStatus";
            this.Col_cart_chapterStatus.ReadOnly = true;
            // 
            // Col_cart_timeAddedToDList
            // 
            this.Col_cart_timeAddedToDList.FillWeight = 150F;
            this.Col_cart_timeAddedToDList.HeaderText = "Time Added to D-List";
            this.Col_cart_timeAddedToDList.Name = "Col_cart_timeAddedToDList";
            this.Col_cart_timeAddedToDList.ReadOnly = true;
            this.Col_cart_timeAddedToDList.Width = 150;
            // 
            // Col_cart_chapterID
            // 
            this.Col_cart_chapterID.HeaderText = "ID";
            this.Col_cart_chapterID.Name = "Col_cart_chapterID";
            this.Col_cart_chapterID.ReadOnly = true;
            // 
            // Col_cart_chapterHash
            // 
            this.Col_cart_chapterHash.HeaderText = "Hash";
            this.Col_cart_chapterHash.Name = "Col_cart_chapterHash";
            this.Col_cart_chapterHash.ReadOnly = true;
            // 
            // Col_cart_chapterImageCount
            // 
            this.Col_cart_chapterImageCount.HeaderText = "Image Count";
            this.Col_cart_chapterImageCount.Name = "Col_cart_chapterImageCount";
            this.Col_cart_chapterImageCount.ReadOnly = true;
            // 
            // Col_cart_chapterAttVolume
            // 
            this.Col_cart_chapterAttVolume.HeaderText = "Volume";
            this.Col_cart_chapterAttVolume.Name = "Col_cart_chapterAttVolume";
            this.Col_cart_chapterAttVolume.ReadOnly = true;
            // 
            // Col_cart_chapterAttChapter
            // 
            this.Col_cart_chapterAttChapter.HeaderText = "Chapter";
            this.Col_cart_chapterAttChapter.Name = "Col_cart_chapterAttChapter";
            this.Col_cart_chapterAttChapter.ReadOnly = true;
            // 
            // Col_cart_chapterImageHost
            // 
            this.Col_cart_chapterImageHost.HeaderText = "Image Host";
            this.Col_cart_chapterImageHost.Name = "Col_cart_chapterImageHost";
            this.Col_cart_chapterImageHost.ReadOnly = true;
            // 
            // Col_cart_chapterIsObsolute
            // 
            this.Col_cart_chapterIsObsolute.HeaderText = "Obsolute";
            this.Col_cart_chapterIsObsolute.Name = "Col_cart_chapterIsObsolute";
            this.Col_cart_chapterIsObsolute.ReadOnly = true;
            // 
            // Col_cart_scanGroup
            // 
            this.Col_cart_scanGroup.HeaderText = "Scan Group";
            this.Col_cart_scanGroup.Name = "Col_cart_scanGroup";
            this.Col_cart_scanGroup.ReadOnly = true;
            // 
            // Col_cart_uploader
            // 
            this.Col_cart_uploader.HeaderText = "Uploader";
            this.Col_cart_uploader.Name = "Col_cart_uploader";
            this.Col_cart_uploader.ReadOnly = true;
            // 
            // Col_cart_chapterTitle
            // 
            this.Col_cart_chapterTitle.HeaderText = "Chapter Title";
            this.Col_cart_chapterTitle.Name = "Col_cart_chapterTitle";
            this.Col_cart_chapterTitle.ReadOnly = true;
            // 
            // panel11
            // 
            this.panel11.Controls.Add(this.btn_cart_checkNumbering);
            this.panel11.Controls.Add(this.btn_cart_delete);
            this.panel11.Controls.Add(this.label_cart_count);
            this.panel11.Controls.Add(this.btn_cartClear);
            this.panel11.Controls.Add(this.btn_cart_addAsNewTask);
            this.panel11.Controls.Add(this.textBox4);
            this.panel11.Controls.Add(this.textBox3);
            this.panel11.Controls.Add(this.textBox1);
            this.panel11.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel11.Location = new System.Drawing.Point(0, 206);
            this.panel11.Name = "panel11";
            this.panel11.Size = new System.Drawing.Size(477, 119);
            this.panel11.TabIndex = 1;
            // 
            // btn_cart_checkNumbering
            // 
            this.btn_cart_checkNumbering.Location = new System.Drawing.Point(165, 58);
            this.btn_cart_checkNumbering.Name = "btn_cart_checkNumbering";
            this.btn_cart_checkNumbering.Size = new System.Drawing.Size(121, 23);
            this.btn_cart_checkNumbering.TabIndex = 7;
            this.btn_cart_checkNumbering.Text = "Check Numbering";
            this.btn_cart_checkNumbering.UseVisualStyleBackColor = true;
            this.btn_cart_checkNumbering.Click += new System.EventHandler(this.btn_cart_checkNumbering_Click);
            // 
            // btn_cart_delete
            // 
            this.btn_cart_delete.Location = new System.Drawing.Point(84, 58);
            this.btn_cart_delete.Name = "btn_cart_delete";
            this.btn_cart_delete.Size = new System.Drawing.Size(75, 23);
            this.btn_cart_delete.TabIndex = 6;
            this.btn_cart_delete.Text = "Delete";
            this.btn_cart_delete.UseVisualStyleBackColor = true;
            this.btn_cart_delete.Click += new System.EventHandler(this.btn_cart_delete_Click);
            // 
            // label_cart_count
            // 
            this.label_cart_count.AutoSize = true;
            this.label_cart_count.Location = new System.Drawing.Point(439, 9);
            this.label_cart_count.Name = "label_cart_count";
            this.label_cart_count.Size = new System.Drawing.Size(16, 13);
            this.label_cart_count.TabIndex = 5;
            this.label_cart_count.Text = "...";
            // 
            // btn_cartClear
            // 
            this.btn_cartClear.Location = new System.Drawing.Point(3, 58);
            this.btn_cartClear.Name = "btn_cartClear";
            this.btn_cartClear.Size = new System.Drawing.Size(75, 23);
            this.btn_cartClear.TabIndex = 4;
            this.btn_cartClear.Text = "Clear";
            this.btn_cartClear.UseVisualStyleBackColor = true;
            this.btn_cartClear.Click += new System.EventHandler(this.btn_cartClear_Click);
            // 
            // btn_cart_addAsNewTask
            // 
            this.btn_cart_addAsNewTask.Location = new System.Drawing.Point(320, 58);
            this.btn_cart_addAsNewTask.Name = "btn_cart_addAsNewTask";
            this.btn_cart_addAsNewTask.Size = new System.Drawing.Size(111, 23);
            this.btn_cart_addAsNewTask.TabIndex = 3;
            this.btn_cart_addAsNewTask.Text = "Add as New Task";
            this.btn_cart_addAsNewTask.UseVisualStyleBackColor = true;
            this.btn_cart_addAsNewTask.Click += new System.EventHandler(this.btn_cart_addAsNewTask_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(3, 32);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(428, 20);
            this.textBox4.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(320, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(111, 20);
            this.textBox3.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(3, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(246, 20);
            this.textBox1.TabIndex = 0;
            // 
            // panel10
            // 
            this.panel10.Controls.Add(this.btn_cart_x);
            this.panel10.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel10.Location = new System.Drawing.Point(0, 0);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(477, 43);
            this.panel10.TabIndex = 0;
            // 
            // btn_cart_x
            // 
            this.btn_cart_x.Dock = System.Windows.Forms.DockStyle.Right;
            this.btn_cart_x.Location = new System.Drawing.Point(434, 0);
            this.btn_cart_x.Name = "btn_cart_x";
            this.btn_cart_x.Size = new System.Drawing.Size(43, 43);
            this.btn_cart_x.TabIndex = 0;
            this.btn_cart_x.Text = "X";
            this.btn_cart_x.UseVisualStyleBackColor = true;
            // 
            // splitter4
            // 
            this.splitter4.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter4.Location = new System.Drawing.Point(757, 0);
            this.splitter4.Name = "splitter4";
            this.splitter4.Size = new System.Drawing.Size(3, 368);
            this.splitter4.TabIndex = 0;
            this.splitter4.TabStop = false;
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.labelPerc_cover);
            this.panel8.Controls.Add(this.pictureBox2);
            this.panel8.Controls.Add(this.btn_loadChapterList);
            this.panel8.Controls.Add(this.btn_saveChapterList);
            this.panel8.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel8.Location = new System.Drawing.Point(760, 0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(241, 368);
            this.panel8.TabIndex = 1;
            // 
            // labelPerc_cover
            // 
            this.labelPerc_cover.Location = new System.Drawing.Point(47, 281);
            this.labelPerc_cover.Name = "labelPerc_cover";
            this.labelPerc_cover.Size = new System.Drawing.Size(151, 23);
            this.labelPerc_cover.TabIndex = 3;
            this.labelPerc_cover.Text = "...";
            this.labelPerc_cover.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(241, 278);
            this.pictureBox2.TabIndex = 2;
            this.pictureBox2.TabStop = false;
            // 
            // btn_loadChapterList
            // 
            this.btn_loadChapterList.Location = new System.Drawing.Point(47, 300);
            this.btn_loadChapterList.Name = "btn_loadChapterList";
            this.btn_loadChapterList.Size = new System.Drawing.Size(151, 23);
            this.btn_loadChapterList.TabIndex = 1;
            this.btn_loadChapterList.Text = "Load Chapter List";
            this.btn_loadChapterList.UseVisualStyleBackColor = true;
            this.btn_loadChapterList.Click += new System.EventHandler(this.btn_loadChapterList_Click);
            // 
            // btn_saveChapterList
            // 
            this.btn_saveChapterList.Location = new System.Drawing.Point(47, 329);
            this.btn_saveChapterList.Name = "btn_saveChapterList";
            this.btn_saveChapterList.Size = new System.Drawing.Size(151, 23);
            this.btn_saveChapterList.TabIndex = 0;
            this.btn_saveChapterList.Text = "Save Chapter List";
            this.btn_saveChapterList.UseVisualStyleBackColor = true;
            this.btn_saveChapterList.Click += new System.EventHandler(this.btn_saveChapterList_Click);
            // 
            // DGV_ChapterList
            // 
            this.DGV_ChapterList.AllowUserToAddRows = false;
            this.DGV_ChapterList.AllowUserToDeleteRows = false;
            this.DGV_ChapterList.AllowUserToResizeRows = false;
            this.DGV_ChapterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV_ChapterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Col_chapter_chapterNo,
            this.Col_chapter_chapterName,
            this.Col_chapter_status,
            this.Col_chapter_timeAddedToDList,
            this.Col_chapter_chapterID,
            this.Col_chapter_chapterHash,
            this.Col_chapter_chapterImageCount,
            this.Col_chapter_chapterAttVolume,
            this.Col_chapter_chapterAttChapter,
            this.Col_chapter_chapterImageHost,
            this.Col_chapter_isObsolute,
            this.Col_chapter_scanGroup,
            this.Col_chapter_uploader,
            this.Col_chapter_chapterTitle});
            this.DGV_ChapterList.ContextMenuStrip = this.CMS_DGV_Chapter;
            this.DGV_ChapterList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.DGV_ChapterList.Location = new System.Drawing.Point(0, 368);
            this.DGV_ChapterList.Name = "DGV_ChapterList";
            this.DGV_ChapterList.ReadOnly = true;
            this.DGV_ChapterList.RowHeadersVisible = false;
            this.DGV_ChapterList.Size = new System.Drawing.Size(1001, 150);
            this.DGV_ChapterList.TabIndex = 0;
            this.DGV_ChapterList.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_ChapterList_CellContentClick);
            // 
            // Col_chapter_chapterNo
            // 
            this.Col_chapter_chapterNo.HeaderText = "No.";
            this.Col_chapter_chapterNo.Name = "Col_chapter_chapterNo";
            this.Col_chapter_chapterNo.ReadOnly = true;
            // 
            // Col_chapter_chapterName
            // 
            this.Col_chapter_chapterName.HeaderText = "Chapter Name";
            this.Col_chapter_chapterName.Name = "Col_chapter_chapterName";
            this.Col_chapter_chapterName.ReadOnly = true;
            // 
            // Col_chapter_status
            // 
            this.Col_chapter_status.HeaderText = "Status";
            this.Col_chapter_status.Name = "Col_chapter_status";
            this.Col_chapter_status.ReadOnly = true;
            // 
            // Col_chapter_timeAddedToDList
            // 
            this.Col_chapter_timeAddedToDList.FillWeight = 150F;
            this.Col_chapter_timeAddedToDList.HeaderText = "Time Added to D-List";
            this.Col_chapter_timeAddedToDList.Name = "Col_chapter_timeAddedToDList";
            this.Col_chapter_timeAddedToDList.ReadOnly = true;
            this.Col_chapter_timeAddedToDList.Width = 150;
            // 
            // Col_chapter_chapterID
            // 
            this.Col_chapter_chapterID.HeaderText = "ID";
            this.Col_chapter_chapterID.Name = "Col_chapter_chapterID";
            this.Col_chapter_chapterID.ReadOnly = true;
            // 
            // Col_chapter_chapterHash
            // 
            this.Col_chapter_chapterHash.HeaderText = "Hash";
            this.Col_chapter_chapterHash.Name = "Col_chapter_chapterHash";
            this.Col_chapter_chapterHash.ReadOnly = true;
            // 
            // Col_chapter_chapterImageCount
            // 
            this.Col_chapter_chapterImageCount.HeaderText = "Image Count";
            this.Col_chapter_chapterImageCount.Name = "Col_chapter_chapterImageCount";
            this.Col_chapter_chapterImageCount.ReadOnly = true;
            // 
            // Col_chapter_chapterAttVolume
            // 
            this.Col_chapter_chapterAttVolume.HeaderText = "Volume";
            this.Col_chapter_chapterAttVolume.Name = "Col_chapter_chapterAttVolume";
            this.Col_chapter_chapterAttVolume.ReadOnly = true;
            // 
            // Col_chapter_chapterAttChapter
            // 
            this.Col_chapter_chapterAttChapter.HeaderText = "Chapter";
            this.Col_chapter_chapterAttChapter.Name = "Col_chapter_chapterAttChapter";
            this.Col_chapter_chapterAttChapter.ReadOnly = true;
            // 
            // Col_chapter_chapterImageHost
            // 
            this.Col_chapter_chapterImageHost.HeaderText = "ImageHost";
            this.Col_chapter_chapterImageHost.Name = "Col_chapter_chapterImageHost";
            this.Col_chapter_chapterImageHost.ReadOnly = true;
            // 
            // Col_chapter_isObsolute
            // 
            this.Col_chapter_isObsolute.HeaderText = "Obsolute";
            this.Col_chapter_isObsolute.Name = "Col_chapter_isObsolute";
            this.Col_chapter_isObsolute.ReadOnly = true;
            // 
            // Col_chapter_scanGroup
            // 
            this.Col_chapter_scanGroup.HeaderText = "Scan Group";
            this.Col_chapter_scanGroup.Name = "Col_chapter_scanGroup";
            this.Col_chapter_scanGroup.ReadOnly = true;
            // 
            // Col_chapter_uploader
            // 
            this.Col_chapter_uploader.HeaderText = "Uploader";
            this.Col_chapter_uploader.Name = "Col_chapter_uploader";
            this.Col_chapter_uploader.ReadOnly = true;
            // 
            // Col_chapter_chapterTitle
            // 
            this.Col_chapter_chapterTitle.HeaderText = "Chapter Title";
            this.Col_chapter_chapterTitle.Name = "Col_chapter_chapterTitle";
            this.Col_chapter_chapterTitle.ReadOnly = true;
            // 
            // CMS_DGV_Chapter
            // 
            this.CMS_DGV_Chapter.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.saveLoadUpdateChapterListToolStripMenuItem,
            this.addToCartToolStripMenuItem,
            this.bulkAddStartToolStripMenuItem,
            this.bulkAddEndToolStripMenuItem,
            this.addAllToCartToolStripMenuItem,
            this.removeTimeAddedToDListToolStripMenuItem});
            this.CMS_DGV_Chapter.Name = "CMS_DGV_Chapter";
            this.CMS_DGV_Chapter.Size = new System.Drawing.Size(251, 136);
            this.CMS_DGV_Chapter.Opening += new System.ComponentModel.CancelEventHandler(this.CMS_DGV_Chapter_Opening);
            // 
            // saveLoadUpdateChapterListToolStripMenuItem
            // 
            this.saveLoadUpdateChapterListToolStripMenuItem.Name = "saveLoadUpdateChapterListToolStripMenuItem";
            this.saveLoadUpdateChapterListToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.saveLoadUpdateChapterListToolStripMenuItem.Text = "Save / Load / Update Chapter List";
            this.saveLoadUpdateChapterListToolStripMenuItem.Click += new System.EventHandler(this.saveLoadUpdateChapterListToolStripMenuItem_Click);
            // 
            // addToCartToolStripMenuItem
            // 
            this.addToCartToolStripMenuItem.Name = "addToCartToolStripMenuItem";
            this.addToCartToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.addToCartToolStripMenuItem.Text = "Add to Cart";
            this.addToCartToolStripMenuItem.Click += new System.EventHandler(this.addToCartToolStripMenuItem_Click);
            // 
            // bulkAddStartToolStripMenuItem
            // 
            this.bulkAddStartToolStripMenuItem.Name = "bulkAddStartToolStripMenuItem";
            this.bulkAddStartToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.bulkAddStartToolStripMenuItem.Text = "Bulk Add - Start";
            this.bulkAddStartToolStripMenuItem.Click += new System.EventHandler(this.bulkAddStartToolStripMenuItem_Click);
            // 
            // bulkAddEndToolStripMenuItem
            // 
            this.bulkAddEndToolStripMenuItem.Name = "bulkAddEndToolStripMenuItem";
            this.bulkAddEndToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.bulkAddEndToolStripMenuItem.Text = "Bulk Add - End";
            this.bulkAddEndToolStripMenuItem.Click += new System.EventHandler(this.bulkAddEndToolStripMenuItem_Click);
            // 
            // addAllToCartToolStripMenuItem
            // 
            this.addAllToCartToolStripMenuItem.Name = "addAllToCartToolStripMenuItem";
            this.addAllToCartToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.addAllToCartToolStripMenuItem.Text = "Add All to Cart";
            this.addAllToCartToolStripMenuItem.Click += new System.EventHandler(this.addAllToCartToolStripMenuItem_Click);
            // 
            // removeTimeAddedToDListToolStripMenuItem
            // 
            this.removeTimeAddedToDListToolStripMenuItem.Name = "removeTimeAddedToDListToolStripMenuItem";
            this.removeTimeAddedToDListToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.removeTimeAddedToDListToolStripMenuItem.Text = "Remove Time Added to D-List";
            this.removeTimeAddedToDListToolStripMenuItem.Click += new System.EventHandler(this.removeTimeAddedToDListToolStripMenuItem_Click);
            // 
            // splitter2
            // 
            this.splitter2.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter2.Location = new System.Drawing.Point(0, 63);
            this.splitter2.Name = "splitter2";
            this.splitter2.Size = new System.Drawing.Size(1001, 3);
            this.splitter2.TabIndex = 6;
            this.splitter2.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_getChapterList);
            this.panel4.Controls.Add(this.label3);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.textBox_ChapterSource);
            this.panel4.Controls.Add(this.textBox_ChapterTitleName);
            this.panel4.Controls.Add(this.textBox_ChapterURL);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1001, 63);
            this.panel4.TabIndex = 2;
            // 
            // btn_getChapterList
            // 
            this.btn_getChapterList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_getChapterList.Location = new System.Drawing.Point(843, 31);
            this.btn_getChapterList.Name = "btn_getChapterList";
            this.btn_getChapterList.Size = new System.Drawing.Size(75, 23);
            this.btn_getChapterList.TabIndex = 1;
            this.btn_getChapterList.Text = "Get Chapter";
            this.btn_getChapterList.UseVisualStyleBackColor = true;
            this.btn_getChapterList.Click += new System.EventHandler(this.btn_getChapterList_Click);
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(659, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Source";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Chapter URL";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Title Name";
            // 
            // textBox_ChapterSource
            // 
            this.textBox_ChapterSource.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ChapterSource.Location = new System.Drawing.Point(722, 7);
            this.textBox_ChapterSource.Name = "textBox_ChapterSource";
            this.textBox_ChapterSource.Size = new System.Drawing.Size(115, 20);
            this.textBox_ChapterSource.TabIndex = 3;
            // 
            // textBox_ChapterTitleName
            // 
            this.textBox_ChapterTitleName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ChapterTitleName.Location = new System.Drawing.Point(100, 7);
            this.textBox_ChapterTitleName.Name = "textBox_ChapterTitleName";
            this.textBox_ChapterTitleName.Size = new System.Drawing.Size(502, 20);
            this.textBox_ChapterTitleName.TabIndex = 2;
            // 
            // textBox_ChapterURL
            // 
            this.textBox_ChapterURL.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox_ChapterURL.Location = new System.Drawing.Point(100, 33);
            this.textBox_ChapterURL.Name = "textBox_ChapterURL";
            this.textBox_ChapterURL.Size = new System.Drawing.Size(737, 20);
            this.textBox_ChapterURL.TabIndex = 1;
            // 
            // tabPage_Image_Download
            // 
            this.tabPage_Image_Download.Controls.Add(this.panel5);
            this.tabPage_Image_Download.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Image_Download.Name = "tabPage_Image_Download";
            this.tabPage_Image_Download.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Image_Download.Size = new System.Drawing.Size(1007, 590);
            this.tabPage_Image_Download.TabIndex = 2;
            this.tabPage_Image_Download.Text = "Image Download";
            this.tabPage_Image_Download.UseVisualStyleBackColor = true;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.tabControl3);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(3, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1001, 584);
            this.panel5.TabIndex = 0;
            // 
            // tabControl3
            // 
            this.tabControl3.Controls.Add(this.tabPage1);
            this.tabControl3.Controls.Add(this.tabPage3);
            this.tabControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl3.Location = new System.Drawing.Point(0, 0);
            this.tabControl3.Name = "tabControl3";
            this.tabControl3.SelectedIndex = 0;
            this.tabControl3.Size = new System.Drawing.Size(1001, 584);
            this.tabControl3.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btn_delSelectedTaskIdle);
            this.tabPage1.Controls.Add(this.panel12);
            this.tabPage1.Controls.Add(this.TV_taskDone);
            this.tabPage1.Controls.Add(this.TV_taskRunning);
            this.tabPage1.Controls.Add(this.TV_taskList);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(993, 558);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Task List";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btn_delSelectedTaskIdle
            // 
            this.btn_delSelectedTaskIdle.Location = new System.Drawing.Point(211, 496);
            this.btn_delSelectedTaskIdle.Name = "btn_delSelectedTaskIdle";
            this.btn_delSelectedTaskIdle.Size = new System.Drawing.Size(75, 23);
            this.btn_delSelectedTaskIdle.TabIndex = 4;
            this.btn_delSelectedTaskIdle.Text = "delete";
            this.btn_delSelectedTaskIdle.UseVisualStyleBackColor = true;
            this.btn_delSelectedTaskIdle.Click += new System.EventHandler(this.btn_delSelectedTaskIdle_Click);
            // 
            // panel12
            // 
            this.panel12.Controls.Add(this.btn_stopDownloadQueue);
            this.panel12.Controls.Add(this.btn_moveRunningToIdle);
            this.panel12.Controls.Add(this.btn_loadTaskListFromJson);
            this.panel12.Controls.Add(this.btn_taskListToJson);
            this.panel12.Controls.Add(this.btn_startDownloadQueue);
            this.panel12.Location = new System.Drawing.Point(292, 52);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(125, 273);
            this.panel12.TabIndex = 3;
            // 
            // btn_stopDownloadQueue
            // 
            this.btn_stopDownloadQueue.Location = new System.Drawing.Point(25, 26);
            this.btn_stopDownloadQueue.Name = "btn_stopDownloadQueue";
            this.btn_stopDownloadQueue.Size = new System.Drawing.Size(75, 23);
            this.btn_stopDownloadQueue.TabIndex = 4;
            this.btn_stopDownloadQueue.Text = "Stop Queue";
            this.btn_stopDownloadQueue.UseVisualStyleBackColor = true;
            this.btn_stopDownloadQueue.Click += new System.EventHandler(this.btn_stopDownloadQueue_Click);
            // 
            // btn_moveRunningToIdle
            // 
            this.btn_moveRunningToIdle.Location = new System.Drawing.Point(25, 202);
            this.btn_moveRunningToIdle.Name = "btn_moveRunningToIdle";
            this.btn_moveRunningToIdle.Size = new System.Drawing.Size(75, 23);
            this.btn_moveRunningToIdle.TabIndex = 3;
            this.btn_moveRunningToIdle.Text = "<<<";
            this.btn_moveRunningToIdle.UseVisualStyleBackColor = true;
            this.btn_moveRunningToIdle.Click += new System.EventHandler(this.btn_moveRunningToIdle_Click);
            // 
            // btn_loadTaskListFromJson
            // 
            this.btn_loadTaskListFromJson.Location = new System.Drawing.Point(25, 120);
            this.btn_loadTaskListFromJson.Name = "btn_loadTaskListFromJson";
            this.btn_loadTaskListFromJson.Size = new System.Drawing.Size(75, 63);
            this.btn_loadTaskListFromJson.TabIndex = 2;
            this.btn_loadTaskListFromJson.Text = "Load Task List From Json";
            this.btn_loadTaskListFromJson.UseVisualStyleBackColor = true;
            this.btn_loadTaskListFromJson.Click += new System.EventHandler(this.btn_loadTaskListFromJson_Click);
            // 
            // btn_taskListToJson
            // 
            this.btn_taskListToJson.Location = new System.Drawing.Point(25, 49);
            this.btn_taskListToJson.Name = "btn_taskListToJson";
            this.btn_taskListToJson.Size = new System.Drawing.Size(75, 50);
            this.btn_taskListToJson.TabIndex = 1;
            this.btn_taskListToJson.Text = "Task List To Json";
            this.btn_taskListToJson.UseVisualStyleBackColor = true;
            this.btn_taskListToJson.Click += new System.EventHandler(this.btn_taskListToJson_Click);
            // 
            // btn_startDownloadQueue
            // 
            this.btn_startDownloadQueue.Location = new System.Drawing.Point(25, 4);
            this.btn_startDownloadQueue.Name = "btn_startDownloadQueue";
            this.btn_startDownloadQueue.Size = new System.Drawing.Size(75, 23);
            this.btn_startDownloadQueue.TabIndex = 0;
            this.btn_startDownloadQueue.Text = "Start Queue";
            this.btn_startDownloadQueue.UseVisualStyleBackColor = true;
            this.btn_startDownloadQueue.Click += new System.EventHandler(this.btn_startDownloadQueue_Click);
            // 
            // TV_taskDone
            // 
            this.TV_taskDone.Location = new System.Drawing.Point(717, 52);
            this.TV_taskDone.Name = "TV_taskDone";
            this.TV_taskDone.Size = new System.Drawing.Size(270, 438);
            this.TV_taskDone.TabIndex = 2;
            // 
            // TV_taskRunning
            // 
            this.TV_taskRunning.Location = new System.Drawing.Point(423, 52);
            this.TV_taskRunning.Name = "TV_taskRunning";
            this.TV_taskRunning.Size = new System.Drawing.Size(270, 438);
            this.TV_taskRunning.TabIndex = 1;
            // 
            // TV_taskList
            // 
            this.TV_taskList.Location = new System.Drawing.Point(16, 52);
            this.TV_taskList.Name = "TV_taskList";
            this.TV_taskList.Size = new System.Drawing.Size(270, 438);
            this.TV_taskList.TabIndex = 0;
            this.TV_taskList.NodeMouseHover += new System.Windows.Forms.TreeNodeMouseHoverEventHandler(this.TV_taskList_NodeMouseHover);
            this.TV_taskList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TV_taskList_AfterSelect);
            this.TV_taskList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.TV_taskList_NodeMouseClick);
            this.TV_taskList.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TV_taskList_MouseDown);
            this.TV_taskList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TV_taskList_MouseUp);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.progressBar_ChapterList);
            this.tabPage3.Controls.Add(this.progressBar_ImageList);
            this.tabPage3.Controls.Add(this.labelDownloaded);
            this.tabPage3.Controls.Add(this.labelPerc);
            this.tabPage3.Controls.Add(this.progressBar1);
            this.tabPage3.Controls.Add(this.labelSpeed);
            this.tabPage3.Controls.Add(this.button4);
            this.tabPage3.Controls.Add(this.btn_testDownloadFile);
            this.tabPage3.Controls.Add(this.pictureBox1);
            this.tabPage3.Controls.Add(this.dataGridView1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(993, 558);
            this.tabPage3.TabIndex = 1;
            this.tabPage3.Text = "Current Task";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // progressBar_ChapterList
            // 
            this.progressBar_ChapterList.Location = new System.Drawing.Point(587, 311);
            this.progressBar_ChapterList.Name = "progressBar_ChapterList";
            this.progressBar_ChapterList.Size = new System.Drawing.Size(400, 23);
            this.progressBar_ChapterList.TabIndex = 9;
            // 
            // progressBar_ImageList
            // 
            this.progressBar_ImageList.Location = new System.Drawing.Point(587, 340);
            this.progressBar_ImageList.Name = "progressBar_ImageList";
            this.progressBar_ImageList.Size = new System.Drawing.Size(400, 23);
            this.progressBar_ImageList.TabIndex = 8;
            // 
            // labelDownloaded
            // 
            this.labelDownloaded.AutoSize = true;
            this.labelDownloaded.Location = new System.Drawing.Point(771, 420);
            this.labelDownloaded.Name = "labelDownloaded";
            this.labelDownloaded.Size = new System.Drawing.Size(89, 13);
            this.labelDownloaded.TabIndex = 7;
            this.labelDownloaded.Text = "labelDownloaded";
            // 
            // labelPerc
            // 
            this.labelPerc.AutoSize = true;
            this.labelPerc.Location = new System.Drawing.Point(863, 399);
            this.labelPerc.Name = "labelPerc";
            this.labelPerc.Size = new System.Drawing.Size(51, 13);
            this.labelPerc.TabIndex = 6;
            this.labelPerc.Text = "labelPerc";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(587, 369);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(400, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // labelSpeed
            // 
            this.labelSpeed.AutoSize = true;
            this.labelSpeed.Location = new System.Drawing.Point(685, 399);
            this.labelSpeed.Name = "labelSpeed";
            this.labelSpeed.Size = new System.Drawing.Size(60, 13);
            this.labelSpeed.TabIndex = 4;
            this.labelSpeed.Text = "labelSpeed";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(587, 444);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "button4";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // btn_testDownloadFile
            // 
            this.btn_testDownloadFile.Location = new System.Drawing.Point(587, 415);
            this.btn_testDownloadFile.Name = "btn_testDownloadFile";
            this.btn_testDownloadFile.Size = new System.Drawing.Size(178, 23);
            this.btn_testDownloadFile.TabIndex = 2;
            this.btn_testDownloadFile.Text = "test download file";
            this.btn_testDownloadFile.UseVisualStyleBackColor = true;
            this.btn_testDownloadFile.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(587, 6);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(400, 304);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(6, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(575, 461);
            this.dataGridView1.TabIndex = 0;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.button1);
            this.tabPage5.Controls.Add(this.btn_testJsonWebClient);
            this.tabPage5.Controls.Add(this.btn_takeScreenShot);
            this.tabPage5.Controls.Add(this.btn_addRowChapter);
            this.tabPage5.Controls.Add(this.textBox2);
            this.tabPage5.Controls.Add(this.btn_getJson);
            this.tabPage5.Controls.Add(this.btn_test_listImgUrls);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(1007, 590);
            this.tabPage5.TabIndex = 3;
            this.tabPage5.Text = "Test";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(8, 55);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 21);
            this.button1.TabIndex = 7;
            this.button1.Text = "get text json";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_testJsonWebClient
            // 
            this.btn_testJsonWebClient.Location = new System.Drawing.Point(355, 26);
            this.btn_testJsonWebClient.Name = "btn_testJsonWebClient";
            this.btn_testJsonWebClient.Size = new System.Drawing.Size(267, 23);
            this.btn_testJsonWebClient.TabIndex = 6;
            this.btn_testJsonWebClient.Text = "Test Json WebClient";
            this.btn_testJsonWebClient.UseVisualStyleBackColor = true;
            this.btn_testJsonWebClient.Click += new System.EventHandler(this.btn_testJsonWebClient_Click);
            // 
            // btn_takeScreenShot
            // 
            this.btn_takeScreenShot.Location = new System.Drawing.Point(8, 82);
            this.btn_takeScreenShot.Name = "btn_takeScreenShot";
            this.btn_takeScreenShot.Size = new System.Drawing.Size(75, 58);
            this.btn_takeScreenShot.TabIndex = 5;
            this.btn_takeScreenShot.Text = "Take ScreenShot";
            this.btn_takeScreenShot.UseVisualStyleBackColor = true;
            this.btn_takeScreenShot.Click += new System.EventHandler(this.btn_takeScreenShot_Click);
            // 
            // btn_addRowChapter
            // 
            this.btn_addRowChapter.Location = new System.Drawing.Point(798, 510);
            this.btn_addRowChapter.Name = "btn_addRowChapter";
            this.btn_addRowChapter.Size = new System.Drawing.Size(75, 23);
            this.btn_addRowChapter.TabIndex = 3;
            this.btn_addRowChapter.Text = "Add Row";
            this.btn_addRowChapter.UseVisualStyleBackColor = true;
            this.btn_addRowChapter.Click += new System.EventHandler(this.btn_addRowChapter_Click);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(0, 0);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(870, 20);
            this.textBox2.TabIndex = 2;
            // 
            // btn_getJson
            // 
            this.btn_getJson.Location = new System.Drawing.Point(8, 26);
            this.btn_getJson.Name = "btn_getJson";
            this.btn_getJson.Size = new System.Drawing.Size(75, 23);
            this.btn_getJson.TabIndex = 3;
            this.btn_getJson.Text = "go";
            this.btn_getJson.UseVisualStyleBackColor = true;
            this.btn_getJson.Click += new System.EventHandler(this.btn_getJson_Click);
            // 
            // btn_test_listImgUrls
            // 
            this.btn_test_listImgUrls.Location = new System.Drawing.Point(89, 26);
            this.btn_test_listImgUrls.Name = "btn_test_listImgUrls";
            this.btn_test_listImgUrls.Size = new System.Drawing.Size(75, 23);
            this.btn_test_listImgUrls.TabIndex = 4;
            this.btn_test_listImgUrls.Text = "List ImgUrls";
            this.btn_test_listImgUrls.UseVisualStyleBackColor = true;
            this.btn_test_listImgUrls.Click += new System.EventHandler(this.button2_Click);
            // 
            // tabPage6
            // 
            this.tabPage6.Controls.Add(this.panel_login);
            this.tabPage6.Location = new System.Drawing.Point(4, 22);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1007, 590);
            this.tabPage6.TabIndex = 4;
            this.tabPage6.Text = "Setting";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // panel_login
            // 
            this.panel_login.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_login.Controls.Add(this.CWB_login);
            this.panel_login.Controls.Add(this.panel14);
            this.panel_login.Location = new System.Drawing.Point(64, 29);
            this.panel_login.Name = "panel_login";
            this.panel_login.Size = new System.Drawing.Size(863, 515);
            this.panel_login.TabIndex = 1;
            // 
            // CWB_login
            // 
            this.CWB_login.ActivateBrowserOnCreation = false;
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.CWB_login.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CWB_login.Location = new System.Drawing.Point(0, 0);
            this.CWB_login.Name = "CWB_login";
            this.CWB_login.Size = new System.Drawing.Size(863, 415);
            this.CWB_login.TabIndex = 0;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btn_setIsNSFW);
            this.panel14.Controls.Add(this.textBox_login);
            this.panel14.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel14.Location = new System.Drawing.Point(0, 415);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(863, 100);
            this.panel14.TabIndex = 1;
            // 
            // btn_setIsNSFW
            // 
            this.btn_setIsNSFW.Location = new System.Drawing.Point(3, 26);
            this.btn_setIsNSFW.Name = "btn_setIsNSFW";
            this.btn_setIsNSFW.Size = new System.Drawing.Size(381, 23);
            this.btn_setIsNSFW.TabIndex = 1;
            this.btn_setIsNSFW.Text = "NSFW : ON";
            this.btn_setIsNSFW.UseVisualStyleBackColor = true;
            this.btn_setIsNSFW.Click += new System.EventHandler(this.btn_setIsNSFW_Click);
            // 
            // textBox_login
            // 
            this.textBox_login.Dock = System.Windows.Forms.DockStyle.Top;
            this.textBox_login.Location = new System.Drawing.Point(0, 0);
            this.textBox_login.Name = "textBox_login";
            this.textBox_login.Size = new System.Drawing.Size(863, 20);
            this.textBox_login.TabIndex = 0;
            this.textBox_login.KeyUp += new System.Windows.Forms.KeyEventHandler(this.textBox_login_KeyUp);
            // 
            // panel_log
            // 
            this.panel_log.Controls.Add(this.textBox_global_log);
            this.panel_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_log.Location = new System.Drawing.Point(0, 621);
            this.panel_log.Name = "panel_log";
            this.panel_log.Size = new System.Drawing.Size(1015, 100);
            this.panel_log.TabIndex = 3;
            // 
            // textBox_global_log
            // 
            this.textBox_global_log.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_global_log.Location = new System.Drawing.Point(0, 0);
            this.textBox_global_log.Multiline = true;
            this.textBox_global_log.Name = "textBox_global_log";
            this.textBox_global_log.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_global_log.Size = new System.Drawing.Size(1015, 100);
            this.textBox_global_log.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(0, 616);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1015, 5);
            this.splitter1.TabIndex = 0;
            this.splitter1.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer_updateCover
            // 
            this.timer_updateCover.Interval = 3000;
            this.timer_updateCover.Tick += new System.EventHandler(this.timer_updateCover_Tick);
            // 
            // tabPage_Title_Completed
            // 
            this.tabPage_Title_Completed.Controls.Add(this.TV_CompletedList);
            this.tabPage_Title_Completed.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Title_Completed.Name = "tabPage_Title_Completed";
            this.tabPage_Title_Completed.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Title_Completed.Size = new System.Drawing.Size(359, 558);
            this.tabPage_Title_Completed.TabIndex = 2;
            this.tabPage_Title_Completed.Text = "Completed List";
            this.tabPage_Title_Completed.UseVisualStyleBackColor = true;
            // 
            // tabPage_Title_Drop
            // 
            this.tabPage_Title_Drop.Controls.Add(this.TV_DropList);
            this.tabPage_Title_Drop.Location = new System.Drawing.Point(4, 22);
            this.tabPage_Title_Drop.Name = "tabPage_Title_Drop";
            this.tabPage_Title_Drop.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Title_Drop.Size = new System.Drawing.Size(359, 558);
            this.tabPage_Title_Drop.TabIndex = 3;
            this.tabPage_Title_Drop.Text = "Drop List";
            this.tabPage_Title_Drop.UseVisualStyleBackColor = true;
            // 
            // TV_CompletedList
            // 
            this.TV_CompletedList.ContextMenuStrip = this.contextMenuStrip1;
            this.TV_CompletedList.HideSelection = false;
            this.TV_CompletedList.HotTracking = true;
            this.TV_CompletedList.Location = new System.Drawing.Point(6, 6);
            this.TV_CompletedList.Name = "TV_CompletedList";
            this.TV_CompletedList.Size = new System.Drawing.Size(347, 365);
            this.TV_CompletedList.TabIndex = 2;
            // 
            // TV_DropList
            // 
            this.TV_DropList.ContextMenuStrip = this.contextMenuStrip1;
            this.TV_DropList.HideSelection = false;
            this.TV_DropList.HotTracking = true;
            this.TV_DropList.Location = new System.Drawing.Point(6, 6);
            this.TV_DropList.Name = "TV_DropList";
            this.TV_DropList.Size = new System.Drawing.Size(347, 365);
            this.TV_DropList.TabIndex = 2;
            // 
            // completedListToolStripMenuItem
            // 
            this.completedListToolStripMenuItem.Name = "completedListToolStripMenuItem";
            this.completedListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.completedListToolStripMenuItem.Text = "Completed List";
            this.completedListToolStripMenuItem.Click += new System.EventHandler(this.completedListToolStripMenuItem_Click);
            // 
            // dropListToolStripMenuItem
            // 
            this.dropListToolStripMenuItem.Name = "dropListToolStripMenuItem";
            this.dropListToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.dropListToolStripMenuItem.Text = "Drop List";
            this.dropListToolStripMenuItem.Click += new System.EventHandler(this.dropListToolStripMenuItem_Click);
            // 
            // Form_Downloader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1015, 721);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel_log);
            this.Name = "Form_Downloader";
            this.Text = "Form_Downloader";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Downloader_FormClosing);
            this.Load += new System.EventHandler(this.Form_Downloader_Load);
            this.tabControl_TitleList.ResumeLayout(false);
            this.tabPage_Title_Read.ResumeLayout(false);
            this.tabPage_Title_Read.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.tabPage_Title_OnHold.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Title.ResumeLayout(false);
            this.panel13.ResumeLayout(false);
            this.panel13.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.tabControl_chapterSelection.ResumeLayout(false);
            this.tabPage7.ResumeLayout(false);
            this.tabPage7.PerformLayout();
            this.tabPage8.ResumeLayout(false);
            this.panel_cart.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ChapterCartList)).EndInit();
            this.panel11.ResumeLayout(false);
            this.panel11.PerformLayout();
            this.panel10.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DGV_ChapterList)).EndInit();
            this.CMS_DGV_Chapter.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabPage_Image_Download.ResumeLayout(false);
            this.panel5.ResumeLayout(false);
            this.tabControl3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel12.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.tabPage5.ResumeLayout(false);
            this.tabPage5.PerformLayout();
            this.tabPage6.ResumeLayout(false);
            this.panel_login.ResumeLayout(false);
            this.panel14.ResumeLayout(false);
            this.panel14.PerformLayout();
            this.panel_log.ResumeLayout(false);
            this.panel_log.PerformLayout();
            this.tabPage_Title_Completed.ResumeLayout(false);
            this.tabPage_Title_Drop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl_TitleList;
        private System.Windows.Forms.TabPage tabPage_Title_Read;
        private System.Windows.Forms.TreeView TV_ReadList;
        private System.Windows.Forms.TabPage tabPage_Title_OnHold;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Title;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel_log;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView DGV_ChapterList;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button btn_getChapterList;
        private System.Windows.Forms.TextBox textBox_global_log;
        private System.Windows.Forms.Button btn_getJson;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btn_title_saveKomikRootDir;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem titleNameInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mangaSiteToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem openChapterToolStripMenuItem;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ChapterSource;
        private System.Windows.Forms.TextBox textBox_ChapterTitleName;
        private System.Windows.Forms.TextBox textBox_ChapterURL;
        private System.Windows.Forms.Button btn_addRowChapter;
        private System.Windows.Forms.Button btn_test_listImgUrls;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Splitter splitter3;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Splitter splitter4;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Splitter splitter2;
        private System.Windows.Forms.TabPage tabPage_Image_Download;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TabControl tabControl3;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TreeView TV_taskDone;
        private System.Windows.Forms.TreeView TV_taskRunning;
        private System.Windows.Forms.TreeView TV_taskList;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.ContextMenuStrip CMS_DGV_Chapter;
        private System.Windows.Forms.Panel panel_cart;
        private System.Windows.Forms.DataGridView DGV_ChapterCartList;
        private System.Windows.Forms.Panel panel11;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.Button btn_cart_x;
        private System.Windows.Forms.ToolStripMenuItem saveLoadUpdateChapterListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToCartToolStripMenuItem;
        private System.Windows.Forms.Button btn_saveChapterList;
        private System.Windows.Forms.Button btn_loadChapterList;
        private System.Windows.Forms.Button btn_testDownloadFile;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label labelSpeed;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label labelPerc;
        private System.Windows.Forms.Label labelDownloaded;
        private System.Windows.Forms.Button btn_cart_addAsNewTask;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Button btn_startDownloadQueue;
        private System.Windows.Forms.Button btn_cartClear;
        private System.Windows.Forms.Button btn_taskListToJson;
        private System.Windows.Forms.Button btn_loadTaskListFromJson;
        private System.Windows.Forms.Button btn_takeScreenShot;
        private System.Windows.Forms.TextBox textBox_title_rootDir;
        private System.Windows.Forms.Button btn_moveRunningToIdle;
        private System.Windows.Forms.Button btn_delSelectedTaskIdle;
        private System.Windows.Forms.ProgressBar progressBar_ImageList;
        private System.Windows.Forms.Button btn_LoadTitleList;
        private System.Windows.Forms.Button btn_SaveTitleList;
        private System.Windows.Forms.Button btn_deleteSelectedReadList;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Button btn_addAsReadList;
        private System.Windows.Forms.TextBox textBox_addReadList_Alias;
        private System.Windows.Forms.TextBox textBox_addReadList_SiteSource;
        private System.Windows.Forms.TextBox textBox_addReadList_ChapterListPageURL;
        private System.Windows.Forms.TextBox textBox_addReadList_TitleName;
        private System.Windows.Forms.Button btn_clearNewTitleListInputDialog;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ProgressBar progressBar_ChapterList;
        private System.Windows.Forms.Button btn_testJsonWebClient;
        private System.Windows.Forms.ToolStripMenuItem bulkAddStartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bulkAddEndToolStripMenuItem;
        private System.Windows.Forms.Button btn_stopDownloadQueue;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_searchReadList;
        private System.Windows.Forms.TextBox textBox_seaarchReadList;
        private System.Windows.Forms.TabPage tabPage6;
        private System.Windows.Forms.Panel panel_login;
        private CefSharp.WinForms.ChromiumWebBrowser CWB_login;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.TextBox textBox_login;
        private System.Windows.Forms.Button btn_setIsNSFW;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_timeAddedToDList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterImageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterAttVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterAttChapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterImageHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterIsObsolute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_scanGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_uploader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_cart_chapterTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_status;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_timeAddedToDList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterID;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterHash;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterImageCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterAttVolume;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterAttChapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterImageHost;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_isObsolute;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_scanGroup;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_uploader;
        private System.Windows.Forms.DataGridViewTextBoxColumn Col_chapter_chapterTitle;
        private System.Windows.Forms.ToolStripMenuItem editTitleToolStripMenuItem;
        private System.Windows.Forms.Button btnXSearch1;
        private System.Windows.Forms.Button btnX_saveroot;
        private System.Windows.Forms.ToolStripMenuItem sortTitleToolStripMenuItem;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Timer timer_updateCover;
        private System.Windows.Forms.Label labelPerc_cover;
        private System.Windows.Forms.TabControl tabControl_chapterSelection;
        private System.Windows.Forms.TabPage tabPage7;
        private System.Windows.Forms.TextBox textBox_titleDesc;
        private System.Windows.Forms.TabPage tabPage8;
        private System.Windows.Forms.ToolStripMenuItem sendTitleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem onHoldListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readListToolStripMenuItem;
        private System.Windows.Forms.TreeView TV_OnHoldList;
        private System.Windows.Forms.Button btn_Trim_Alias;
        private System.Windows.Forms.Label label_cart_count;
        private System.Windows.Forms.Button btn_cart_delete;
        private System.Windows.Forms.Button btn_cart_checkNumbering;
        private System.Windows.Forms.ToolStripMenuItem addAllToCartToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeTimeAddedToDListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem completedListToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dropListToolStripMenuItem;
        private System.Windows.Forms.TabPage tabPage_Title_Completed;
        private System.Windows.Forms.TreeView TV_CompletedList;
        private System.Windows.Forms.TabPage tabPage_Title_Drop;
        private System.Windows.Forms.TreeView TV_DropList;
    }
}