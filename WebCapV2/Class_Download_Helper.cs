using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WebCapV2
{
    class Class_Download_Helper
    {
    }

    public class Download
    {
        public event EventHandler<DownloadStatusChangedEventArgs> DownloadStatusChanged;
        public event EventHandler<DownloadProgressChangedEventArgs> DownloadProgressChanged;
        public event EventHandler DownloadCompleted;

        public Form_Downloader FDownload;

        public void Log(string msg)
        {
            if (FDownload != null)
            {
                FDownload.Log3(msg);
            }
            
        }

        public void Log(string msg, params object[] o)
        {

            if (FDownload != null)
            {
                FDownload.Log3(msg, o);
            }
                

        }

        public bool stop = true; // by default stop is true

        public void DownloadFile(string DownloadLink, string Path)
        {
            stop = false; // always set this bool to false, everytime this method is called

            long ExistingLength = 0;
            FileStream saveFileStream;

            if (File.Exists(Path))
            {
                FileInfo fileInfo = new FileInfo(Path);
                ExistingLength = fileInfo.Length;
                Log("Old file data size = {0}", ExistingLength);
               
            }

            if (ExistingLength > 0)
            {
                saveFileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite);
            }
            else
            {
                saveFileStream = new FileStream(Path, FileMode.Create, FileAccess.Write, FileShare.ReadWrite);
            }



            

            try
            {

                //===============================================================================1
                //var request0 = (HttpWebRequest)HttpWebRequest.Create(DownloadLink);
                //request0.Proxy = null;
                long totalSize = 0;
                try
                {
                    var request0 = (HttpWebRequest)HttpWebRequest.Create(DownloadLink);
                    request0.Proxy = null;
                    //
                    using (var response = (HttpWebResponse)request0.GetResponse())
                    {
                        totalSize = response.ContentLength;
                    }
                }
                catch (Exception ex)
                {
                    //
                    Log(ex.Message);
                }


                //
                //cek if already completed
                if (ExistingLength == totalSize)
                {
                    Log("File already complete {0}", ExistingLength);
                    var args = new DownloadProgressChangedEventArgs();
                    args.TotalBytesToReceive = ExistingLength;
                    args.ProgressPercentage = 100;
                    OnDownloadProgressChanged(args);

                    var completedArgs0 = new EventArgs();
                    OnDownloadCompleted(completedArgs0);
                    return;
                }



                var request = (HttpWebRequest)HttpWebRequest.Create(DownloadLink);
                request.Proxy = null;
                request.AddRange(ExistingLength);
                //===============================================================================1


                using (var response = (HttpWebResponse)request.GetResponse())
                {
                    long FileSize = ExistingLength + response.ContentLength; //response.ContentLength gives me the size that is remaining to be downloaded
                    bool downloadResumable; // need it for sending empty progress

                    

                    if ((int)response.StatusCode == 206)
                    {
                        //Console.WriteLine("Resumable");
                        Log("Resumable");
                        var downloadStatusArgs = new DownloadStatusChangedEventArgs();
                        downloadResumable = true;
                        downloadStatusArgs.ResumeSupported = downloadResumable;
                        OnDownloadStatusChanged(downloadStatusArgs);
                    }
                    else // sometimes a server that supports partial content will lose its ability to send partial content(weird behavior) and thus the download will lose its resumability
                    {
                        //Console.WriteLine("Resume Not Supported");
                        Log("Resume Not Supported");
                        ExistingLength = 0;
                        var downloadStatusArgs = new DownloadStatusChangedEventArgs();
                        downloadResumable = false;
                        downloadStatusArgs.ResumeSupported = downloadResumable;
                        OnDownloadStatusChanged(downloadStatusArgs);
                        // restart downloading the file from the beginning because it isn't resumable
                        // if this isn't done, the method downloads the file from the beginning and starts writing it after the previously half downloaded file, thus increasing the filesize and corrupting the downloaded file
                        saveFileStream.Dispose(); // dispose object to free it for the next operation
                        File.WriteAllText(Path, string.Empty); // clear the contents of the half downloaded file that can't be resumed
                        saveFileStream = new FileStream(Path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite); // reopen it for writing
                    }

                    using (var stream = response.GetResponseStream())
                    {
                        byte[] downBuffer = new byte[4096];
                        int byteSize = 0;
                        long totalReceived = byteSize + ExistingLength;
                        var sw = new Stopwatch();
                        sw.Start();

                        byteSize = stream.Read(downBuffer, 0, downBuffer.Length);
                        //while ((byteSize = stream.Read(downBuffer, 0, downBuffer.Length)) > 0)
                        while (byteSize > 0)
                        {
                            saveFileStream.Write(downBuffer, 0, byteSize);
                            totalReceived += byteSize;

                            var args = new DownloadProgressChangedEventArgs();
                            args.BytesReceived = totalReceived;
                            args.TotalBytesToReceive = FileSize;
                            float currentSpeed = totalReceived / (float)sw.Elapsed.TotalSeconds;
                            args.CurrentSpeed = currentSpeed;
                            if (downloadResumable == true)
                            {
                                args.ProgressPercentage = ((float)totalReceived / (float)FileSize) * 100;
                                long bytesRemainingtoBeReceived = FileSize - totalReceived;
                                //Log("remaining data = {0}", bytesRemainingtoBeReceived);
                                args.TimeLeft = (long)(bytesRemainingtoBeReceived / currentSpeed);
                            }
                            else
                            {
                                //args.ProgressPercentage = Unknown;
                                //args.TimeLeft = Unknown;
                            }
                            OnDownloadProgressChanged(args);

                            if (stop == true)
                                return;

                            //next
                            try
                            {
                                byteSize = stream.Read(downBuffer, 0, downBuffer.Length);
                            } catch (Exception ee)
                            {
                                Log("cant read stream when downloading file, e = "+ee.Message);
                                byteSize = 0; //force end?
                            }
                            
                            
                        }
                        sw.Stop();
                    }
                }
                var completedArgs = new EventArgs();
                OnDownloadCompleted(completedArgs);
            }
            catch (WebException e)
            {
                string filename = System.IO.Path.GetFileName(Path);
                Log(e.Message);
            }
            finally
            {
                saveFileStream.Dispose();
            }
        }

        public void StopDownload()
        {
            stop = true;
        }

        protected virtual void OnDownloadStatusChanged(DownloadStatusChangedEventArgs e)
        {
            Log("OnDownloadStatusChanged, ResumeSupported = " + e.ResumeSupported.ToString());
            EventHandler<DownloadStatusChangedEventArgs> handler = DownloadStatusChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDownloadProgressChanged(DownloadProgressChangedEventArgs e)
        {
            //Log("OnDownloadProgressChanged");
            EventHandler<DownloadProgressChangedEventArgs> handler = DownloadProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        protected virtual void OnDownloadCompleted(EventArgs e)
        {
            Log("OnDownloadCompleted");
            EventHandler handler = DownloadCompleted;
            if (handler != null)
            {
                handler(this, e);
            }
        }
    }

    public class DownloadStatusChangedEventArgs : EventArgs
    {
        public bool ResumeSupported { get; set; }
    }

    public class DownloadProgressChangedEventArgs : EventArgs
    {
        public long BytesReceived { get; set; }
        public long TotalBytesToReceive { get; set; }
        public float ProgressPercentage { get; set; }
        public float CurrentSpeed { get; set; } // in bytes
        public long TimeLeft { get; set; } // in seconds
    }
}
