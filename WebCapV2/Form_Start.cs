using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebCapV2
{
    public partial class Form_Start : Form
    {
        public Form_Start()
        {
            InitializeComponent();
        }


        IList<Form_Downloader> iList_Form_Downloader = new List<Form_Downloader>();
        int intIDFormDownloaderCounter = 0;


        private void button1_Click(object sender, EventArgs e)
        {
            ShowFormDownloader(1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ShowFormDownloader(2);
        }

        


        
        private void ShowFormDownloader(int ID)
        {
            //intIDFormDownloaderCounter++;
            Form_Downloader F;
            if (checkFormDownloaderIDExists(ID))
            {
                 F = iList_Form_Downloader[GetIndexIDFormDownloader(ID)];
               
            }
            else
            {               
                 F = new Form_Downloader();
                F.Name = "FDownloader_" + ID.ToString();
                F.Form_ID = ID;
                F.Form_Log = Form_Log;
                iList_Form_Downloader.Add(F);
     
            }

            if (F != null)
            {
                try { F.Show(); } catch (Exception e) { MessageBox.Show(e.Message); }
                
            }



        }

        private bool checkFormDownloaderIDExists(int ID)
        {
            if (iList_Form_Downloader.Count <= 0)
            {
                return false;
            }

            for(int i=0;i< iList_Form_Downloader.Count; i++)
            {
               if( iList_Form_Downloader[i].Form_ID == ID)
                {
                    return true;
                }
            }


            return false;
        }


        private int GetIndexIDFormDownloader(int ID)
        {
            if (iList_Form_Downloader.Count <= 0)
            {
                return -1;
            }
            for (int i = 0; i < iList_Form_Downloader.Count; i++)
            {
                if (iList_Form_Downloader[i].Form_ID == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        static Form_log Form_Log= new Form_log();

        private void Form_Start_Load(object sender, EventArgs e)
        {
            Form_Log.Name = "Form_Log";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form_Log.Show();
        }

        private void btn_set_web_emu_Click(object sender, EventArgs e)
        {
            if (!IsBrowserEmulationSet())
            {

                SetBrowserEmulationVersion();
                MessageBox.Show("set");
            }
        }


        //=============================================================emu

        private const string InternetExplorerRootKey = @"Software\Microsoft\Internet Explorer";

        public static int GetInternetExplorerMajorVersion()
        {
            int result;

            result = 0;

            try
            {
                RegistryKey key;

                key = Registry.LocalMachine.OpenSubKey(InternetExplorerRootKey);

                if (key != null)
                {
                    object value;

                    value = key.GetValue("svcVersion", null) ?? key.GetValue("Version", null);

                    if (value != null)
                    {
                        string version;
                        int separator;

                        version = value.ToString();
                        separator = version.IndexOf('.');
                        if (separator != -1)
                        {
                            int.TryParse(version.Substring(0, separator), out result);
                        }
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
                MessageBox.Show("1, The user does not have the permissions required to read from the registry key.");
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
                MessageBox.Show("2, The user does not have the necessary registry rights.");
            }

            return result;
        }


        //===================
        public enum BrowserEmulationVersion
        {
            Default = 0,
            Version7 = 7000,
            Version8 = 8000,
            Version8Standards = 8888,
            Version9 = 9000,
            Version9Standards = 9999,
            Version10 = 10000,
            Version10Standards = 10001,
            Version11 = 11000,
            Version11Edge = 11001
        }
        //===================

        private const string BrowserEmulationKey =
        InternetExplorerRootKey + @"\Main\FeatureControl\FEATURE_BROWSER_EMULATION";

        public static BrowserEmulationVersion GetBrowserEmulationVersion()
        {
            BrowserEmulationVersion result;

            result = BrowserEmulationVersion.Default;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);
                if (key != null)
                {
                    string programName;
                    object value;

                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);
                    value = key.GetValue(programName, null);
                    MessageBox.Show("programName = "+ programName);

                    if (value != null)
                    {
                        result = (BrowserEmulationVersion)Convert.ToInt32(value);
                    }
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
                MessageBox.Show("3, The user does not have the permissions required to read from the registry key.");
            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
                MessageBox.Show("4, The user does not have the necessary registry rights.");
            }

            return result;
        }

        public static bool IsBrowserEmulationSet()
        {
            return GetBrowserEmulationVersion() != BrowserEmulationVersion.Default;
        }
        //==============
        public static bool SetBrowserEmulationVersion(BrowserEmulationVersion browserEmulationVersion)
        {
            bool result;

            result = false;

            try
            {
                RegistryKey key;

                key = Registry.CurrentUser.OpenSubKey(BrowserEmulationKey, true);

                if (key != null)
                {
                    string programName;

                    programName = Path.GetFileName(Environment.GetCommandLineArgs()[0]);

                    if (browserEmulationVersion != BrowserEmulationVersion.Default)
                    {
                        // if it's a valid value, update or create the value
                        key.SetValue(programName, (int)browserEmulationVersion, RegistryValueKind.DWord);
                    }
                    else
                    {
                        // otherwise, remove the existing value
                        key.DeleteValue(programName, false);
                    }

                    result = true;
                }
            }
            catch (SecurityException)
            {
                // The user does not have the permissions required to read from the registry key.
                MessageBox.Show("5, The user does not have the permissions required to read from the registry key.");

            }
            catch (UnauthorizedAccessException)
            {
                // The user does not have the necessary registry rights.
                MessageBox.Show("6, The user does not have the necessary registry rights.");
            }

            return result;
        }

        public static bool SetBrowserEmulationVersion()
        {
            int ieVersion;
            BrowserEmulationVersion emulationCode;

            ieVersion = GetInternetExplorerMajorVersion();

            if (ieVersion >= 11)
            {
                emulationCode = BrowserEmulationVersion.Version11;
            }
            else
            {
                switch (ieVersion)
                {
                    case 10:
                        emulationCode = BrowserEmulationVersion.Version10;
                        break;
                    case 9:
                        emulationCode = BrowserEmulationVersion.Version9;
                        break;
                    case 8:
                        emulationCode = BrowserEmulationVersion.Version8;
                        break;
                    default:
                        emulationCode = BrowserEmulationVersion.Version7;
                        break;
                }
            }

            return SetBrowserEmulationVersion(emulationCode);
        }
        //=============================================================emu end


    }
}
