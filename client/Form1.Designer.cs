
namespace client
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.textPort = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textHost = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.textStatus = new System.Windows.Forms.TextBox();
            this.listFiles = new System.Windows.Forms.ListBox();
            this.getFiles = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(264, 61);
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(100, 26);
            this.textPort.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(221, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "port";
            // 
            // textHost
            // 
            this.textHost.Location = new System.Drawing.Point(97, 61);
            this.textHost.Name = "textHost";
            this.textHost.Size = new System.Drawing.Size(117, 26);
            this.textHost.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(47, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Host";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(394, 57);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(156, 35);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // textStatus
            // 
            this.textStatus.Location = new System.Drawing.Point(51, 119);
            this.textStatus.Multiline = true;
            this.textStatus.Name = "textStatus";
            this.textStatus.Size = new System.Drawing.Size(313, 284);
            this.textStatus.TabIndex = 11;
            // 
            // listFiles
            // 
            this.listFiles.FormattingEnabled = true;
            this.listFiles.ItemHeight = 20;
            this.listFiles.Location = new System.Drawing.Point(518, 119);
            this.listFiles.Name = "listFiles";
            this.listFiles.Size = new System.Drawing.Size(226, 284);
            this.listFiles.TabIndex = 12;
            // 
            // getFiles
            // 
            this.getFiles.Location = new System.Drawing.Point(394, 121);
            this.getFiles.Name = "getFiles";
            this.getFiles.Size = new System.Drawing.Size(92, 52);
            this.getFiles.TabIndex = 13;
            this.getFiles.Text = "get files";
            this.getFiles.UseVisualStyleBackColor = true;
            this.getFiles.Click += new System.EventHandler(this.getFiles_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(394, 197);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(92, 50);
            this.button1.TabIndex = 14;
            this.button1.Text = "start file";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.getFiles);
            this.Controls.Add(this.listFiles);
            this.Controls.Add(this.textStatus);
            this.Controls.Add(this.textPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textHost);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonConnect);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textHost;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.TextBox textStatus;
        private System.Windows.Forms.ListBox listFiles;
        private System.Windows.Forms.Button getFiles;
        private System.Windows.Forms.Button button1;
    }
}

