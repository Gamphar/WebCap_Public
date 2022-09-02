using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;

using System.Windows.Forms;
using CefSharp;
using CefSharp.OffScreen;
using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace WebCapV2
{
    class Class_MangaDex
    {
    }
    public partial class Form_Test : Form
    {


        private ChromiumWebBrowser browser2;

        public void Log2(string msg)
        {
            string titleInfo = "log";
            Console.WriteLine("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            msg = String.Format("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            this.InvokeEx(f => f.textBox_log2.AppendText(msg + "\r\n"));
        }

        public void Log2(string msg, params object[] o)
        {


            msg = String.Format(msg,
                              o);


            this.InvokeEx(f => f.textBox_log2.AppendText(msg + "\r\n"));

        }


        

        private void Browser2_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Check to see if loading is complete - this event is called twice, one when loading starts
            // second time when it's finished
            // (rather than an iframe within the main frame).
            if (!e.IsLoading)
            {
                // Remove the load event handler, because we only want one snapshot of the initial page.
                //browser2.LoadingStateChanged -= BrowserLoadingStateChanged;

                var scriptTask = browser2.EvaluateScriptAsync("document.querySelector('[name=q]').value = 'CefSharp Was Here!'");

                scriptTask.ContinueWith(t =>
                {
                    //Give the browser a little time to render
                    Thread.Sleep(5000);
                    // Wait for the screenshot to be taken.
                    takeScreenShot2(browser2);
                });
            }
        }


        private void Browser2_LoadingStateChanged1(object sender, LoadingStateChangedEventArgs e)
        {
            // Check to see if loading is complete - this event is called twice, one when loading starts
            // second time when it's finished
            // (rather than an iframe within the main frame).
            if (!e.IsLoading)
            {
                // Remove the load event handler, because we only want one snapshot of the initial page.
                //browser2.LoadingStateChanged -= BrowserLoadingStateChanged;
                Thread.Sleep(5000);
                Log2("not loading");
                Log2("res = "+browser2.GetTextAsync().Result);
            }
        }

        private void takeScreenShot2(ChromiumWebBrowser aBrowser)
        {
            var scriptTask = aBrowser.EvaluateScriptAsync("document.querySelector('[name=q]').value = 'CefSharp Was Here!'");
            if (scriptTask != null)
            {
                var task = aBrowser.ScreenshotAsync();
                task.ContinueWith(x =>
                {
                    // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                    //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");
                    var screenshotPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp screenshot.png");

                    //Console.WriteLine();
                    //Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                    Log2("-");
                    Log2("Screenshot ready. Saving to {0}", screenshotPath);

                    // Save the Bitmap to the path.
                    // The image type is auto-detected via the ".png" extension.
                    task.Result.Save(screenshotPath);

                    // We no longer need the Bitmap.
                    // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                    task.Result.Dispose();

                    Log2("Screenshot saved.  Launching your default image viewer...");

                    // Tell Windows to launch the saved image.
                    Process.Start(new ProcessStartInfo(screenshotPath)
                    {
                        // UseShellExecute is false by default on .NET Core.
                        UseShellExecute = true
                    });

                    Log2("Image viewer launched.  Press any key to exit.");
                }, TaskScheduler.Default);
            }
        }

        

        

 

       


    }


    //===========================================================================================================FORM DOWNLOAD START

    public partial class Form_Downloader : Form
    {



        bool IsNSFW = true;

        private string getURLApi_ChapterList_MangaDex(string URLChapterPage, int iOffset = 0, int iLimit = 96)
        {
            IList<string> URLChapterPagePathData = URLChapterPage.Split('/').ToList();

            //V1
            //https://api.mangadex.org/manga/24e5f5b0-c14b-4597-bb0a-606c583a657c/feed?
            //translatedLanguage%5B%5D=ja%2Cen
            //&limit=96
            //&includes%5B%5D=scanlation_group%2Cuser
            //&order%5Bvolume%5D=desc
            //&order%5Bchapter%5D=desc
            //&offset=0
            //&contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic



            /*
            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];
            string param_translatedLanguage = "translatedLanguage%5B%5D=en";
            string param_limit = "&limit=" + iLimit.ToString();
            string param_includes = "&includes%5B%5D=scanlation_group%2Cuser";
            string param_orderVolume = "&order%5Bvolume%5D=desc";
            string param_orderChapter = "&order%5Bchapter%5D=desc";
            string param_offset = "&offset=" + iOffset.ToString();
            //string param_contentRating = "&contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic"; //without user login the api will fail
            string param_contentRating = "";
            if (IsNSFW)
            {
                //param_contentRating = "&contentRating%5B%5D=pornographic"; //without user login the api will fail
                
            }
            param_contentRating = "&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica&contentRating%5B%5D=pornographic";
            */


            //V2
            //https://api.mangadex.org/manga/24e5f5b0-c14b-4597-bb0a-606c583a657c/feed?
            //translatedLanguage[]=ja
            //&translatedLanguage[]=en
            //&limit=96
            //&includes[]=scanlation_group
            //&includes[]=user
            //&order[volume]=desc
            //&order[chapter]=desc
            //&offset=0
            //&contentRating[]=safe
            //&contentRating[]=suggestive
            //&contentRating[]=erotica
            //&contentRating[]=pornographic

            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];
            string param_translatedLanguage = "translatedLanguage[]=ja&translatedLanguage[]=en";
            string param_limit = "&limit=" + iLimit.ToString();
            string param_includes = "&includes[]=scanlation_group&includes[]=user";
            string param_orderVolume = "&order[volume]=desc";
            string param_orderChapter = "&order[chapter]=desc";
            string param_offset = "&offset=" + iOffset.ToString();
            //string param_contentRating = "&contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic"; //without user login the api will fail
            string param_contentRating = "";
            if (IsNSFW)
            {
                //param_contentRating = "&contentRating%5B%5D=pornographic"; //without user login the api will fail

            }
            param_contentRating = "&contentRating[]=safe&contentRating[]=suggestive&contentRating[]=erotica&contentRating[]=pornographic";


            return string.Format("https://api.mangadex.org/manga/{0}/feed?{1}{2}{3}{4}{5}{6}{7}", titleID
                , param_translatedLanguage
                , param_limit
                , param_includes
                , param_orderVolume
                , param_orderChapter
                , param_offset
                , param_contentRating
                );
        }

        private string getURLApi_ChapterList(string URLChapterPage, int iOffset = 0, int iLimit = 96)
        {
            //sementara hanya ada mangadex, belum ada param constanta sitesource, adanya string sitrsource
            return getURLApi_ChapterList_MangaDex(URLChapterPage,  iOffset , iLimit);
        }


        private string getURLApi_ChapterInfo_MangaDex(string URLChapterPage)
        {
            IList<string> URLChapterPagePathData = URLChapterPage.Split('/').ToList();

            /*
             https://api.mangadex.org/manga/45d3ebca-8d74-4e51-be90-8582e4756cbd
            ?includes[]=artist
            &includes[]=author
            &includes[]=cover_art
             */
            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];
            string param_includes = "includes[]=artist&includes[]=author&includes[]=cover_art";
            

            return string.Format("https://api.mangadex.org/manga/{0}?{1}", titleID
                , param_includes
                );
            
        }

        private string getURLApi_ChapterInfo(string URLChapterPage)
        {
            //sementara hanya ada mangadex, belum ada param constanta sitesource, adanya string sitrsource
            return getURLApi_ChapterInfo_MangaDex(URLChapterPage);
        }

        private string getURLApi_ImageHost(string ChapterID, bool IsForcePort443 = false)
        {
            
            //https://api.mangadex.org/at-home/server/3e64b0b0-872c-43c4-9a4b-c3a12013bb6a?forcePort443=false
            string param_chapterID = ChapterID;
            string param_forcePort443 = @"forcePort443=false";
            if (IsForcePort443)
            {
                param_forcePort443 = @"forcePort443=true";
            }


            string URLApi_getImageHost = string.Format(@"https://api.mangadex.org/at-home/server/{0}?{1}", param_chapterID, param_forcePort443);
            Log3("getURLApi_ImageHost = {0}", URLApi_getImageHost);

            return URLApi_getImageHost;
        }

        private string getURLAPi_ImageList(string ChapterListPageUrl, string volume, string chapter, string lang = cstrLang_En)
        {
            /*
             * https://api.mangadex.org/chapter?
             * manga=52ede55c-1584-4019-b85b-3902a423c3ab
             * &volume=1
             * &chapter=1
             * &contentRating%5B%5D=safe%2Csuggestive%2Cerotica%2Cpornographic
             * &includes%5B%5D=scanlation_group%2Cuser
             */

            IList<string> URLChapterPagePathData = ChapterListPageUrl.Split('/').ToList();

            string titleID = URLChapterPagePathData[URLChapterPagePathData.Count - 1 - 1];

            string param_titleID = "manga="+titleID;
            string param_volume = "&volume="+volume;
            string param_chapter = "&chapter="+chapter;
            string param_include = @"&includes%5B%5D=scanlation_group%2Cuser";
            string param_contentRating = "";
            if (IsNSFW)
            {
                //param_contentRating = "&contentRating%5B%5D=pornographic"; //without user login the api will fail
            }
            param_contentRating = "&contentRating%5B%5D=safe&contentRating%5B%5D=suggestive&contentRating%5B%5D=erotica&contentRating%5B%5D=pornographic";

            return string.Format("https://api.mangadex.org/chapter?{0}{1}{2}{3}{4}", param_titleID, param_volume, param_chapter, param_include, param_contentRating);
        
        }

        private string getImageFileURL(string strImageHost, string strChapterHash, string ImgBaseFileUrl)
        {
            string ImageURL = string.Format("{0}/data/{1}/{2}", strImageHost, strChapterHash, ImgBaseFileUrl);
            return ImageURL;
        }


    }

    //===========================================================================================================FORM DOWNLOAD END

    public class DefaultRequestHandler : IRequestHandler
    {

        public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            /*if (request.Headers["X-Requested-With"] != "XMLHttpRequest" ||
                response.ResponseHeaders["Content-Type"].Contains("application/json")) return null;*/

            if (!response.Headers["Content-Type"].Contains("application/json"))
            {
                return null;
            }

            var filter = FilterManager.CreateFilter(request.Identifier.ToString());

            return filter;
        }

        public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request,
            IResponse response, UrlRequestStatus status, long receivedContentLength)
        {
            if (!response.Headers["Content-Type"].Contains("application/json"))
            {
                return;
            }

            var filter = FilterManager.GetFileter(request.Identifier.ToString()) as TestJsonFilter;

            if (filter != null)
            {
                //Console.WriteLine(filter.DataAll);
                ASCIIEncoding encoding = new ASCIIEncoding();
                string data = encoding.GetString(filter.DataAll.ToArray());
                Console.WriteLine(data);
            }
                
        }

        public bool GetAuthCredentials(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            return false;
        }

        public IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return null;
        }

        public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            return false;
        }

        public bool OnCertificateError(IWebBrowser chromiumWebBrowser, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
        {
            return false;
        }

        public void OnDocumentAvailableInMainFrame(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            return;
        }

        public bool OnOpenUrlFromTab(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
        {
            return false;
        }

        public void OnPluginCrashed(IWebBrowser chromiumWebBrowser, IBrowser browser, string pluginPath)
        {
            return;
        }

        public bool OnQuotaRequest(IWebBrowser chromiumWebBrowser, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
        {
            return false;
        }

        public void OnRenderProcessTerminated(IWebBrowser chromiumWebBrowser, IBrowser browser, CefTerminationStatus status)
        {
            throw new NotImplementedException();
        }

        public void OnRenderViewReady(IWebBrowser chromiumWebBrowser, IBrowser browser)
        {
            //throw new NotImplementedException();
            return;
        }

        public bool OnSelectClientCertificate(IWebBrowser chromiumWebBrowser, IBrowser browser, bool isProxy, string host, int port, X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
        {
            //throw new NotImplementedException();
            return false;
        }
    }






    public class TestJsonFilter : IResponseFilter
    {
        public List<byte> DataAll = new List<byte>();

        public FilterStatus Filter(System.IO.Stream dataIn, out long dataInRead, System.IO.Stream dataOut, out long dataOutWritten)
        {
            try
            {
                if (dataIn == null || dataIn.Length == 0)
                {
                    dataInRead = 0;
                    dataOutWritten = 0;

                    return FilterStatus.Done;
                }

                dataInRead = dataIn.Length;
                dataOutWritten = Math.Min(dataInRead, dataOut.Length);

                dataIn.CopyTo(dataOut);
                dataIn.Seek(0, SeekOrigin.Begin);
                byte[] bs = new byte[dataIn.Length];
                dataIn.Read(bs, 0, bs.Length);
                DataAll.AddRange(bs);

                dataInRead = dataIn.Length;
                dataOutWritten = dataIn.Length;

                return FilterStatus.NeedMoreData;
            }
            catch (Exception ex)
            {
                dataInRead = dataIn.Length;
                dataOutWritten = dataIn.Length;

                return FilterStatus.Done;
            }
        }

        public bool InitFilter()
        {
            return true;
        }

        public void Dispose()
        {

        }
    }

    public class FilterManager
    {
        private static Dictionary<string, IResponseFilter> dataList = new Dictionary<string, IResponseFilter>();

        public static IResponseFilter CreateFilter(string guid)
        {
            lock (dataList)
            {
                var filter = new TestJsonFilter();
                dataList.Add(guid, filter);

                return filter;
            }
        }

        public static IResponseFilter GetFileter(string guid)
        {
            lock (dataList)
            {
                return dataList[guid];
            }
        }
    }




}
