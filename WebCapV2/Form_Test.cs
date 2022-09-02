using System;
using System.Collections.Generic;
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
using System.Runtime.InteropServices;

namespace WebCapV2
{
    public partial class Form_Test : Form
    {
        public Form_Test()
        {
            InitializeComponent();
        }
        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool AllocConsole();

        private static ChromiumWebBrowser browser;

        




        private void button1_Click(object sender, EventArgs e)
        {
            //
            
        }

        private void btn_cap_3_Click(object sender, EventArgs e)
        {


            Log("Start Cap");
            const string UrlString = "https://www.google.com/";

            /*
            string DirPath_Cache = Path.Combine( Path.GetDirectoryName(Application.ExecutablePath), "CefSharp\\Cache");
            if (!Directory.Exists(DirPath_Cache)) { Directory.CreateDirectory(DirPath_Cache); }

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
                CachePath = DirPath_Cache
            };
            */

            //Perform dependency check to make sure all relevant resources are in our output directory.
            //Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            Log("Init Cap");
            // Create the offscreen Chromium browser.
            browser = new ChromiumWebBrowser(UrlString);

            // An event that is fired when the first page is finished loading.
            // This returns to us from another thread.
            browser.LoadingStateChanged += BrowserLoadingStateChanged;

            Log("Wait to Cap");

            // We have to wait for something, otherwise the process will exit too soon.
            //Console.ReadKey();

            //Thread.Sleep(500);

            // Clean up Chromium objects.  You need to call this in your application otherwise
            // you will get a crash when closing.
            //Cef.Shutdown();


            //end you
        }

        private void BrowserLoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Check to see if loading is complete - this event is called twice, one when loading starts
            // second time when it's finished
            // (rather than an iframe within the main frame).
            if (!e.IsLoading)
            {
                // Remove the load event handler, because we only want one snapshot of the initial page.
                browser.LoadingStateChanged -= BrowserLoadingStateChanged;

                var scriptTask = browser.EvaluateScriptAsync("document.querySelector('[name=q]').value = 'CefSharp Was Here!'");

                scriptTask.ContinueWith(t =>
                {
                    //Give the browser a little time to render
                    Thread.Sleep(500);
                    // Wait for the screenshot to be taken.
                    var task = browser.ScreenshotAsync();
                    task.ContinueWith(x =>
                    {
                        // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                        //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");
                        var screenshotPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp screenshot.png");
                        
                        //Console.WriteLine();
                        //Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                        Log("-");
                        Log("Screenshot ready. Saving to {0}", screenshotPath);

                        // Save the Bitmap to the path.
                        // The image type is auto-detected via the ".png" extension.
                        task.Result.Save(screenshotPath);

                        // We no longer need the Bitmap.
                        // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                        task.Result.Dispose();

                        Log("Screenshot saved.  Launching your default image viewer...");

                        // Tell Windows to launch the saved image.
                        Process.Start(new ProcessStartInfo(screenshotPath)
                        {
                            // UseShellExecute is false by default on .NET Core.
                            UseShellExecute = true
                        });

                        Log("Image viewer launched.  Press any key to exit.");
                    }, TaskScheduler.Default);
                });
            }
        }

        public void Log(string msg)
        {
            string titleInfo = "log";
            Console.WriteLine("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            msg = String.Format("Thread ({0}) info: {1}:: {2}.",
                              Thread.CurrentThread.ManagedThreadId, titleInfo, msg);

            this.InvokeEx(f => f.textBox_log.AppendText(msg + "\r\n"));
        }

        public void Log(string msg, params object[] o)
        {


            msg = String.Format(msg,
                              o);


            this.InvokeEx(f => f.textBox_log.AppendText(msg + "\r\n"));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
#if ANYCPU
            //Only required for PlatformTarget of AnyCPU
            CefRuntime.SubscribeAnyCpuAssemblyResolver();
            Log("SubscribeAnyCpuAssemblyResolver");
#endif

            string DirPath_Cache = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp\\Cache");

            if (!Directory.Exists(DirPath_Cache)) { Directory.CreateDirectory(DirPath_Cache); }

            var settings = new CefSettings()
            {
                //By default CefSharp will use an in-memory cache, you need to specify a Cache Folder to persist data
                //CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
                CachePath = DirPath_Cache
            };

            //Perform dependency check to make sure all relevant resources are in our output directory.
            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            AllocConsole();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Clean up Chromium objects.  You need to call this in your application otherwise
            // you will get a crash when closing.
            Cef.Shutdown();
        }

        private void btn_cap_M_Click(object sender, EventArgs e)
        {
            Log("Start Cap");
            const string UrlString = "https://rawkuma.com/sukoppu-musou-sukoppu-hadou-hou-chapter-6/";

            

            Log("Init Cap");
            // Create the offscreen Chromium browser.
            browser = new ChromiumWebBrowser(UrlString);
            browser.Size = new Size(1360, 1080);

            // An event that is fired when the first page is finished loading.
            // This returns to us from another thread.
            browser.LoadingStateChanged += BrowserLoadingState2Changed;

            Log("Wait to Cap");
        }

        private void BrowserLoadingState2Changed(object sender, LoadingStateChangedEventArgs e)
        {
            // Check to see if loading is complete - this event is called twice, one when loading starts
            // second time when it's finished
            // (rather than an iframe within the main frame).
            if (!e.IsLoading)
            {
                // Remove the load event handler, because we only want one snapshot of the initial page.
                browser.LoadingStateChanged -= BrowserLoadingStateChanged;

                var scriptTask = browser.EvaluateScriptAsync("document.querySelector('[name=s]').value = 'CefSharp Was Here!'");

                scriptTask.ContinueWith(t =>
                {
                    //Give the browser a little time to render
                    Thread.Sleep(500);
                    // Wait for the screenshot to be taken.
                    var task = browser.ScreenshotAsync();
                    task.ContinueWith(x =>
                    {
                        // Make a file to save it to (e.g. C:\Users\jan\Desktop\CefSharp screenshot.png)
                        //var screenshotPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "CefSharp screenshot.png");
                        var screenshotPath = Path.Combine(Path.GetDirectoryName(Application.ExecutablePath), "CefSharp screenshot.png");

                        //Console.WriteLine();
                        //Console.WriteLine("Screenshot ready. Saving to {0}", screenshotPath);

                        Log("-");
                        Log("Screenshot ready. Saving to {0}", screenshotPath);

                        // Save the Bitmap to the path.
                        // The image type is auto-detected via the ".png" extension.
                        task.Result.Save(screenshotPath);

                        // We no longer need the Bitmap.
                        // Dispose it to avoid keeping the memory alive.  Especially important in 32-bit applications.
                        task.Result.Dispose();

                        Log("Screenshot saved.  Launching your default image viewer...");

                        // Tell Windows to launch the saved image.
                        Process.Start(new ProcessStartInfo(screenshotPath)
                        {
                            // UseShellExecute is false by default on .NET Core.
                            UseShellExecute = true
                        });

                        Log("Image viewer launched.  Press any key to exit.");
                    }, TaskScheduler.Default);
                });
            }
        }

        private void btn_go_mangaDex_Click(object sender, EventArgs e)
        {

            Log2("Start Cap");
            const string UrlString = @"https://mangadex.org/title/99182618-ae92-4aec-a5df-518659b7b613/rebuild-world";
            textBox_url2.Text = UrlString;


            Log2("Init Mangadex");
            // Create the offscreen Chromium browser.
            //if (browser2 == null)
            //{
                browser2 = new ChromiumWebBrowser(UrlString);
                browser2.Size = new Size(1360, 1080);
                // An event that is fired when the first page is finished loading.
                // This returns to us from another thread.
                browser2.LoadingStateChanged += Browser2_LoadingStateChanged;
            //}
            //browser2.LoadUrlAsync(UrlString);



            Log2("Wait to Cap");

        }

        private void btn_go2url_Click(object sender, EventArgs e)
        {
            string UrlString = textBox_url2.Text;

            chromiumWebBrowser1.Load(UrlString);


            Log2(chromiumWebBrowser1.Text);

            return;
            

            if (browser2 == null)
            {
                browser2 = new ChromiumWebBrowser(UrlString);
                browser2.Size = new Size(1360, 1080);
                // An event that is fired when the first page is finished loading.
                // This returns to us from another thread.
                browser2.LoadingStateChanged += Browser2_LoadingStateChanged1;
                //Log2(browser2.GetTextAsync().Result);
            }
            else
            {
                //browser2.LoadUrlAsync(UrlString);
                browser2.Load(UrlString);
               
            }



        }

        private void btn_test1_Click(object sender, EventArgs e)
        {



            var wb = new ChromiumWebBrowser("http://www.bilibili.com/video/av8503878/");

            //Dock = DockStyle.Fill,
            wb.RequestHandler = new DefaultRequestHandler();
            //Log2( ((DefaultRequestHandler)wb.RequestHandler).ToString() );







            return;
            //=====================

            //browser2.ViewSource();
            browser2.GetSourceAsync().ContinueWith(taskHtml =>
            {
                var html = taskHtml.Result;
                Log2(html);
            });



            return;
            //===================================================
            //.gap - 6 > div:nth - child(2)
            var scriptTask = browser2.EvaluateScriptAsync("document.querySelector('.gap - 6 > div:nth - child(2)').InnerText ");
            Log2(scriptTask.Result.ToString());


        }

        private void button3_Click(object sender, EventArgs e)
        {
            Log2(chromiumWebBrowser1.GetTextAsync().Result);
        }

        private void chromiumWebBrowser1_ConsoleMessage(object sender, ConsoleMessageEventArgs e)
        {

        }

        private void chromiumWebBrowser1_FrameLoadEnd(object sender, FrameLoadEndEventArgs e)
        {
           
        }

        private void chromiumWebBrowser1_JavascriptMessageReceived(object sender, JavascriptMessageReceivedEventArgs e)
        {
            
        }

        private void btn_cap2_Click(object sender, EventArgs e)
        {

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

    
    
}
