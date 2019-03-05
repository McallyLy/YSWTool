using System;

using System.Windows.Forms;
using ToolLibrary;
using YSWTool.Service;

namespace YSWTool
{
    public partial class CustomAdvancedWin : Form
    {
        public CustomAdvancedWin()
        {
            InitializeComponent();
        }

        private void btn_selectFilesClike(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if (open.ShowDialog() == DialogResult.OK)
            {
                if (open.FileName.EndsWith("xls") || open.FileName.EndsWith("xlsx"))
                {
                    Txt_content.Text = open.FileName;
                }
                else
                {
                    MessageBox.Show("兄弟请选择正确的文件！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btn_cancel_Clike(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Sure_Clike(object sender, EventArgs e)
        {
      
            object  msg =CustomAdv.CustomAdvImport(Txt_content.Text);
           DialogResult dialogResult= MessageBox.Show(msg+"","温馨小提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            if (dialogResult== DialogResult.OK) {
                this.Close();
            }
        }

        private void CustomAdvancedWin_Load(object sender, EventArgs e)
        {

        }

        private void AdvClose(object sender, FormClosingEventArgs e)
        {
         DialogResult res=  MessageBox.Show("兄弟你真的要退出吗??","小提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (res==DialogResult.No) {
                e.Cancel = true; //取消关闭操作
            }
        }
    }
}
