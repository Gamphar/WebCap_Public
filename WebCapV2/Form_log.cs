using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
//using WebCapV2;

namespace WebCapV2
{
    public partial class Form_log : Form
    {
        public Form_log()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //textBox_log.Text = "";
            textBox_log.Clear();
        }

        private void Form_log_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();
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

            msg = String.Format(msg,o);
            this.InvokeEx(f => f.textBox_log.AppendText(msg + "\r\n"));

        }

        public static void LogMe(string msg)
        {
            
        }
    }
}
