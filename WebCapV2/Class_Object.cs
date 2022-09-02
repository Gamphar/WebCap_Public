using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.Internals;
//using CefSharp.OffScreen;

namespace WebCapV2
{
    class Class_Object
    {
    }
    public partial class Form_Downloader : Form
    {

    }

    public static class ISynchronizeInvokeExtensions
    {
        public static void InvokeEx<T>(this T @this, Action<T> action) where T : ISynchronizeInvoke
        {
            if (@this != null)
            {
                if (@this.InvokeRequired)
                {
                    @this.Invoke(action, new object[] { @this });
                }
                else
                {
                    action(@this);
                }
            }
        }
    }

    

    //======================================================================================
    //======================================================================================Setting

    public class SettingGlobal
    {
        public string ExeDir { get; set; }
        public string BaseSettingDir { get; set; }
        public string BaseSettingFilePath { get; set; }
        public string RawJsonDir { get; set; }
    }
    public class SettingTitleSelectionData
    {
        public string KomikRootDir { get; set; }
        public string JsonFilePath { get; set; }
    }
    //======================================================================================Setting
    //======================================================================================
    public class ActiveTitleListInfo
    {
        public TreeView ActiveTV { get; set; }
        public string DataPath { get; set; }
    }
    //======================================================================================
    //check numbering chapter
    public class ChapterNumbering
    {
        public int iMajor { get; set; }
        public List<int> iMinors { get; set; }
    }
    //======================================================================================

    public class ChapterInfoData
    {
        public string result { get; set; }
        public string response { get; set; }
        public CID_data0 data { get; set; }

    }

    public class CID_data0
    {
        public string id { get; set; }
        public string type { get; set; }
        public CID_Attributes0 attributes { get; set; }
        public IList<CID_relationships0> relationships { get; set; }
    }

    public class CID_Attributes0
    {
        //local field
        private LangObject0 _description;
        private bool _isSetDescription_error;
        private int _iError = 0;

        //public properties
        public LangObject0 title { get; set; }
        public LangObject0 description
        {
            get { return _description; }
            set
            {
                //if no description then we dont care, just set it null object, so no error message because no error itended.
                //ahaha if using get set normal this will throw error when used in CID = JsonConvert.DeserializeObject<ChapterInfoData>(JSON_ChapterInfo);
                //so _isSetDescription_error is always false, cus everyting is ok now
                try
                {
                    _description = value;
                    _isSetDescription_error = false;
                    
                }
                catch (Exception)
                {
                    
                    //throw;
                    _description=null;
                    _isSetDescription_error = true;
                    _iError++;
                }   
            } 
        }
        public string contentRating { get; set; }

        public bool isSetDescription_error { get { return _isSetDescription_error; } }
        public int iError { get { return _iError; } }
    }

    public class LangObject0
    {
        public string en { get; set; }
        public string ru { get; set; }
        public string fa { get; set; }
        public string th { get; set; }
        public string ja { get; set; }
        public string zh { get; set; }
        public string zh_hk { get; set; }
        public string ko { get; set; }
    }

    public class CID_relationships0
    {
        public string id { get; set; }
        public string type { get; set; }
        public CID_Attributes1 attributes { get; set; }
    }

    public class CID_Attributes1
    {
        public string name { get; set; } //untuk type artist dan author
        public string fileName { get; set; } //untuk type cover_art
    }

    public class ChapterHostData
    {
        public string result { get; set; }
        public string baseUrl { get; set; }

        public chapterObject0 chapter { get; set; } //added per 2022-1=01-16, 10.33
    }

    public class chapterObject0
    {
        public string hash { get; set; }
        public IList<string> data { get; set; }
        public IList<string> dataSaver { get; set; }

    }

    public class ChapterListData
    {
        public string result { get; set; }
        public string response { get; set; }

        public IList<dataObject0> data { get; set; }

        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }

    public class dataObject0
    {
        public string id { get; set; }
        public string type { get; set; }
        public attributesObject1 attributes { get; set; }
        public IList<relationshipsObject1> relationships { get; set; }

    }

    public class attributesObject1
    {
        public string volume { get; set; }
        public string chapter { get; set; }
        public string title { get; set; }
        public string translatedLanguage { get; set; }
        public string hash { get; set; }
        public IList<string> data { get; set; } //per 10-01-2022 some title not using this but using pages below
        public IList<string> dataSaver { get; set; }
        public string externalUrl { get; set; }

        public DateTime publishAt { get; set; }
        public DateTime createdAt { get; set; }
        public DateTime updatedAt { get; set; }
        public int pages { get; set; } //added per 10-01-2022, so now no more image name but direct image count 
        public int version { get; set; }

    }

    public class relationshipsObject1
    {
        public string id { get; set; }
        public string type { get; set; }
        public attributesObject2 attributes { get; set; }
    }


    public class attributesObject2
    {
        //scan group
        public string name { get; set; }
        public IList<altNamesObject1> altNames { get; set; }
        public bool locked { get; set; }
        public string website { get; set; }
        public IList<string> focusedLanguages { get; set; }
        public int version { get; set; }


        //user
        public string username { get; set; }
        public IList<string> roles { get; set; }
    }

    public class altNamesObject1
    {
        public string en { get; set; }
    }

    //==============================================================1
    public class ImageData
    {
        public string ImagePageURL { get; set; }
        public string ImageURL { get; set; }
        public string ImageExt { get; set; }
        public string ImageSize { get; set; }
        public int IDone { get; set; }
    }
    public class ChapterData
    {
        public string ChapterName { get; set; }
        public IList<ImageData> images { get; set; }

        public string TotalImage { get; set; }
        public string status { get; set; }
        public string startDate { get; set; }
        public string ChapterID { get; set; }
        public string ChapterHash { get; set; }
        public string AttVolume { get; set; } //attribute volume, volume number, value = "none" or number
        public string AttChapter { get; set; } //attribute chapter, chapter number, value = "none" or number 
        public string ImageHost { get; set; }
    }

    public class TaskDownloadData
    {
        public string TaskName { get; set; }
        public IList<ChapterData> Chapters { get; set; }
        public string TitleName { get; set; }
        public string ChapterListPageUrl { get; set; }
        public string SiteSource { get; set; }
        public string DatetimeAdded { get; set; }
        public string RetryCount { get; set; }

    }

    public class TaskListData
    {
        public IList<TaskDownloadData> TaskList { get; set; }

        public TaskListData() { }
        public TaskListData(TaskListData TLD) //neded for copy object
        {
            TaskList = TLD.TaskList;
        }
    }

    //==============================================================1
    //==============================================================2 DL

    public class DL_relationship
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class DL_attributes
    {
        public string volume { get; set; }
        public string chapter { get; set; }
        public string title { get; set; }
        public string translatedLanguage { get; set; }
        public string hash { get; set; }
        public IList<string> data { get; set; }
        public IList<string> dataSaver { get; set; }
        public string externalUrl { get; set; }
        public string publishAt { get; set; }
        public string createdAt { get; set; }
        public string updatedAt { get; set; }
        public int version { get; set; }
    }

    public class DL_data
    {
        public string id { get; set; }
        public string type { get; set; }
        public DL_attributes attributes { get; set; }
        public IList<DL_relationship> relationships { get; set; }
    }

    public class DL_imageDownloadData
    {
        public string result { get; set; }
        public string response { get; set; }
        public IList<DL_data> data { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public int total { get; set; }
    }
    //==============================================================2 DL END
    //==============================================================3
    


    public class SiteSourceData
    {
        public string SiteSourceName { get; set; }
        public string ChpaterListPageURL { get; set; }
        public IList<string> TitleAliases { get; set; }
    }

    public class TitleData
    {
        public string TitleName { get; set; }
        public IList<SiteSourceData> SiteSources { get; set; }
    }

    public class TitleListData
    {
        public IList<TitleData> Titles { get; set; }
    }


    //==============================================================3 END

    public interface IResourceRequestHandlerFactory
    {
        /// <summary>
        /// Are there any <see cref="ResourceHandler"/>'s registered?
        /// </summary>
        bool HasHandlers { get; }

        /// <summary>
        /// Called on the CEF IO thread before a resource request is initiated.
        /// </summary>
        /// <param name="chromiumWebBrowser">the ChromiumWebBrowser control</param>
        /// <param name="browser">represent the source browser of the request</param>
        /// <param name="frame">represent the source frame of the request</param>
        /// <param name="request">represents the request contents and cannot be modified in this callback</param>
        /// <param name="isNavigation">will be true if the resource request is a navigation</param>
        /// <param name="isDownload">will be true if the resource request is a download</param>
        /// <param name="requestInitiator">is the origin (scheme + domain) of the page that initiated the request</param>
        /// <param name="disableDefaultHandling">to true to disable default handling of the request, in which case it will need to be handled via <see cref="IResourceRequestHandler.GetResourceHandler"/> or it will be canceled</param>
        /// <returns>To allow the resource load to proceed with default handling return null. To specify a handler for the resource return a <see cref="IResourceRequestHandler"/> object. If this callback returns null the same method will be called on the associated <see cref="IRequestContextHandler"/>, if any</returns>
        IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling);
    }

    public class ResourceRequestHandlerFactory : IResourceRequestHandlerFactory
    {
        /// <summary>
        /// Resource handler thread safe dictionary
        /// </summary>
        public ConcurrentDictionary<string, ResourceRequestHandlerFactoryItem> Handlers { get; private set; }

        /// <summary>
        /// Create a new instance of DefaultResourceHandlerFactory
        /// </summary>
        /// <param name="comparer">string equality comparer</param>
        public ResourceRequestHandlerFactory(IEqualityComparer<string> comparer = null)
        {
            Handlers = new ConcurrentDictionary<string, ResourceRequestHandlerFactoryItem>(comparer ?? StringComparer.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Register a handler for the specified Url
        /// </summary>
        /// <param name="url">url</param>
        /// <param name="data">The data in byte[] format that will be used for the response</param>
        /// <param name="mimeType">mime type</param>
        /// <param name="oneTimeUse">Whether or not the handler should be used once (true) or until manually unregistered (false)</param>
        /// <returns>returns true if the Url was successfully parsed into a Uri otherwise false</returns>
        public virtual bool RegisterHandler(string url, byte[] data, string mimeType = ResourceHandler.DefaultMimeType, bool oneTimeUse = false)
        {
            Uri uri;
            if (Uri.TryCreate(url, UriKind.Absolute, out uri))
            {
                var entry = new ResourceRequestHandlerFactoryItem(data, mimeType, oneTimeUse);

                Handlers.AddOrUpdate(uri.AbsoluteUri, entry, (k, v) => entry);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Unregister a handler for the specified Url
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>returns true if successfully removed</returns>
        public virtual bool UnregisterHandler(string url)
        {
            ResourceRequestHandlerFactoryItem entry;
            return Handlers.TryRemove(url, out entry);
        }

        /// <summary>
        /// Are there any <see cref="ResourceHandler"/>'s registered?
        /// </summary>
        bool IResourceRequestHandlerFactory.HasHandlers
        {
            get { return Handlers.Count > 0; }
        }

        /// <inheritdoc /> 
        IResourceRequestHandler IResourceRequestHandlerFactory.GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return GetResourceRequestHandler(chromiumWebBrowser, browser, frame, request, isNavigation, isDownload, requestInitiator, ref disableDefaultHandling);
        }

        /// <summary>
        /// Called on the CEF IO thread before a resource request is initiated.
        /// </summary>
        /// <param name="chromiumWebBrowser">the ChromiumWebBrowser control</param>
        /// <param name="browser">represent the source browser of the request</param>
        /// <param name="frame">represent the source frame of the request</param>
        /// <param name="request">represents the request contents and cannot be modified in this callback</param>
        /// <param name="isNavigation">will be true if the resource request is a navigation</param>
        /// <param name="isDownload">will be true if the resource request is a download</param>
        /// <param name="requestInitiator">is the origin (scheme + domain) of the page that initiated the request</param>
        /// <param name="disableDefaultHandling">to true to disable default handling of the request, in which case it will need to be handled via <see cref="IResourceRequestHandler.GetResourceHandler"/> or it will be canceled</param>
        /// <returns>To allow the resource load to proceed with default handling return null. To specify a handler for the resource return a <see cref="IResourceRequestHandler"/> object. If this callback returns null the same method will be called on the associated <see cref="IRequestContextHandler"/>, if any</returns>
        protected virtual IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            try
            {
                ResourceRequestHandlerFactoryItem entry;

                if (Handlers.TryGetValue(request.Url, out entry))
                {
                    if (entry.OneTimeUse)
                    {
                        Handlers.TryRemove(request.Url, out entry);
                    }

                    return new InMemoryResourceRequestHandler(entry.Data, entry.MimeType);
                }

                return null;
            }
            finally
            {
                request.Dispose();
            }
        }
    }

    public class DownloadItem
    {
        /// <summary>
        /// Returns true if this object is valid. Do not call any other methods if this function returns false.
        /// </summary>
        public bool IsValid { get; set; }

        /// <summary>
        /// Returns true if the download is in progress.
        /// </summary>
        public bool IsInProgress { get; set; }

        /// <summary>
        /// Returns true if the download is complete.
        /// </summary>
        public bool IsComplete { get; set; }

        /// <summary>
        /// Returns true if the download has been canceled or interrupted.
        /// </summary>
        public bool IsCancelled { get; set; }

        /// <summary>
        /// Returns a simple speed estimate in bytes/s.
        /// </summary>
        public Int64 CurrentSpeed { get; set; }

        /// <summary>
        /// Returns the rough percent complete or -1 if the receive total size is unknown.
        /// </summary>
        public int PercentComplete { get; set; }

        /// <summary>
        /// Returns the total number of bytes.
        /// </summary>
        public Int64 TotalBytes { get; set; }

        /// <summary>
        /// Returns the number of received bytes.
        /// </summary>
        public Int64 ReceivedBytes { get; set; }

        /// <summary>
        /// Returns the time that the download started
        /// </summary>
        public DateTime? StartTime { get; set; }

        /// <summary>
        /// Returns the time that the download ended
        /// </summary>
        public DateTime? EndTime { get; set; }

        /// <summary>
        /// Returns the full path to the downloaded or downloading file.
        /// </summary>
        public string FullPath { get; set; }

        /// <summary>
        /// Returns the unique identifier for this download.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Returns the URL.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Returns the suggested file name.
        /// </summary>
        public string SuggestedFileName { get; set; }

        /// <summary>
        /// Returns the content disposition.
        /// </summary>
        public string ContentDisposition { get; set; }

        /// <summary>
        /// Returns the mime type.
        /// </summary>
        public string MimeType { get; set; }
    }

    public interface IDownloadHandler
    {
        /// <summary>
        /// Called before a download begins.
        /// </summary>
        /// <param name="downloadItem">Represents the file being downloaded.</param>
        /// <param name="downloadPath">Path where the file will be saved if <see cref="showDialog"/> is False.</param>
        /// <param name="showDialog">Display a dialog allowing the user to specify a custom path and filename.</param>
        /// <returns>Return True to continue the download otherwise return False to cancel the download</returns>
        bool OnBeforeDownload(DownloadItem downloadItem, out string downloadPath, out bool showDialog);

        /// <summary>
        /// Called when a download's status or progress information has been updated. This may be called multiple times before and after <see cref="OnBeforeDownload"/>.
        /// </summary>
        /// <param name="downloadItem">Represents the file being downloaded.</param>
        /// <returns>Return True to cancel, otherwise False to allow the download to continue.</returns>
        bool OnDownloadUpdated(DownloadItem downloadItem);
    }

    //public class DownloadHandler : CefSharp.Handler.DownloadHandler
    //{
    //    public bool OnBeforeDownload(DownloadItem downloadItem, out string downloadPath, out bool showDialog)
    //    {
    //        downloadPath = downloadItem.SuggestedFileName;
    //        showDialog = true;

    //        return true;
    //    }

    //    public bool OnDownloadUpdated(DownloadItem downloadItem)
    //    {
    //        return false;
    //    }
    //}

    //public class DownloadHandler : IDownloadHandler
    //{
    //    public event EventHandler<DownloadItem> OnBeforeDownloadFired;

    //    public event EventHandler<DownloadItem> OnDownloadUpdatedFired;

    //    public void OnBeforeDownload(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IBeforeDownloadCallback callback)
    //    {
    //        OnBeforeDownloadFired?.Invoke(this, downloadItem);

    //        if (!callback.IsDisposed)
    //        {
    //            using (callback)
    //            {
    //                callback.Continue(downloadItem.SuggestedFileName, showDialog: true);
    //            }
    //        }
    //    }

    //    public void OnDownloadUpdated(IWebBrowser chromiumWebBrowser, IBrowser browser, DownloadItem downloadItem, IDownloadItemCallback callback)
    //    {
    //        OnDownloadUpdatedFired?.Invoke(this, downloadItem);
    //    }
    //}



    public class CustomResourceRequestHandler : CefSharp.Handler.ResourceRequestHandler
    {
        protected override IResourceHandler GetResourceHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request)
        {
            //ResourceHandler has many static methods for dealing with Streams, 
            // byte[], files on disk, strings
            // Alternatively ou can inheir from IResourceHandler and implement
            // a custom behaviour that suites your requirements.
            return ResourceHandler.FromString("Welcome to CefSharp!", mimeType: Cef.GetMimeType("html"));
        }
    }

    public class CustomRequestHandler : CefSharp.Handler.RequestHandler
    {
        public Form_Downloader FDownloader;

        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            //Only intercept specific Url's
            //Console.WriteLine(request.Url);
            if (FDownloader != null)
            {
                FDownloader.Log3("request.Url = "+ request.Url);
            }
            if (request.Url.ToLower().Contains(".jpg"))
            {
                FDownloader.Log3("inttercept req JPG image");
                FDownloader.imgUrls.Add(request.Url);
                
            }
            if (request.Url == "https://cefsharp.test/")
            {
                return new CustomResourceRequestHandler();
            }
            //Default behaviour, url will be loaded normally.
            return null;
        }
    }

    public class CWB_Helper
    {
        public void takeScreenShot(CefSharp.OffScreen.ChromiumWebBrowser aBrowser)
        {
            //var scriptTask = aBrowser.EvaluateScriptAsync("document.querySelector('[name=q]').value = 'CefSharp Was Here!'");
            //if (scriptTask != null)
            //{
                var task = aBrowser.ScreenshotAsync();
                task.ContinueWith(x =>
                {
                    // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                    //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");
                    var screenshotPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp screenshot.png");

                    //Console.WriteLine();
                    //Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                    //Log2("-");
                    //Log2("Screenshot ready. Saving to {0}", screenshotPath);

                    // Save the Bitmap to the path.
                    // The image type is auto-detected via the ".png" extension.
                    task.Result.Save(screenshotPath);

                    // We no longer need the Bitmap.
                    // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                    task.Result.Dispose();

                    //Log2("Screenshot saved.  Launching your default image viewer...");

                    // Tell Windows to launch the saved image.
                    Process.Start(new ProcessStartInfo(screenshotPath)
                    {
                        // UseShellExecute is false by default on .NET Core.
                        UseShellExecute = true
                    });

                    //Log2("Image viewer launched.  Press any key to exit.");
                }, TaskScheduler.Default);
            //}
        }
    }


    public class NodeSorter : IComparer
    {
        // Compare the length of the strings, or the strings
        // themselves, if they are the same length.
        private bool bAllowSorting = true;

        public void Set_AllowSorting(bool b)
        {
            bAllowSorting = b;
        }

        public int Compare(object x, object y)
        {
            TreeNode tx = x as TreeNode;
            TreeNode ty = y as TreeNode;

            if (bAllowSorting)
            {
                if (tx.Level == 0)
                {


                    return string.Compare(tx.Text, ty.Text);


                }
                else
                {
                    return tx.Index.CompareTo(ty.Index);
                }
            }
            else
            {
                return 0;
            }
            


            
        }
    }

}
