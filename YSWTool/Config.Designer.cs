namespace YSWTool
{
    partial class Config
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Config));
            this.label1 = new System.Windows.Forms.Label();
            this.FileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Model = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ModelService = new System.Windows.Forms.TextBox();
            this.Save = new System.Windows.Forms.Button();
            this.SelectFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.SQL = new System.Windows.Forms.TextBox();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SystemID = new System.Windows.Forms.TextBox();
            this.lble1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Table = new System.Windows.Forms.TextBox();
            this.ParType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.Parameter = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 133);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "文档名称";
            // 
            // FileName
            // 
            this.FileName.Location = new System.Drawing.Point(143, 130);
            this.FileName.Name = "FileName";
            this.FileName.Size = new System.Drawing.Size(344, 21);
            this.FileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(54, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Model命名空间";
            // 
            // Model
            // 
            this.Model.Location = new System.Drawing.Point(143, 166);
            this.Model.Name = "Model";
            this.Model.Size = new System.Drawing.Size(344, 21);
            this.Model.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 204);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "ModelService命名空间";
            // 
            // ModelService
            // 
            this.ModelService.Location = new System.Drawing.Point(143, 201);
            this.ModelService.Name = "ModelService";
            this.ModelService.Size = new System.Drawing.Size(344, 21);
            this.ModelService.TabIndex = 5;
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(267, 264);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(75, 23);
            this.Save.TabIndex = 6;
            this.Save.Text = "保存";
            this.Save.UseVisualStyleBackColor = true;
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // SelectFile
            // 
            this.SelectFile.Location = new System.Drawing.Point(493, 130);
            this.SelectFile.Name = "SelectFile";
            this.SelectFile.Size = new System.Drawing.Size(75, 23);
            this.SelectFile.TabIndex = 7;
            this.SelectFile.Text = "选择文件";
            this.SelectFile.UseVisualStyleBackColor = true;
            this.SelectFile.Click += new System.EventHandler(this.SelectFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(48, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 12);
            this.label4.TabIndex = 8;
            this.label4.Text = "数据库连接语句";
            // 
            // SQL
            // 
            this.SQL.Location = new System.Drawing.Point(143, 237);
            this.SQL.Name = "SQL";
            this.SQL.Size = new System.Drawing.Size(344, 21);
            this.SQL.TabIndex = 9;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Items.AddRange(new object[] {
            "EMO",
            "SWGS",
            "MFOS",
            "MES"});
            this.comboBox.Location = new System.Drawing.Point(232, 12);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(121, 20);
            this.comboBox.TabIndex = 10;
            this.comboBox.SelectedIndexChanged += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // SystemID
            // 
            this.SystemID.Location = new System.Drawing.Point(213, 52);
            this.SystemID.Name = "SystemID";
            this.SystemID.Size = new System.Drawing.Size(40, 21);
            this.SystemID.TabIndex = 11;
            // 
            // lble1
            // 
            this.lble1.AutoSize = true;
            this.lble1.Location = new System.Drawing.Point(154, 55);
            this.lble1.Name = "lble1";
            this.lble1.Size = new System.Drawing.Size(53, 12);
            this.lble1.TabIndex = 12;
            this.lble1.Text = "系统编号";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(331, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 14;
            this.label5.Text = "表结构页签";
            // 
            // Table
            // 
            this.Table.Location = new System.Drawing.Point(402, 52);
            this.Table.Name = "Table";
            this.Table.Size = new System.Drawing.Size(40, 21);
            this.Table.TabIndex = 13;
            // 
            // ParType
            // 
            this.ParType.Location = new System.Drawing.Point(213, 94);
            this.ParType.Name = "ParType";
            this.ParType.Size = new System.Drawing.Size(40, 21);
            this.ParType.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(130, 97);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 12);
            this.label6.TabIndex = 16;
            this.label6.Text = "参数类型页签";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(343, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 12);
            this.label7.TabIndex = 18;
            this.label7.Text = "参数页签";
            // 
            // Parameter
            // 
            this.Parameter.Location = new System.Drawing.Point(402, 94);
            this.Parameter.Name = "Parameter";
            this.Parameter.Size = new System.Drawing.Size(40, 21);
            this.Parameter.TabIndex = 17;
            // 
            // Config
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.Parameter);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.ParType);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Table);
            this.Controls.Add(this.lble1);
            this.Controls.Add(this.SystemID);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.SQL);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SelectFile);
            this.Controls.Add(this.Save);
            this.Controls.Add(this.ModelService);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Model);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.FileName);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "配置中心";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox FileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Model;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ModelService;
        private System.Windows.Forms.Button Save;
        private System.Windows.Forms.Button SelectFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox SQL;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.TextBox SystemID;
        private System.Windows.Forms.Label lble1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox Table;
        private System.Windows.Forms.TextBox ParType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox Parameter;
    }
}