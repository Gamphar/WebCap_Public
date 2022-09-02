using CefSharp;
using CefSharp.OffScreen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using Microsoft.Win32;

namespace WebCapV2
{
    public partial class Form_Downloader : Form
    {
        public Form_Downloader()
        {
            InitializeComponent();
        }

        //[DllImport("kernel32.dll", SetLastError = true)]
        //[return: MarshalAs(UnmanagedType.Bool)]
        //static extern bool AllocConsole();

        public int Form_ID = 0; //resetup by the main form
        SettingGlobal MySetting = new SettingGlobal();         
        SettingTitleSelectionData settingTitleSelection = new SettingTitleSelectionData();
        Form_Downloader FDowloder;

        TextBox TB_Log1;
        TextBox TB_Log2;

        private void Form_Downloader_Load(object sender, EventArgs e)
        {
            FDowloder = this;
            this.Text = string.Format("Downloader {0}", Form_ID);
            IsWindows10 = getIsWindows10();

            TB_Log1 = new TextBox();
            TB_Log1.Name = "TB_Log1";
            TB_Log1.Multiline = true;
            TB_Log1.ScrollBars = ScrollBars.Both;
            TB_Log1.Dock = DockStyle.Fill;
            panel_log.Controls.Add(TB_Log1);

            TB_Log2 = new TextBox();
            TB_Log2.Name = "TB_Log2";
            TB_Log2.Multiline = true;
            TB_Log2.ScrollBars = ScrollBars.Both;
            TB_Log2.Dock = DockStyle.Fill;
            panel_log.Controls.Add(TB_Log2);


            UpdateUI_ShowActiveLog();




#if ANYCPU
            //Only required for PlatformTarget of AnyCPU
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
            Log("SubscribeAnyCpuAssemblyResolver");
#endif

            string DirPath_Cache = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp\\CacheDownload");

            if (!Directory.Exists(DirPath_Cache)) { Directory.CreateDirectory(DirPath_Cache); }

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
                CachePath = DirPath_Cache
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            //Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);


            try {
                if (!Cef.IsInitialized)
                {
                    Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
                }
                
            } catch (Exception ex) { MessageBox.Show(ex.Message); }

            CWB = new ChromiumWebBrowser();
            CWB.LoadingStateChanged += CWB_LoadingStateChanged;
            //CWB.ResourceRequestHandlerFactory = new DefaultResourceHandlerFactory();
            CWB.AddressChanged += CWB_AddressChanged;
            CWB.ConsoleMessage += CWB_ConsoleMessage;
            CWB.JavascriptMessageReceived += CWB_JavascriptMessageReceived;

            CWB.RequestHandler = new CustomRequestHandler();
            (CWB.RequestHandler as CustomRequestHandler).FDownloader = this;

            //===============================
            CWB.DownloadHandler = new CefSharp.Handler.DownloadHandler();

            //===========================login web
            //CWB_login.


            //AllocConsole();

            //global setting
            
            
            MySetting.ExeDir = Path.GetDirectoryName(Application.ExecutablePath);
            MySetting.RawJsonDir = Path.Combine(MySetting.ExeDir, "Raw");
            MySetting.RawJsonDir = Path.Combine(MySetting.RawJsonDir, "ID" + Form_ID.ToString());
            MySetting.RawJsonDir = getDir(MySetting.RawJsonDir);

            MySetting.BaseSettingDir = Path.Combine(MySetting.ExeDir, "Settings");
            MySetting.BaseSettingDir = Path.Combine(MySetting.BaseSettingDir, "ID" + Form_ID.ToString());
            MySetting.BaseSettingDir = getDir(MySetting.BaseSettingDir);

            MySetting.BaseSettingFilePath = Path.Combine(MySetting.BaseSettingDir, "set.json");




            //set other var
            strSetting_ChapterListDir = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "ChapterList");
            strSetting_ChapterListDir = Path.Combine(strSetting_ChapterListDir, "ID" + Form_ID.ToString());
            strSetting_ChapterListDir = getDir(strSetting_ChapterListDir);


            //task done
            TaskDoneDir = Path.Combine(MySetting.ExeDir, "TaskDone");
            TaskDoneDir = Path.Combine(TaskDoneDir, "ID" + Form_ID.ToString());
            TaskDoneDir = getDir(TaskDoneDir);

            //ReadListJsonFilePath = string.Format("ReadList{0}.json", Form_ID);
            ReadListJsonFilePath = string.Format(@"Settings\ID{0}\TitleList_Read.json", Form_ID);
            OnHoldListJsonFilePath = string.Format(@"Settings\ID{0}\TitleList_OnHold.json", Form_ID);
            CompletedListJsonFilePath = string.Format(@"Settings\ID{0}\TitleList_Completed.json", Form_ID);
            DropListJsonFilePath = string.Format(@"Settings\ID{0}\TitleList_Drop.json", Form_ID);

            //IList<ActiveTitleListInfo> ActiveTitleListInfos = new List<ActiveTitleListInfo>();

            //Read
            intTitleList_Read = 0;
            ActiveTitleListInfo ATLI = new ActiveTitleListInfo();
            ATLI.ActiveTV = TV_ReadList;
            ATLI.DataPath = ReadListJsonFilePath;
            ActiveTitleListInfos.Add(ATLI);

            //OnHold
            intTitleList_OnHold = 1;
            ATLI = new ActiveTitleListInfo();
            ATLI.ActiveTV = TV_OnHoldList;
            ATLI.DataPath = OnHoldListJsonFilePath;
            ActiveTitleListInfos.Add(ATLI);

            //Completed
            intTitleList_Completed = 2;
            ATLI = new ActiveTitleListInfo();
            ATLI.ActiveTV = TV_CompletedList;
            ATLI.DataPath = CompletedListJsonFilePath;
            ActiveTitleListInfos.Add(ATLI);

            //Drop
            intTitleList_Drop = 3;
            ATLI = new ActiveTitleListInfo();
            ATLI.ActiveTV = TV_DropList;
            ATLI.DataPath = DropListJsonFilePath;
            ActiveTitleListInfos.Add(ATLI);


            string json;
            if (File.Exists(MySetting.BaseSettingFilePath))
            {
                json = File.ReadAllText(MySetting.BaseSettingFilePath);
            }
            else
            {
                json = JsonConvert.SerializeObject(MySetting);
                File.WriteAllText(MySetting.BaseSettingFilePath, json);
            }

            //title selection setting
            settingTitleSelection.KomikRootDir = "";
            settingTitleSelection.JsonFilePath = Path.Combine(MySetting.BaseSettingDir, "settingTitleSelection.json");
            if (File.Exists(settingTitleSelection.JsonFilePath))
            {
                //load settingTitleSelection
                json = File.ReadAllText(settingTitleSelection.JsonFilePath);
                
                settingTitleSelection = JsonConvert.DeserializeObject<SettingTitleSelectionData>(json);

                //apply settingTitleSelection
                textBox_title_rootDir.Text = settingTitleSelection.KomikRootDir;
            }
            else
            {
                //json = JsonConvert.SerializeObject(settingTitleSelection);
                //File.WriteAllText(settingTitleSelection.JsonFilePath, json);
                saveSettingTitleSelection();
            }
            Log3("Komik root dir = "+ settingTitleSelection.KomikRootDir);

            //setup download
            TaskList_Idle_BaseFileName = string.Format("TaskList_Idle{0}.json", Form_ID);
            TaskList_Running_BaseFileName = string.Format("TaskList_Running{0}.json", Form_ID);
            TaskList_Done_BaseFileName = string.Format("TaskList_Idle{0}.json", Form_ID); //this no longer used because now separate file each task

            //load old task list
            //load task idle
            Log3("Load Task Idle");
            string TaskIdleFilePath = Path.Combine(MySetting.ExeDir, TaskList_Idle_BaseFileName);
            if (File.Exists(TaskIdleFilePath))
            {
                json = File.ReadAllText(TaskIdleFilePath);
                TaskListData TLD = JsonConvert.DeserializeObject<TaskListData>(json);
                Log3("TLD, TaskName = {0}, ChapterName = {1}"
                    , TLD.TaskList[0].TaskName
                    , TLD.TaskList[0].Chapters[0].ChapterName);
                ConvertJsonDataToTVTaskList(TLD, TV_taskList);
            }
            

            //load task running
            Log3("Load Task Idle");
            string TaskRunningFilePath = Path.Combine(MySetting.ExeDir, TaskList_Running_BaseFileName);
            if (File.Exists(TaskRunningFilePath))
            {
                json = File.ReadAllText(TaskRunningFilePath);
                TaskListData TLD = JsonConvert.DeserializeObject<TaskListData>(json);
                Log3("TLD, TaskName = {0}, ChapterName = {1}"
                    , TLD.TaskList[0].TaskName
                    , TLD.TaskList[0].Chapters[0].ChapterName);
                ConvertJsonDataToTVTaskList(TLD, TV_taskRunning);
            }



            //LOAD ReadList
            //btn_LoadTitleList.PerformClick();
            //LoadTitleListByTitleListIndex(intTitleList_Read);

            //LOAD OnHoldList
            //LoadTitleListByTitleListIndex(intTitleList_OnHold);

            LoadAllTitleList(); //need setup above


            //Load old task Done
            startThread_LoadTVDone();



            //setup dragdrop
            setupTreeViewDragDrop(TV_taskList);


            //cear any old download of cover art
            for(int i = 0;i< List_SiteSource.Count; i++)
            {
                string SiteSource = List_SiteSource[i];
                ClearRelBaseCoverDownloadDir(SiteSource);
            }

        }

        private void UpdateUI_ShowActiveLog()
        {
            //hide all tab first
            foreach(Control c in panel_log.Controls)
            {
                Log3("log type = {0}", c.GetType());
                if (c.GetType().Equals(Type.GetType("TextBox") ))
                {
                    (c as TextBox).Visible = false;
                }
            }

            TB_Log1.Visible = false;
            TB_Log2.Visible = false;
            textBox_global_log.Visible = false;

            //show only selected
            int iTab = tabControl1.SelectedIndex;
            Log3(iTab.ToString());
            if (iTab == 0)
            {
                TB_Log1.Visible = true;
            }
            else if (iTab == 1)
            {
                TB_Log2.Visible = true;
            }
            else if (iTab == 2)
            {
                textBox_global_log.Visible = true;
            }
        }

        public void saveSettingTitleSelection()
        {
            
            string json = JsonConvert.SerializeObject(settingTitleSelection);
            File.WriteAllText(settingTitleSelection.JsonFilePath, json);
        }

        private string getDir(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            return dirPath;
        }

        public IList<string> imgUrls = new List<string>();

        private void CWB_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            Log3("CWB_JavascriptMessageReceived, Message = {0} ", e.Message);
        }

        private void CWB_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Log3("CWB_ConsoleMessage, Message = {0} ", e.Message);
        }




        public void Log1(string msg)
        {
            string titleInfo = "log";
            Console.WriteLine("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            msg = String.Format("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            this.InvokeEx(f => f.TB_Log1.AppendText(msg + "\r\n"));
        }

        public void Log1(string msg, params object[] o)
        {

            msg = String.Format(msg,
                              o);


            this.InvokeEx(f => f.TB_Log1.AppendText(msg + "\r\n"));

        }


        public void Log2(string msg)
        {
            string titleInfo = "log";
            Console.WriteLine("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            msg = String.Format("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            this.InvokeEx(f => f.TB_Log2.AppendText(msg + "\r\n"));
        }

        public void Log2(string msg, params object[] o)
        {

            msg = String.Format(msg,
                              o);


            this.InvokeEx(f => f.TB_Log2.AppendText(msg + "\r\n"));

        }



        public void Log3(string msg)
        {
            string titleInfo = "log";
            Console.WriteLine("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            msg = String.Format("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            this.InvokeEx(f => f.textBox_global_log.AppendText(msg + "\r\n"));
        }

        public void Log3(string msg, params object[] o)
        {

            msg = String.Format(msg,
                              o);


            this.InvokeEx(f => f.textBox_global_log.AppendText(msg + "\r\n"));

        }


        private void Form_Downloader_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            this.Hide();

        }

        bool IsLoading = false;
        bool IsDoneLoad = false;
        private void CWB_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                IsLoading = false;
                IsDoneLoad = true;
                // Remove the load event handler, because we only want one snapshot of the initial page.
                //browser2.LoadingStateChanged -= BrowserLoadingStateChanged;
                //Thread.Sleep(3000);
                Log3("LoadingStateChanged, IsLoading = {0}", e.IsLoading);
                //Log("res = " + CWB.GetTextAsync().Result); 
                Log3("LoadingStateChanged after get");
            }
        }



        private void CWB_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Log3("address change = "+ e.Address );
        }

        private void btn_getChapterList_Click(object sender, EventArgs e)
        {
            string chapterListURL = textBox_ChapterURL.Text; //@"https://mangadex.org/title/52ede55c-1584-4019-b85b-3902a423c3ab/fairy-tail-100-years-quest";
            if (chapterListURL == "") { return; }
            LoadChapterListDGVFromOnlineURL(textBox_ChapterSource.Text, chapterListURL);

        }
        ChromiumWebBrowser CWB;
        string JSON_ChapterInfo = "";
        string JSON_ChapterList = "";
        string JSON_ChapterHost = "";
        string strCurrentURLChapterPage = "";

        public void LoadChapterListDGVFromOnlineURL(string SiteSourceName, string URL)
        {
            
            if (SiteSourceName.ToLower() == "mangadex")
            {
                LoadChapterListDGVFromOnlineURL_mangadex(SiteSourceName, URL);
            } else if (SiteSourceName.ToLower() == "taadd")
            {
                LoadChapterListDGVFromOnlineURL_taadd(SiteSourceName, URL);
            }

        }

        public void LoadChapterListDGVFromOnlineURL_taadd(string SiteSourceName, string URL)
        {
            strCurrentURLChapterPage = URL;            

            //clear DGV first before start
            DataGridView DGV = DGV_ChapterList;
            DGV.Rows.Clear();

            chapterPageCount = 1;
            

            IsLoading = true;
            IsDoneLoad = false;

            CWB.Load(strCurrentURLChapterPage);
            CWB.Size = new Size(1360, 1080);

            //set chapter step
            chapterStep = 1;
        }

        public void LoadChapterListDGVFromOnlineURL_mangadex(string SiteSourceName, string URL)
        {
            strCurrentURLChapterPage = URL;
            /*
            IList<string> ChapterURLPathData = URL.Split('/').ToList();

            string titleID = ChapterURLPathData[ChapterURLPathData.Count-1-1];
            string param_translatedLanguage = "translatedLanguage%5B%5D=en";
            string param_limit = "&limit=96";
            string param_includes = "&includes%5B%5D=scanlation_group%2Cuser";
            string param_orderVolume = "&order%5Bvolume%5D=desc";
            string param_orderChapter = "&order%5Bchapter%5D=desc";
            string param_offset = "&offset=0";
            string param_contentRating = "&contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic";


            string URLApi_ChapterList = string.Format("https://api.mangadex.org/manga/{0}/feed?{1}{2}{3}{4}{5}{6}", titleID
                , param_translatedLanguage
                , param_limit
                , param_includes
                , param_orderVolume
                , param_orderChapter
                , param_offset
                , param_contentRating
                );
            */



            /*
             chapter english only
             https://api.mangadex.org/manga/52ede55c-1584-4019-b85b-3902a423c3ab/feed?
            translatedLanguage%5B%5D=en
            &limit=96
            &includes%5B%5D=scanlation_group%2Cuser
            &order%5Bvolume%5D=desc
            &order%5Bchapter%5D=desc
            &offset=0
            &contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic
             
             
             * 
             * 
             */


            //clear DGV first before start
            DataGridView DGV = DGV_ChapterList;
            DGV.Rows.Clear();



            chapterPageCount = 1;
            string URLApi_ChapterList = getURLApi_ChapterList(URL, chapterPageCount - 1);

            IsLoading = true;
            IsDoneLoad = false;

            CWB.Load(URLApi_ChapterList);
            CWB.Size = new Size(1360, 1080);

            //set chapter step
            chapterStep = 1;
            //System.Threading.Timer TimerCheck = new System.Threading.Timer();

            //Task textTask = CWB.GetTextAsync();
            //textTask.ContinueWith(t =>
            //{
            //    Log(textTask.ToString());
            //}
            //);
        }




        bool IsLoading_DL = false;
        bool IsDoneLoad_DL = false;
        private void CWB_DL_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading)
            {
                IsLoading_DL = false;
                IsDoneLoad_DL = true;
                // Remove the load event handler, because we only want one snapshot of the initial page.
                //browser2.LoadingStateChanged -= BrowserLoadingStateChanged;
                //Thread.Sleep(3000);
                Log3("LoadingStateChanged, IsLoading = {0}", e.IsLoading);
                //Log("res = " + CWB.GetTextAsync().Result); 
                Log3("LoadingStateChanged after get");
            }
        }

        private void CWB_DL_AddressChanged(object sender, AddressChangedEventArgs e)
        {
            Log3("address change = " + e.Address);
        }

        private void CWB_DL_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {
            Log3("CWB_ConsoleMessage, Message = {0} ", e.Message);
        }

        private void CWB_DL_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            Log3("CWB_JavascriptMessageReceived, Message = {0} ", e.Message);
        }

        ChromiumWebBrowser CWB_DL;

        private void btn_getJson_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "") { textBox2.Text = @"https://api.mangadex.org/chapter?manga=63a76f81-0e64-47b6-b8d7-4feda78c10f1&volume=none&chapter=4&includes%5B%5D=scanlation_group%2Cuser"; }

            if (CWB_DL == null)
            {
                CWB_DL = new ChromiumWebBrowser();
                CWB_DL.LoadingStateChanged += CWB_DL_LoadingStateChanged;
                //CWB.ResourceRequestHandlerFactory = new DefaultResourceHandlerFactory();
                CWB_DL.AddressChanged += CWB_DL_AddressChanged;
                CWB_DL.ConsoleMessage += CWB_DL_ConsoleMessage;
                CWB_DL.JavascriptMessageReceived += CWB_DL_JavascriptMessageReceived;

                CWB_DL.RequestHandler = new CustomRequestHandler();
                (CWB_DL.RequestHandler as CustomRequestHandler).FDownloader = this;

                //===============================
                CWB_DL.DownloadHandler = new CefSharp.Handler.DownloadHandler();
            }
            //if (!CWB_DL.IsBrowserInitialized)
            //{
            //    Log("CWB_DL not init");

            //    string DirPath_Cache = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp\\CacheDownload");

            //    if (!Directory.Exists(DirPath_Cache)) { Directory.CreateDirectory(DirPath_Cache); }

            //    var settings = new CefSettings()
            //    {
            //        //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
            //        //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            //        CachePath = DirPath_Cache
            //    };

            //    try
            //    {
            //        Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);
            //    }
            //    catch (Exception ex) { MessageBox.Show(ex.Message); }
            //}


            //Console.WriteLine(textBox2.Text);
            IsLoading_DL = true;
            IsDoneLoad_DL = false;
            CWB_DL.Load(textBox2.Text);

            //while (!IsDoneLoad_DL)
            //{

            //}

            //var DownloadHandler = new DownloadHandler();

            //CWB.DownloadHandler = (CefSharp.IDownloadHandler)(DownloadHandler)DownloadHandler;

            //Log(CWB.GetSourceAsync().Result);
            //Log(CWB_DL.GetTextAsync().Result);
        }

        ChapterListData CLD;
        ChapterHostData CHD;
        ChapterInfoData CID;
        const int cintCol_ChapterNo = 0;
        const int cintCol_ChapterName = 1;
        const int cintCol_ChapterStatus = 2;
        const int cintCol_ChapterTimeAddedToDList = 3;
        const int cintCol_ChapterID = 4;
        const int cintCol_ChapterHash = 5;
        const int cintCol_ChapterImageCount = 6;
        const int cintCol_ChapterAttVolume = 7;
        const int cintCol_ChapterAttChapter = 8;
        const int cintCol_ChapterImageHost = 9;
        const int cintCol_ChapterIsObsolute = 10;
        const int cintCol_ChapterScanGroup = 11;
        const int cintCol_ChapterUploader = 12;
        const int cintCol_ChapterTitle = 13;

        int chapterStep = 0;
        string strCurrentChapterID = "";
        string strCurrentChapterHash = "";
        int chapterPageMaxCount = 0;
        int chapterPageCount = 0;

        bool bReqUpdateCover = false;
        //string strCurrentTitleID = "";

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //sitesource taad
                if (textBox_ChapterSource.Text.ToLower() == "taadd")
                {
                    timer1_Tick_taadd(sender, e);
                    return;
                }

                //sitesource mangadex
                if (IsDoneLoad & !IsLoading & chapterStep == 1)
                {
                    Log2("chapterStep = {0}", chapterStep);
                    IsDoneLoad = false;
                    JSON_ChapterList = CWB.GetTextAsync().Result;
                    Log2("JSON_ChapterList = {0}", JSON_ChapterList);


                    if (JSON_ChapterList.Contains("503 Service Unavailable"))
                    {
                        Log2("Service Unavailable, cancel to load chapter list");
                        chapterStep = 0;
                        IsDoneLoad = false;
                    }
                    else
                    {
                        //chapter list data
                        CLD = JsonConvert.DeserializeObject<ChapterListData>(JSON_ChapterList);
                        bool isValid = CLD != null;


                        if (isValid)
                            isValid = CLD.total > 0 && CLD.limit > 0;

                        if (CLD != null && isValid)
                        {
                            chapterPageMaxCount = (CLD.total / CLD.limit) + ((CLD.total % CLD.limit) > 0 ? 1 : 0);
                            Log2("chapterPageMaxCount = {0}", chapterPageMaxCount);

                            Log2("limit = {0}, offset = {1}, total = {2}", CLD.limit, CLD.offset, CLD.total);
                            File.WriteAllText("JSON_ChapterList.json", JSON_ChapterList);

                            //set data grid
                            DataGridView DGV = DGV_ChapterList;
                            //DGV.Rows.Add();
                            int iNumberStart = DGV.Rows.Count;
                            int iNumber = 0;
                            foreach (var data in CLD.data)
                            {
                                if ((data.attributes.externalUrl == null || data.attributes.externalUrl == "") ) //&& data.attributes.data != null)
                                {
                                    //only list chapter not from external web
                                    iNumber++;
                                    string sNumber = (iNumberStart + iNumber).ToString();
                                    string chapterName = "Chapter " + PadStringChapterNumber(data.attributes.chapter);
                                    string chapter_id = data.id;
                                    string chapter_hash = data.attributes.hash;
                                    string chapterAttVolume = data.attributes.volume;
                                    string chapterAttChapter = data.attributes.chapter;
                                    int imgCount = data.attributes.pages; //data.attributes.data.Count; changed to pages

                                    var rs_group = from relationship in data.relationships where relationship.type == "scanlation_group" select relationship;
                                    string chapterScanGroup = "-";
                                    foreach (var rs in rs_group)
                                    {
                                        chapterScanGroup = rs.attributes.name;
                                        break;
                                    }
                                    

                                    var rs_uploader = from relationship in data.relationships where relationship.type == "user" select relationship;
                                    string chapterUploader = "-";
                                    foreach (var rs in rs_uploader)
                                    {
                                        chapterUploader = rs.attributes.username;
                                        break;
                                    }

                                    string chapterTitle = data.attributes.title;

                                    DGV.Rows.Add();
                                    int iRow = DGV.Rows.Count - 1;

                                    int iCol = cintCol_ChapterNo;
                                    DGV[iCol, iRow].Value = sNumber;

                                    iCol = cintCol_ChapterName;
                                    DGV[iCol, iRow].Value = chapterName;

                                    iCol = cintCol_ChapterStatus;
                                    DGV[iCol, iRow].Value = "Online";


                                    iCol = cintCol_ChapterID;
                                    DGV[iCol, iRow].Value = chapter_id;
                                    strCurrentChapterID = chapter_id;

                                    iCol = cintCol_ChapterHash;
                                    DGV[iCol, iRow].Value = chapter_hash;
                                    strCurrentChapterHash = chapter_hash;

                                    iCol = cintCol_ChapterAttVolume;
                                    DGV[iCol, iRow].Value = chapterAttVolume;

                                    iCol = cintCol_ChapterAttChapter;
                                    DGV[iCol, iRow].Value = chapterAttChapter;

                                    iCol = cintCol_ChapterImageCount;
                                    DGV[iCol, iRow].Value = imgCount;

                                    //scan goup
                                    iCol = cintCol_ChapterScanGroup;
                                    DGV[iCol, iRow].Value = chapterScanGroup;

                                    //uploader
                                    iCol = cintCol_ChapterUploader;
                                    DGV[iCol, iRow].Value = chapterUploader;

                                    //chapter title
                                    iCol = cintCol_ChapterTitle;
                                    DGV[iCol, iRow].Value = chapterTitle;

                                }

                            }

                            //next step
                            chapterStep = 2;
                            IsDoneLoad = true;
                        }
                        else
                        {
                            Log2("CLD is null or not valid, cancel to load chapter list");
                            chapterStep = 0;
                            IsDoneLoad = false;
                        }
                    }


                }


                //2
                if (IsDoneLoad & chapterStep == 2)
                {
                    IsDoneLoad = false;
                    //chapter page
                    if (chapterPageMaxCount > 1 && chapterPageCount < chapterPageMaxCount)
                    {

                        chapterPageCount++;
                        Log2("there still more chapter page, try load chapterPageCount = {0}", chapterPageCount);

                        string URLApi_ChapterList = getURLApi_ChapterList(strCurrentURLChapterPage, (chapterPageCount - 1) * 96);

                        IsLoading = true;
                        IsDoneLoad = false;

                        CWB.Load(URLApi_ChapterList);
                        //CWB.Size = new Size(1360, 1080);

                        //set chapter step
                        chapterStep = 1;
                    }
                    else
                    {
                        //set chapter step
                        chapterStep = 3;
                        IsDoneLoad = true;
                    }
                }




                //3
                if (IsDoneLoad & chapterStep == 3)
                {
                    IsDoneLoad = false;
                    //get image host
                    Log2("chapterStep = {0}", chapterStep);

                    ////https://api.mangadex.org/at-home/server/3e64b0b0-872c-43c4-9a4b-c3a12013bb6a?forcePort443=false
                    //string param_chapterID = strCurrentChapterID;
                    //string param_forcePort443 = @"forcePort443=false";
                    //string URLApi_getImageHost = string.Format(@"https://api.mangadex.org/at-home/server/{0}?{1}", param_chapterID, param_forcePort443);
                    //Log("URLApi_getImageHost = {0}", URLApi_getImageHost);



                    string URLApi_getImageHost = getURLApi_ImageHost(strCurrentChapterID);
                    IsLoading = true;
                    IsDoneLoad = false;
                    CWB.Load(URLApi_getImageHost);

                    //next step
                    chapterStep = 4;

                }

                if (IsDoneLoad & !IsLoading & chapterStep == 4)
                {
                    //store image host
                    Log2("chapterStep = {0}", chapterStep);
                    IsDoneLoad = false;
                    Log2("get chapter host");
                    JSON_ChapterHost = CWB.GetTextAsync().Result;
                    Log2("JSON_ChapterHost = {0}", JSON_ChapterHost);


                    //chapter host data, setiap chapter id bisa beda, ini hanya sementara dianggap semua chapter id sama host nya.
                    CHD = JsonConvert.DeserializeObject<ChapterHostData>(JSON_ChapterHost);
                    Log2("result = {0}, baseUrl = {1}", CHD.result, CHD.baseUrl);

                    for (int iRow = 0; iRow < DGV_ChapterList.RowCount; iRow++)
                    {
                        //if(DGV_ChapterList[cintCol_ChapterID, iRow].Value.ToString() == strCurrentChapterID)
                        {
                            DGV_ChapterList[cintCol_ChapterImageHost, iRow].Value = CHD.baseUrl;
                        }

                    }


                    //next step
                    chapterStep = 5;
                    IsDoneLoad = true;
                }

                if(IsDoneLoad & chapterStep == 5)
                {
                    IsDoneLoad = false;
                    //get image host
                    Log2("chapterStep = {0}", chapterStep);

                    string URLApi_ChapterInfo = getURLApi_ChapterInfo(strCurrentURLChapterPage);
                    IsLoading = true;
                    IsDoneLoad = false;
                    CWB.Load(URLApi_ChapterInfo);

                    //next step
                    chapterStep = 6;
                    
                }

                if (IsDoneLoad & !IsLoading & chapterStep == 6)
                {
                    //
                    Log2("chapterStep = {0}", chapterStep);
                    IsDoneLoad = false;
                    Log2("get chapter info");
                    JSON_ChapterInfo = CWB.GetTextAsync().Result;
                    Log2("JSON_ChapterInfo = {0}", JSON_ChapterInfo);


                    //chapter info data
                    CID = JsonConvert.DeserializeObject<ChapterInfoData>(JSON_ChapterInfo);
                    Log2("isSetDescription_error = {0}, iError = {1}", CID.data.attributes.isSetDescription_error, CID.data.attributes.iError);
                    Log2("result = {0}, response = {1}, fileName = {2}", CID.result, CID.response, CID.data.relationships[2].attributes.fileName);

                    string desc = getLangObjectDefaultAndAll(CID.data.attributes.description, "en");
                    textBox_titleDesc.Text = desc;

                    //https://uploads.mangadex.org/covers/45d3ebca-8d74-4e51-be90-8582e4756cbd/9a4769db-46e8-4135-acb3-1c19152d4090.jpg

                    string titleID = CID.data.id;
                    //strCurrentTitleID = titleID;

                    //string FileName = CID.data.relationships[2].attributes.fileName;

                    string FileName = "";
                    for (int i = 0;i< CID.data.relationships.Count;i++)
                    {
                        string type = CID.data.relationships[i].type.ToLower();
                        if (type == "cover_art")
                        {
                            //
                            FileName = CID.data.relationships[i].attributes.fileName;
                            break;
                        }
                    }
                    
                    string URL_CoverImage = string.Format("https://uploads.mangadex.org/covers/{0}/{1}", titleID
                    , FileName
                    );

                    Log2("Cover URL = {0}", URL_CoverImage);
                    
                    //next step
                    chapterStep = 7;
                    IsDoneLoad = true;

                    //string RelDirCover = "Cover_" + Form_ID.ToString(); //relative path dir cover
                    //if (!Directory.Exists(RelDirCover))
                    //{
                    //    Directory.CreateDirectory(RelDirCover);
                    //}

                    //string fileCoverImage = PathCombine(RelDirCover, titleID + ".jpg");

                    string fileCoverImage = GetCoverImage(strCurrentSiteSource);

                    if (!File.Exists(fileCoverImage))
                    {
                        Log2("Download cover image url {0}", URL_CoverImage);
                        Log2("Download cover image file {0}", fileCoverImage);
                        DownloadFile_cover(URL_CoverImage, fileCoverImage);
                    }
                    else
                    {
                        Log2("Load old cover image");
                    }

                    UpdateUI_RefreshCover();
                    

                }

                if (IsDoneLoad & chapterStep == 7)
                {
                    Log2("chapterStep = {0}", chapterStep);
                    Log2("Get Chapter is Done");
                    chapterStep = 8;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string getLangObjectDefaultAndAll(LangObject0 langObject, string defLangID, bool IsGetAllLang = false)
        {
            string s = "";
            if (defLangID == "en")
            {
                s = langObject.en;
            }


            if (IsGetAllLang)
            {
                if (defLangID != "en")
                {
                    s = s + "\r\n" + langObject.en;
                }

                if (defLangID != "ru")
                {
                    s = s + "\r\n" + langObject.ru;
                }

                if (defLangID != "fa")
                {
                    s = s + "\r\n" + langObject.fa;
                }

                if (defLangID != "th")
                {
                    s = s + "\r\n" + langObject.fa;
                }

                if (defLangID != "ja")
                {
                    s = s + "\r\n" + langObject.fa;
                }

                if (defLangID != "zh")
                {
                    s = s + "\r\n" + langObject.fa;
                }

                if (defLangID != "zh_hk")
                {
                    s = s + "\r\n" + langObject.fa;
                }

                if (defLangID != "ko")
                {
                    s = s + "\r\n" + langObject.fa;
                }

            }

            return s;
        }


        private void timer1_Tick_taadd(object sender, EventArgs e)
        {
            try
            {
                

                //sitesource taadd
                if (IsDoneLoad & !IsLoading & chapterStep == 1)
                {
                    Log2("chapterStep = {0}", chapterStep);
                    IsDoneLoad = false;
                    //JSON_ChapterList = CWB.GetTextAsync().Result;
                    JSON_ChapterList = CWB.GetSourceAsync().Result;
                    Log2("HTML Text = {0}", JSON_ChapterList);




                    if (JSON_ChapterList.Contains("503 Service Unavailable"))
                    {
                        Log2("Service Unavailable, cancel to load chapter list");
                        chapterStep = 0;
                        IsDoneLoad = false;
                    }
                    else
                    {


                        //next step
                        chapterStep = 5;// 2;
                        IsDoneLoad = true;
  
                    }


                }


                

                if (IsDoneLoad & chapterStep == 5)
                {
                    Log2("chapterStep = {0}", chapterStep);
                    Log2("Get Chapter is Done");
                    chapterStep = 6;
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private string PadStringChapterNumber(string s)
        {
            string ns = "";
            if (s == "" | s == null)
            {
                return ns;
            }

            IList<string> LS = s.Split('.').ToList();
            
            int i = 0;
            string deli = "";
            foreach(string ss in LS)
            {
                i++;
                if (i > 1) { deli = "."; }
                ns += deli+ss.PadLeft(3, '0');
            }

            return ns;
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Log3("e.Node.Level = {0}", e.Node.Level);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            TreeView TV = ActiveTitleListInfos[ActiveTitleListIndex].ActiveTV ;//TV_ReadList;
            ContextMenuStrip CMS = contextMenuStrip1;

            if(TV.SelectedNode is null) { return; }

            int iCurrentLevel = TV.SelectedNode.Level;
            IList<string> NodeTexts = TV.SelectedNode.FullPath.Split('\\').ToList();
            if (NodeTexts.Count >= 1)
            {
                CMS.Items[0].Text = NodeTexts[0];
            }
            else
            {
                CMS.Items[0].Text = "Select Title";
            }

            if (NodeTexts.Count >= 2)
            {
                CMS.Items[1].Text = NodeTexts[1];
            }
            else
            {
                CMS.Items[1].Text = "Select Site Source";
            }

            //open chapter
            Log3("iCurrentLevel = {0}", iCurrentLevel);
            CMS.Items[3].Enabled = iCurrentLevel == 1;

            //edit title
            CMS.Items[4].Enabled = iCurrentLevel == 1;

            //set open
            if (iCurrentLevel == 1)
            {

            }



        }

        string strCurrentLocalTitleNameID = "";
        string strCurrentSiteSource = "";

        private void openChapterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TreeView TV = TV_ReadList;
            ContextMenuStrip CMS = contextMenuStrip1;
            if (TV.SelectedNode == null) { return; }

            if (TV.SelectedNode.Level == 1)
            {

                textBox_ChapterTitleName.Text = CMS.Items[0].Text;
                textBox_ChapterSource.Text = CMS.Items[1].Text;
                textBox_ChapterURL.Text = TV.SelectedNode.FirstNode.Text;

                //set base need
                strCurrentSiteSource = textBox_ChapterSource.Text;
                strCurrentLocalTitleNameID = Path.GetFileName(textBox_ChapterURL.Text);
                Log1("set strCurrentLocalTitleNameID = {0}", strCurrentLocalTitleNameID);


                //clear button
                iaddAsNewTask_Click = 0;
                btn_cart_addAsNewTask.Text = "Add as New Task";

                //clear title desc
                textBox_titleDesc.Text = "";


                //clear cover
                pictureBox2.Image = null;

                //clear dgv
                DGV_ChapterList.Rows.Clear();
                DGV_ChapterCartList.Rows.Clear();


                //load DGV
                saveLoadUpdateChapterList(textBox_ChapterSource.Text);


            }

        }

        private void btn_addRowChapter_Click(object sender, EventArgs e)
        {
            DataGridView DGV = DGV_ChapterList;
            DGV.Rows.Add();
        }

        private void DGV_ChapterList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (imgUrls.Count > 0)
            {
                int i = 0;
                foreach(string s in imgUrls)
                {
                    i++;
                    Log3(i.ToString()+", "+s);
                }
            }
        }

        private void addToCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddSelectedChapterTOCart();

            //change tab to cart
            tabControl_chapterSelection.SelectedIndex = 1;

            //
            Cart_CheckNumbering();
        }

        private void AddSelectedChapterTOCart()
        {
            DataGridView DGV_CL = DGV_ChapterList;
            DataGridView DGV_CCL = DGV_ChapterCartList;
            if (DGV_CL.ColumnCount != DGV_CCL.ColumnCount)
            {
                Log3("something wrong when adding cart, col count not the same");
                return;
            }

            Log3("DGV_CL.SelectedCells.Count = {0}", DGV_CL.SelectedCells.Count);
            if (DGV_CL.SelectedCells.Count > 0)
            {

                int iColSelected = 0;
                for (int i = 0; i < DGV_CL.SelectedCells.Count; i++)
                {
                    DataGridViewCell DIR = DGV_CL.SelectedCells[i];

                    if (i == 0)
                    {
                        iColSelected = DIR.ColumnIndex;
                    }

                    if (iColSelected == DIR.ColumnIndex)
                    {
                        DGV_CCL.Rows.Add();
                        int iRow = DGV_CCL.Rows.Count - 1;
                        //DGV_CCL.ro

                        for (int iCol = 0; iCol < DGV_CL.ColumnCount; iCol++)
                        {
                            DGV_CCL[iCol, iRow].Value = DGV_CL[iCol, DIR.RowIndex].Value;
                            if (iCol == 0)
                            {
                                DGV_CCL[iCol, iRow].Value = DGV_CCL[iCol, iRow].Value.ToString().PadLeft(5, '0');
                            }

                        }
                        //write date add
                        DGV_CL[cintCol_ChapterTimeAddedToDList, DIR.RowIndex].Value = DateTime.Now.ToString("G");
                    }

                }
            }

            //sort
            DGV_CCL.Sort(DGV_CCL.Columns[0], ListSortDirection.Descending);
        }

        private void CMS_DGV_Chapter_Opening(object sender, CancelEventArgs e)
        {

        }

        private void saveLoadUpdateChapterListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveLoadUpdateChapterList(textBox_ChapterSource.Text);
        }

        string strSetting_ChapterListDir = "init set, need load set"; // Path.Combine( Path.GetDirectoryName( Application.ExecutablePath), "ChapterList");

        private void saveLoadUpdateChapterList(string SiteSourceName)
        {
            if (SiteSourceName.ToLower() == "mangadex")
            {
                saveLoadUpdateChapterList_mangadex(SiteSourceName);
            } else if (SiteSourceName.ToLower() == "taadd")
            {
                saveLoadUpdateChapterList_taadd(SiteSourceName);
            }
            else
            {
                MessageBox.Show("Site Source not valid.");
            }
            


        }

        private void saveLoadUpdateChapterList_taadd(string SiteSourceName)
        {
            //create dir
            if (!Directory.Exists(strSetting_ChapterListDir))
            {
                Directory.CreateDirectory(strSetting_ChapterListDir);
            }

            //get local file chapter list data
            string ChapterListFileJson = getChapterListFileJson(SiteSourceName, textBox_ChapterURL.Text);

            //===================================================================================

            //check first need to load local file?
            bool IsLocalAvailable = File.Exists(ChapterListFileJson);
            //bool IsNeedLoadLocalFirst = IsLocalAvailable && DGV_ChapterList.Rows.Count<=0;
            if (DGV_ChapterList.Rows.Count <= 0 && IsLocalAvailable)
            {
                //try load local first
                LoadChapterListDGVFromJsonFile(ChapterListFileJson, "stored");
                Log3("Load Chapter list from " + ChapterListFileJson);
            }
            else if (DGV_ChapterList.Rows.Count <= 0 && !IsLocalAvailable)
            {
                //load online
                string chapterListURL = textBox_ChapterURL.Text; //@"https://mangadex.org/title/52ede55c-1584-4019-b85b-3902a423c3ab/fairy-tail-100-years-quest";
                if (chapterListURL == "") { return; }
                LoadChapterListDGVFromOnlineURL(SiteSourceName, chapterListURL);
                Log3("Load Online Chapter list from " + chapterListURL);

            }
            else if (DGV_ChapterList.Rows.Count > 0 && !IsLocalAvailable)
            {
                //just save
                SaveChapterListToJsonFile(ChapterListFileJson, "new");
                Log3("Save Chapter list to " + ChapterListFileJson);
            }
            else if (DGV_ChapterList.Rows.Count > 0 && IsLocalAvailable)
            {
                //update
                UpdateChaterListToJsonFile(ChapterListFileJson);
                LoadChapterListDGVFromJsonFile(ChapterListFileJson);
                Log3("done reload update");
                Log3("Update Chapter list to " + ChapterListFileJson);
            }
            else
            {
                //what now?
                Log3("saveLoadUpdateChapterList doing nothing ???, try update? no?");
            }

        }

        private void saveLoadUpdateChapterList_mangadex(string SiteSourceName)
        {
            //create dir
            if (!Directory.Exists(strSetting_ChapterListDir))
            {
                Directory.CreateDirectory(strSetting_ChapterListDir);
            }

            //create file name
            //if mangadex
            //string ChapterListPageUrl = textBox_ChapterURL.Text;
            //IList<string> URLChapterPagePathData = ChapterListPageUrl.Split('/').ToList();
            //string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];


            //string baseFileName = Path.GetFullPath(titleID + ".json");
            //string ChapterListFileJson = Path.Combine(cstrSetting_ChapterListDir, baseFileName);

            string ChapterListFileJson = getChapterListFileJson(SiteSourceName, textBox_ChapterURL.Text);

            //===================================================================================

            //check first need to load local file?
            bool IsLocalAvailable = File.Exists(ChapterListFileJson);
            //bool IsNeedLoadLocalFirst = IsLocalAvailable && DGV_ChapterList.Rows.Count<=0;
            if (DGV_ChapterList.Rows.Count <= 0 && IsLocalAvailable)
            {
                //try load local first
                LoadChapterListDGVFromJsonFile(ChapterListFileJson, "stored");
                Log3("Load Chapter list from " + ChapterListFileJson);
            }
            else if (DGV_ChapterList.Rows.Count <= 0 && !IsLocalAvailable)
            {
                //load online
                string chapterListURL = textBox_ChapterURL.Text; //@"https://mangadex.org/title/52ede55c-1584-4019-b85b-3902a423c3ab/fairy-tail-100-years-quest";
                if (chapterListURL == "") { return; }
                LoadChapterListDGVFromOnlineURL(SiteSourceName, chapterListURL);
                Log3("Load Online Chapter list from " + chapterListURL);

            }
            else if (DGV_ChapterList.Rows.Count > 0 && !IsLocalAvailable)
            {
                //just save
                SaveChapterListToJsonFile(ChapterListFileJson, "new");
                Log3("Save Chapter list to " + ChapterListFileJson);
            }
            else if (DGV_ChapterList.Rows.Count > 0 && IsLocalAvailable)
            {
                //update
                UpdateChaterListToJsonFile(ChapterListFileJson);
                LoadChapterListDGVFromJsonFile(ChapterListFileJson);
                Log3("done reload update");
                Log3("Update Chapter list to " + ChapterListFileJson);
            }
            else
            {
                //what now?
                Log3("saveLoadUpdateChapterList doing nothing ???, try update? no?");
            }



            //check local file is exists
            if (File.Exists(ChapterListFileJson))
            {
                //

            }
        }

        private void UpdateChaterListToJsonFile(string FilePath, string status = "")
        {
            IList<ChapterListDataLocal> ChapterListDataOnlines = new List<ChapterListDataLocal>();
            IList<ChapterListDataLocal> newChapterListDataLocals = new List<ChapterListDataLocal>();
            ChapterListDataLocals.Clear();
            ChapterListDataLocal CLDL_Online;
            ChapterListDataLocal CLDL_Local;


            //LOAD ONLINE
            DataGridView DGV = DGV_ChapterList;
            int iColCount = DGV.Columns.Count;
            int iRowCount = DGV.Rows.Count;
            Log3("iColCount = {0}, iRowCount = {1} ", iColCount, iRowCount);

            foreach (DataGridViewRow Row in DGV.Rows)
            {
                CLDL_Online = new ChapterListDataLocal();
                foreach (DataGridViewColumn Col in DGV.Columns)
                {
                    int iCol = Col.Index;
                    int iRow = Row.Index;


                    if (iCol == cintCol_ChapterNo)
                        CLDL_Online.chapterNo = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterName)
                        CLDL_Online.chapterName = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterStatus)
                    {
                        if (status != "") { DGV[iCol, iRow].Value = status; }
                        CLDL_Online.chapterStatus = (string)DGV[iCol, iRow].Value;
                    }

                    else if (iCol == cintCol_ChapterTimeAddedToDList)
                        CLDL_Online.chapterDateAddedToDList = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterID)
                        CLDL_Online.chapterID = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterHash)
                        CLDL_Online.chapterHash = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageCount)
                        CLDL_Online.chapterImageCount = DGV[iCol, iRow].Value != null ? DGV[iCol, iRow].Value.ToString() : "";
                    else if (iCol == cintCol_ChapterAttVolume)
                        CLDL_Online.chapterAttVolume = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterAttChapter)
                        CLDL_Online.chapterAttChapter = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageHost)
                        CLDL_Online.chapterImageHost = (string)DGV[iCol, iRow].Value;

                    else if (iCol == cintCol_ChapterScanGroup)
                        CLDL_Online.chapterScanGroup = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterUploader)
                        CLDL_Online.chapterUploader = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterTitle)
                        CLDL_Online.chapterTitle = DGV[iCol, iRow].Value != null ? DGV[iCol, iRow].Value.ToString() : "";
                }
                if (CLDL_Online != null)
                {
                    ChapterListDataOnlines.Add(CLDL_Online);
                }


            }


            //LOAD LOCAL
            string json = File.ReadAllText(FilePath);
            ChapterListDataLocals = JsonConvert.DeserializeObject<IList<ChapterListDataLocal>>(json);

            //COMPARE ONLINE AND LOCAL
            foreach (ChapterListDataLocal CLDLOnline in ChapterListDataOnlines)
            {
                Log3("Check online chapter id = {0}, chapter name = {1}", CLDLOnline.chapterID, CLDLOnline.chapterName);
                bool IsNew = true;
                foreach (ChapterListDataLocal CLDLLocal in ChapterListDataLocals)
                {
                    Log3("---- {0} == {1}", CLDLOnline.chapterID, CLDLLocal.chapterID);                    
                    if(CLDLOnline.chapterID==CLDLLocal.chapterID)
                    {
                        //found old data
                        //store old data
                        CLDLOnline.chapterDateAddedToDList = CLDLLocal.chapterDateAddedToDList;

                        //remove old data because no need to llop search again
                        ChapterListDataLocals.Remove(CLDLLocal);
                        IsNew = false;
                        break;
                    } 

                }

                if (IsNew)
                {
                    //status new
                    CLDLOnline.chapterStatus = "new";
                    newChapterListDataLocals.Add(CLDLOnline);
                    Log3("---- Found new Chapter = {0}", CLDLOnline.chapterName);
                }
                else
                {
                    //status stored
                    CLDLOnline.chapterStatus = "stored";
                    newChapterListDataLocals.Add(CLDLOnline);                    
                    Log3("---- Found old Chapter = {0}", CLDLOnline.chapterName);
                }

            }

            //store obsolute
            Log3("{0} obsolute chapter", ChapterListDataLocals.Count);
            if (ChapterListDataLocals.Count > 0)
            {
                //store obsolute
                foreach (ChapterListDataLocal CLDLLocal in ChapterListDataLocals)
                {
                    CLDLLocal.chapterStatus = "stored obsolute";
                    CLDLLocal.chapterIsObsolute = true;
                    newChapterListDataLocals.Add(CLDLLocal);
                    Log3("Obsolute Chapter = {0}", CLDLLocal.chapterName);
                }
            }

            




            //SAVE UPDATE

             json = JsonConvert.SerializeObject(newChapterListDataLocals);
            File.WriteAllText(FilePath, json);
            Log3("done saving update");
        }


        private string getChapterListFileJson(string SiteSourceName, string ChapterListPageUrl)
        {
            string ChapterListFileJson = "";

            if (SiteSourceName.ToLower() == "mangadex")
            {
                ChapterListFileJson = getChapterListFileJson_mangadex(ChapterListPageUrl);
            } else if (SiteSourceName.ToLower() == "taadd")
            {
                ChapterListFileJson = getChapterListFileJson_taadd(SiteSourceName, ChapterListPageUrl);
            }


            return ChapterListFileJson;
        }

        private string getChapterListFileJson_taadd(string SiteSourceName, string ChapterListPageUrl)
        {
            IList<string> URLChapterPagePathData = ChapterListPageUrl.Split('/').ToList();
            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 ];


            string baseFileName = SiteSourceName +"_"+ titleID + ".json";
            string ChapterListFileJson = Path.Combine(strSetting_ChapterListDir, baseFileName);
            //MessageBox.Show(ChapterListFileJson);
            return ChapterListFileJson;
        }

        private string getChapterListFileJson_mangadex(string ChapterListPageUrl)
        {
            IList<string> URLChapterPagePathData = ChapterListPageUrl.Split('/').ToList();
            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];


            string baseFileName = titleID + ".json";
            string ChapterListFileJson = Path.Combine(strSetting_ChapterListDir, baseFileName);
            //MessageBox.Show(ChapterListFileJson);
            return ChapterListFileJson;
        }

        private string PathCombine(string path1, string path2)
        {
            if (Path.IsPathRooted(path2))
            {
                path2 = path2.TrimStart(Path.DirectorySeparatorChar);
                path2 = path2.TrimStart(Path.AltDirectorySeparatorChar);
            }

            return Path.Combine(path1, path2);
        }

        IList<ChapterListDataLocal> ChapterListDataLocals = new List<ChapterListDataLocal>();
        private void btn_saveChapterList_Click(object sender, EventArgs e)
        {
            ChapterListDataLocals.Clear();
            ChapterListDataLocal CLDL;
            DataGridView DGV = DGV_ChapterList;
            int iColCount = DGV.Columns.Count;
            int iRowCount = DGV.Rows.Count;
            Log3("iColCount = {0}, iRowCount = {1} ", iColCount, iRowCount);

            foreach (DataGridViewRow Row in DGV.Rows)
            {
                CLDL = new ChapterListDataLocal();
                foreach (DataGridViewColumn Col in DGV.Columns)
                {
                    int iCol = Col.Index;
                    int iRow = Row.Index;

                    
                    if(iCol==cintCol_ChapterNo)
                        CLDL.chapterNo = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterName)
                        CLDL.chapterName = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterStatus)
                        CLDL.chapterStatus = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterTimeAddedToDList)
                        CLDL.chapterDateAddedToDList = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterID)
                        CLDL.chapterID = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterHash)
                        CLDL.chapterHash = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageCount)
                        CLDL.chapterImageCount = DGV[iCol, iRow].Value != null? DGV[iCol, iRow].Value.ToString():"";
                    else if (iCol == cintCol_ChapterAttVolume)
                        CLDL.chapterAttVolume = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterAttChapter)
                        CLDL.chapterAttChapter = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageHost)
                        CLDL.chapterImageHost = (string)DGV[iCol, iRow].Value;

                    else if (iCol == cintCol_ChapterScanGroup)
                        CLDL.chapterScanGroup = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterUploader)
                        CLDL.chapterUploader = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterTitle)
                        CLDL.chapterTitle = DGV[iCol, iRow].Value != null ? DGV[iCol, iRow].Value.ToString() : "";
                }
                if(CLDL != null)
                {
                    ChapterListDataLocals.Add(CLDL);
                }
                

            }

            string json = JsonConvert.SerializeObject(ChapterListDataLocals);
            File.WriteAllText("ChapterListDataLocals.json", json);


        }

        private void SaveChapterListToJsonFile(string FilePath, string status="")
        {
            ChapterListDataLocals.Clear();
            ChapterListDataLocal CLDL;
            DataGridView DGV = DGV_ChapterList;
            int iColCount = DGV.Columns.Count;
            int iRowCount = DGV.Rows.Count;
            Log3("iColCount = {0}, iRowCount = {1} ", iColCount, iRowCount);

            foreach (DataGridViewRow Row in DGV.Rows)
            {
                CLDL = new ChapterListDataLocal();
                foreach (DataGridViewColumn Col in DGV.Columns)
                {
                    int iCol = Col.Index;
                    int iRow = Row.Index;


                    if (iCol == cintCol_ChapterNo)
                        CLDL.chapterNo = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterName)
                        CLDL.chapterName = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterStatus)
                    {
                        if (status != "") { DGV[iCol, iRow].Value = status; }
                        CLDL.chapterStatus = (string)DGV[iCol, iRow].Value;
                    }
                        
                    else if (iCol == cintCol_ChapterTimeAddedToDList)
                        CLDL.chapterDateAddedToDList = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterID)
                        CLDL.chapterID = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterHash)
                        CLDL.chapterHash = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageCount)
                        CLDL.chapterImageCount = DGV[iCol, iRow].Value != null ? DGV[iCol, iRow].Value.ToString() : "";
                    else if (iCol == cintCol_ChapterAttVolume)
                        CLDL.chapterAttVolume = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterAttChapter)
                        CLDL.chapterAttChapter = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterImageHost)
                        CLDL.chapterImageHost = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterIsObsolute)
                        CLDL.chapterIsObsolute = DGV[iCol, iRow].Value!=""?Convert.ToBoolean(DGV[iCol, iRow].Value):false;

                    else if (iCol == cintCol_ChapterScanGroup)
                        CLDL.chapterScanGroup = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterUploader)
                        CLDL.chapterUploader = (string)DGV[iCol, iRow].Value;
                    else if (iCol == cintCol_ChapterTitle)
                        CLDL.chapterTitle = DGV[iCol, iRow].Value != null ? DGV[iCol, iRow].Value.ToString() : "";
                }
                if (CLDL != null)
                {
                    ChapterListDataLocals.Add(CLDL);
                }


            }

            string json = JsonConvert.SerializeObject(ChapterListDataLocals);
            File.WriteAllText(FilePath, json);
        }

        private void btn_loadChapterList_Click(object sender, EventArgs e)
        {
            LoadChapterListDGVFromJsonFile("ChapterListDataLocals.json");
        }

        private void LoadChapterListDGVFromJsonFile(string FilePath, string status = "")
        {
            string json = File.ReadAllText(FilePath);
            DataGridView DGV = DGV_ChapterList;

            ChapterListDataLocals.Clear();
            DGV.Rows.Clear();

            ChapterListDataLocals = JsonConvert.DeserializeObject<IList<ChapterListDataLocal>>(json);

            if (ChapterListDataLocals.Count > 0)
            {
                int iRow = -1; //zero-based
                foreach (ChapterListDataLocal CLDL in ChapterListDataLocals)
                {
                    iRow++;
                    DGV.Rows.Add();
                    foreach (DataGridViewColumn Col in DGV.Columns)
                    {
                        int iCol = Col.Index;



                        if (iCol == cintCol_ChapterNo)
                            DGV[iCol, iRow].Value = CLDL.chapterNo;
                        else if (iCol == cintCol_ChapterName)
                            DGV[iCol, iRow].Value = CLDL.chapterName;
                        else if (iCol == cintCol_ChapterStatus)
                        {
                            if (status != "") { CLDL.chapterStatus = status; }
                            DGV[iCol, iRow].Value = CLDL.chapterStatus;
                        }

                        else if (iCol == cintCol_ChapterTimeAddedToDList)
                            DGV[iCol, iRow].Value = CLDL.chapterDateAddedToDList;
                        else if (iCol == cintCol_ChapterID)
                            DGV[iCol, iRow].Value = CLDL.chapterID;
                        else if (iCol == cintCol_ChapterHash)
                            DGV[iCol, iRow].Value = CLDL.chapterHash;
                        else if (iCol == cintCol_ChapterImageCount)
                            DGV[iCol, iRow].Value = CLDL.chapterImageCount;
                        else if (iCol == cintCol_ChapterAttVolume)
                            DGV[iCol, iRow].Value = CLDL.chapterAttVolume;
                        else if (iCol == cintCol_ChapterAttChapter)
                            DGV[iCol, iRow].Value = CLDL.chapterAttChapter;
                        else if (iCol == cintCol_ChapterImageHost)
                            DGV[iCol, iRow].Value = CLDL.chapterImageHost;
                        else if (iCol == cintCol_ChapterIsObsolute)
                            DGV[iCol, iRow].Value = CLDL.chapterIsObsolute.ToString();

                        else if (iCol == cintCol_ChapterScanGroup)
                            DGV[iCol, iRow].Value = CLDL.chapterScanGroup;
                        else if (iCol == cintCol_ChapterUploader)
                            DGV[iCol, iRow].Value = CLDL.chapterUploader;
                        else if (iCol == cintCol_ChapterTitle)
                            DGV[iCol, iRow].Value = CLDL.chapterTitle;
                    }
                }
            }

            IsDownloadDone_cover = true; //karena dari lokal maka anggap sudah selesai download
            UpdateUI_RefreshCover();
        }

        private void DGV_ChapterCartList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //ChromiumWebBrowser CWB_Download = new ChromiumWebBrowser();

        private void button3_Click(object sender, EventArgs e)
        {
            //string url = @"https://xxgv3gd28paf2.apttrvtvrt9zm.mangadex.network/gUKeu5j3Qa7mYNcKTRR4A7D1KTJvOTeon3S54_wYscu-j188KvKnuJQwWgVAKKux6wC1NfKIw0PuP4lo3A0NOKxTN2gTzVY_1diynjc0EIwZG_SJMfCPf1LYt3WOj8tSdnuSbSIGoC41OMoex9WCqXUbhSG-iZlSgWALf4qN94Ein888oer6RZl2OfAjminS/data/c7a9c9e2bae6991a36d609c69df6559c/U1-3f2609f14e96ee8f3e165084c856b083f89edb31d34088103c15e263589755e7.jpg";
            string url = @"https://uploads.mangadex.org/data/c7a9c9e2bae6991a36d609c69df6559c/U1-3f2609f14e96ee8f3e165084c856b083f89edb31d34088103c15e263589755e7.jpg";
            //CWB.Load(url);
            //download(url); //ok
            if (textBox2.Text == "")
            {
                textBox2.Text = "https://api.mangadex.org/at-home/server/dc5bec25-5349-48bb-929d-0eda96eca3de?forcePort443=false";

                textBox2.Text = @"https://uploads.mangadex.org/data/c7a9c9e2bae6991a36d609c69df6559c/U1-3f2609f14e96ee8f3e165084c856b083f89edb31d34088103c15e263589755e7.jpg";
            }

            url = textBox2.Text;

            DownloadFile(url, @"image2.jpg");



        }

        private void download(string url)
        {
            using (WebClient client = new WebClient())
            {
                client.DownloadFile(new Uri(url), @"image1.jpg");
                // OR 
                //client.DownloadFileAsync(new Uri(url), @"c:\temp\image35.png");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var task = CWB.ScreenshotAsync();
            task.ContinueWith(x =>
            {
                // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");
                var screenshotPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp screenshot.png");

                //Console.WriteLine();
                //Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                Log3("-");
                Log3("Screenshot ready. Saving to {0}", screenshotPath);

                // Save the Bitmap to the path.
                // The image type is auto-detected via the ".png" extension.
                task.Result.Save(screenshotPath);

                // We no longer need the Bitmap.
                // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                task.Result.Dispose();

                Log3("Screenshot saved.  Launching your default image viewer...");

                // Tell Windows to launch the saved image.
                Process.Start(new ProcessStartInfo(screenshotPath)
                {
                    // UseShellExecute is false by default on .NET Core.
                    UseShellExecute = true
                });

                Log3("Image viewer launched.  Press any key to exit.");
            }, TaskScheduler.Default);
        }

        //sample download
        WebClient webClient;               // Our WebClient that will be doing the downloading for us
        Stopwatch sw = new Stopwatch();    // The stopwatch which we will be using to calculate the download speed
        bool IsDownloadDone_cover = false;
        Stopwatch sw_cover = new Stopwatch();

        

        public void DownloadFile_cover(string urlAddress, string location)
        {
            IsDownloadDone_cover = false;
            Log3("Downloading cover url = " + urlAddress);
            //if (!IsWindows10)
            //{
            //    Log("Not windows 10, try fix SecurityProtocolType");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Ssl3

                ; //(SecurityProtocolType)3072;// SecurityProtocolType.Ssl3;
            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; }); //TODO: IN W7 need this for webclient working, but this is dangerous cus can be attack by middle man





            ServicePointManager.ServerCertificateValidationCallback += delegate
                (
                    object Sender,
                    X509Certificate cert,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
            {

                Log3("cert hash = {0}", cert.GetCertHashString().ToLower());


                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }



                if (cert.GetCertHashString().ToLower() == "")
                {
                    return true;
                }

                return false;
            };






            //}


            using (webClient = new WebClient())
            {
                //if (!IsWindows10)
                //    webClient.Proxy = WebProxy.GetDefaultProxy();

                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed_cover);
                webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(ProgressChanged_cover);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw_cover.Start();

                try
                {

                    string dir = PathCombine(Path.GetDirectoryName(location), "download");
                    string filename = Path.GetFileName(location);
                    Directory.CreateDirectory(dir);

                    string DownloadLocation = PathCombine(dir, filename);
                    Log2("download cover = {0}", DownloadLocation);
                    


                    // Start downloading the file
                    //webClient.DownloadFileAsync(URL, location);
                    webClient.DownloadFileAsync(URL, DownloadLocation);
                }
                catch (Exception ex)
                {
                    //Log("exception "+ex.Message);
                    while (ex != null)
                    {
                        Log2(ex.Message);
                        ex = ex.InnerException;
                    }
                }
            }
        }

        public void DownloadFile(string urlAddress, string location)
        {
            IsDownloadDone = false;
            Log3("Downloading file url = "+ urlAddress);
            //if (!IsWindows10)
            //{
            //    Log("Not windows 10, try fix SecurityProtocolType");
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
                | SecurityProtocolType.Tls12
                | SecurityProtocolType.Tls11
                | SecurityProtocolType.Ssl3

                ; //(SecurityProtocolType)3072;// SecurityProtocolType.Ssl3;
            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; }); //TODO: IN W7 need this for webclient working, but this is dangerous cus can be attack by middle man





            ServicePointManager.ServerCertificateValidationCallback += delegate
                (
                    object Sender,
                    X509Certificate cert,
                    X509Chain chain,
                    SslPolicyErrors sslPolicyErrors
                )
            {

                Log3("cert hash = {0}", cert.GetCertHashString().ToLower());


                if (sslPolicyErrors == SslPolicyErrors.None)
                {
                    return true;
                }



                if (cert.GetCertHashString().ToLower() == "")
                {
                    return true;
                }

                return false;
            };






            //}


            using (webClient = new WebClient())
            {
                //if (!IsWindows10)
                //    webClient.Proxy = WebProxy.GetDefaultProxy();
                
                webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);

                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {

                    
                    

                    // Start downloading the file
                    webClient.DownloadFileAsync(URL, location);
                    
                }
                catch (Exception ex)
                {
                    //Log("exception "+ex.Message);
                    while (ex != null)
                    {
                        Log3(ex.Message);
                        ex = ex.InnerException;
                    }
                }
            }
        }

        // The event that will fire whenever the progress of the WebClient is changed
        private void ProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            //Log("ProgressChanged");
            // Calculate download speed and output it to labelSpeed.
            this.InvokeEx(f=> f.labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")) );

            // Update the progressbar percentage only when the value is not the same.
            this.InvokeEx(f => f.progressBar1.Value = e.ProgressPercentage);

            // Show the percentage on our label.
            this.InvokeEx(f => f.labelPerc.Text = e.ProgressPercentage.ToString() + "%");

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            this.InvokeEx(f => f.labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")));
        }

        private void ProgressChanged_cover(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            //Log("ProgressChanged");

            // Show the percentage on our label.
            this.InvokeEx(f => f.labelPerc_cover.Text = e.ProgressPercentage.ToString() + "%");

            
        }


        // The event that will trigger when the WebClient is completed
        private void Completed(object sender, AsyncCompletedEventArgs e)
        {
            IsDownloadDone = true;
            Log3("Completed, {0}",e.UserState);
            
            // Reset the stopwatch.
            sw.Reset();
            
            if (e.Cancelled == true)
            {
                Log3("Download has been canceled.");
            }
            else if (e.Error!=null)
            {
                Log3("Download error! "+ e.Error.Message);
            }
            else
            {
                //LoadImage2();
                Log3("Download completed!");
            }
            
        }

        private void Completed_cover(object sender, AsyncCompletedEventArgs e)
        {
            IsDownloadDone_cover = true;
            Log2("Cover Completed, {0}", e.UserState);
            
            // Reset the stopwatch.
            sw_cover.Reset();

            if (e.Cancelled == true)
            {
                Log2("Download has been canceled.");
            }
            else if (e.Error != null)
            {
                Log2("Download error! " + e.Error.Message);
            }
            else
            {
                //LoadImage2();              
                Log2("Download completed!");
            }

        }

        private void LoadImage2()
        {
            pictureBox1.Load("image2.jpg");
        }

        int iaddAsNewTask_Click = 0;
        private void btn_cart_addAsNewTask_Click(object sender, EventArgs e)
        {
            iaddAsNewTask_Click++;
            btn_cart_addAsNewTask.Text = "Add as New Task "+ iaddAsNewTask_Click.ToString();
            string chapterName = textBox_ChapterTitleName.Text.Trim();
            string chapterURL = textBox_ChapterURL.Text;
            string chapterSiteSource = textBox_ChapterSource.Text;
            string sItemsCount = string.Format("{0} item{1}",DGV_ChapterCartList.Rows.Count, DGV_ChapterCartList.Rows.Count>1?"s":"");
            string sDatetime = DateTime.Now.ToString("G");


            TreeView TV_Dst = TV_taskList;
            DataGridView DGV_Src = DGV_ChapterCartList;

            TreeNode NodeTask = new TreeNode();
            NodeTask.Text = string.Format("Task | {0} | {1} | {2} | {3} ", chapterName, chapterSiteSource, sItemsCount, sDatetime);

            //node chapters
            TreeNode NodeChapters = new TreeNode();
            NodeChapters.Text = "Chapters";
            

            foreach (DataGridViewRow Row in DGV_Src.Rows)
            {
                TreeNode NodeChapter = new TreeNode();
                NodeChapter.Text = Row.Cells[cintCol_ChapterName].Value.ToString();
                //=========================================2
                //add template image list
                TreeNode NodeImageList = new TreeNode();
                NodeImageList.Text = "Image List";

                //image first page url
                TreeNode NodeFirstPageUrl = new TreeNode();
                NodeFirstPageUrl.Text = "First Page URL";

                //=========================================1
                TreeNode NodeImageURL = new TreeNode();
                NodeImageURL.Text = "Image URL";
                NodeFirstPageUrl.Nodes.Add(NodeImageURL);

                TreeNode NodeImageExt = new TreeNode();
                NodeImageExt.Text = "Image Ext";
                NodeFirstPageUrl.Nodes.Add(NodeImageExt);

                TreeNode NodeImageSize = new TreeNode();
                NodeImageSize.Text = "Image Size";
                NodeFirstPageUrl.Nodes.Add(NodeImageSize);

                TreeNode NodeIDone = new TreeNode();
                NodeIDone.Text = "0";
                NodeFirstPageUrl.Nodes.Add(NodeIDone);
                //=========================================1

                //







                NodeImageList.Nodes.Add(NodeFirstPageUrl);

                NodeChapter.Nodes.Add(NodeImageList);


                TreeNode NodeTotalImage = new TreeNode();
                NodeTotalImage.Text = "Total Image";
                NodeChapter.Nodes.Add(NodeTotalImage);

                TreeNode NodeStatus = new TreeNode();
                NodeStatus.Text = "Status";
                NodeChapter.Nodes.Add(NodeStatus);

                TreeNode NodeStartDatetime = new TreeNode();
                NodeStartDatetime.Text = "Start Datetime";
                NodeChapter.Nodes.Add(NodeStartDatetime);

                //khusus mangadex
                //id
                string ChapterID = Row.Cells[cintCol_ChapterID].Value.ToString();
                TreeNode NodeChapterID = new TreeNode();
                NodeChapterID.Text = ChapterID;
                NodeChapter.Nodes.Add(NodeChapterID);

                //hash, per 10-01-2022 no longer used, and hash generated when later downloading the image in getting host server from api
                string ChapterHash = Row.Cells[cintCol_ChapterHash].Value!=null? Row.Cells[cintCol_ChapterHash].Value.ToString():"";
                TreeNode NodeChapterHash = new TreeNode();
                NodeChapterHash.Text = ChapterHash;
                NodeChapter.Nodes.Add(NodeChapterHash);

                //attribute volume number
                string AttVolume = Row.Cells[cintCol_ChapterAttVolume].Value!=null? Row.Cells[cintCol_ChapterAttVolume].Value.ToString():"none";
                TreeNode NodeAttVolume = new TreeNode();
                NodeAttVolume.Text = AttVolume;
                NodeChapter.Nodes.Add(NodeAttVolume);

                //attribute chapter number
                string AttChapter = Row.Cells[cintCol_ChapterAttChapter].Value!=null? Row.Cells[cintCol_ChapterAttChapter].Value.ToString():"none";
                TreeNode NodeAttChapter = new TreeNode();
                NodeAttChapter.Text = AttChapter;
                NodeChapter.Nodes.Add(NodeAttChapter);


                //host
                string ChapterImageHosh = Row.Cells[cintCol_ChapterImageHost].Value.ToString();
                TreeNode NodeChapterImageHosh = new TreeNode();
                NodeChapterImageHosh.Text = ChapterImageHosh;
                NodeChapter.Nodes.Add(NodeChapterImageHosh);

                //scan group
                string ChapterScanGroup = Row.Cells[cintCol_ChapterScanGroup].Value!=null? Row.Cells[cintCol_ChapterScanGroup].Value.ToString():"";
                TreeNode NodeChapterScanGroup = new TreeNode();
                NodeChapterScanGroup.Text = ChapterScanGroup;
                NodeChapter.Nodes.Add(NodeChapterScanGroup);

                //=========================================2

                NodeChapters.Nodes.Add(NodeChapter);
            }




            NodeTask.Nodes.Add(NodeChapters);


            //add chapter info
            //chapter name
            TreeNode NodeChapterName = new TreeNode();
            NodeChapterName.Text = chapterName;
            NodeTask.Nodes.Add(NodeChapterName);


            //chapter url
            TreeNode NodeChapterURL = new TreeNode();
            NodeChapterURL.Text = chapterURL;
            NodeTask.Nodes.Add(NodeChapterURL);


            //site source
            TreeNode NodeChapterSiteSource = new TreeNode();
            NodeChapterSiteSource.Text = chapterSiteSource;
            NodeTask.Nodes.Add(NodeChapterSiteSource);

            //added datetime
            TreeNode NodeChapterAddedDatetime = new TreeNode();
            NodeChapterAddedDatetime.Text = sDatetime;
            NodeTask.Nodes.Add(NodeChapterAddedDatetime);

            //retry count
            TreeNode NodeChapterRetryCount = new TreeNode();
            NodeChapterRetryCount.Text = "0";
            NodeTask.Nodes.Add(NodeChapterRetryCount);

            TV_Dst.Nodes.Add(NodeTask);

            //SAVE TASK LIST
            saveTVTaskList_Idle();

            //SAVE Chapter List
            string ChapterListFileJson = getChapterListFileJson(textBox_ChapterSource.Text, textBox_ChapterURL.Text);
            SaveChapterListToJsonFile(ChapterListFileJson);

        }


        private void cart_addAsNewTask()
        {

        }

        private void btn_title_saveKomikRootDir_Click(object sender, EventArgs e)
        {
            Log3("{0}", Environment.OSVersion);
            getIsWindows10();


            //save
            settingTitleSelection.KomikRootDir = textBox_title_rootDir.Text;
            saveSettingTitleSelection();
        }

        public bool IsWindows10 = false;
        private bool getIsWindows10()
        {
            //var reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");

            //string productName = (string)reg.GetValue("ProductName");
            string productName = "";
            Log3(productName);

            return productName.StartsWith("Windows 10");
        }

        private void btn_startDownloadQueue_Click(object sender, EventArgs e)
        {
            startThread_DownloadQueue();
        }

        private void btn_cartClear_Click(object sender, EventArgs e)
        {
            DGV_ChapterCartList.Rows.Clear();
        }

        private void btn_taskListToJson_Click(object sender, EventArgs e)
        {
            saveTVTaskList_Idle();
        }

        private void saveTVTaskList_Idle()
        {

            string TaskIdleFilePath = Path.Combine(MySetting.ExeDir, TaskList_Idle_BaseFileName);
            if (TV_taskList.Nodes.Count > 0)
            {
                ConvertTVTaskListToJsonData(TV_taskList, TaskList_Idle);

                Log3("TaskList_Idle, TaskName = {0}, ChapterName = {1}"
                    , TaskList_Idle.TaskList[0].TaskName
                    , TaskList_Idle.TaskList[0].Chapters[0].ChapterName);

                //test save to json

                string json = JsonConvert.SerializeObject(TaskList_Idle);

                File.WriteAllText(TaskIdleFilePath, json);
                Log3("done saving to " + TaskIdleFilePath);
            } else
            {
                //just delete old data, becaouse no data in current tv
                Log3("nothing to save in TV Idle, try delete old data if exist");
                if (File.Exists(TaskIdleFilePath))
                {
                    File.Delete(TaskIdleFilePath);
                    Log3("deleting file {0}", TaskIdleFilePath);
                }
            }

            
        }

        private void saveTVTaskList_Running()
        {
            string TaskRunningFilePath = Path.Combine(MySetting.ExeDir, TaskList_Running_BaseFileName);
            if (TV_taskRunning.Nodes.Count > 0)
            {
                ConvertTVTaskListToJsonData(TV_taskRunning, TaskList_Running);

                Log3("TaskList_Running, TaskName = {0}, ChapterName = {1}"
                    , TaskList_Running.TaskList[0].TaskName
                    , TaskList_Running.TaskList[0].Chapters[0].ChapterName);

                //test save to json

                string json = JsonConvert.SerializeObject(TaskList_Running);

                File.WriteAllText(TaskRunningFilePath, json);
                Log3("done saving to " + TaskRunningFilePath);
            }
            else
            {
                //just delete old data, becaouse no data in current tv
                Log3("nothing to save in TV Running, try delete old data if exist");
                if (File.Exists(TaskRunningFilePath))
                {
                    File.Delete(TaskRunningFilePath);
                    Log3("deleting file {0}", TaskRunningFilePath);
                }
            }

            //////////////////
            //ConvertTVTaskListToJsonData(TV_taskRunning, TaskList_Running);

            //Log("TaskList_Running, TaskName = {0}, ChapterName = {1}"
            //    , TaskList_Running.TaskList[0].TaskName
            //    , TaskList_Running.TaskList[0].Chapters[0].ChapterName);

            ////test save to json

            //string json = JsonConvert.SerializeObject(TaskList_Running);

            //File.WriteAllText(TaskList_Running_BaseFileName, json);
            //Log("done saving to "+ TaskList_Running_BaseFileName);
        }

        private void saveTaskListData_Running(TaskListData TLD)
        {
            string TaskRunningFilePath = Path.Combine(MySetting.ExeDir, TaskList_Running_BaseFileName);
            if (TLD !=null && TLD.TaskList!=null && TLD.TaskList.Count > 0)
            {       

                Log3("TLD Running, TaskName = {0}, ChapterName = {1}"
                    , TLD.TaskList[0].TaskName
                    , TLD.TaskList[0].Chapters[0].ChapterName);

                //test save to json

                string json = JsonConvert.SerializeObject(TLD);

                File.WriteAllText(TaskRunningFilePath, json);
                Log3("done saving to " + TaskRunningFilePath);
            }
            else
            {
                //just delete old data, becaouse no data in current tv
                Log3("nothing to save in TLD Running, try delete old data if exist");
                if (File.Exists(TaskRunningFilePath))
                {
                    File.Delete(TaskRunningFilePath);
                    Log3("deleting file {0}", TaskRunningFilePath);
                }
            }

            //////////////////
            //ConvertTVTaskListToJsonData(TV_taskRunning, TaskList_Running);

            //Log("TaskList_Running, TaskName = {0}, ChapterName = {1}"
            //    , TaskList_Running.TaskList[0].TaskName
            //    , TaskList_Running.TaskList[0].Chapters[0].ChapterName);

            ////test save to json

            //string json = JsonConvert.SerializeObject(TaskList_Running);

            //File.WriteAllText(TaskList_Running_BaseFileName, json);
            //Log("done saving to "+ TaskList_Running_BaseFileName);
        }

        string TaskDoneDir = "init set, need load set";

        private void saveTVTaskList_Running_as_Done(TaskListData TaskList_Done = null)
        {
            if (TaskList_Done == null)
            {
                ConvertTVTaskListToJsonData(TV_taskRunning, TaskList_Done);
            }
            

            Log3("TaskList_Done, TaskName = {0}, ChapterName = {1}"
                , TaskList_Done.TaskList[0].TaskName
                , TaskList_Done.TaskList[0].Chapters[0].ChapterName);

            //test save to json

            string json = JsonConvert.SerializeObject(TaskList_Done);
            //string TaskDoneDir = getDir(Path.Combine(MySetting.ExeDir, "TaskDone"));
            //string TaskDoneFilePath = Path.Combine(TaskDoneDir, TaskList_Done_BaseFileName);
            string TaskDoneFilePath = Path.Combine(TaskDoneDir, GetSafeFilename(TaskList_Done.TaskList[0].TaskName)+".json");
            File.WriteAllText(TaskDoneFilePath, json);
            Log3("done saving to "+ TaskDoneFilePath);
        }


        //IList<TaskDownloadData> TaskList_Running = new List<TaskDownloadData>();
        TaskListData TaskList_Idle = new TaskListData();
        TaskListData TaskList_Running = new TaskListData();
        TaskListData TaskList_Done = new TaskListData();
        string TaskList_Idle_BaseFileName = ""; //setup in form load
        string TaskList_Running_BaseFileName = ""; //setup in form load
        string TaskList_Done_BaseFileName = ""; //setup in form load

        private void ConvertTVTaskListToJsonData(TreeView TV, TaskListData TLD)
        {
            IList<TaskDownloadData> TaskList = new List<TaskDownloadData>();
            foreach (TreeNode NodeTasks in TV.Nodes)
            {
                
                TreeNode NodeChapters = NodeTasks.Nodes[0];
                TreeNode NodeTitleName = NodeTasks.Nodes[1];
                TreeNode NodeChapterListPageURL = NodeTasks.Nodes[2];
                TreeNode NodeSiteSource = NodeTasks.Nodes[3];
                TreeNode NodeDateTimeAdded = NodeTasks.Nodes[4];
                TreeNode NodeRetryCount = NodeTasks.Nodes[5];


                //chapter
                IList<ChapterData> Chapters = new List<ChapterData>();
                foreach (TreeNode NodeChapter in NodeChapters.Nodes)
                {

                    TreeNode NodeImages = NodeChapter.Nodes[0];
                    TreeNode NodeTotalImage = NodeChapter.Nodes[1];
                    TreeNode NodeStatus = NodeChapter.Nodes[2];
                    TreeNode NodeStartDate = NodeChapter.Nodes[3];
                    TreeNode NodeChapterID = NodeChapter.Nodes[4];
                    TreeNode NodeChapterHash = NodeChapter.Nodes[5];
                    TreeNode NodeAttVolume = NodeChapter.Nodes[6];
                    TreeNode NodeAttChapter = NodeChapter.Nodes[7];
                    TreeNode NodeImageHost = NodeChapter.Nodes[8];


                    IList<ImageData> Images = new List<ImageData>();
                    foreach (TreeNode NodeImagePageURL in NodeImages.Nodes)
                    {
                        TreeNode NodeImageURL = NodeImagePageURL.Nodes[0];
                        TreeNode NodeImageExt = NodeImagePageURL.Nodes[1];
                        TreeNode NodeImageSize = NodeImagePageURL.Nodes[2];
                        TreeNode NodeIDone = NodeImagePageURL.Nodes[3];

                        ImageData ImgData = new ImageData();
                        ImgData.ImagePageURL = NodeImagePageURL.Text;
                        ImgData.ImageURL = NodeImageURL.Text;
                        ImgData.ImageExt = NodeImageExt.Text;
                        ImgData.ImageSize = NodeImageSize.Text;// getConvertStringToInt64(NodeImageSize.Text);
                        ImgData.IDone = getConvertStringToInt32( NodeIDone.Text );

                        Images.Add(ImgData);

                    }



                    ChapterData CD = new ChapterData();
                    CD.ChapterName = NodeChapter.Text;
                    CD.images = Images;
                    CD.TotalImage = NodeTotalImage.Text;// getConvertStringToInt32(NodeTotalImage.Text);
                    CD.status = NodeStatus.Text;
                    CD.startDate = NodeStartDate.Text;
                    CD.ChapterID = NodeChapterID.Text;
                    CD.ChapterHash = NodeChapterHash.Text;
                    CD.AttVolume= NodeAttVolume.Text;
                    CD.AttChapter= NodeAttChapter.Text;

                    CD.ImageHost = NodeImageHost.Text;

                    Chapters.Add(CD);
                }

                TaskDownloadData TaskD = new TaskDownloadData();
                TaskD.TaskName = NodeTasks.Text;
                TaskD.Chapters = Chapters;
                TaskD.TitleName = NodeTitleName.Text;
                TaskD.ChapterListPageUrl = NodeChapterListPageURL.Text;
                TaskD.SiteSource = NodeSiteSource.Text;
                TaskD.DatetimeAdded = NodeDateTimeAdded.Text;
                TaskD.RetryCount = NodeRetryCount.Text;// getConvertStringToInt32(NodeRetryCount.Text);

                TaskList.Add(TaskD);
            }

            TLD.TaskList = TaskList;


        }

        private void loadJsonFileTaskListDataToTVTaskList(string jsonFilePath, TreeView TV)
        {

            if (!File.Exists(jsonFilePath)) { Log3("File not exist {0}", jsonFilePath); return; }

            string json = File.ReadAllText(jsonFilePath);

            TaskListData TLD = JsonConvert.DeserializeObject<TaskListData>(json);
            ConvertJsonDataToTVTaskList(TLD, TV);
        }

        private void ConvertJsonDataToTVTaskList(TaskListData TLD,TreeView TV)
        {            
            
            foreach(TaskDownloadData TDD in TLD.TaskList)
            {
                //TDD.TaskName
                string TitleName = TDD.TitleName;// textBox_ChapterTitleName.Text;
                string ChapterListPageUrl = TDD.ChapterListPageUrl ;// textBox_ChapterURL.Text;
                string chapterSiteSource = TDD.SiteSource;// textBox_ChapterSource.Text;
                //string sItemsCount = string.Format("{0} item{1}", DGV_ChapterCartList.Rows.Count, DGV_ChapterCartList.Rows.Count > 1 ? "s" : ""); ;
                string sDatetime = TDD.DatetimeAdded;// DateTime.Now.ToString("G");
                string sRetryCount = TDD.RetryCount.ToString();// "0";


                TreeView TV_Dst = TV;// TV_taskList;
                //DataGridView DGV_Src = DGV_ChapterCartList;

                //node task name
                TreeNode NodeTask = new TreeNode();
                NodeTask.Text = TDD.TaskName; // string.Format("Task | {0} | {1} | {2} | {3} ", chapterName, chapterSiteSource, sItemsCount, sDatetime);

                //node chapters
                TreeNode NodeChapters = new TreeNode();
                NodeChapters.Text = "Chapters";

                //get chapters child
                foreach (ChapterData CD in TDD.Chapters)
                {
                    TreeNode NodeChapter = new TreeNode();
                    NodeChapter.Text = CD.ChapterName;
                    //=========================================2
                    //add template image list
                    TreeNode NodeImageList = new TreeNode();
                    NodeImageList.Text = "Image List";
                    //TODO: still not done ConvertJsonDataToTVTaskList


                    
                    foreach (ImageData ImgD in CD.images)
                    {
                        //image first page url
                        TreeNode NodeFirstPageUrl = new TreeNode();
                        NodeFirstPageUrl.Text = ImgD.ImagePageURL;// "First Page URL";

                        //=========================================1
                        TreeNode NodeImageURL = new TreeNode();
                        NodeImageURL.Text = ImgD.ImageURL;// "Image URL";
                        NodeFirstPageUrl.Nodes.Add(NodeImageURL);

                        TreeNode NodeImageExt = new TreeNode();
                        NodeImageExt.Text = ImgD.ImageExt;//"Image Ext";
                        NodeFirstPageUrl.Nodes.Add(NodeImageExt);

                        TreeNode NodeImageSize = new TreeNode();
                        NodeImageSize.Text = ImgD.ImageSize.ToString();//"Image Size";
                        NodeFirstPageUrl.Nodes.Add(NodeImageSize);

                        TreeNode NodeIDone = new TreeNode();
                        NodeIDone.Text = ImgD.IDone.ToString();//"int is done, 0/1";
                        NodeFirstPageUrl.Nodes.Add(NodeIDone);

                        NodeImageList.Nodes.Add(NodeFirstPageUrl);
                        //=========================================1

                        //
                    }



                    //NodeImageList.Nodes.Add(NodeFirstPageUrl);

                    NodeChapter.Nodes.Add(NodeImageList);


                    TreeNode NodeTotalImage = new TreeNode();
                    NodeTotalImage.Text = CD.TotalImage.ToString();// "Total Image";
                    NodeChapter.Nodes.Add(NodeTotalImage);

                    TreeNode NodeStatus = new TreeNode();
                    NodeStatus.Text = CD.status;// "Status";
                    NodeChapter.Nodes.Add(NodeStatus);

                    TreeNode NodeStartDatetime = new TreeNode();
                    NodeStartDatetime.Text = CD.startDate;// "Start Datetime";
                    NodeChapter.Nodes.Add(NodeStartDatetime);

                    //khusus mangadex
                    //id
                    string ChapterID = CD.ChapterID;// Row.Cells[cintCol_ChapterID].Value.ToString();
                    TreeNode NodeChapterID = new TreeNode();
                    NodeChapterID.Text = ChapterID;
                    NodeChapter.Nodes.Add(NodeChapterID);

                    //hash
                    string ChapterHash = CD.ChapterHash;// Row.Cells[cintCol_ChapterHash].Value.ToString();
                    TreeNode NodeChapterHash = new TreeNode();
                    NodeChapterHash.Text = ChapterHash;
                    NodeChapter.Nodes.Add(NodeChapterHash);

                    //att volume
                    string AttVolume = CD.AttVolume;
                    TreeNode NodeAttVolume = new TreeNode();
                    NodeAttVolume.Text = AttVolume;
                    NodeChapter.Nodes.Add(NodeAttVolume);

                    //att chapter
                    string AttChapter = CD.AttChapter;
                    TreeNode NodeAttChapter = new TreeNode();
                    NodeAttChapter.Text = AttChapter;
                    NodeChapter.Nodes.Add(NodeAttChapter);

                    //host
                    string ChapterImageHosh = CD.ImageHost;// Row.Cells[cintCol_ChapterImageHost].Value.ToString();
                    TreeNode NodeChapterImageHosh = new TreeNode();
                    NodeChapterImageHosh.Text = ChapterImageHosh;
                    NodeChapter.Nodes.Add(NodeChapterImageHosh);

                    //=========================================2

                    NodeChapters.Nodes.Add(NodeChapter);
                }




                NodeTask.Nodes.Add(NodeChapters);


                //add chapter info
                //chapter name
                TreeNode NodeChapterName = new TreeNode();
                NodeChapterName.Text = TitleName;
                NodeTask.Nodes.Add(NodeChapterName);


                //chapter list page url
                TreeNode NodeChapterURL = new TreeNode();
                NodeChapterURL.Text = ChapterListPageUrl;
                NodeTask.Nodes.Add(NodeChapterURL);


                //site source
                TreeNode NodeChapterSiteSource = new TreeNode();
                NodeChapterSiteSource.Text = chapterSiteSource;
                NodeTask.Nodes.Add(NodeChapterSiteSource);

                //added datetime
                TreeNode NodeChapterAddedDatetime = new TreeNode();
                NodeChapterAddedDatetime.Text = sDatetime;
                NodeTask.Nodes.Add(NodeChapterAddedDatetime);

                //retry count
                TreeNode NodeChapterRetryCount = new TreeNode();
                NodeChapterRetryCount.Text = sRetryCount;
                NodeTask.Nodes.Add(NodeChapterRetryCount);

                TV_Dst.Nodes.Add(NodeTask);
            }

            //========================
            
        }

        private long getConvertStringToInt64(string value)
        {
            long result = 0;
            if (value == "" | value == null)
            {
                //do nothing
                Log3("Fail to convert string to int64, value is null or blank, return 0");
            } 
            else if (value.Length > 0)
            {
                try
                {
                    result = Convert.ToInt64(value);
                }
                catch 
                {
                    Log3("Fail to convert string to int64, value = {0}, return 0", value);
                    result = 0;
                
                }
                
                    
            }

            return result;
        }

        private int getConvertStringToInt32(string value)
        {
            int result = 0;
            if (value == "" | value == null)
            {
                //do nothing
                Log3("Fail to convert string to int64, value is null or blank, return 0");
            }
            else if (value.Length > 0)
            {
                try
                {
                    result = Convert.ToInt32(value);
                }
                catch
                {
                    Log3("Fail to convert string to int64, value = {0}, return 0", value);
                    result = 0;

                }


            }

            return result;
        }

        private string getJsonStringFromJsonData()
        {
            return "";
        }

        private void btn_loadTaskListFromJson_Click(object sender, EventArgs e)
        {
            string json = File.ReadAllText(TaskList_Idle_BaseFileName);
            TaskListData TLD = JsonConvert.DeserializeObject<TaskListData>(json);
            Log3("TLD, TaskName = {0}, ChapterName = {1}"
                , TLD.TaskList[0].TaskName
                , TLD.TaskList[0].Chapters[0].ChapterName);
            ConvertJsonDataToTVTaskList(TLD, TV_taskList);
        }

        private void btn_takeScreenShot_Click(object sender, EventArgs e)
        {
            CWB_Helper CWBHelper = new CWB_Helper();
            CWBHelper.takeScreenShot(CWB);
        }

        private void btn_moveRunningToIdle_Click(object sender, EventArgs e)
        {
            MoveTV_TaskRunningToTaskList();
            saveTVTaskList_Idle();
            saveTVTaskList_Running();
        }

        private void btn_delSelectedTaskIdle_Click(object sender, EventArgs e)
        {
            if(TV_taskList.SelectedNode!=null && TV_taskList.SelectedNode.Level == 0)
            {
                TV_taskList.Nodes.Remove(TV_taskList.SelectedNode);
            }
        }

        string ReadListJsonFilePath = "init set, need load set";
        string OnHoldListJsonFilePath = "init set, need load set";
        string CompletedListJsonFilePath = "init set, need load set";
        string DropListJsonFilePath = "init set, need load set";

        private void btn_LoadTitleList_Click(object sender, EventArgs e)
        {

            LoadTitleListByTitleListIndex(ActiveTitleListIndex);
                      
        }

        private void LoadAllTitleList()
        {
            for (int i = 0; i < ActiveTitleListInfos.Count; i++)
            {
                LoadTitleListByTitleListIndex(i);
            }
        }

        int intTitleList_Read;
        int intTitleList_OnHold;
        int intTitleList_Completed;
        int intTitleList_Drop;

        private void LoadTitleListByTitleListIndex(int intTitleList)
        {
            TreeView TV = ActiveTitleListInfos[intTitleList].ActiveTV;
            string JsonFilePath = ActiveTitleListInfos[intTitleList].DataPath;
            LoadTitleList(TV, JsonFilePath);

            /*
            TV.Nodes.Clear();

            Log1("Load Read List");
            string strBaseFileName = ReadListJsonFilePath;// "ReadList.json";
            string ReadListFilePath = Path.Combine(MySetting.ExeDir, strBaseFileName);
            if (File.Exists(ReadListFilePath))
            {
                string json = File.ReadAllText(ReadListFilePath);
                TitleListData TitleLD = JsonConvert.DeserializeObject<TitleListData>(json);
                Log3("TitleLD, SiteSourceName = {0}, TitleName = {1}"
                    , TitleLD.Titles[0].SiteSources[0].SiteSourceName
                    , TitleLD.Titles[0].TitleName);
                loadTitleListDataToTV(TitleLD, TV);
            }
            */
        }

        

        private void LoadTitleList(TreeView TV, string JsonFilePath)
        {
            if (CheckStarOnTVParentIsTabPage(TV))
            {
                var dr = MessageBox.Show("Load unsaved TV " + TV.Name,"Confirmation", MessageBoxButtons.YesNo);
                if (dr == DialogResult.No) { return; }
            }
            

            TV.Nodes.Clear();

            Log1("Load Read List");
            string strBaseFileName = JsonFilePath;// "ReadList.json";
            string ReadListFilePath = Path.Combine(MySetting.ExeDir, strBaseFileName);
            if (File.Exists(ReadListFilePath))
            {
                string json = File.ReadAllText(ReadListFilePath);
                TitleListData TitleLD = JsonConvert.DeserializeObject<TitleListData>(json);

                if (TitleLD.Titles.Count() == 0) { return; }
                Log3("TitleLD, SiteSourceName = {0}, TitleName = {1}"
                    , TitleLD.Titles[0].SiteSources[0].SiteSourceName
                    , TitleLD.Titles[0].TitleName);
                loadTitleListDataToTV(TitleLD, TV);
            }
        }

        private void saveTitleListDataToJsonFile(TitleListData TitleLD, string JsonFilePath)
        {
            //TitleListData TitleLD = new TitleListData();
            //ConvertTVTitleListToTitleListData();
            //foreach (TitleData _T in )
            //{

            //}
        }

        private void saveTVTitleSelectionToJsonFile(TreeView TV, string JsonFilePath)
        {
            TitleListData TitleD = new TitleListData();
            ConvertTVTitleListToTitleListData(TV, TitleD);
            string json = JsonConvert.SerializeObject(TitleD);
            File.WriteAllText(JsonFilePath, json);
            Log3("Save json to {0}", JsonFilePath);

            UpdateUI_RemoveStarOnTVParentIsTabPage(TV);
        }

        private void UpdateUI_RemoveStarOnTVParentIsTabPage(TreeView TV)
        {
            if (TV.Parent is TabPage)
            {
                TabPage TP = (TV.Parent as TabPage);
                TP.Text = TP.Text.Replace("*", "");
            }
        }

        private void UpdateUI_AddStarOnTVParentIsTabPage(TreeView TV)
        {
            if (TV.Parent is TabPage)
            {
                TabPage TP = (TV.Parent as TabPage);
                TP.Text = "*" + TP.Text.Replace("*", "");
            }
        }

        private bool CheckStarOnTVParentIsTabPage(TreeView TV)
        {
            if (TV.Parent is TabPage)
            {
                TabPage TP = (TV.Parent as TabPage);
                return TP.Text.Contains("*");

            }
            return false;
        }

        private void ConvertTVTitleListToTitleListData(TreeView TV, TitleListData TitleLD)
        {
            //loop title
            TitleLD.Titles = new List<TitleData>();
            foreach (TreeNode Node0 in TV.Nodes)
            {
                TitleData Title = new TitleData();
                Title.TitleName = Node0.Text;

                //loop sitesources
                Title.SiteSources = new List<SiteSourceData>();
                foreach (TreeNode node1 in Node0.Nodes)
                {
                    SiteSourceData SiteSource = new SiteSourceData();


                    SiteSource.SiteSourceName = node1.Text;

                    SiteSource.ChpaterListPageURL = node1.Nodes[0].Text;
                    if (node1.Nodes.Count > 1)
                    {
                        SiteSource.TitleAliases = new List<string>();
                        for (int i = 1;i< node1.Nodes.Count;i++) //start from 1 because the first is chapter list page url
                        {
                            string alias = node1.Nodes[i].Text;
                             SiteSource.TitleAliases.Add(alias);
                        }
                        
                    }

                    Title.SiteSources.Add(SiteSource);


                }




                TitleLD.Titles.Add(Title);
            }
        }

        private void loadTitleListDataToTV(TitleListData TitleLD, TreeView TV)
        {
             foreach(TitleData _T in TitleLD.Titles)
            {
                TreeNode NodeTitle = new TreeNode();
                NodeTitle.Text = _T.TitleName;

                foreach(SiteSourceData _ss in _T.SiteSources)
                {
                    TreeNode NodeSiteSource = new TreeNode();
                    NodeSiteSource.Text = _ss.SiteSourceName;



                    //chapterlist page url
                    TreeNode NodeChapterListPAgeURL= new TreeNode();
                    NodeChapterListPAgeURL.Text = _ss.ChpaterListPageURL;
                    NodeSiteSource.Nodes.Add(NodeChapterListPAgeURL);

                    if (_ss.TitleAliases != null)
                    {
                        foreach (string alias in _ss.TitleAliases)
                        {
                            TreeNode NodeAlias = new TreeNode();
                            NodeAlias.Text = alias;
                            NodeSiteSource.Nodes.Add(NodeAlias);
                        }
                       
                    }
                    NodeTitle.Nodes.Add(NodeSiteSource);
                }

                TV.Nodes.Add(NodeTitle);

            }
        }

        private void btn_SaveReadList_Click(object sender, EventArgs e)
        {
            SaveTitleListByTitleListIndex(ActiveTitleListIndex);
        }

        private void SaveTitleListByTitleListIndex(int intTitleList)
        {
            TreeView TV = ActiveTitleListInfos[intTitleList].ActiveTV;
            string JsonFilePath = ActiveTitleListInfos[intTitleList].DataPath;
            saveTVTitleSelectionToJsonFile(TV, JsonFilePath);
        }


        private void btn_deleteSelectedReadList_Click(object sender, EventArgs e)
        {
            deleteSelectedLevel0TV(TV_ReadList);
        }

        private void deleteSelectedLevel0TV(TreeView TV)
        {
            if (TV.SelectedNode != null && TV.SelectedNode.Level == 0)
            {
                TV.Nodes.Remove(TV.SelectedNode);
                UpdateUI_AddStarOnTVParentIsTabPage(TV);
            }

            
        }

        int btn_addAsReadList_State = 0; //0 baru, 1 edit;
        int indexEdit = 0;
        private void btn_addAsReadList_Click(object sender, EventArgs e)
        {
            TreeView TV = TV_ReadList;
            if (btn_addAsReadList_State == 0)
            {
                //new
                //check kembar
                string title = textBox_addReadList_TitleName.Text.Trim();
                foreach (TreeNode n in TV.Nodes)
                {
                    string titleNode = n.Text;
                    if (title == titleNode)
                    {
                        TV.SelectedNode = n;
                        Log1("Title already exists!");
                        MessageBox.Show("Title already exists!");
                        return;
                    }
                }


                TreeNode NodeTitle = new TreeNode();
                NodeTitle.Text = textBox_addReadList_TitleName.Text.Trim();
                TV.Nodes.Add(NodeTitle);

                TreeNode NodeSiteSourceName = new TreeNode();
                NodeSiteSourceName.Text = textBox_addReadList_SiteSource.Text.Trim();
                NodeTitle.Nodes.Add(NodeSiteSourceName);

                TreeNode NodeChapterListPageURL = new TreeNode();
                NodeChapterListPageURL.Text = textBox_addReadList_ChapterListPageURL.Text.Trim();
                NodeSiteSourceName.Nodes.Add(NodeChapterListPageURL);

                foreach (string alias in textBox_addReadList_Alias.Lines)
                {
                    TreeNode NodeAlias = new TreeNode();
                    NodeAlias.Text = alias.Trim();
                    NodeSiteSourceName.Nodes.Add(NodeAlias);
                }
            }
            else
            {
                //edit
                TreeNode NodeTitle = TV.Nodes[indexEdit];
                NodeTitle.Text = textBox_addReadList_TitleName.Text;

                


            }



            //btn_SaveTitleList.PerformClick();
            SaveTitleListByTitleListIndex(intTitleList_Read);

        }

        private void textBox_addReadList_ChapterListPageURL_TextChanged(object sender, EventArgs e)
        {
            textBox_addReadList_SiteSource.Text = getSiteSourceFromURL(((TextBox)sender).Text);
        }

        private IList<string> List_SiteSource = new List<string> { "Mangadex", "Taadd" };

        private string getSiteSourceFromURL(string URL)
        {
            string siteSource = "";
            if (URL.ToLower().Contains("mangadex"))
            {
                siteSource = "Mangadex";
            }
            else if (URL.ToLower().Contains(".taadd"))
            {
                siteSource = "Taadd";
            }
            else
            {
                siteSource = "Unknown";
            }

            return siteSource;

        }

        private void btn_clearNewTitleListInputDialog_Click(object sender, EventArgs e)
        {
            textBox_addReadList_TitleName.Text = "";
            textBox_addReadList_ChapterListPageURL.Text = "";
            textBox_addReadList_SiteSource.Text = "";
            textBox_addReadList_Alias.Text = "";
        }

        private void btn_testJsonWebClient_Click(object sender, EventArgs e)
        {


            string url = textBox2.Text;

            DownloadFile(url, @"testJsonWebClient.json");



            return;

            //ServicePointManager.ServerCertificateValidationCallback = delegate
            // { return true; };

            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12
                //SecurityProtocolType.Ssl3
                //| SecurityProtocolType.Tls
                //| SecurityProtocolType.Tls11
                //| SecurityProtocolType.Tls12
                //| SecurityProtocolType.SystemDefault
                ;


            ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; }); //TODO: IN W7 need this for webclient working, but this is dangerous cus can be attack by middle man

            //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate
            //(
            //        object Sender,
            //        X509Certificate cert,
            //        X509Chain chain,
            //        SslPolicyErrors sslPolicyErrors
            //    )
            //{

            //    Log("cert hash = {0}", cert.GetCertHashString().ToLower());


            //    if (sslPolicyErrors == SslPolicyErrors.None)
            //    {
            //        return true;
            //    }



            //    if (cert.GetCertHashString().ToLower() == "")
            //    {
            //        return true;
            //    }

            //    return false;

            //}); 


            //
            //ServicePointManager.ServerCertificateValidationCallback += delegate
            //    (
            //        object Sender,
            //        X509Certificate cert,
            //        X509Chain chain,
            //        SslPolicyErrors sslPolicyErrors
            //    )
            //{

            //    Log("cert hash = {0}", cert.GetCertHashString().ToLower());


            //    if (sslPolicyErrors == SslPolicyErrors.None)
            //    {
            //        return true;
            //    }



            //    if (cert.GetCertHashString().ToLower() == "")
            //    {
            //        return true;
            //    }

            //    return false;
            //};

            using (WebClient webClient = new WebClient())
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text=   "https://api.mangadex.org/at-home/server/dc5bec25-5349-48bb-929d-0eda96eca3de?forcePort443=false";
                }
                
                string urlAddress = textBox2.Text;
                string location = "testJsonWebClient.json";
                //not async
                //webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DL_Completed);


                //async
                //webClientT.DownloadFileCompleted += new AsyncCompletedEventHandler(DL_AsyncCompleted);



                //webClientT.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DL_ProgressChanged);

                webClient.DownloadStringCompleted += new DownloadStringCompletedEventHandler(Completed);
                webClient.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(ProgressChanged);



                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);
                Log3("json web client, URL = " + URL);
                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    //webClient.DownloadFile(URL, location);
                    var json = webClient.DownloadString(URL);
                    Log3("json = {0}", json);

                    //webClient.DownloadStringAsync(URL);
                    

                }
                catch (Exception ex)
                {
                    Log3("exception " + ex.Message);
                }
            }
        }


        
        private void TV_taskList_MouseHover(object sender, EventArgs e)
        {
            
            
        }




        private void TV_taskList_NodeMouseHover(object sender, TreeNodeMouseHoverEventArgs e)
        {

        }

        private void TV_taskList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {

        }

        private void TV_taskList_MouseDown(object sender, MouseEventArgs e)
        {

        }


        bool IsStartSaveTV = false;
        private void TV_taskList_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        //=================================================TreeView DragDrop
        private void setupTreeViewDragDrop(TreeView TV)
        {
            TV.AllowDrop = true;

            // Add event handlers for the required drag events.
            TV.ItemDrag += new ItemDragEventHandler(TV_ItemDrag);
            TV.DragEnter += new DragEventHandler(TV_DragEnter);
            TV.DragOver += new DragEventHandler(TV_DragOver);
            TV.DragDrop += new DragEventHandler(TV_DragDrop);

        }

        private void TV_ItemDrag(object sender, ItemDragEventArgs e)
        {
            // Move the dragged node when the left mouse button is used.
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(e.Item, DragDropEffects.Move);
            }

            // Copy the dragged node when the right mouse button is used.
            else if (e.Button == MouseButtons.Right)
            {
               // DoDragDrop(e.Item, DragDropEffects.Copy);
            }
        }

        // Set the target drop effect to the effect 
        // specified in the ItemDrag event handler.
        private void TV_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = e.AllowedEffect;
        }

        // Select the node under the mouse pointer to indicate the 
        // expected drop location.
        private void TV_DragOver(object sender, DragEventArgs e)
        {
            //Log("sender.GetType() = {0}", sender.GetType());
            if (sender.GetType() != typeof(TreeView)) { Log3("Invalid sender Type"); return; }

            TreeView TV = sender as TreeView;
            // Retrieve the client coordinates of the mouse position.
            Point targetPoint = TV.PointToClient(new Point(e.X, e.Y));

            // Select the node at the mouse position.
            TV.SelectedNode = TV.GetNodeAt(targetPoint);
        }

        private void TV_DragDrop(object sender, DragEventArgs e)
        {
            if (sender.GetType() != typeof(TreeView)) { Log3("Invalid sender Type"); return; }
            TreeView TV = sender as TreeView;
            // Retrieve the client coordinates of the drop location.
            Point targetPoint = TV.PointToClient(new Point(e.X, e.Y));

            // Retrieve the node at the drop location.
            TreeNode targetNode = TV.GetNodeAt(targetPoint);

            // Retrieve the node that was dragged.
            TreeNode draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            // Confirm that the node at the drop location is not 
            // the dragged node or a descendant of the dragged node.
            //if (!draggedNode.Equals(targetNode) && !ContainsNode(draggedNode, targetNode))
            if (!draggedNode.Equals(targetNode) && draggedNode.Level==0 && targetNode.Level == 0)
            {
                // If it is a move operation, remove the node from its current 
                // location and add it to the node at the drop location.
                if (e.Effect == DragDropEffects.Move)
                {
                    //Log("DragDropEffects.Move");
                    draggedNode.Remove();
                    //targetNode.Nodes.Add(draggedNode);
                    //targetNode.
                    if (targetNode.Index<draggedNode.Index)
                    {
                        TV.Nodes.Insert(targetNode.Index, draggedNode);
                    }
                    else
                    {
                        if (targetNode.NextNode != null)
                        {
                            TV.Nodes.Insert(targetNode.NextNode.Index, draggedNode);
                        } else 
                        {
                            TV.Nodes.Add(draggedNode);

                        }
                        
                    }

                    Log3("DragDropEffects.Move");
                    //optional save after move

                    IsStartSaveTV = true;
                    TV.SelectedNode = draggedNode;
                    
                }

                // If it is a copy operation, clone the dragged node 
                // and add it to the node at the drop location.
                else if (e.Effect == DragDropEffects.Copy)
                {
                    Log3("DragDropEffects.Copy");
                    //targetNode.Nodes.Add((TreeNode)draggedNode.Clone());
                }

                // Expand the node at the location 
                // to show the dropped node.
                //targetNode.Expand();
            }
        }

        // Determine whether one node is a parent 
        // or ancestor of a second node.
        private bool ContainsNode(TreeNode node1, TreeNode node2)
        {
            // Check the parent node of the second node.
            if (node2.Parent == null) return false;
            if (node2.Parent.Equals(node1)) return true;

            // If the parent node is not null or equal to the first node, 
            // call the ContainsNode method recursively using the parent of 
            // the second node.
            return ContainsNode(node1, node2.Parent);
        }

        private void TV_taskList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (IsStartSaveTV)
            {
                Log3("mouse up, save TV idle");
                IsStartSaveTV = false;
                saveTVTaskList_Idle();
            }

        }

        int intSelectRowIndexStart = -1;
        int intSelectRowIndexEnd = -1;

        private void bulkAddStartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //    Int32 selectedCellCount =
            //dataGridView1.GetCellCount(DataGridViewElementStates.Selected);

            //dataGridView1.CurrentRow.Selected = true;
            //intSelectRowIndexStart = DGV_ChapterList.CurrentCell.RowIndex;
            SetSelectRowIndexStart();
        }

        private void SetSelectRowIndexStart(int iRow=-1)
        {
            if (iRow == -1)
            {
                intSelectRowIndexStart = DGV_ChapterList.CurrentCell.RowIndex;
            }
            else
            {
                intSelectRowIndexStart = iRow;
            }
            
        }

        private void SetSelectRowIndexEnd(int iRow = -1)
        {
            if (iRow == -1)
            {
                intSelectRowIndexEnd = DGV_ChapterList.CurrentCell.RowIndex;
            }
            else
            {
                intSelectRowIndexEnd = iRow;
            }
            
            int iCol = DGV_ChapterList.CurrentCell.ColumnIndex;

            int iStart = Math.Min(intSelectRowIndexStart, intSelectRowIndexEnd);
            int iEnd = Math.Max(intSelectRowIndexStart, intSelectRowIndexEnd);

            bool IsStartSelect = false;
            foreach (DataGridViewRow r in DGV_ChapterList.Rows)
            {
                if (r.Index == iStart && !IsStartSelect) { IsStartSelect = true; }

                if (IsStartSelect)
                {
                    r.Cells[iCol].Selected = true;

                    if (r.Index == iEnd)
                    {
                        break;
                    }
                }
            }
        }

        private void bulkAddEndToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //dataGridView1.CurrentRow.Selected = true;
            SetSelectRowIndexEnd();
        }

        private void btn_stopDownloadQueue_Click(object sender, EventArgs e)
        {
            IsStopDownloadSignal = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (CWB_DL != null)
            {
                Log3(CWB_DL.GetTextAsync().Result);
                Log3("IsDoneLoad_DL = {0}", IsDoneLoad_DL);
            }
            
        }

        int ReadListSeachIndex = 0;
        private void btn_searchReadList_Click(object sender, EventArgs e)
        {


            if (TV_ReadList.Nodes.Count <= 0)
            {
                Log1("Nothhing to search.");
                return;
            }
            bool found = false;
            Log1("ReadListSeachIndex = {0}", ReadListSeachIndex);
            for(int i= ReadListSeachIndex; i< TV_ReadList.Nodes.Count; i++)
            {
                string titleName = TV_ReadList.Nodes[i].Text;
                string keyword = textBox_seaarchReadList.Text;
                if (titleName.ToLower().Contains(keyword.ToLower()))
                {
                    found = true;
                    Log1("found {0}", titleName);
                    TV_ReadList.SelectedNode = TV_ReadList.Nodes[i];
                    
                }

                //search alias
                if(!found)
                for(int j = 0; j< TV_ReadList.Nodes[i].Nodes.Count;j++)
                {
                    //loop thru site
                    for(int k = 0; k< TV_ReadList.Nodes[i].Nodes[j].Nodes.Count;k++)
                    {
                        string LinkAndAlias = TV_ReadList.Nodes[i].Nodes[j].Nodes[k].Text;
                        if (LinkAndAlias.ToLower().Contains(keyword.ToLower()))
                        {
                            found = true;
                            Log1("found link and alias {0}", LinkAndAlias);
                            TV_ReadList.SelectedNode = TV_ReadList.Nodes[i];
                        }
                        if (found)
                        {
                            break;
                        }

                    }
                    if (found)
                    {
                        break;
                    }
                }



                ReadListSeachIndex = i+1; // TV_ReadList.Nodes[i].NextNode.Index;//
                if (ReadListSeachIndex> TV_ReadList.Nodes.Count - 1)
                {
                    Log1("Last search, next search from first item");
                    ReadListSeachIndex = 0;
                }


                if (found)
                {
                    break;
                }
            }

            if (!found)
            {
                Log1("Found nothing after {0}", TV_ReadList.Nodes[ReadListSeachIndex].Text);
            }

            


        }

        private void textBox_login_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                string url = textBox_login.Text;

                if (url == "")
                {
                    //return;
                    url = @"https://mangadex.org/title/0b58c5b8-1003-45c3-a997-67d2dc20e516/shogo-beat";
                }

                CWB_login.Load(url);
            }
        }

        private void btn_setIsNSFW_Click(object sender, EventArgs e)
        {
            IsNSFW = !IsNSFW;

            if (IsNSFW)
            {
                btn_setIsNSFW.Text = "NSFW : ON";
            }
            else
            {
                btn_setIsNSFW.Text = "NSFW : OFF";
            }
        }

        private void tabControl1_TabIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateUI_ShowActiveLog();
        }

        private void btnXSearch1_Click(object sender, EventArgs e)
        {
            textBox_seaarchReadList.Text = ""; //clear
        }

        private void btnX_saveroot_Click(object sender, EventArgs e)
        {
            textBox_title_rootDir.Text = ""; //clear
        }

        
        private void sortTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //TV_ReadList.Sort(); this will short all levels, we just need level 0
            TreeView TV = ActiveTitleListInfos[ActiveTitleListIndex].ActiveTV;// TV_ReadList;

            if(TV is null) { return; }
            if (TV.Nodes.Count <= 0) { return; }

            int maxIndexToSort = TV.Nodes.Count-1;
            Log1("{0} maxIndexToSort = {1}", TV.Name, maxIndexToSort);
            //NodeSorter ns = TV_ReadList.TreeViewNodeSorter as NodeSorter;
            TV.TreeViewNodeSorter = new NodeSorter();
            (TV.TreeViewNodeSorter as NodeSorter).Set_AllowSorting(false);
            //TV_ReadList.TreeViewNodeSorter = ns;

            UpdateUI_AddStarOnTVParentIsTabPage(TV);
        }



        private void UpdateUI_RefreshCover()
        {
            Log2("Refresh Cover");


            bReqUpdateCover = true;
            timer_updateCover.Enabled = true;
            timer_updateCover.Start();
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private string GetRelBaseCoverDir(string SiteSource)
        {
            string RelDirCover = PathCombine("Cover_" + Form_ID.ToString(), SiteSource); //relative path dir cover
            return RelDirCover;
        }

        private string GetRelBaseCoverDownloadDir(string SiteSource)
        {
            string RelDirCoverDownload = PathCombine(GetRelBaseCoverDir(SiteSource), "download"); //relative path dir cover download
            return RelDirCoverDownload;
        }

        private void ClearRelBaseCoverDownloadDir(string SiteSource)
        {
            //ingat harus dijalankan saat form dibuat supaya tidak ada yg akses
            string DirPath = GetRelBaseCoverDownloadDir(SiteSource);
            try
            {
                if (Directory.Exists(DirPath))
                {
                    Directory.Delete(DirPath, true);
                }
                
            }
            catch (Exception ee)
            {

                //throw;
                Log2("cant clear dir : {0}, {1}", DirPath, ee.Message);
            }
        }

        private string GetCoverImage(string SiteSource)
        {
            //
            string RelDirCover = GetRelBaseCoverDir(SiteSource);// PathCombine( "Cover_" + Form_ID.ToString(), strCurrentSiteSource) ; //relative path dir cover
            if (!Directory.Exists(RelDirCover))
            {
                Directory.CreateDirectory(RelDirCover);
            }

            string basefilename = strCurrentLocalTitleNameID;
            string baseExt = ".jpg";
            //string fileCoverImage_download = PathCombine(PathCombine(RelDirCover, "download"), basefilename + baseExt);
            string fileCoverImage_download = PathCombine(GetRelBaseCoverDownloadDir(SiteSource), basefilename + baseExt);
            string fileCoverImage = PathCombine(RelDirCover, basefilename + baseExt);

            if (IsDownloadDone_cover)
            {
                if (labelPerc_cover.Text == "100%")
                {
                    if (File.Exists(fileCoverImage_download))
                    {
                        IsDownloadDone_cover = false;
                        try
                        {
                            //File.Copy(fileCoverImage_download, fileCoverImage,false);
                            File.Move(fileCoverImage_download, fileCoverImage);
                        }
                        catch (Exception ee)
                        {

                            //throw;
                            Log2("fail to move cover from download, {0}, {1}", fileCoverImage_download, ee.Message);
                        }

                        
                    }
                }
                

            }

            return fileCoverImage;
        }


        private void timer_updateCover_Tick(object sender, EventArgs e)
        {
            //Log2("timer_updateCover_Tick");
            if (bReqUpdateCover) 
            {
                string fileCoverImage = GetCoverImage(strCurrentSiteSource);
                //Log2("fileCoverImage = {0}", fileCoverImage);

                //cek exist
                if (File.Exists(fileCoverImage))
                {
                    bReqUpdateCover = false;

                    //set cover
                    try
                    {
                        Log2("Cover loaded = {0}", fileCoverImage);
                        pictureBox2.Load(fileCoverImage);
                    }
                    catch (Exception ee)
                    {

                        //throw;
                        Log2("Can't load cover, {0} ", ee.Message);
                    }



                }
                else
                {
                    //Log2("fileCoverImage not exist, {0}", fileCoverImage);
                    labelPerc_cover.Text = "No Cover Art";
                    //clear image if no file to load
                    if(pictureBox2.Image != null)
                    {
                        Log2("Cover unloaded");
                        pictureBox2.Image = null;
                    }
                    
                }
            }
            else
            {
                //Log2("bReqUpdateCover false");
            }
            
        }

        private void editTitleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //copy from tv to panel edit
            
            TreeView TV = TV_ReadList;
            ContextMenuStrip CMS = contextMenuStrip1;

            if (TV.SelectedNode is null) { return; }

            int iCurrentLevel = TV.SelectedNode.Level;
            IList<string> NodeTexts = TV.SelectedNode.FullPath.Split('\\').ToList();
            Log1("editing : {0}", TV.SelectedNode.FullPath);

            if (NodeTexts.Count < 2) { return; } //harus select site source dulu



            textBox_addReadList_TitleName.Text = NodeTexts[0];
            textBox_addReadList_ChapterListPageURL.Text = TV.SelectedNode.Nodes[0].Text;
            Log1("TV.SelectedNode.Nodes.Count = {0}", TV.SelectedNode.Nodes.Count);
            if (TV.SelectedNode.Nodes.Count > 1)
            {
                for (int i = 1;i< TV.SelectedNode.Nodes.Count; i++)
                {
                    string alias = TV.SelectedNode.Nodes[i].Text;
                    Log1("add alias = {0}", alias);
                    textBox_addReadList_Alias.AppendText(alias + "\r\n");
                    //textBox_addReadList_Alias.Lines.Append(alias);


                }
            }           
            

        }

        private Control GetSourceControlForToolStripMenuItem(object sender)
        {
            Control c = null;
            ToolStripMenuItem MenuItem = (sender as ToolStripMenuItem);

            //Log1(sender.GetType().Name);

            //Log1("1, " + MenuItem.Text);

            while ( !(MenuItem.GetCurrentParent() is ContextMenuStrip) & (MenuItem.GetCurrentParent() is ToolStripDropDownMenu) )
            {
                //Log1( (MenuItem.GetCurrentParent() as ToolStripDropDownMenu).OwnerItem.GetType().Name);
                MenuItem = (MenuItem.GetCurrentParent() as ToolStripDropDownMenu).OwnerItem as ToolStripMenuItem;
            }

            //Log1("2, "+MenuItem.Text);
            ContextMenuStrip PopupMenu = MenuItem.GetCurrentParent() as ContextMenuStrip;
            c = PopupMenu.SourceControl;

            return c;
        }

        private void readListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = GetSourceControlForToolStripMenuItem(sender);
            TreeView TV = c as TreeView;
            TreeView OtherTV = TV_ReadList;
            Log1(TV.Name);
            MoveSelectedTVNodeTitle(TV, OtherTV);

            //save copy
            saveTVTitleSelectionToJsonFile(OtherTV, ReadListJsonFilePath);

            //save delete
            string JsonFilePath = ActiveTitleListInfos[ActiveTitleListIndex].DataPath;
            saveTVTitleSelectionToJsonFile(TV, JsonFilePath);
        }

        private void onHoldToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Control c = GetSourceControlForToolStripMenuItem(sender);
            TreeView TV = c as TreeView;
            TreeView OtherTV = TV_OnHoldList;
            Log1(TV.Name);
            MoveSelectedTVNodeTitle(TV, OtherTV);

            //save copy
            saveTVTitleSelectionToJsonFile(OtherTV, OnHoldListJsonFilePath);

            //save delete
            string JsonFilePath = ActiveTitleListInfos[ActiveTitleListIndex].DataPath;
            saveTVTitleSelectionToJsonFile(TV, JsonFilePath);

            /* ok, simple version on above
            Log1(sender.GetType().Name);
            ToolStripMenuItem MenuItem = (sender as ToolStripMenuItem);
            Log1(MenuItem.Text);
            

            Log1(MenuItem.Owner.GetType().Name);
            Log1(MenuItem.GetCurrentParent().GetType().Name);
            ToolStripDropDownMenu DropDownMenu = MenuItem.GetCurrentParent() as ToolStripDropDownMenu;

            Log1(DropDownMenu.OwnerItem.GetType().Name);

            ToolStripMenuItem MenuItem2 = (DropDownMenu.OwnerItem as ToolStripMenuItem);

            Log1(MenuItem2.Text);

            Log1(MenuItem2.GetCurrentParent().GetType().Name);

            ContextMenuStrip PopupMenu = MenuItem2.GetCurrentParent() as ContextMenuStrip;
            Log1(PopupMenu.SourceControl.GetType().Name);
            */




            //ToolStrip toolStrip = MenuItem.GetCurrentParent() as ToolStrip;
            //Log1(toolStrip.Name);
            //Log1(toolStrip.Parent.GetType().Name);



            //ContextMenuStrip PopupMenu = MenuItem.Owner as ContextMenuStrip;
            //Log1(PopupMenu.SourceControl.GetType().Name);


            //Log1(MenuItem.GetCurrentParent().GetType().Name);
            //ToolStripDropDownMenu DropDownMenu = MenuItem.GetCurrentParent() as ToolStripDropDownMenu;
            //Log1(DropDownMenu.Name);

            //ContextMenuStrip PopupMenu = (MenuItem.GetCurrentParent() as ContextMenuStrip);
            //TreeView TV = (PopupMenu.Parent as TreeView);
            //Log1(TV.Name);
        }

        private void completedListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = GetSourceControlForToolStripMenuItem(sender);
            TreeView TV = c as TreeView;
            TreeView OtherTV = TV_CompletedList;
            Log1(TV.Name);
            MoveSelectedTVNodeTitle(TV, OtherTV);

            //save copy
            saveTVTitleSelectionToJsonFile(OtherTV, CompletedListJsonFilePath);

            //save delete
            string JsonFilePath = ActiveTitleListInfos[ActiveTitleListIndex].DataPath;
            saveTVTitleSelectionToJsonFile(TV, JsonFilePath);
        }

        private void dropListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Control c = GetSourceControlForToolStripMenuItem(sender);
            TreeView TV = c as TreeView;
            TreeView OtherTV = TV_DropList;
            Log1(TV.Name);
            MoveSelectedTVNodeTitle(TV, OtherTV);

            //save copy
            saveTVTitleSelectionToJsonFile(OtherTV, DropListJsonFilePath);

            //save delete
            string JsonFilePath = ActiveTitleListInfos[ActiveTitleListIndex].DataPath;
            saveTVTitleSelectionToJsonFile(TV, JsonFilePath);
        }

        

        private void MoveSelectedTVNodeTitle(TreeView TV, TreeView OtherTV)
        {
            if (TV.SelectedNode is null) { return; }
            if (TV.SelectedNode.Level > 0) { return; }

            
            CopySelectedTVNodeToOtherTV(TV, OtherTV);

            //delete selected
            deleteSelectedLevel0TV(TV);

            

        }

        private void CopySelectedTVNodeToOtherTV(TreeView TV, TreeView OtherTV, bool bIsAddLast = true)
        {
            if (TV.SelectedNode is null) { return; }

            TreeNode NodeCopy = (TreeNode)TV.SelectedNode.Clone(); //remember, using clone means tag will point to the same instance

            //copy selected
            if (bIsAddLast)
            {
                OtherTV.Nodes.Add(NodeCopy); //add as last
            }
            else
            {
                OtherTV.Nodes.Insert(0,NodeCopy); //add as first
            }

            



        }


        IList<ActiveTitleListInfo> ActiveTitleListInfos = new List<ActiveTitleListInfo>();
        int ActiveTitleListIndex = 0;

        private void tabControl_TitleList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ActiveTitleListIndex = tabControl_TitleList.SelectedIndex;
            Log1("Active Title List Index = {0}", ActiveTitleListIndex);
        }

        private void sendTitleToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            onHoldListToolStripMenuItem.Visible = ActiveTitleListIndex != intTitleList_OnHold;
            readListToolStripMenuItem.Visible = ActiveTitleListIndex != intTitleList_Read;
            completedListToolStripMenuItem.Visible = ActiveTitleListIndex != intTitleList_Completed;
            dropListToolStripMenuItem.Visible = ActiveTitleListIndex != intTitleList_Drop;
        }

        private void btn_Trim_Alias_Click(object sender, EventArgs e)
        {
            textBox_addReadList_TitleName.Text = textBox_addReadList_TitleName.Text.Trim();
            textBox_addReadList_ChapterListPageURL.Text = textBox_addReadList_ChapterListPageURL.Text.Trim();
            textBox_addReadList_Alias.Text = textBox_addReadList_Alias.Text.Trim();

        }

        private void DGV_ChapterCartList_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            UpdateUI_SetLabelCartCounter();
        }

        private void DGV_ChapterCartList_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            UpdateUI_SetLabelCartCounter();
        }

        private void UpdateUI_SetLabelCartCounter()
        {
            label_cart_count.Text = (DGV_ChapterCartList.Rows.Count).ToString();
        }

        private void btn_cart_delete_Click(object sender, EventArgs e)
        {
            var SelectedCells = DGV_ChapterCartList.SelectedCells;
            if (SelectedCells.Count == 0) { Log2("no selection to delete"); return; }

            int iCol = 0;
            for(int i=0; i< SelectedCells.Count; i++)
            {
                if (i == 0)
                {
                    iCol = SelectedCells[i].ColumnIndex;
                }
                if(iCol== SelectedCells[i].ColumnIndex)
                {
                    int iRowSelected = SelectedCells[i].RowIndex;
                    DGV_ChapterCartList.Rows.RemoveAt(iRowSelected);
                }
                
            }
            
        }

        private void btn_cart_checkNumbering_Click(object sender, EventArgs e)
        {
            Cart_CheckNumbering();
        }

        private void Cart_CheckNumbering()
        {
            DataGridView DGV = DGV_ChapterCartList;
            //float fFirstNumber = 0;
            //float fLastNumber = 0;
            //IList<float> List_fNumbers = new List<float>();
            IList<string> List_ChapterName_cek = new List<string>();

            //setup data major minor
            IList<int> List_iMajor = new List<int>();
            for (int i = 0; i < DGV.Rows.Count; i++)
            {
                string sChapterName = DGV.Rows[i].Cells[cintCol_ChapterName].Value.ToString();
                string sChapterNumber = sChapterName.Replace("Chapter", "").Trim();

                List_ChapterName_cek.Add(sChapterName);

                //get nMajor
                //string sChapterNumberMajor = sChapterNumber.Remove(sChapterNumber.IndexOf(".")).Trim();
                string sChapterNumberMajor = sChapterNumber;
                if (sChapterNumberMajor.IndexOf(".") > -1)
                {
                    sChapterNumberMajor = sChapterNumberMajor.Remove(sChapterNumberMajor.IndexOf(".")).Trim();
                }
                int iMajor = Convert.ToInt32(sChapterNumberMajor);
                List_iMajor.Add(iMajor);
            }

            //remove dupe in major
            List_iMajor = List_iMajor.Distinct().ToList();

            
            //get nMinor
            IList<ChapterNumbering> nMajors = new List<ChapterNumbering>();
            for (int i = 0; i < List_iMajor.Count; i++)
            {
                ChapterNumbering Major = new ChapterNumbering();
                Major.iMajor = List_iMajor[i];


                IList<int> nMinors = new List<int>();
                for (int j = 0; j < List_ChapterName_cek.Count; j++)
                {
                    string sChapterNumber = List_ChapterName_cek[j].Replace("Chapter", "").Trim();
                    //string sChapterNumberMajor = sChapterNumber.Remove(sChapterNumber.IndexOf(".")).Trim();
                    string sChapterNumberMajor = sChapterNumber;
                    if (sChapterNumberMajor.IndexOf(".") > -1)
                    {
                        sChapterNumberMajor = sChapterNumberMajor.Remove(sChapterNumberMajor.IndexOf(".")).Trim();
                    }
                    int iMajor = Convert.ToInt32(sChapterNumberMajor);
                    if (iMajor == Major.iMajor)
                    {
                        string sChapterNumberMinor = "0";
                        if (sChapterNumber.IndexOf(".") > -1)
                        {
                            sChapterNumberMinor = sChapterNumber.Substring(sChapterNumber.IndexOf(".") + 1).Trim();
                        }

                        int iMinor = Convert.ToInt32(sChapterNumberMinor);
                        if (Major.iMinors is null)
                        {
                            Major.iMinors = new List<int>();
                        }
                        Major.iMinors.Add(iMinor);
                        //Log2("Major {0}, Minor {1}", iMajor, iMinor);
                    }
                }


                nMajors.Add(Major);
            }



            //cek dupe
            Log2("cek dupe");
            //bool bCek = true;
            bool bCek = List_ChapterName_cek.Count > 0;
            int iCountDupe = 0;
            while (bCek)
            {
                bool bFound = false;
                string sNameCek = "";// List_fNumbers_dupe[0];
                for (int j = 0; j < List_ChapterName_cek.Count; j++)
                {
                    if (j == 0)
                    {
                        sNameCek = List_ChapterName_cek[j];
                    }
                    else
                    {
                        if (sNameCek == List_ChapterName_cek[j])
                        {
                            bFound = true;
                            iCountDupe++;
                            List_ChapterName_cek[j] = "remove";
                        }


                    }
                }

                if (bFound)
                {
                    Log2("Dupe Chapter {0}", List_ChapterName_cek[0]);
                }
                List_ChapterName_cek.RemoveAt(0);
                while (List_ChapterName_cek.Contains("remove"))
                {
                    List_ChapterName_cek.Remove("remove");
                }



                bCek = List_ChapterName_cek.Count > 0;
            }

            

            //IList<int> List_iNumbers_dupe = new List<int>();
            //List_iNumbers.CopyTo((int[])List_iNumbers_dupe, 0);

            ////var trimDupe = List_fNumbers.Distinct();
            ////Log2(trimDupe.ToString());
            ////if(trimDupe.Count() != List_fNumbers.Count)
            ////{
            ////    Log2("Cart contain dupe chapter");
            ////}
            ////else
            ////{
            ////    Log2("Cart no dupe, ok");
            ////}

            Log2("cek missing");
            int iCountMissing = 0;
            for (int iMajor = nMajors.First().iMajor; iMajor <= nMajors.Last().iMajor; iMajor++)
            {
                bool bFoundMajor = false;
                for (int j = 0; j < nMajors.Count; j++)
                {
                    int iMajorCek = nMajors[j].iMajor;

                    if (iMajor == iMajorCek)
                    {
                        bFoundMajor = true;
                        //var allMajorCekMinor = nMajors.Where(n => n.iMajor == iMajor);
                        for (int iMinor = nMajors[j].iMinors.First(); iMinor <= nMajors[j].iMinors.Last(); iMinor++)
                        {
                            bool bFoundMinor = false;
                            for (int k = 0; k < nMajors[j].iMinors.Count; k++)
                            {
                                int iMinorCek = nMajors[j].iMinors[k];
                                if (iMinor == iMinorCek)
                                {
                                    bFoundMinor = true;
                                }
                            }
                            if (!bFoundMinor)
                            {
                                iCountMissing++;
                                Log2("Missing Chapter {0}.{1}", iMajor.ToString().PadLeft(3, '0'), iMinor.ToString().PadLeft(3, '0'));
                            }


                        }
                    }

                }
                if (!bFoundMajor)
                {
                    iCountMissing++;
                    Log2("Missing Chapter {0}", iMajor.ToString().PadLeft(3, '0'));
                }
            }



            //====================================log info summary
            //dupe
            if (iCountDupe <= 0)
            {
                Log2("No Dupe Chapter, OK!", iCountDupe);
            }
            else
            {
                Log2("{0} Dupe Chapter", iCountDupe);
            }

            //missing
            if (iCountMissing == 0)
            {
                Log2("No Missing Chapter, OK!", iCountMissing);
            }
            else
            {
                Log2("Possible missing {0} chapter", iCountMissing);
            }
        }

        

        private void addAllToCartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (DGV_ChapterList.Rows.Count <= 1) { return; }

            //setup
            int iRowFirstData = 0; //0 because header is not counted as row
            SetSelectRowIndexStart(iRowFirstData);

            int iRowLastData = DGV_ChapterList.Rows.Count-1;
            SetSelectRowIndexEnd(iRowLastData);

            //add
            AddSelectedChapterTOCart();

            //change tab to cart
            tabControl_chapterSelection.SelectedIndex = 1;

            //
            Cart_CheckNumbering();
        }

        private void removeTimeAddedToDListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridView DGV_CL = DGV_ChapterList;
            //DataGridView DGV_CCL = DGV_ChapterCartList;
            if (DGV_CL.Rows.Count <= 1)
            {
                Log3("something wrong when removing date");
                return;
            }

            Log3("DGV_CL.SelectedCells.Count = {0}", DGV_CL.SelectedCells.Count);
            if (DGV_CL.SelectedCells.Count > 0)
            {

                int iColSelected = 0;
                for (int i = 0; i < DGV_CL.SelectedCells.Count; i++)
                {
                    DataGridViewCell DIR = DGV_CL.SelectedCells[i];

                    if (i == 0)
                    {
                        iColSelected = DIR.ColumnIndex;
                    }

                    if (iColSelected == DIR.ColumnIndex)
                    {

                        //write date add
                        DGV_CL[cintCol_ChapterTimeAddedToDList, DIR.RowIndex].Value = "-";// DateTime.Now.ToString("G");
                    }

                }
            }
        }

        



        //=================================================TreeView DragDrop END
    }
    //end
    public class ChapterListDataLocal
    {
        public string chapterNo { get; set; }
        public string chapterName { get; set; }
        public string chapterStatus { get; set; }
        public string chapterDateAddedToDList { get; set; }
        public string chapterID { get; set; }
        public string chapterHash { get; set; }
        public string chapterImageCount { get; set; }
        public string chapterAttVolume { get; set; }
        public string chapterAttChapter { get; set; }
        public string chapterImageHost { get; set; }
        public bool chapterIsObsolute { get; set; }
        public string chapterScanGroup { get; set; }
        public string chapterUploader { get; set; }
        public string chapterTitle { get; set; }

    }
}
