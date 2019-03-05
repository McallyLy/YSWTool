using System.Windows.Forms;
using ToolLibrary;
using YSWTool.Service;

namespace YSWTool
{
    public partial class UpdateLog : Form
    {
        public UpdateLog()
        {
            InitializeComponent();
            textBox.Text = FlieService.getLog();
        }
    }
}
