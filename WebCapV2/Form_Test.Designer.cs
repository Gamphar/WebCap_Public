
namespace WebCapV2
{
    partial class Form_Test
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
            this.tabControl2 = new System.Windows.Forms.TabControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chromiumHostControl1 = new CefSharp.WinForms.Host.ChromiumHostControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btn_cap_M = new System.Windows.Forms.Button();
            this.textBox_log = new System.Windows.Forms.TextBox();
            this.btn_cap_3 = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chromiumWebBrowser1 = new CefSharp.WinForms.ChromiumWebBrowser();
            this.textBox_log2 = new System.Windows.Forms.TextBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel4 = new System.Windows.Forms.Panel();
            this.btn_go2url = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.btn_test1 = new System.Windows.Forms.Button();
            this.btn_cap2 = new System.Windows.Forms.Button();
            this.btn_go_mangaDex = new System.Windows.Forms.Button();
            this.textBox_url2 = new System.Windows.Forms.TextBox();
            this.tabControl2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl_TitleList
            // 
            this.tabControl2.Controls.Add(this.tabPage3);
            this.tabControl2.Controls.Add(this.tabPage4);
            this.tabControl2.Controls.Add(this.tabPage1);
            this.tabControl2.Controls.Add(this.tabPage2);
            this.tabControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl2.Location = new System.Drawing.Point(0, 0);
            this.tabControl2.Name = "tabControl_TitleList";
            this.tabControl2.SelectedIndex = 0;
            this.tabControl2.Size = new System.Drawing.Size(800, 450);
            this.tabControl2.TabIndex = 1;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.webBrowser1);
            this.tabPage3.Controls.Add(this.panel1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(792, 424);
            this.tabPage3.TabIndex = 0;
            this.tabPage3.Text = "Cap1";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(3, 3);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(786, 318);
            this.webBrowser1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.button1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 321);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(786, 100);
            this.panel1.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 6);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(792, 424);
            this.tabPage4.TabIndex = 1;
            this.tabPage4.Text = "Set";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chromiumHostControl1);
            this.tabPage1.Controls.Add(this.panel2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(792, 424);
            this.tabPage1.TabIndex = 2;
            this.tabPage1.Text = "Chromium - Offscreen";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chromiumHostControl1
            // 
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.chromiumHostControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumHostControl1.Location = new System.Drawing.Point(3, 3);
            this.chromiumHostControl1.Name = "chromiumHostControl1";
            this.chromiumHostControl1.Size = new System.Drawing.Size(786, 265);
            this.chromiumHostControl1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btn_cap_M);
            this.panel2.Controls.Add(this.textBox_log);
            this.panel2.Controls.Add(this.btn_cap_3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(3, 268);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(786, 153);
            this.panel2.TabIndex = 0;
            // 
            // btn_cap_M
            // 
            this.btn_cap_M.Location = new System.Drawing.Point(86, 3);
            this.btn_cap_M.Name = "btn_cap_M";
            this.btn_cap_M.Size = new System.Drawing.Size(75, 23);
            this.btn_cap_M.TabIndex = 2;
            this.btn_cap_M.Text = "Cap M";
            this.btn_cap_M.UseVisualStyleBackColor = true;
            this.btn_cap_M.Click += new System.EventHandler(this.btn_cap_M_Click);
            // 
            // textBox_log
            // 
            this.textBox_log.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.textBox_log.Location = new System.Drawing.Point(0, 32);
            this.textBox_log.Multiline = true;
            this.textBox_log.Name = "textBox_log";
            this.textBox_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_log.Size = new System.Drawing.Size(786, 121);
            this.textBox_log.TabIndex = 1;
            // 
            // btn_cap_3
            // 
            this.btn_cap_3.Location = new System.Drawing.Point(5, 3);
            this.btn_cap_3.Name = "btn_cap_3";
            this.btn_cap_3.Size = new System.Drawing.Size(75, 23);
            this.btn_cap_3.TabIndex = 0;
            this.btn_cap_3.Text = "Cap";
            this.btn_cap_3.UseVisualStyleBackColor = true;
            this.btn_cap_3.Click += new System.EventHandler(this.btn_cap_3_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.panel3);
            this.tabPage2.Controls.Add(this.splitter1);
            this.tabPage2.Controls.Add(this.panel4);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(792, 424);
            this.tabPage2.TabIndex = 3;
            this.tabPage2.Text = "MangaDex";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.chromiumWebBrowser1);
            this.panel3.Controls.Add(this.textBox_log2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(786, 308);
            this.panel3.TabIndex = 0;
            // 
            // chromiumWebBrowser1
            // 
            this.chromiumWebBrowser1.ActivateBrowserOnCreation = false;
// TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
            this.chromiumWebBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.chromiumWebBrowser1.Location = new System.Drawing.Point(0, 0);
            this.chromiumWebBrowser1.Name = "chromiumWebBrowser1";
            this.chromiumWebBrowser1.Size = new System.Drawing.Size(539, 308);
            this.chromiumWebBrowser1.TabIndex = 1;
            this.chromiumWebBrowser1.FrameLoadEnd += new System.EventHandler<CefSharp.FrameLoadEndEventArgs>(this.chromiumWebBrowser1_FrameLoadEnd);
            this.chromiumWebBrowser1.ConsoleMessage += new System.EventHandler<CefSharp.ConsoleMessageEventArgs>(this.chromiumWebBrowser1_ConsoleMessage);
            this.chromiumWebBrowser1.JavascriptMessageReceived += new System.EventHandler<CefSharp.JavascriptMessageReceivedEventArgs>(this.chromiumWebBrowser1_JavascriptMessageReceived);
            // 
            // textBox_log2
            // 
            this.textBox_log2.Dock = System.Windows.Forms.DockStyle.Right;
            this.textBox_log2.Location = new System.Drawing.Point(539, 0);
            this.textBox_log2.Multiline = true;
            this.textBox_log2.Name = "textBox_log2";
            this.textBox_log2.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_log2.Size = new System.Drawing.Size(247, 308);
            this.textBox_log2.TabIndex = 0;
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter1.Location = new System.Drawing.Point(3, 311);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(786, 10);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.btn_go2url);
            this.panel4.Controls.Add(this.button3);
            this.panel4.Controls.Add(this.btn_test1);
            this.panel4.Controls.Add(this.btn_cap2);
            this.panel4.Controls.Add(this.btn_go_mangaDex);
            this.panel4.Controls.Add(this.textBox_url2);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(3, 321);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(786, 100);
            this.panel4.TabIndex = 1;
            // 
            // btn_go2url
            // 
            this.btn_go2url.Location = new System.Drawing.Point(706, 6);
            this.btn_go2url.Name = "btn_go2url";
            this.btn_go2url.Size = new System.Drawing.Size(75, 23);
            this.btn_go2url.TabIndex = 5;
            this.btn_go2url.Text = "go";
            this.btn_go2url.UseVisualStyleBackColor = true;
            this.btn_go2url.Click += new System.EventHandler(this.btn_go2url_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(504, 53);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "button3";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_test1
            // 
            this.btn_test1.Location = new System.Drawing.Point(188, 61);
            this.btn_test1.Name = "btn_test1";
            this.btn_test1.Size = new System.Drawing.Size(96, 23);
            this.btn_test1.TabIndex = 3;
            this.btn_test1.Text = "test1";
            this.btn_test1.UseVisualStyleBackColor = true;
            this.btn_test1.Click += new System.EventHandler(this.btn_test1_Click);
            // 
            // btn_cap2
            // 
            this.btn_cap2.Location = new System.Drawing.Point(188, 32);
            this.btn_cap2.Name = "btn_cap2";
            this.btn_cap2.Size = new System.Drawing.Size(96, 23);
            this.btn_cap2.TabIndex = 2;
            this.btn_cap2.Text = "cap";
            this.btn_cap2.UseVisualStyleBackColor = true;
            this.btn_cap2.Click += new System.EventHandler(this.btn_cap2_Click);
            // 
            // btn_go_mangaDex
            // 
            this.btn_go_mangaDex.Location = new System.Drawing.Point(5, 32);
            this.btn_go_mangaDex.Name = "btn_go_mangaDex";
            this.btn_go_mangaDex.Size = new System.Drawing.Size(177, 23);
            this.btn_go_mangaDex.TabIndex = 1;
            this.btn_go_mangaDex.Text = "go mangadex chapter";
            this.btn_go_mangaDex.UseVisualStyleBackColor = true;
            this.btn_go_mangaDex.Click += new System.EventHandler(this.btn_go_mangaDex_Click);
            // 
            // textBox_url2
            // 
            this.textBox_url2.Location = new System.Drawing.Point(5, 6);
            this.textBox_url2.Name = "textBox_url2";
            this.textBox_url2.Size = new System.Drawing.Size(695, 20);
            this.textBox_url2.TabIndex = 0;
            // 
            // Form_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl2);
            this.Name = "Form_Test";
            this.Text = "WebCap";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btn_cap_3;
        private CefSharp.WinForms.Host.ChromiumHostControl chromiumHostControl1;
        private System.Windows.Forms.TextBox textBox_log;
        private System.Windows.Forms.Button btn_cap_M;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBox_log2;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btn_go_mangaDex;
        private System.Windows.Forms.TextBox textBox_url2;
        private System.Windows.Forms.Button btn_cap2;
        private System.Windows.Forms.Button btn_go2url;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_test1;
        private CefSharp.WinForms.ChromiumWebBrowser chromiumWebBrowser1;
    }
}

