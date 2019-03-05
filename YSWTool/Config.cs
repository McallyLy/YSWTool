using System;
using System.Windows.Forms;
using ToolLibrary;
using YSWTool.Service;

namespace YSWTool
{
    public partial class Config : Form
    {
        public Config()
        {
            InitializeComponent();
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            comboBox.Text = con["Home"];
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            FileName.Text = config["FileName"];
            Model.Text = config["Model"];
            ModelService.Text = config["ModelService"];
            SQL.Text = config["connectionString"];
            SystemID.Text = config["SystemID"];
            Parameter.Text = config["Parameter"];
            ParType.Text = config["ParType"];
            Table.Text = config["Table"];
        }

        /// <summary>
        /// 保存
        /// SAM 2017年3月5日11:58:49
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Save_Click(object sender, EventArgs e)
        {
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            con["Home"] = comboBox.Text;
            ConfigFile config = ConfigFile.LoadOrCreateFile(comboBox.Text + "config");
            config["FileName"] = FileName.Text;
            config["Model"] = Model.Text;
            config["ModelService"] = ModelService.Text;
            config["connectionString"] = SQL.Text;
            config["SystemID"] = SystemID.Text;
            config["ParType"] = ParType.Text;
            config["Parameter"] = Parameter.Text;
            config["Table"] = Table.Text;
            MessageBox.Show("保存成功！", "提示");
            Close();
        }

        /// <summary>
        /// 选择文件
        /// SAM 2017年3月5日01:57:05
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.FileName.EndsWith("xls") || open.FileName.EndsWith("xlsx"))
                {
                    FileName.Text = open.FileName;
                }
                else
                {
                    MessageBox.Show("请选择正确的文件！", "提示");
                }
            }
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConfigFile config = ConfigFile.LoadOrCreateFile(comboBox.Text + "config");
            FileName.Text = config["FileName"];
            Model.Text = config["Model"];
            ModelService.Text = config["ModelService"];
            SQL.Text = config["connectionString"];
            SystemID.Text = config["SystemID"];
            ParType.Text = config["ParType"];
            Parameter.Text = config["Parameter"];
            Table.Text = config["Table"];
        }
    }
}
