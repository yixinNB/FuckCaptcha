namespace FuckCaptcha
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.打开数据统计 = new System.Windows.Forms.WebBrowser();
            this.webBrowser2 = new System.Windows.Forms.WebBrowser();
            this.button_start = new System.Windows.Forms.Button();
            this.label_1_1 = new System.Windows.Forms.Label();
            this.label_1_2 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.versionLow = new System.Windows.Forms.Label();
            this.xieyi = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(121, 24);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(395, 172);
            this.richTextBox1.TabIndex = 2;
            this.richTextBox1.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(119, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "系统公告";
            // 
            // 打开数据统计
            // 
            this.打开数据统计.Location = new System.Drawing.Point(69, 371);
            this.打开数据统计.MinimumSize = new System.Drawing.Size(20, 20);
            this.打开数据统计.Name = "打开数据统计";
            this.打开数据统计.ScriptErrorsSuppressed = true;
            this.打开数据统计.ScrollBarsEnabled = false;
            this.打开数据统计.Size = new System.Drawing.Size(40, 20);
            this.打开数据统计.TabIndex = 4;
            this.打开数据统计.Url = new System.Uri("http://qr61.cn/oFQTMX/qsDCS8M", System.UriKind.Absolute);
            // 
            // webBrowser2
            // 
            this.webBrowser2.Location = new System.Drawing.Point(121, 202);
            this.webBrowser2.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser2.Name = "webBrowser2";
            this.webBrowser2.ScriptErrorsSuppressed = true;
            this.webBrowser2.Size = new System.Drawing.Size(395, 254);
            this.webBrowser2.TabIndex = 5;
            this.webBrowser2.Url = new System.Uri("http://yixin666.mikecrm.com/dp6Zq8i", System.UriKind.Absolute);
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 12);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(75, 66);
            this.button_start.TabIndex = 6;
            this.button_start.Text = "开始识别";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // label_1_1
            // 
            this.label_1_1.AutoSize = true;
            this.label_1_1.Location = new System.Drawing.Point(10, 331);
            this.label_1_1.Name = "label_1_1";
            this.label_1_1.Size = new System.Drawing.Size(29, 12);
            this.label_1_1.TabIndex = 7;
            this.label_1_1.Text = "系统";
            // 
            // label_1_2
            // 
            this.label_1_2.AutoSize = true;
            this.label_1_2.Font = new System.Drawing.Font("黑体", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_1_2.ForeColor = System.Drawing.Color.Green;
            this.label_1_2.Location = new System.Drawing.Point(40, 331);
            this.label_1_2.Name = "label_1_2";
            this.label_1_2.Size = new System.Drawing.Size(31, 12);
            this.label_1_2.TabIndex = 8;
            this.label_1_2.Text = "正常";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(10, 382);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(53, 12);
            this.label10.TabIndex = 9;
            this.label10.Text = "版本V1.0";
            // 
            // versionLow
            // 
            this.versionLow.AutoSize = true;
            this.versionLow.ForeColor = System.Drawing.Color.Red;
            this.versionLow.Location = new System.Drawing.Point(8, 91);
            this.versionLow.Name = "versionLow";
            this.versionLow.Size = new System.Drawing.Size(101, 24);
            this.versionLow.TabIndex = 10;
            this.versionLow.Text = "版本过低，请更新\r\n详情系统公告";
            this.versionLow.Visible = false;
            // 
            // xieyi
            // 
            this.xieyi.AutoSize = true;
            this.xieyi.Location = new System.Drawing.Point(10, 357);
            this.xieyi.Name = "xieyi";
            this.xieyi.Size = new System.Drawing.Size(53, 12);
            this.xieyi.TabIndex = 11;
            this.xieyi.Text = "用户协议";
            this.xieyi.Click += new System.EventHandler(this.xieyi_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(517, 403);
            this.Controls.Add(this.xieyi);
            this.Controls.Add(this.versionLow);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label_1_2);
            this.Controls.Add(this.label_1_1);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.webBrowser2);
            this.Controls.Add(this.打开数据统计);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.richTextBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "验证码智能识别内测版  PoweredBy：江高 高一：易鑫";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.WebBrowser 打开数据统计;
        private System.Windows.Forms.WebBrowser webBrowser2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Label label_1_1;
        private System.Windows.Forms.Label label_1_2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label versionLow;
        private System.Windows.Forms.Label xieyi;
    }
}

