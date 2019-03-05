namespace YSWTool
{
    partial class CustomAdvancedWin
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
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.Txt_content = new System.Windows.Forms.TextBox();
            this.btn_selectFiles = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_Sure = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.label1.Location = new System.Drawing.Point(33, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "请选择导入的Excel文件";
            // 
            // Txt_content
            // 
            this.Txt_content.ForeColor = System.Drawing.Color.Black;
            this.Txt_content.Location = new System.Drawing.Point(215, 212);
            this.Txt_content.Name = "Txt_content";
            this.Txt_content.Size = new System.Drawing.Size(335, 21);
            this.Txt_content.TabIndex = 1;
            // 
            // btn_selectFiles
            // 
            this.btn_selectFiles.BackColor = System.Drawing.Color.Coral;
            this.btn_selectFiles.Location = new System.Drawing.Point(556, 209);
            this.btn_selectFiles.Name = "btn_selectFiles";
            this.btn_selectFiles.Size = new System.Drawing.Size(110, 27);
            this.btn_selectFiles.TabIndex = 2;
            this.btn_selectFiles.Text = "选择文件";
            this.btn_selectFiles.UseVisualStyleBackColor = false;
            this.btn_selectFiles.Click += new System.EventHandler(this.btn_selectFilesClike);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_cancel.Location = new System.Drawing.Point(196, 298);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(75, 46);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Clike);
            // 
            // btn_Sure
            // 
            this.btn_Sure.BackColor = System.Drawing.Color.DodgerBlue;
            this.btn_Sure.Location = new System.Drawing.Point(535, 298);
            this.btn_Sure.Name = "btn_Sure";
            this.btn_Sure.Size = new System.Drawing.Size(75, 46);
            this.btn_Sure.TabIndex = 4;
            this.btn_Sure.Text = "确认";
            this.btn_Sure.UseVisualStyleBackColor = false;
            this.btn_Sure.Click += new System.EventHandler(this.btn_Sure_Clike);
            // 
            // CustomAdvancedWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::YSWTool.Properties.Resources.timg;
            this.ClientSize = new System.Drawing.Size(800, 443);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_selectFiles);
            this.Controls.Add(this.Txt_content);
            this.Controls.Add(this.btn_Sure);
            this.Controls.Add(this.btn_cancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CustomAdvancedWin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "仔细找按钮哦";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AdvClose);
            this.Load += new System.EventHandler(this.CustomAdvancedWin_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Txt_content;
        private System.Windows.Forms.Button btn_selectFiles;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_Sure;
    }
}