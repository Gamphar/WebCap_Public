
namespace WebCapV2
{
    partial class Form_Start
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_ShowFormLog = new System.Windows.Forms.Button();
            this.btn_set_web_emu = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "DL1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(93, 12);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 1;
            this.button2.Text = "DL2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_ShowFormLog
            // 
            this.btn_ShowFormLog.Location = new System.Drawing.Point(12, 41);
            this.btn_ShowFormLog.Name = "btn_ShowFormLog";
            this.btn_ShowFormLog.Size = new System.Drawing.Size(75, 23);
            this.btn_ShowFormLog.TabIndex = 2;
            this.btn_ShowFormLog.Text = "Log";
            this.btn_ShowFormLog.UseVisualStyleBackColor = true;
            this.btn_ShowFormLog.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn_set_web_emu
            // 
            this.btn_set_web_emu.Location = new System.Drawing.Point(337, 8);
            this.btn_set_web_emu.Name = "btn_set_web_emu";
            this.btn_set_web_emu.Size = new System.Drawing.Size(91, 30);
            this.btn_set_web_emu.TabIndex = 3;
            this.btn_set_web_emu.Text = "set web emu";
            this.btn_set_web_emu.UseVisualStyleBackColor = true;
            this.btn_set_web_emu.Click += new System.EventHandler(this.btn_set_web_emu_Click);
            // 
            // Form_Start
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_set_web_emu);
            this.Controls.Add(this.btn_ShowFormLog);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "Form_Start";
            this.Text = "Komik Downloader";
            this.Load += new System.EventHandler(this.Form_Start_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_ShowFormLog;
        private System.Windows.Forms.Button btn_set_web_emu;
    }
}