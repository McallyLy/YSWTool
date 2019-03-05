using System;
using System.IO;
using System.Text;

namespace ToolLibrary
{
    /// <summary>
    /// 文件操作类
    /// SAM 2017年4月1日10:29:30
    /// 生成，读取文件
    /// </summary>
    public class FlieService
    {
        /// <summary>
        /// 生成文件
        /// SAM 2017年3月4日00:33:47
        /// </summary>
        /// <param name="content">文件的内容</param>
        /// <param name="FileName">文件的名字，包括后缀名</param>
        public static void createFile(string content, string FileName)
        {
            //获取桌面路径：Environment.GetFolderPath(Environment.SpecialFolder.Desktop)
            //获取以桌面以当前年月日命名的文件夹，用以存放要生成的文件
            string strLogFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + DateTime.Now.ToString("yyyy年MM月dd日");

            DirectoryInfo di = new DirectoryInfo(strLogFolderPath);

            if (!di.Exists)//如果不存在，创建目录
                di.Create();

            string strLogPath = Path.Combine(strLogFolderPath, FileName);
            if (!File.Exists(strLogPath))//如果文件不存在
            {
                var o = File.Create(strLogPath);
                o.Close();
            }
            else//如果存在
            {
                File.Delete(strLogPath);//删除旧的
                var o = File.Create(strLogPath);//再创建
                o.Close();
            }
            try
            {
                FileInfo fi = new FileInfo(strLogPath);
                using (StreamWriter sw = fi.AppendText())
                {
                    sw.WriteLine(content);//写入内容
                    sw.Close();
                }
            }
            catch (Exception em)
            {
                Console.WriteLine(em.Message.ToString());
            }
        }

        /// <summary>
        /// 获取更新日志
        /// SAM 2017年3月5日00:03:33
        /// </summary>
        /// <returns></returns>
        public static string getLog()
        {
            StreamReader sr = new StreamReader("UpdateLog.txt", Encoding.Default);
            String line = null;
            string str = null;
            while ((line = sr.ReadLine()) != null)
            {
                str += line.ToString();
                str += "\r\n";
            }
            sr.Close();
            return str;
        }
    }
}
