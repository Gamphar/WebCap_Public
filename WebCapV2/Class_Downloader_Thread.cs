using CefSharp;
using CefSharp.OffScreen;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCapV2
{
    class Class_Downloader_Thread
    {
    }
    public partial class Form_Downloader : Form 
    {
        bool isThreadRun_DownloadQueue = false;
        bool isThreadRun_LoadTVDone = false;

        public Form_log Form_Log = null;

        public void LogT(string msg)
        {
            string titleInfo = "log";
            msg = String.Format("Thread ({0}) info: {1}:: {2}.", Thread.CurrentThread.ManagedThreadId, titleInfo, msg);
            this.InvokeEx(f => f.Form_Log.textBox_log.AppendText(msg + "\r\n"));

        }

        public void LogT(string msg, params object[] o)
        {

            msg = String.Format(msg, o);
            this.InvokeEx(f => f.Form_Log.textBox_log.AppendText(msg + "\r\n"));

        }

        private void startThread_LoadTVDone()
        {
            //TODO:thread load list box title folder
            if (isThreadRun_LoadTVDone)
            {
                Log3("LoadTVDone Thread still running");
                return;
            }


            var th = new Thread(ThreadMaster_LoadTVDone);
            th.IsBackground = true;
            th.Start();
            //Thread.Sleep(1000);
            Log3("startThread_LoadTVDone thread ({0}) ",
                              Thread.CurrentThread.ManagedThreadId);
        }


        private void ThreadMaster_LoadTVDone()
        {
            isThreadRun_LoadTVDone = true;
            LogT("ThreadMaster_LoadTVDone Thread ({0}) running.", Thread.CurrentThread.ManagedThreadId);
            //==========================================start
            //this.InvokeEx(f => ThreadSub_DownloadQueue(strCurrentRootFolder));
            ThreadSub_LoadTVDone();






            //==========================================end
            LogT("ThreadMaster_LoadTVDone Thread ({0}) ending.", Thread.CurrentThread.ManagedThreadId);
            isThreadRun_LoadTVDone = false;
        }

        private void ThreadSub_LoadTVDone()
        {
            //string TaskDoneDir = getDir( Path.Combine(MySetting.ExeDir, "TaskDone") );
            DirectoryInfo di = new DirectoryInfo(TaskDoneDir);
            foreach (var f in di.GetFiles("*"))
            {
                Log3(f.FullName);
                if (f.Name != "[hide]")
                {
                    if (
                    Path.GetExtension(f.FullName).ToLower().Contains(".json")
                    )
                    {
                        this.InvokeEx(x => x.loadJsonFileTaskListDataToTVTaskList(f.FullName, TV_taskDone) );
                        
                    }
                    

                }
            }
        }


        //===================================================DOwnload

        private void startThread_DownloadQueue()
        {
            //TODO:thread load list box title folder
            if (isThreadRun_DownloadQueue)
            {
                Log3("DownloadQueue Thread still running");
                return;
            }

            //check if root exist
            if (!Directory.Exists(settingTitleSelection.KomikRootDir))
            {
                string msg = "Komik Root Dir is not exist, please resetup properly.";
                Log3(msg);
                MessageBox.Show(msg);
               return;
            }
                

            var th = new Thread(ThreadMaster_DownloadQueue);
            th.IsBackground = true;
            th.Start();
            //Thread.Sleep(1000);
            Log3("startThread_DownloadQueue thread ({0}) ",
                              Thread.CurrentThread.ManagedThreadId);
        }


        private void ThreadMaster_DownloadQueue()
        {
            isThreadRun_DownloadQueue = true;
            Log3("DownloadQueue Thread ({0}) running.", Thread.CurrentThread.ManagedThreadId);
            //==========================================start
            //this.InvokeEx(f => ThreadSub_DownloadQueue(strCurrentRootFolder));
            ThreadSub_DownloadQueue();






            //==========================================end
            Log3("DownloadQueue Thread ({0}) ending.", Thread.CurrentThread.ManagedThreadId);
            isThreadRun_DownloadQueue = false;
        }

        const string cstrLang_En = "en";
        bool IsDownloadDone = false;
        long TotalBytesToReceive = 0;
        int ProgressPercentage = 0;
        int iDownloadDoneStatus = 0;
        bool IsStopDownloadSignal = false;
        private void ThreadSub_DownloadQueue()
        {
            //
            //LogT("DownloadQueue");
            Log3("DownloadQueue");
            //listBox_title.Items.Clear();

            //setup
            string KomikRootDir = getDir( settingTitleSelection.KomikRootDir );
            //ProgressBar PBarChpList = progressBar_ChapterList;
            //ProgressBar PBarImgListt = progressBar_ImageList;


            //reset all var at starting queue
            TaskListData TLD_Idle = new TaskListData();
            ConvertTVTaskListToJsonData(TV_taskList, TLD_Idle);
            foreach(TaskDownloadData TDD in TLD_Idle.TaskList)
            {
                TDD.RetryCount = "-1";
            }

            //reload task list idle
            this.InvokeEx(f => f.TV_taskList.Nodes.Clear());
            this.InvokeEx(f => f.ConvertJsonDataToTVTaskList(TLD_Idle, TV_taskList));



            //listBox_page.DataSource = null;
            //this.InvokeEx(f => listBox_page.Items.Clear());
            IsStopDownloadSignal = false;
            while (TV_taskList.Nodes.Count > 0 && !IsStopDownloadSignal)
            {

                //move task list idle to task running
                this.InvokeEx(f => f.MoveTV_TaskListToTaskRunning());
                //save task running
                saveTVTaskList_Running();
                //save task idle
                saveTVTaskList_Idle();

                Thread.Sleep(2000);
                TaskListData TLD = new TaskListData();
                ConvertTVTaskListToJsonData(TV_taskRunning, TLD);

                //inc retry count
                int iTaskRetry = Convert.ToInt32(TLD.TaskList[0].RetryCount);
                TLD.TaskList[0].RetryCount = (iTaskRetry + 1).ToString();

                //check if retry count found bigger than 3 then stop all download queue
                if (iTaskRetry > 3)
                {
                    Log3("Stop task queue, Task retry {0}", iTaskRetry);
                    IsStopDownloadSignal = true;
                }
                else
                {
                    Log3("Task retry {0}", iTaskRetry);
                }

                //backu TLD for savinf the edit
                TaskListData TLD_Save = new TaskListData(TLD);

                //loop running task, usually just 1, but this just incase if next time added ability to add more tsk on running task
                int iTDD = -1;
                foreach (TaskDownloadData TDD in TLD.TaskList)
                {
                    iTDD++;
                    //set title folder
                    string ValidTitleFolderName = GetSafeFilename( TDD.TitleName);
                    

                    string KomikTitleDir = getDir( Path.Combine(KomikRootDir, ValidTitleFolderName) );
                    int iDownloadFailCount = 0;
                    int iChapterFailCheckCount = 0;                                      
                    string ChapterStatus = "";
                    string ChapterListPageUrl = TDD.ChapterListPageUrl;

                    //SETUP progress bar chapter list
                    int iNumberChapterLoop = 0;
                    int iTotalChapterCount = TDD.Chapters.Count;
                    this.InvokeEx(f => f.progressBar_ChapterList.Maximum = iTotalChapterCount);
                    this.InvokeEx(f => f.progressBar_ChapterList.Minimum = 0);
                    this.InvokeEx(f => f.progressBar_ChapterList.Value = progressBar_ChapterList.Minimum);
                    
                    //loop chapter                    
                    foreach (ChapterData CD in TDD.Chapters)
                    {
                        if (IsStopDownloadSignal)
                        {
                            Log3("While loop chapter, stop signal, break");
                            break;
                        }
                        iNumberChapterLoop++;
                        int iCD = iNumberChapterLoop - 1;
                        this.InvokeEx(f => f.progressBar_ChapterList.Value = iNumberChapterLoop); //move preogress bar chapter list

                        //reset check
                        iChapterFailCheckCount = 0;

                        //set chapter folder
                        string ValidChapterFolderName = GetSafeFilename(CD.ChapterName).Trim();
                        string KomikChapterDir = getDir(Path.Combine(KomikTitleDir, ValidChapterFolderName));
                        string KomikChapterHide = getDir(Path.Combine(KomikChapterDir, "[hide]"));
                        string KomikChapterDownloadDir = getDir(Path.Combine(KomikChapterHide, "download"));

                        //chapter first check
                        ChapterStatus = CD.status;
                        if (ChapterStatus.ToLower() == "done")
                        {
                            Log3("Skipping {0}, because already done", CD.ChapterName);
                        }
                        else
                        {

                            Log3("Chapter still not done, try to get image");
                            //chapter need something to download
                            

                            //update image host on each chapter
                            string strChapterID = CD.ChapterID;
                            string URLAPi_ImageHost = getURLApi_ImageHost(strChapterID); 
                            string jsonHost = getJsonStringFromURL(URLAPi_ImageHost); // need handle condition if result is blank string

                            //try retry
                            int iRetryJsonHost = 0;
                            while (jsonHost == "" && iRetryJsonHost<20)
                            {
                                iRetryJsonHost++;
                                if (iRetryJsonHost > 1) 
                                {
                                    Log3("Fail to get jsonHost, retry #"+ iRetryJsonHost.ToString());
                                    Thread.Sleep(2000); 
                                }
                                jsonHost = getJsonStringFromURL(URLAPi_ImageHost);
                                if (jsonHost!="")
                                {
                                    Log3("retry #{0} success!", iRetryJsonHost);
                                }
                            }



                            ChapterHostData DL_CHD = JsonConvert.DeserializeObject<ChapterHostData>(jsonHost); //per 2022-01-16, 10.22 json host contain hash and file image


                            string strImageHost = DL_CHD!=null? DL_CHD.baseUrl:CD.ImageHost!=""?CD.ImageHost: "https://failImageHost";
                            string strChapterHash = DL_CHD.chapter.hash;// CD.ChapterHash;

                            //per 2022-01-16, save hash
                            TLD_Save.TaskList[iTDD].Chapters[iCD].ChapterHash = strChapterHash;
                            CD.ChapterHash = strChapterHash;


                            Log3("get image host = {0}", strImageHost);
                            Log3("get chapter hash = {0}", strChapterHash);

                            //get image
                            string URLApi_getImageURL = getURLAPi_ImageList(ChapterListPageUrl, CD.AttVolume, CD.AttChapter);
                            Log3("URLApi_getImageURL = {0}", URLApi_getImageURL);
                            //string json = getJsonStringFromURL(URLApi_getImageURL);
                            string json = getJsonStringFromURL_DL(URLApi_getImageURL);
                            string jsonFilePAth = Path.Combine(MySetting.RawJsonDir, "Json_URLApi_getImageURL_" + CD.ChapterName + ".json");
                            File.WriteAllText(jsonFilePAth, json);

                            DL_imageDownloadData IDD = JsonConvert.DeserializeObject<DL_imageDownloadData>(json);
                            DL_data data = getDL_data_LangEnFromIDD(IDD, strChapterHash); //per 2022-01-16, each translated chapter lang got its own chapter id, no longer in the same chapter id

                            int dataCount = 0;
                            if(DL_CHD != null) { dataCount = DL_CHD.chapter.data.Count; }

                            //if (data != null)
                            //if (DL_CHD != null && DL_CHD.chapter.data.Count>0)
                            if(dataCount>0)
                            {
                                //ada en lang
                                Log3("==========================STARTING Download En");


                                //SETUP progress bar image list
                                int iNumber = 0;
                                int iTotalImageCount = DL_CHD.chapter.data.Count; // data.attributes.data.Count;
                                this.InvokeEx(f => f.progressBar_ImageList.Maximum = iTotalImageCount);
                                this.InvokeEx(f => f.progressBar_ImageList.Minimum = 0);
                                this.InvokeEx(f => f.progressBar_ImageList.Value = progressBar_ImageList.Minimum);

                                //IList<ImageData> Images = new List<ImageData>();
                                //before start just add the image data for referense and numbering
                                ChapterStatus = "GI";
                                int iStarterImageCount = TLD_Save.TaskList[iTDD].Chapters[iCD].images.Count;

                                if (iStarterImageCount< iTotalImageCount)
                                {
                                    for (int j = iStarterImageCount; j < iTotalImageCount; j++) //start from 1 because there is already the first one on index 0
                                    {
                                        ImageData ImgData = new ImageData();
                                        ImgData.ImagePageURL = "ImagePageURL";
                                        ImgData.ImageURL = "ImageURL";
                                        ImgData.ImageExt = "ImageExt";
                                        ImgData.ImageSize = "ImageSize";
                                        ImgData.IDone = 0;
                                        TLD_Save.TaskList[iTDD].Chapters[iCD].images.Add(ImgData);
                                    }

                                    //save image template
                                    saveTaskListData_Running(TLD_Save);

                                    //need reload
                                    //reload first
                                    this.InvokeEx(f => f.TV_taskRunning.Nodes.Clear());
                                    this.InvokeEx(f => f.ConvertJsonDataToTVTaskList(TLD_Save, TV_taskRunning));
                                }





                                //loop image
                                //foreach (string ImgBaseFileUrl in data.attributes.data)
                                foreach (string ImgBaseFileUrl in DL_CHD.chapter.data)
                                {
                                    iNumber++;
                                    int i = iNumber - 1;
                                    this.InvokeEx(f => f.progressBar_ImageList.Value = iNumber); //move preogress bar image list
                                    Log3("==========================Download Image " + string.Format("{0}/{1}", iNumber, iTotalImageCount));
                                    Log3("ImgBaseFileUrl = {0}", ImgBaseFileUrl);


                                    //check if image is already done
                                    int IDone = TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].IDone;
                                    if (IDone == 1)
                                    {
                                        Log3("skip download cus already done");
                                    }
                                    else
                                    {
                                        string ImageURL = getImageFileURL(strImageHost, strChapterHash, ImgBaseFileUrl);
                                        Log3("ImageURL = {0}", ImageURL);

                                        string baseImageFileName = "Image" + iNumber.ToString().PadLeft(4, '0') + ".jpg";

                                        string ImageDownloadFilePath = Path.Combine(KomikChapterDownloadDir, baseImageFileName);

                                        //IsDownloadDone = false;
                                        //

                                        //ImageData ImgData = new ImageData();
                                        TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].ImagePageURL = CD.ImageHost;
                                        TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].ImageURL = ImageURL;

                                        //
                                        Log3("chapter dir ok = {1}, download to file = {0}", ImageDownloadFilePath, Directory.Exists(KomikChapterDir));

                                        //v1
                                        //DownloadFile(ImageURL, ImageFilePath);

                                        //v2
                                        //Thread_DownloadFile(ImageURL, ImageFilePath);


                                        ////v3
                                        //TotalBytesToReceive = 0;
                                        //Download D = new Download();
                                        //D.DownloadProgressChanged += new EventHandler<DownloadProgressChangedEventArgs>(DL_ProgressChanged2);
                                        //D.DownloadCompleted += new EventHandler(DL_Completed2);
                                        //D.FDownload = FDowloder;
                                        //D.DownloadFile(ImageURL, ImageFilePath);


                                        //v4-part1/2
                                        Download D = new Download();
                                        D.DownloadProgressChanged += new EventHandler<DownloadProgressChangedEventArgs>(DL_ProgressChanged2);
                                        D.DownloadCompleted += new EventHandler(DL_Completed2);
                                        D.FDownload = FDowloder;


                                        //IsDownloadDone = true;
                                        int iMaxRetry = 10;
                                        int iRetry = -1;
                                        while (iRetry < iMaxRetry && !IsStopDownloadSignal)
                                        {
                                            iRetry++;


                                            //v4-part2/2
                                            TotalBytesToReceive = 0;
                                            IsDownloadDone = false;
                                            D.DownloadFile(ImageURL, ImageDownloadFilePath); //DOWNLOAD THE FILE



                                            if (IsDownloadDone)
                                            {
                                                //iRetry = iMaxRetry;


                                                FileInfo fileInfo = new FileInfo(ImageDownloadFilePath);
                                                if (fileInfo.Length == TotalBytesToReceive && TotalBytesToReceive>0)
                                                {
                                                    iRetry = iMaxRetry; //force max to end retry because download is done
                                                    TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].IDone = 1;
                                                    Log3("Download is done, {2}%, {0}/{1}", fileInfo.Length, TotalBytesToReceive, ProgressPercentage);
                                                }
                                                else
                                                {
                                                    iDownloadFailCount++;
                                                    Log3("Download is done, but file not complete, {2}%, {0}/{1}", fileInfo.Length, TotalBytesToReceive, ProgressPercentage);
                                                }
                                                
                                                //fail or not just copy the file
                                                string ImageFilePath = Path.Combine(KomikChapterDir, baseImageFileName);
                                                File.Copy(ImageDownloadFilePath, ImageFilePath, true);


                                            } //download is done, no need to wait anymore
                                            else
                                            {
                                                Log3("Download fail, retry {0}/{1}", iRetry, iMaxRetry);
                                            }

                                            Thread.Sleep(1000);

                                        }

                                        TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].ImageSize = TotalBytesToReceive.ToString();
                                        TLD_Save.TaskList[iTDD].Chapters[iCD].images[i].ImageExt = Path.GetExtension(ImageURL);
                                    }


                                    //TLD_Save.TaskList[iTDD].Chapters[iCD].images.Add(ImgData); //add save image data


                                    Log3("iDownloadDoneStatus = " + iDownloadDoneStatus.ToString());
                                    Log3("==========================NEXT Image");

                                    if (IsStopDownloadSignal) { break; }

                                }

                            }
                            else
                            {
                                Log3("chapter fail, cant get eng lang data");
                                iDownloadFailCount++;
                            }

                            Log3("done downloading image");
                        }

                        //
                        if (iDownloadFailCount > 0) 
                        { 
                            ChapterStatus = "Fail "+iDownloadFailCount.ToString(); 
                        }
                        else
                        {
                            //delete download folder because all image is successfuly downloaded
                            //Directory.Delete(KomikChapterDownloadDir, true);
                            tryDeleteDir(KomikChapterDownloadDir);
                            ChapterStatus = "Done";
                        }
                        
                        TLD_Save.TaskList[iTDD].Chapters[iCD].status = ChapterStatus;

                        //before next chapter, we should save TLD_SAveFirst for running task
                        saveTaskListData_Running(TLD_Save);
                        Log3("==========================NEXT CHAPTER");

                        if (IsStopDownloadSignal) { break; }
                    }

                    
                    //TODO: first save json data from tv running as json done
                    //saveTVTaskList_Running_as_Done();

                    if (iDownloadFailCount <= 0 && !IsStopDownloadSignal)
                    {
                        

                        //or just use TLD above to save as done
                        saveTVTaskList_Running_as_Done(TLD_Save);



                        //move from running to done only visual...
                        //reload first
                        this.InvokeEx(f => f.TV_taskRunning.Nodes.Clear());
                        this.InvokeEx(f => f.ConvertJsonDataToTVTaskList(TLD_Save, TV_taskRunning));

                        LogT("MoveTV_TaskRunningToTaskDone");
                        this.InvokeEx(f => f.MoveTV_TaskRunningToTaskDone());


                        //save again running for deleting its file json
                        saveTVTaskList_Running();
                    }
                    else
                    {

                        //reload first
                        this.InvokeEx(f => f.TV_taskRunning.Nodes.Clear());
                        this.InvokeEx(f => f.ConvertJsonDataToTVTaskList(TLD_Save, TV_taskRunning));

                        //return to task idle for redownload later
                        this.InvokeEx(f => f.MoveTV_TaskRunningToTaskList());

                        saveTVTaskList_Idle();
                        saveTVTaskList_Running();

                    }

                    


                    Thread.Sleep(2000);
                    Log3("==========================NEXT TASK RUNNING, currently just one task at times");
                }
                

                //LogT("chapter = {0}", NodeChapter.Nodes[0]);
                Log3("==========================NEXT TASK IDLE");
            }



            
        }

        private void tryDeleteDir(string Dir)
        {
            int iMaxTry = 30;
            int iTry = 0;

            while (iTry<iMaxTry)
            {
                iTry++;

                try
                {
                    Log3("Try deleting dir {0}, attemp {1}", Dir, iTry);
                    Directory.Delete(Dir, true);

                    if (!Directory.Exists(Dir))
                    {
                        Log3("Done deleting dir {0}, attemp {1}", Dir, iTry);
                        iTry = iMaxTry;
                    }
                    else
                    {
                        if (iTry == iMaxTry)
                        {
                            Log3("Fail deleting dir {0}, attemp {1}", Dir, iTry);
                        }
                    }
 
                }
                catch (Exception ex)
                {
                    Log3(ex.Message);
                }

            }
        }

        public static string GetSafeFilename(string arbitraryString)
        {
            //TODO: Need to remove dot on last string. 
            while (arbitraryString[arbitraryString.Length - 1] == '.')
            {
                arbitraryString = arbitraryString.Remove(arbitraryString.Length - 1, 1);
            }

            var invalidChars = System.IO.Path.GetInvalidFileNameChars();
            var replaceIndex = arbitraryString.IndexOfAny(invalidChars, 0);
            if (replaceIndex == -1) return arbitraryString;

            var r = new StringBuilder();
            var i = 0;

            do
            {
                r.Append(arbitraryString, i, replaceIndex - i);

                switch (arbitraryString[replaceIndex])
                {
                    case '"':
                        r.Append("''");
                        break;
                    case '<':
                        r.Append('\u02c2'); // '˂' (modifier letter left arrowhead)
                        break;
                    case '>':
                        r.Append('\u02c3'); // '˃' (modifier letter right arrowhead)
                        break;
                    case '|':
                        r.Append('\u2223'); // '∣' (divides)
                        break;
                    case ':':
                        r.Append('\uA789'); // '꞉' MODIFIER LETTER COLON, see colon (letter), sometimes used in Windows filenames as it is identical to the colon in the Segoe UI font used for filenames. The colon itself is not permitted as it is a reserved character
                        break;
                    case '*':
                        r.Append('\u2217'); // '∗' (asterisk operator)
                        break;
                    case '\\':
                    case '/':
                        r.Append('\u2044'); // '⁄' (fraction slash)
                        break;
                    case '\0':
                    case '\f':
                    case '?':
                        r.Append('\uFE56'); //﹖ SMALL QUESTION MARK (HTML &#65110;)
                        break;
                    case '\t':
                    case '\n':
                    case '\r':
                    case '\v':
                        r.Append(' ');
                        break;
                    default:
                        r.Append('_');
                        break;
                }

                i = replaceIndex + 1;
                replaceIndex = arbitraryString.IndexOfAny(invalidChars, i);
            } while (replaceIndex != -1);

            

            r.Append(arbitraryString, i, arbitraryString.Length - i);


            

                return r.ToString();
        }

        public void Thread_DownloadFile(string urlAddress, string location)
        {
            Log3("Downloading file url = " + urlAddress);
            //if (!IsWindows10)
            //{
            //    LogT("Not windows 10, try fix SecurityProtocolType");
            //    //ServicePointManager.Expect100Continue = true;
            //    //ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls
            //    //    | SecurityProtocolType.Tls12
            //    //    | SecurityProtocolType.Tls11
            //    //    | SecurityProtocolType.Ssl3

            //    //    ; //(SecurityProtocolType)3072;// SecurityProtocolType.Ssl3;
            //    //ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(delegate { return true; }); //TODO: IN W7 need this for webclient working, but this is dangerous cus can be attack by middle man

            //}


            using (WebClient webClientT = new WebClient())
            {
                
                //not async
                //webClient.DownloadDataCompleted += new DownloadDataCompletedEventHandler(DL_Completed);
                

                //async
                webClientT.DownloadFileCompleted += new AsyncCompletedEventHandler(DL_AsyncCompleted);



                webClientT.DownloadProgressChanged += new System.Net.DownloadProgressChangedEventHandler(DL_ProgressChanged);

                // The variable that will be holding the url address (making sure it starts with http://)
                Uri URL = urlAddress.StartsWith("https://", StringComparison.OrdinalIgnoreCase) ? new Uri(urlAddress) : new Uri("https://" + urlAddress);
                Log3("Thread_DownloadFile, URL = " + URL);
                // Start the stopwatch which we will be using to calculate the download speed
                sw.Start();

                try
                {
                    // Start downloading the file
                    //webClient.DownloadFile(URL, location);
                    webClient.DownloadFileAsync(URL, location);

                }
                catch (Exception ex)
                {
                    Log3("exception " + ex.Message);
                }
            }
        }

        private void DL_ProgressChanged(object sender, System.Net.DownloadProgressChangedEventArgs e)
        {
            Log3("ProgressChanged");
            // Calculate download speed and output it to labelSpeed.
         this.InvokeEx(f =>   f.labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")) );

            // Update the progressbar percentage only when the value is not the same.
            this.InvokeEx(f => f.progressBar1.Value = (int)e.ProgressPercentage);

            // Show the percentage on our label.
            this.InvokeEx(f => f.labelPerc.Text = e.ProgressPercentage.ToString() + "%");

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            this.InvokeEx(f => f.labelDownloaded.Text = string.Format("{0} MB's / {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")));
        }


        private void DL_ProgressChanged2(object sender, DownloadProgressChangedEventArgs e)
        {
            //Log("ProgressChanged 2");
            // Calculate download speed and output it to labelSpeed.
            //this.InvokeEx(f => f.labelSpeed.Text = string.Format("{0} kb/s", (e.BytesReceived / 1024d / sw.Elapsed.TotalSeconds).ToString("0.00")));
            //this.InvokeEx(f => f.labelSpeed.Text = string.Format("{0} kb/s", (e.CurrentSpeed).ToString("0.00")));
            this.InvokeEx(f => f.labelSpeed.Text = string.Format("{0}/s", getFixedSize((long)e.CurrentSpeed) ));

            // Update the progressbar percentage only when the value is not the same.
            this.InvokeEx(f => f.progressBar1.Value = (int)e.ProgressPercentage);

            // Show the percentage on our label.
            this.InvokeEx(f => f.labelPerc.Text = e.ProgressPercentage.ToString() + "%");

            // Update the label with how much data have been downloaded so far and the total size of the file we are currently downloading
            /*
            this.InvokeEx(f => f.labelDownloaded.Text = string.Format("{0} MB's/ {1} MB's",
                (e.BytesReceived / 1024d / 1024d).ToString("0.00"),
                (e.TotalBytesToReceive / 1024d / 1024d).ToString("0.00")));
            */
            this.InvokeEx(f => f.labelDownloaded.Text = string.Format("{0} / {1}",
                    getFixedSize(e.BytesReceived),
                    getFixedSize(e.TotalBytesToReceive)
                )
            );


            TotalBytesToReceive = e.TotalBytesToReceive;
            ProgressPercentage = (int)e.ProgressPercentage;
        }

        // The event that will trigger when the WebClient is completed
        private void DL_Completed(object sender, DownloadDataCompletedEventArgs e)
        {
            LogT("Completed, {0}", e.UserState);

            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                LogT("Download has been canceled.");
            }
            else if (e.Error != null)
            {
                LogT("Download error! " + e.Error.Message);
            }
            else
            {
                //LoadImage2();
                LogT("Download completed!");
            }
        }

        private void DL_Completed2(object sender, EventArgs e)
        {
            //Log("Completed, {0}", e.);

            // Reset the stopwatch.
            sw.Reset();

            //if (e.Cancelled == true)
            //{
            //    LogT("Download has been canceled. 2");
            //}
            //else if (e.Error != null)
            //{
            //    LogT("Download error 2! " + e.Error.Message);
            //}
            //else
            //{
            //    //LoadImage2();
            //    Log("Download completed! 2");
            //}
            Log3("Download completed! 2");
            IsDownloadDone = true;
        }

        private void DL_AsyncCompleted(object sender, AsyncCompletedEventArgs e)
        {
            Log3("Completed, {0}", e.UserState);

            // Reset the stopwatch.
            sw.Reset();

            if (e.Cancelled == true)
            {
                iDownloadDoneStatus = 1;
                Log3("Download has been canceled.");
            }
            else if (e.Error != null)
            {
                iDownloadDoneStatus = 2;
                Log3("Download error! " + e.Error.Message);
            }
            else
            {
                //LoadImage2();
                iDownloadDoneStatus = 3;
                Log3("Download completed!");
            }
            IsDownloadDone = true;
        }

        private string getFixedSize(long SizeInByte)
        {
            string sSize = "";
            double sB = SizeInByte;
            double sK = sB / 1024;
            double sM = sK / 1024;
            double sG = sM / 1024;
            double sT = sG / 1024;

            double mK;
            double mM;
            double mG;
            double mT;

            //if (Math.Truncate(sK) > 0) {  mK = 2; } else { mK= 0; }
            //if (Math.Truncate(sM) > 0) { mM = 2; } else { mM = 0; }
            //if (Math.Truncate(sG) > 0) { mG = 2; } else { mG = 0; }
            //if (Math.Truncate(sT) > 0) { mT = 2; } else { mT = 0; }

            if (sK >= 1)
            {
                if (sM >= 1)
                {
                    if (sG >= 1)
                    {
                        if (sT >= 1)
                        {
                            sSize = string.Format("{0} Tib", getSimpleFloat(sT)); //tibibyte
                        }
                        else
                        {
                            sSize = string.Format("{0} Gib", getSimpleFloat(sG)); //gibibyte
                        }
                    }
                    else
                    {
                        sSize = string.Format("{0} Mib", getSimpleFloat(sM)); //mibibyte
                    }
                }
                else
                {
                    sSize = string.Format("{0} Kib", getSimpleFloat(sK)); // kibibyte
                }
            }
            else
            {
                sSize = string.Format("{0} B", getSimpleFloat(sB)); //Byte
            }




            return sSize;
        }

        private double getFraction(double number)
        {
            double frac = number - Math.Truncate(number);
            return frac;
        }

        private double getSimpleFloat(double myFloaty)
        {
            //double result = myFloaty;
            double result = Convert.ToDouble(myFloaty.ToString("0.00"));            

            //string rS1 = "";
            //string rS2= "";
            //double fraction= getFraction(myFloaty);
            //int part= 1;


            //if (fraction > 0)
            //{
            //    string sFloat = myFloaty.ToString("0.00");
            //    for (int i = 0; i < sFloat.Length; i++)
            //    {
            //        if (sFloat[i] == ',' || sFloat[i] == '.')
            //        {
            //            part = 2;
            //        }

            //        if (part == 1) { rS1 = rS1 + sFloat[i]; }
            //        if (part == 2) { rS2 = rS2 + sFloat[i]; }
            //    }

            //    result = Convert.ToDouble(rS1 + rS2[1] + rS2[2] + rS2[3]);
            //}



            return result;
        }

        private DL_data getDL_data_LangEnFromIDD(DL_imageDownloadData IDD, string strChapterHash)
        {
            if (IDD !=null)
            foreach (DL_data data in IDD.data)
            {
                if (data.attributes.translatedLanguage == cstrLang_En && data.attributes.hash == strChapterHash)
                {
                    return data;
                }
            }
            return null;
        }

        private string getJsonStringFromURL_DL(string URL)
        {
            //
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

            while (!CWB_DL.IsBrowserInitialized)
            {
                Thread.Sleep(100);
                Log3("CWB_DL is still not init, please wait!");
            }

            if (CWB_DL.IsBrowserInitialized)
            {
                Log3("CWB_DL init success!");
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
            CWB_DL.Load(URL);

            while (!IsDoneLoad_DL)
            {
                Thread.Sleep(100);
                Log3("Please wait, json still not ready");
            }

            return CWB_DL.GetTextAsync().Result;
        }

        private string getJsonStringFromURL(string URL)
        {

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

                return true;
            };


            using (var webClient = new System.Net.WebClient())
            {
                var json = "";
                try 
                {
                    json = webClient.DownloadString(URL);
                    Log3("getJsonStringFromURL, Url = {0} \r\n json = {1}", URL, json);
                }
                catch(Exception ex)
                {
                    Log3(ex.Message);
                }
                

                return json;
            }
        }



        private void MoveTV_TaskListToTaskRunning()
        {
            MoveFirstNodeToOtheTV(TV_taskList, TV_taskRunning);
        }

        private void MoveTV_TaskRunningToTaskDone()
        {
            MoveFirstNodeToOtheTV(TV_taskRunning, TV_taskDone);
        }

        private void MoveTV_TaskRunningToTaskList() //incase for fail to download
        {
            MoveFirstNodeToOtheTV(TV_taskRunning, TV_taskList);
        }

        private void MoveFirstNodeToOtheTV(TreeView TV_Src, TreeView TV_Dst)
        {
            if (TV_Src.Nodes.Count <= 0) { return; }
            TreeNode NodeCopy = TV_Src.Nodes[0];
            TV_Src.Nodes[0].Remove();
            TV_Dst.Nodes.Add(NodeCopy);

        }

    }
}
