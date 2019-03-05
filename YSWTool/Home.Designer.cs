namespace YSWTool
{
    partial class Home
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.ButtonTable = new System.Windows.Forms.Button();
            this.DateTables = new System.Windows.Forms.DataGridView();
            this.Start = new System.Windows.Forms.TextBox();
            this.End = new System.Windows.Forms.TextBox();
            this.Parameter = new System.Windows.Forms.Button();
            this.Emptied = new System.Windows.Forms.Button();
            this.CreateModel = new System.Windows.Forms.Button();
            this.CreateModelService = new System.Windows.Forms.Button();
            this.logic = new System.Windows.Forms.TextBox();
            this.CreateSQL = new System.Windows.Forms.Button();
            this.UpdateLog = new System.Windows.Forms.Button();
            this.Config = new System.Windows.Forms.Button();
            this.CreateParameterSQL = new System.Windows.Forms.Button();
            this.runSQL = new System.Windows.Forms.Button();
            this.CreateService = new System.Windows.Forms.Button();
            this.TabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CustomAdvanced = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.ParTypeSQL = new System.Windows.Forms.Button();
            this.ParameterrunSQL = new System.Windows.Forms.Button();
            this.ParameterText = new System.Windows.Forms.TextBox();
            this.ParType = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DateTables)).BeginInit();
            this.TabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonTable
            // 
            this.ButtonTable.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ButtonTable.Location = new System.Drawing.Point(118, 22);
            this.ButtonTable.Name = "ButtonTable";
            this.ButtonTable.Size = new System.Drawing.Size(75, 23);
            this.ButtonTable.TabIndex = 2;
            this.ButtonTable.Text = "表结构";
            this.ButtonTable.UseVisualStyleBackColor = true;
            this.ButtonTable.Click += new System.EventHandler(this.ButtonTable_Click);
            // 
            // DateTables
            // 
            this.DateTables.AllowUserToAddRows = false;
            this.DateTables.AllowUserToDeleteRows = false;
            this.DateTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DateTables.Location = new System.Drawing.Point(12, 50);
            this.DateTables.Name = "DateTables";
            this.DateTables.RowTemplate.Height = 23;
            this.DateTables.Size = new System.Drawing.Size(560, 500);
            this.DateTables.TabIndex = 1;
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(12, 24);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(44, 21);
            this.Start.TabIndex = 0;
            this.Start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // End
            // 
            this.End.Location = new System.Drawing.Point(62, 24);
            this.End.Name = "End";
            this.End.Size = new System.Drawing.Size(50, 21);
            this.End.TabIndex = 1;
            this.End.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Parameter
            // 
            this.Parameter.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Parameter.Location = new System.Drawing.Point(199, 22);
            this.Parameter.Name = "Parameter";
            this.Parameter.Size = new System.Drawing.Size(59, 23);
            this.Parameter.TabIndex = 3;
            this.Parameter.Text = "参数";
            this.Parameter.UseVisualStyleBackColor = true;
            this.Parameter.Click += new System.EventHandler(this.Parameter_Click);
            // 
            // Emptied
            // 
            this.Emptied.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Emptied.Location = new System.Drawing.Point(335, 21);
            this.Emptied.Name = "Emptied";
            this.Emptied.Size = new System.Drawing.Size(75, 23);
            this.Emptied.TabIndex = 4;
            this.Emptied.Text = "清空";
            this.Emptied.UseVisualStyleBackColor = true;
            this.Emptied.Click += new System.EventHandler(this.Emptied_Click);
            // 
            // CreateModel
            // 
            this.CreateModel.Enabled = false;
            this.CreateModel.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.CreateModel.Location = new System.Drawing.Point(149, 10);
            this.CreateModel.Name = "CreateModel";
            this.CreateModel.Size = new System.Drawing.Size(62, 23);
            this.CreateModel.TabIndex = 6;
            this.CreateModel.Text = "Model";
            this.CreateModel.UseVisualStyleBackColor = true;
            this.CreateModel.Click += new System.EventHandler(this.CreateModel_Click);
            // 
            // CreateModelService
            // 
            this.CreateModelService.Enabled = false;
            this.CreateModelService.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.CreateModelService.Location = new System.Drawing.Point(217, 10);
            this.CreateModelService.Name = "CreateModelService";
            this.CreateModelService.Size = new System.Drawing.Size(97, 23);
            this.CreateModelService.TabIndex = 7;
            this.CreateModelService.Text = "ModelService";
            this.CreateModelService.UseVisualStyleBackColor = true;
            this.CreateModelService.Click += new System.EventHandler(this.CreateModelService_Click);
            // 
            // logic
            // 
            this.logic.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.logic.Location = new System.Drawing.Point(6, 68);
            this.logic.Multiline = true;
            this.logic.Name = "logic";
            this.logic.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logic.Size = new System.Drawing.Size(574, 439);
            this.logic.TabIndex = 8;
            // 
            // CreateSQL
            // 
            this.CreateSQL.Enabled = false;
            this.CreateSQL.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.CreateSQL.Location = new System.Drawing.Point(53, 10);
            this.CreateSQL.Name = "CreateSQL";
            this.CreateSQL.Size = new System.Drawing.Size(90, 23);
            this.CreateSQL.TabIndex = 9;
            this.CreateSQL.Text = "CreateSQL";
            this.CreateSQL.UseVisualStyleBackColor = true;
            this.CreateSQL.Click += new System.EventHandler(this.CreateSQL_Click);
            // 
            // UpdateLog
            // 
            this.UpdateLog.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.UpdateLog.Location = new System.Drawing.Point(416, 21);
            this.UpdateLog.Name = "UpdateLog";
            this.UpdateLog.Size = new System.Drawing.Size(75, 23);
            this.UpdateLog.TabIndex = 5;
            this.UpdateLog.Text = "更新日志";
            this.UpdateLog.UseVisualStyleBackColor = true;
            this.UpdateLog.Click += new System.EventHandler(this.UpdateLog_Click);
            // 
            // Config
            // 
            this.Config.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.Config.Location = new System.Drawing.Point(497, 21);
            this.Config.Name = "Config";
            this.Config.Size = new System.Drawing.Size(75, 23);
            this.Config.TabIndex = 6;
            this.Config.Text = "配置";
            this.Config.UseVisualStyleBackColor = true;
            this.Config.Click += new System.EventHandler(this.Config_Click);
            // 
            // CreateParameterSQL
            // 
            this.CreateParameterSQL.Enabled = false;
            this.CreateParameterSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateParameterSQL.Location = new System.Drawing.Point(6, 7);
            this.CreateParameterSQL.Name = "CreateParameterSQL";
            this.CreateParameterSQL.Size = new System.Drawing.Size(68, 23);
            this.CreateParameterSQL.TabIndex = 12;
            this.CreateParameterSQL.Text = "参数SQL";
            this.CreateParameterSQL.UseVisualStyleBackColor = true;
            this.CreateParameterSQL.Click += new System.EventHandler(this.CreateParameterSQL_Click);
            // 
            // runSQL
            // 
            this.runSQL.Enabled = false;
            this.runSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.runSQL.Location = new System.Drawing.Point(505, 5);
            this.runSQL.Name = "runSQL";
            this.runSQL.Size = new System.Drawing.Size(75, 23);
            this.runSQL.TabIndex = 13;
            this.runSQL.Text = "执行SQL";
            this.runSQL.UseVisualStyleBackColor = true;
            this.runSQL.Click += new System.EventHandler(this.runSQL_Click);
            // 
            // CreateService
            // 
            this.CreateService.Enabled = false;
            this.CreateService.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CreateService.Location = new System.Drawing.Point(53, 39);
            this.CreateService.Name = "CreateService";
            this.CreateService.Size = new System.Drawing.Size(90, 23);
            this.CreateService.TabIndex = 14;
            this.CreateService.Text = "Service";
            this.CreateService.UseVisualStyleBackColor = true;
            this.CreateService.Click += new System.EventHandler(this.CreateService_Click);
            // 
            // TabControl
            // 
            this.TabControl.Controls.Add(this.tabPage1);
            this.TabControl.Controls.Add(this.tabPage2);
            this.TabControl.Location = new System.Drawing.Point(578, 12);
            this.TabControl.Name = "TabControl";
            this.TabControl.SelectedIndex = 0;
            this.TabControl.Size = new System.Drawing.Size(594, 539);
            this.TabControl.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.runSQL);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.CreateSQL);
            this.tabPage1.Controls.Add(this.CustomAdvanced);
            this.tabPage1.Controls.Add(this.CreateService);
            this.tabPage1.Controls.Add(this.CreateModelService);
            this.tabPage1.Controls.Add(this.logic);
            this.tabPage1.Controls.Add(this.CreateModel);
            this.tabPage1.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(586, 513);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "逻辑";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 16;
            this.label2.Text = "第二层";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 17);
            this.label1.TabIndex = 15;
            this.label1.Text = "第一层";
            // 
            // CustomAdvanced
            // 
            this.CustomAdvanced.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.CustomAdvanced.Location = new System.Drawing.Point(163, 38);
            this.CustomAdvanced.Name = "CustomAdvanced";
            this.CustomAdvanced.Size = new System.Drawing.Size(142, 23);
            this.CustomAdvanced.TabIndex = 14;
            this.CustomAdvanced.Text = "CustomAdvanced";
            this.CustomAdvanced.UseVisualStyleBackColor = true;
            this.CustomAdvanced.Click += new System.EventHandler(this.CustomAdvanced_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.ParTypeSQL);
            this.tabPage2.Controls.Add(this.ParameterrunSQL);
            this.tabPage2.Controls.Add(this.ParameterText);
            this.tabPage2.Controls.Add(this.CreateParameterSQL);
            this.tabPage2.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabPage2.Size = new System.Drawing.Size(586, 513);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "参数";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // ParTypeSQL
            // 
            this.ParTypeSQL.Location = new System.Drawing.Point(80, 8);
            this.ParTypeSQL.Name = "ParTypeSQL";
            this.ParTypeSQL.Size = new System.Drawing.Size(96, 23);
            this.ParTypeSQL.TabIndex = 15;
            this.ParTypeSQL.Text = "参数类型SQL";
            this.ParTypeSQL.UseVisualStyleBackColor = true;
            this.ParTypeSQL.Click += new System.EventHandler(this.ParTypeSQL_Click);
            // 
            // ParameterrunSQL
            // 
            this.ParameterrunSQL.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParameterrunSQL.Location = new System.Drawing.Point(505, 7);
            this.ParameterrunSQL.Name = "ParameterrunSQL";
            this.ParameterrunSQL.Size = new System.Drawing.Size(75, 23);
            this.ParameterrunSQL.TabIndex = 14;
            this.ParameterrunSQL.Text = "执行SQL";
            this.ParameterrunSQL.UseVisualStyleBackColor = true;
            this.ParameterrunSQL.Click += new System.EventHandler(this.ParameterrunSQL_Click);
            // 
            // ParameterText
            // 
            this.ParameterText.Location = new System.Drawing.Point(7, 37);
            this.ParameterText.Multiline = true;
            this.ParameterText.Name = "ParameterText";
            this.ParameterText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ParameterText.Size = new System.Drawing.Size(573, 470);
            this.ParameterText.TabIndex = 13;
            // 
            // ParType
            // 
            this.ParType.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ParType.Location = new System.Drawing.Point(264, 21);
            this.ParType.Name = "ParType";
            this.ParType.Size = new System.Drawing.Size(65, 23);
            this.ParType.TabIndex = 16;
            this.ParType.Text = "参数类型";
            this.ParType.UseVisualStyleBackColor = true;
            this.ParType.Click += new System.EventHandler(this.ParType_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 561);
            this.Controls.Add(this.ParType);
            this.Controls.Add(this.TabControl);
            this.Controls.Add(this.Config);
            this.Controls.Add(this.UpdateLog);
            this.Controls.Add(this.Emptied);
            this.Controls.Add(this.Parameter);
            this.Controls.Add(this.End);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.DateTables);
            this.Controls.Add(this.ButtonTable);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "YSWTool-V0.9.1";
            ((System.ComponentModel.ISupportInitialize)(this.DateTables)).EndInit();
            this.TabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonTable;
        private System.Windows.Forms.TextBox Start;
        private System.Windows.Forms.TextBox End;
        private System.Windows.Forms.Button Parameter;
        private System.Windows.Forms.Button Emptied;
        private System.Windows.Forms.Button CreateModel;
        private System.Windows.Forms.Button CreateModelService;
        private System.Windows.Forms.TextBox logic;
        private System.Windows.Forms.Button CreateSQL;
        private System.Windows.Forms.Button UpdateLog;
        private System.Windows.Forms.Button Config;
        private System.Windows.Forms.Button CreateParameterSQL;
        private System.Windows.Forms.Button runSQL;
        private System.Windows.Forms.Button CreateService;
        public System.Windows.Forms.DataGridView DateTables;
        private System.Windows.Forms.TabControl TabControl;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ParameterText;
        private System.Windows.Forms.Button ParameterrunSQL;
        private System.Windows.Forms.Button ParType;
        private System.Windows.Forms.Button ParTypeSQL;
        private System.Windows.Forms.Button CustomAdvanced;
    }
}