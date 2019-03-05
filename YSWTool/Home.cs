using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using ToolLibrary;
using YSWTool.Service;

namespace YSWTool
{

    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
            DateTables.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        /// <summary>
        /// 打开表数据
        /// SAM 2017年3月31日16:03:48
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonTable_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(Start.Text) || string.IsNullOrWhiteSpace(End.Text))
            {
                //开始结束为空就什么都不做。
                //是否需要弹窗提醒？
            }
            else
            {
                ConfigFile con = ConfigFile.LoadOrCreateFile("config");
                ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
                string filename = config["FileName"]; //读取文件
                int start = int.Parse(Start.Text);//得到开始行
                int end = int.Parse(End.Text);//得到结束行
                DataTable dt = GeneralService.CreateTableDataTable();
                DataRow dr = null;
                //起止由界面填入，由于实际查询是从0开始的，为了方便。起止对应界面的排序。由系统自动减1
                start = start - 1;
                end = end - 1;
                IWorkbook wk = null;
                List<Hashtable> list = new List<Hashtable>();
                using (FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))   //打开.xls文件
                {
                    //xls和xlsx需要不同的获取函数
                    if (filename.EndsWith(".xls"))
                        wk = new HSSFWorkbook(fs);
                    else if (filename.EndsWith(".xlsx"))
                        wk = new XSSFWorkbook(fs);
                    //读取excel的第几个页签
                    ISheet sheet = wk.GetSheetAt(string.IsNullOrWhiteSpace(config["Table"].ToString()) ? 0 : int.Parse(config["Table"]) - 1);
                    for (int j = start; j <= end; j++) //循环行，循环列，将数据一个一个读出来
                    {
                        dr = dt.NewRow();
                        IRow row = sheet.GetRow(j);
                        ICell cell = null;
                        if (row != null)
                        {
                            cell = row.GetCell(0);
                            dr["序号"] = cell.ToString();
                            cell = row.GetCell(1);
                            dr["字段"] = cell.ToString();
                            cell = row.GetCell(2);
                            dr["说明"] = cell.ToString();
                            cell = row.GetCell(3);
                            dr["数据类型"] = cell.ToString();
                            cell = row.GetCell(4);
                            if (cell != null)
                                dr["是否空"] = cell.ToString();
                            cell = row.GetCell(5);
                            if (cell != null)
                                dr["默认值"] = cell.ToString();
                            if (j >= (start + 4))
                                dr["新增"] = true;
                            if (j >= (start + 5) && j <= (end - 4))
                                dr["编辑"] = true;
                            else
                                dr["编辑"] = false;

                        }
                        dt.Rows.Add(dr);//整合
                    }
                }
                DateTables.DataSource = dt;//赋值给表格显示
                for (int i = 0; i < DateTables.Columns.Count; i++) //循环设置移除表头的排序按钮
                {
                    DateTables.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;

                }
                DateTables.Columns[6].Width = 50;
                CreateModel.Enabled = true;
                CreateModelService.Enabled = true;
                CreateSQL.Enabled = true;
                CreateService.Enabled = true;
                TabControl.SelectedTab = TabControl.TabPages[0];
            }
        }

        /// <summary>
        /// 打开参数
        /// SAM 2017年3月2日23:23:03
        /// TODO 未完善
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Parameter_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Start.Text) || String.IsNullOrWhiteSpace(End.Text))
            {
                //开始和结束不些就什么都不做
            }
            else
            {
                ConfigFile con = ConfigFile.LoadOrCreateFile("config");
                ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
                string filename = config["FileName"]; //读取文件
                DataTable dt = GeneralService.CreateParameterDataTable();
                DataRow dr = null;
                int start = int.Parse(Start.Text);
                int end = int.Parse(End.Text);

                //起止由界面添加，由于实际查询是从0开始的，为了方便。起止对应界面的排序。由系统自动减1
                start = start - 1;
                end = end - 1;
                IWorkbook wk = null;
                using (FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))   //打开.xls文件
                {
                    //xls和xlsx需要不同的获取函数
                    if (filename.EndsWith(".xls"))
                        wk = new HSSFWorkbook(fs);
                    else if (filename.EndsWith(".xlsx"))
                        wk = new XSSFWorkbook(fs);
                    //读取excel的第几个页签
                    ISheet sheet = wk.GetSheetAt(string.IsNullOrWhiteSpace(config["Parameter"].ToString()) ? 0 : int.Parse(config["Parameter"]) - 1);
                    for (int j = start; j <= end; j++)
                    {
                        dr = dt.NewRow();
                        IRow row = sheet.GetRow(j);
                        ICell cell = null;
                        if (row != null)
                        {
                            if (con["Home"] == "MES")
                            {
                                cell = row.GetCell(1);
                                dr["参数流水"] = cell.ToString();
                                cell = row.GetCell(2);
                                if (cell != null)
                                    dr["代号"] = cell.ToString();
                                cell = row.GetCell(3);
                                dr["名称"] = cell.ToString();
                                cell = row.GetCell(4);
                                if (cell != null)
                                    dr["父参数名称"] = cell.ToString();
                                cell = row.GetCell(5);
                                dr["父参数流水"] = cell.ToString();
                            }
                            else
                            {
                                cell = row.GetCell(1);
                                dr["参数流水"] = cell.RichStringCellValue;
                                cell = row.GetCell(2);
                                dr["名称"] = cell.ToString();
                                cell = row.GetCell(3);
                                if (cell != null)
                                    dr["父参数名称"] = cell.ToString();
                                cell = row.GetCell(4);
                                dr["父参数流水"] = cell.ToString();
                            }
                        }
                        dt.Rows.Add(dr);
                    }

                }
                DateTables.DataSource = dt;
                for (int i = 0; i < DateTables.Columns.Count; i++)
                {
                    DateTables.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                TabControl.SelectedTab = TabControl.TabPages[1];
                CreateParameterSQL.Enabled = true;
                CreateModel.Enabled = false;
                CreateModelService.Enabled = false;
                CreateSQL.Enabled = false;
            }
        }

        /// <summary>
        /// 清空
        /// SAM 2017年3月2日23:23:11
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Emptied_Click(object sender, EventArgs e)
        {
            Start.Text = null;
            End.Text = null;
            DateTables.DataSource = null;
            logic.Text = null;
            CreateModel.Enabled = false;
            CreateModelService.Enabled = false;
            CreateSQL.Enabled = false;
            CreateParameterSQL.Enabled = false;
            runSQL.Enabled = false;
        }

        /// <summary>
        /// 创建model
        /// SAM 2017年3月4日00:16:40
        /// 1.读取DataGridView的内容，逐个拼接一个Model的内容
        /// 2.调用创建文件的函数，在桌面指定地方生成文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModel_Click(object sender, EventArgs e)
        {
            runSQL.Enabled = false;
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            string Namespaces = config["Model"]; //获取Modle的命名空间
            StringBuilder sb = new StringBuilder();
            int n = DateTables.RowCount;
            string startStr = "public ";
            string endStr = " { get; set; }";
            string Name = DateTables.Rows[0].Cells[0].Value.ToString().Substring(DateTables.Rows[0].Cells[0].Value.ToString().IndexOf('.') + 1);
            string type = null;

            sb.Append("namespace " + Namespaces + "");
            sb.Append("\r\n");
            sb.Append("{");
            sb.Append("\r\n");
            sb.Append("using MonkeyFly.Core;");
            sb.Append("\r\n");
            sb.Append("using System;");
            sb.Append("\r\n");
            sb.Append("public class " + Name + " : IModel");
            sb.Append("\r\n");
            sb.Append("{");
            sb.Append("\r\n");
            for (int x = 2; x < n; x++)
            {
                sb.Append(startStr);
                type = DateTables.Rows[x].Cells[3].Value.ToString();
                if (type.Contains("varchar"))
                    sb.Append("string");
                else if (type.Contains("int"))
                    sb.Append("int");
                else if (type.Contains("bit"))
                    sb.Append("bool");
                else if (type.Contains("datetime"))
                    sb.Append("DateTime");
                else if (type.Contains("numeric") || type.Contains("decimal"))
                    sb.Append("decimal");
                sb.Append(" " + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", ""));
                sb.Append(endStr);
                sb.Append("\r\n");
            }
            sb.Append("}");
            sb.Append("\r\n");
            sb.Append("}");
            logic.Text = sb.ToString();
            FlieService.createFile(sb.ToString(), Name + ".cs");
        }

        /// <summary>
        /// 创建modelService
        /// SAM 2017年3月5日01:00:41
        /// 1.读取DataGridView的内容，逐个拼接一个ModelService的内容
        ///   目前包括新增，更新，获取单一实体3个函数
        /// 2.调用创建文件的函数，在桌面指定地方生成文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateModelService_Click(object sender, EventArgs e)
        {
            runSQL.Enabled = false;
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            string Namespaces = config["ModelService"]; //获取ModleService的命名空间
            StringBuilder sb = new StringBuilder();
            int n = DateTables.RowCount;
            string TableName = DateTables.Rows[0].Cells[0].Value.ToString();
            TableName = TableName.Substring(TableName.IndexOf('.') + 1);   //获取表名（移除序号的）
            string TableID = DateTables.Rows[4].Cells[1].Value.ToString().Replace("[", "").Replace("]", ""); //获取表序号
            string type = null;
            sb.Append("using MonkeyFly.Core;\r\n");
            sb.Append("using MonkeyFly." + con["Home"] + ".BasicService;\r\n");
            sb.Append("using MonkeyFly." + con["Home"] + ".Models;\r\n");
            sb.Append("using MonkeyFly.Model;\r\n");
            sb.Append("using System;\r\n");
            sb.Append("using System.Collections;\r\n");
            sb.Append("using System.Collections.Generic;\r\n");
            sb.Append(" using System.Data;\r\n");
            sb.Append("using System.Data.SqlClient;\r\n");
            sb.Append("\r\n");
            sb.Append("namespace " + Namespaces + "\r\n");
            sb.Append("{\r\n");
            sb.Append("public class " + TableName + "Service : SuperModel<" + TableName + ">\r\n");
            sb.Append("{\r\n");

            sb.Append("\r\n");
            //添加函数
            string key = null;
            string value = null;
            if (con["Home"] == "EMO" || con["Home"] == "MES") //因为EMO系统的特别。所以要区分好当前配置是否为EMO
            {
                sb.Append("public static bool insert(string userId, " + TableName + " Model)\r\n");
                sb.Append("{\r\n");
                sb.Append("try\r\n");
                sb.Append("{\r\n");
                sb.Append("string sql = string.Format(@\"insert[" + TableName + "](");
                for (int x = 4; x < n; x++)
                {
                    string CellsSix = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(CellsSix) && bool.Parse(CellsSix))//判断新增按钮是否勾选
                    {
                        if (x % 3 == 0)
                            key += "\r\n";
                        key += DateTables.Rows[x].Cells[1].Value.ToString() + ",";
                    }
                }
                key += "[SystemID]) values\r\n (";
                sb.Append(key);
                for (int x = 4; x < n - 6; x++) //新增时，不需要拼接最后6项。
                {
                    string cellsix = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cellsix) && bool.Parse(cellsix))//判断新增按钮是否勾选
                    {
                        if (x % 3 == 0)
                            value += "\r\n";
                        value += "@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + ",";
                    }
                }
                value = value + "'{0}','{1}','{2}','{0}','{1}','{2}','{3}')\", userId,DateTime.UtcNow,DateTime.Now,Framework.SystemID); ";
                sb.Append(value);
                sb.Append("\r\n");
                sb.Append("\r\n");
                sb.Append(" SqlParameter[] parameters = new SqlParameter[]{");

                for (int x = 4; x < n - 6; x++)//新增时，不需要拼接最后6项。
                {
                    string cellsix = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cellsix) && bool.Parse(cellsix))//判断新增按钮是否勾选
                    {
                        sb.Append("\r\n");
                        sb.Append("\t\t\t\t\t");
                        sb.Append("new SqlParameter(\"@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + "\",SqlDbType.");
                        type = DateTables.Rows[x].Cells[3].Value.ToString();
                        if (type.Contains("nvarchar"))
                            sb.Append("NVarChar");
                        else if (type.Contains("varchar"))
                            sb.Append("VarChar");
                        else if (type.Contains("tinyint"))
                            sb.Append("TinyInt");
                        else if (type.Contains("int"))
                            sb.Append("Int");
                        else if (type.Contains("bit"))
                            sb.Append("Bit");
                        else if (type.Contains("datetime"))
                            sb.Append("DateTime");
                        else if (type.Contains("numeric"))
                            sb.Append("Decimal");
                        sb.Append("),");
                    }
                }
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("};\r\n");
                sb.Append("\r\n");
                int i = 0;
                for (int x = 4; x < n - 6; x++)
                {
                    string cell = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cell) && bool.Parse(cell))//判断新增按钮是否勾选
                    {
                        if (x % 3 == 0)
                            value += "\r\n";
                        sb.Append("parameters[" + i.ToString() + "].Value = (Object)Model." + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + " ?? DBNull.Value;\r\n");
                    }
                    i++;
                }
                sb.Append("\r\n");
                sb.Append("return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;\r\n");
                sb.Append("}\r\n");
                sb.Append("catch (Exception ex)\r\n");
                sb.Append("{\r\n");
                sb.Append("DataLogerService.writeerrlog(ex);\r\n");
                sb.Append("return false;\r\n");
                sb.Append("}\r\n");
                sb.Append("}\r\n");

                sb.Append("\r\n");
                //更新函数 
                sb.Append("public static bool update(string userId, " + TableName + " Model)\r\n");
                sb.Append("{\r\n");
                sb.Append("try\r\n");
                sb.Append("{\r\n");

                sb.Append("string sql = String.Format(@\"update[" + TableName + "] set {0},");
                sb.Append("\r\n");
                key = null;
                value = null;

                for (int x = 5; x < n; x++)//更新默认从流水号的下一行开始
                {
                    string cell = DateTables.Rows[x].Cells[7].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(cell) && bool.Parse(cell))//判断更新按钮是否勾选
                    {
                        if (x % 4 == 0)
                            key += "\r\n";
                        key += DateTables.Rows[x].Cells[1].Value.ToString() + "=@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + ",";
                    }
                }
                sb.Append(key.Trim(','));
                sb.Append(" where [" + TableID + "]=@" + TableID + "\", UniversalService.getUpdateUTC(userId));");
                sb.Append("\r\n");

                sb.Append(" SqlParameter[] parameters = new SqlParameter[]{");
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("new SqlParameter(\"@" + TableID + "\",SqlDbType.VarChar),");
                for (int x = 5; x < n - 1; x++)
                {
                    string cell = DateTables.Rows[x].Cells[7].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cell) && bool.Parse(cell))
                    {
                        sb.Append("\r\n");
                        sb.Append("\t\t\t\t\t");
                        sb.Append("new SqlParameter(\"@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + "\",SqlDbType.");
                        type = DateTables.Rows[x].Cells[3].Value.ToString();
                        if (type.Contains("nvarchar"))
                            sb.Append("NVarChar");
                        else if (type.Contains("nvarchar"))
                            sb.Append("NVarChar");
                        else if (type.Contains("varchar"))
                            sb.Append("VarChar");
                        else if (type.Contains("tinyint"))
                            sb.Append("TinyInt");
                        else if (type.Contains("int"))
                            sb.Append("Int");
                        else if (type.Contains("bit"))
                            sb.Append("Bit");
                        else if (type.Contains("datetime"))
                            sb.Append("DateTime");
                        else if (type.Contains("numeric"))
                            sb.Append("Decimal");
                        sb.Append("),");
                    }
                }
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("};\r\n");
                sb.Append("\r\n");
                sb.Append("parameters[0].Value =Model." + TableID + ";\r\n");
                i = 1;
                for (int x = 4; x < n; x++)
                {
                    string cell = DateTables.Rows[x].Cells[7].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cell) && bool.Parse(cell))
                    {
                        sb.Append("parameters[" + i.ToString() + "].Value = (Object)Model." + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + " ?? DBNull.Value;\r\n");
                        i++;
                    }
                }
                sb.Append("\r\n");
                sb.Append("return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;\r\n");
                sb.Append("}\r\n");
                sb.Append("catch (Exception ex)\r\n");
                sb.Append("{\r\n");
                sb.Append("DataLogerService.writeerrlog(ex);\r\n");
                sb.Append("return false;\r\n");
                sb.Append("}\r\n");
                sb.Append("}\r\n");
            }
            else  //其他情况
            {
                sb.Append("public static bool insert(string userId, " + TableName + " Model)\r\n");
                sb.Append("{\r\n");
                sb.Append("try\r\n");
                sb.Append("{\r\n");
                sb.Append("string sql = string.Format(@\"insert[" + TableName + "](");
                for (int x = 4; x < n; x++)
                {
                    string cells = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cells) && bool.Parse(cells))//判断新增按钮是否勾选
                    {
                        if (x % 3 == 0)
                            key += "\r\n";
                        key += DateTables.Rows[x].Cells[1].Value.ToString() + ",";

                    }
                }
                key += "[SystemID]) values\r\n (";
                sb.Append(key);
                for (int x = 4; x < n - 4; x++)//新增时，不需要拼接最后4项。
                {
                    string cells = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cells) && bool.Parse(cells))//判断新增按钮是否勾选
                    {
                        if (x % 3 == 0)
                            value += "\r\n";
                        value += "@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + ",";
                    }
                }
                value = value + "'{0}','{1}','{0}','{1}','{2}')\", userId,DateTime.Now,Framework.SystemID); ";
                sb.Append(value);
                sb.Append("\r\n");
                sb.Append("\r\n");
                sb.Append(" SqlParameter[] parameters = new SqlParameter[]{");

                for (int x = 4; x < n - 4; x++)//新增时，不需要拼接最后4项。
                {
                    string cells = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cells) && bool.Parse(cells))//判断新增按钮是否勾选
                    {
                        sb.Append("\r\n");
                        sb.Append("\t\t\t\t\t");
                        sb.Append("new SqlParameter(\"@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + "\",SqlDbType.");
                        type = DateTables.Rows[x].Cells[3].Value.ToString();
                        if (type.Contains("nvarchar"))
                            sb.Append("NVarChar");
                        else if (type.Contains("varchar"))
                            sb.Append("VarChar");
                        else if (type.Contains("tinyint"))
                            sb.Append("TinyInt");
                        else if (type.Contains("int"))
                            sb.Append("Int");
                        else if (type.Contains("bit"))
                            sb.Append("Bit");
                        else if (type.Contains("datetime"))
                            sb.Append("DateTime");
                        else if (type.Contains("numeric"))
                            sb.Append("Decimal");
                        sb.Append("),");
                    }
                }
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("};\r\n");
                sb.Append("\r\n");
                int i = 0;
                for (int x = 4; x < n - 4; x++)
                {
                    string cells = DateTables.Rows[x].Cells[6].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cells)&&bool.Parse(cells))//判断新增按钮是否勾选
                    {
                        sb.Append("parameters[" + i.ToString() + "].Value = (Object)Model." + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + " ?? DBNull.Value;\r\n");
                        i++;
                    }

                }
                sb.Append("\r\n");
                sb.Append("return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;\r\n");
                sb.Append("}\r\n");
                sb.Append("catch (Exception ex)\r\n");
                sb.Append("{\r\n");
                sb.Append("DataLogerService.writeerrlog(ex);\r\n");
                sb.Append("return false;\r\n");
                sb.Append("}\r\n");
                sb.Append("}\r\n");

                sb.Append("\r\n");
                //更新函数 
                sb.Append("public static bool update(string userId, " + TableName + " Model)\r\n");
                sb.Append("{\r\n");
                sb.Append("try\r\n");
                sb.Append("{\r\n");

                sb.Append("string sql = String.Format(@\"update[" + TableName + "] set {0},");
                sb.Append("\r\n");
                key = null;
                value = null;

                for (int x = 5; x < n; x++)//更新默认从流水号的下一行开始
                {
                    string cellone = DateTables.Rows[x].Cells[7].Value.ToString();
                    if (!string.IsNullOrWhiteSpace(cellone) && bool.Parse(cellone))//判断更新按钮是否勾选
                    {
                        if (x % 4 == 0)
                            key += "\r\n";
                        key += DateTables.Rows[x].Cells[1].Value.ToString() + "=@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + ",";
                    }
                }
                sb.Append(key.Trim(','));
                sb.Append(" where [" + TableID + "]=@" + TableID + "\", UniversalService.getUpdate(userId));");
                sb.Append("\r\n");

                sb.Append(" SqlParameter[] parameters = new SqlParameter[]{");
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("new SqlParameter(\"@" + TableID + "\",SqlDbType.VarChar),");
                for (int x = 5; x < n - 1; x++)
                {
                    string cells = DateTables.Rows[x].Cells[7].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(cells) && bool.Parse(cells))
                    {
                        sb.Append("\r\n");
                        sb.Append("\t\t\t\t\t");
                        sb.Append("new SqlParameter(\"@" + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + "\",SqlDbType.");
                        type = DateTables.Rows[x].Cells[3].Value.ToString();
                        if (type.Contains("nvarchar"))
                            sb.Append("NVarChar");
                        else if (type.Contains("varchar"))
                            sb.Append("VarChar");
                        else if (type.Contains("tinyint"))
                            sb.Append("TinyInt");
                        else if (type.Contains("int"))
                            sb.Append("Int");
                        else if (type.Contains("bit"))
                            sb.Append("Bit");
                        else if (type.Contains("datetime"))
                            sb.Append("DateTime");
                        else if (type.Contains("numeric"))
                            sb.Append("Decimal");
                        sb.Append("),");
                    }
                }
                sb.Append("\r\n");
                sb.Append("\t\t\t\t\t");
                sb.Append("};\r\n");
                sb.Append("\r\n");
                sb.Append("parameters[0].Value =Model." + TableID + ";\r\n");
                i = 1;
                for (int x = 4; x < n; x++)
                {
                    string CellsSeven = DateTables.Rows[x].Cells[7].Value.ToString();

                    if (!string.IsNullOrWhiteSpace(CellsSeven) && bool.Parse(CellsSeven))
                    {
                        sb.Append("parameters[" + i.ToString() + "].Value = (Object)Model." + DateTables.Rows[x].Cells[1].Value.ToString().Replace("[", "").Replace("]", "") + " ?? DBNull.Value;\r\n");
                        i++;
                    }
                }
                sb.Append("\r\n");
                sb.Append("return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;\r\n");
                sb.Append("}\r\n");
                sb.Append("catch (Exception ex)\r\n");
                sb.Append("{\r\n");
                sb.Append("DataLogerService.writeerrlog(ex);\r\n");
                sb.Append("return false;\r\n");
                sb.Append("}\r\n");
                sb.Append("}\r\n");
            }

            sb.Append("\r\n");
            //获取单一实体
            sb.Append("public static " + TableName + " get(string " + TableID + ")\r\n");
            sb.Append("{\r\n");
            sb.Append("string sql = string.Format(@\"select Top 1 * from [" + TableName + "] where [" + TableID + "] = '{0}'  and [SystemID] = '{1}' \", " + TableID + ", Framework.SystemID);");
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append("DataTable dt = SQLHelper.ExecuteDataTable(sql, CommandType.Text);");
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append("if (dt.Rows.Count == 0)");
            sb.Append("\r\n");
            sb.Append("return null;");
            sb.Append("\r\n");
            sb.Append("else");
            sb.Append("\r\n");
            sb.Append("return ToEntity(dt.Rows[0]);");
            sb.Append("\r\n");
            sb.Append("}\r\n");

            sb.Append("\r\n");
            //删除
            sb.Append("public static bool delete(string " + TableID + ")\r\n");
            sb.Append("{\r\n");
            sb.Append("try\r\n");
            sb.Append("{\r\n");
            sb.Append("string sql = string.Format(@\"delete from [" + TableName + "] where [" + TableID + "] = '{0}'  and [SystemID] = '{1}' \", " + TableID + ", Framework.SystemID);");
            sb.Append("\r\n");
            sb.Append("\r\n");
            sb.Append("return SQLHelper.ExecuteNonQuery(sql, CommandType.Text) > 0;");
            sb.Append("\r\n");
            sb.Append("}\r\n");
            sb.Append("\r\n");
            sb.Append("catch (Exception ex)");
            sb.Append("\r\n");
            sb.Append("{\r\n");
            sb.Append("\r\n");
            sb.Append(" DataLogerService.writeerrlog(ex);");
            sb.Append("\r\n");
            sb.Append(" return false;");
            sb.Append("\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");


            sb.Append("}\r\n");
            sb.Append("}\r\n");
            logic.Text = sb.ToString();
            FlieService.createFile(sb.ToString(), TableName + "Service.cs");
        }

        /// <summary>
        /// 创建SQL
        /// SAM 2017年3月4日00:16:17
        /// 1.读取DataGridView的内容，逐个拼接一个标准的创表代码
        /// 2.顺带生成编号生成表和表属性表的插入语句
        /// 3.直接调用函数将此SQL执行？（未做）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateSQL_Click(object sender, EventArgs e)
        {
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            StringBuilder sb = new StringBuilder();
            int n = DateTables.RowCount;
            //获取表名
            string Tablename = DateTables.Rows[0].Cells[0].Value.ToString().Substring(DateTables.Rows[0].Cells[0].Value.ToString().IndexOf('.') + 1);
            //获取表序号
            int num = int.Parse(DateTables.Rows[0].Cells[0].Value.ToString().Substring(0, DateTables.Rows[0].Cells[0].Value.ToString().IndexOf('.')));
            //获取表的流水号
            string TableID = DateTables.Rows[4].Cells[1].Value.ToString().Replace("[", "").Replace("]", "");
            sb.Append("CREATE TABLE [dbo].[" + Tablename + "](");
            sb.Append("\r\n");
            for (int x = 2; x < n; x++)
            {
                sb.Append(DateTables.Rows[x].Cells[1].Value.ToString());
                sb.Append(" ");
                sb.Append(DateTables.Rows[x].Cells[3].Value.ToString());
                sb.Append(" ");
                if (string.IsNullOrWhiteSpace(DateTables.Rows[x].Cells[4].Value.ToString()))
                    sb.Append("NULL");
                else
                    sb.Append(DateTables.Rows[x].Cells[4].Value.ToString());
                if (!string.IsNullOrWhiteSpace(DateTables.Rows[x].Cells[5].Value.ToString()) && DateTables.Rows[x].Cells[5].Value.ToString() != "[S]" && DateTables.Rows[x].Cells[5].Value.ToString() != "[P]" && DateTables.Rows[x].Cells[5].Value.ToString() != "[A]")
                    sb.Append(" DEFAULT " + DateTables.Rows[x].Cells[5].Value.ToString());
                sb.Append(",");
                sb.Append("\r\n");
            }
            sb.Append("CONSTRAINT [PK_" + Tablename + "] PRIMARY KEY CLUSTERED \r\n(\r\n[ID] ASC\r\n)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]\r\n) ON [PRIMARY];");
            sb.Append("\r\n");
            sb.Append("create unique nonclustered index  [unique" + TableID + "] on [" + Tablename + "] ([SystemID] asc,  [" + TableID + "] asc );");
            sb.Append("\r\n");
            if (con["Home"].ToString() == "EMO" || con["Home"].ToString() == "MES")
            {
                sb.Append("INSERT[dbo].[SYS_TableProperty]([SystemID], [TablePropertyID], [TableName], [Database],[Modifier],[Creator]) VALUES(N'" + config["SystemID"].ToString() + "'," + num.ToString() + ", N'" + Tablename + "', N'" + config["SystemID"].ToString() + "', N'adminy', N'adminy');");
                sb.Append("\r\n");
                sb.Append("INSERT [dbo].[SYS_SerialNumber] ([SystemID], [SNID], [TableName], [TablePropertyID], [FirstSN], [SplitOne], [DateID], [SplitTwo], [Number], [IsClear], [Sequence],[Modifier], [Creator]) VALUES (N'" + config["SystemID"].ToString() + "', N'" + config["SystemID"].ToString() + "0021213" + num.ToString().PadLeft(6, '0') + "', N'" + Tablename + "', " + num.ToString() + ", N'" + config["SystemID"].ToString() + "', NULL, N'yyMM', NULL, N'1', 0, 1, N'adminy', N'adminy');");
            }
            else
            {
                sb.Append("INSERT[dbo].[TableProperty]([SystemID], [TablePropertyID], [TableName], [Database],[Modifier],[Creator], [CreateTime]) VALUES(N'" + config["SystemID"].ToString() + "'," + num.ToString() + ", N'" + Tablename + "', N'" + config["SystemID"].ToString() + "', N'adminy', N'adminy', N'" + DateTime.Now + "');");
                sb.Append("\r\n");
                sb.Append("INSERT [dbo].[SerialNumber] ([SystemID], [SNID], [TableName], [TablePropertyID], [FirstSN], [SplitOne], [DateID], [SplitTwo], [Number], [IsClear], [Sequence],[Modifier], [Creator], [CreateTime]) VALUES (N'" + config["SystemID"].ToString() + "', N'" + config["SystemID"].ToString() + "0021213" + num.ToString().PadLeft(6, '0') + "', N'" + Tablename + "', " + num.ToString() + ", N'" + config["SystemID"].ToString() + "', NULL, N'yyMM', NULL, N'1', 0, 1, N'adminy', N'adminy', N'" + DateTime.Now + "');");
            }
            logic.Text = sb.ToString();
            runSQL.Enabled = true;
        }

        /// <summary>
        /// 打开更新日志窗口
        /// SAM 2017年3月5日00:53:18
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateLog_Click(object sender, EventArgs e)
        {
            UpdateLog log = new UpdateLog();
            log.ShowDialog();
        }

        /// <summary>
        /// 打开配置窗口
        /// SAM 2017年3月5日00:53:29
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Config_Click(object sender, EventArgs e)
        {
            Config form = new Config();
            form.ShowDialog();
        }

        /// <summary>
        /// 生成参数的插入语句
        /// SAM 2017年3月5日11:13:02
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateParameterSQL_Click(object sender, EventArgs e)
        {
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            int n = DateTables.RowCount;
            string sqlAAA = null;
            string sql = null;
            int Sequence = 10;
            if (con["Home"].ToString() == "EMO")
            {
                sqlAAA = "INSERT [SYS_Parameters] ([SystemID], [ParameterID], [OrganizationID],[ParameterTypeID],[UsingType],[Code],[Description],[Name],[DescriptionOne],[IsSystem], [IsEnable], [IsDefault], [Sequence], [Modifier], [Creator]) VALUES(N'{0}', N'{1}', '0', N'{3}', '0',N'', N'', N'{2}', N'', 0, 1, 0, {4}, N'adminy', N'adminy');";

                sql = null;
                for (int x = 0; x < n; x++)
                {
                    sql += string.Format(sqlAAA,
                        config["SystemID"].ToString(),
                        DateTables.Rows[x].Cells[0].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        DateTables.Rows[x].Cells[1].Value.ToString(),
                        DateTables.Rows[x].Cells[3].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        Sequence);
                    sql += "\r\n";
                    Sequence += 10;
                }
            }
            else if (con["Home"].ToString() == "MES") //MES移除了OrganizationID，加入了Code的概念
            {

                sqlAAA = "INSERT [SYS_Parameters] ([SystemID],[ParameterID],[ParameterTypeID],[UsingType],[Code],[Description],[Name],[DescriptionOne],[IsSystem], [IsEnable], [IsDefault], [Sequence], [Modifier], [Creator]) VALUES(N'{0}', N'{1}', N'{3}', '0', N'{4}',N'', N'{2}', N'', 0, 1, 0, {5}, N'adminy', N'adminy');";

                sql = null;

                for (int x = 0; x < n; x++)
                {
                    sql += string.Format(sqlAAA,
                        config["SystemID"].ToString(),
                        DateTables.Rows[x].Cells[0].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        DateTables.Rows[x].Cells[2].Value.ToString(),
                        DateTables.Rows[x].Cells[4].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        DateTables.Rows[x].Cells[1].Value.ToString(),
                        Sequence);

                    sql += "\r\n";
                    Sequence += 10;
                }
            }
            else
            {
                sqlAAA = "INSERT [Parameters] ([SystemID], [ParameterID], [ParameterTypeID],[Name],[IsSystem], [IsEnable], [IsDefault], [Sequence], [Modifier], [Creator]) VALUES(N'{0}', N'{1}', N'{3}', N'{2}', 0, 1, 0, {4}, N'adminy', N'adminy');";
                sql = null;
                for (int x = 0; x < n; x++)
                {

                    sql += String.Format(sqlAAA,
                        config["SystemID"].ToString(),
                        DateTables.Rows[x].Cells[0].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        DateTables.Rows[x].Cells[2].Value.ToString(),
                        DateTables.Rows[x].Cells[4].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        Sequence);
                    sql += "\r\n";
                    Sequence += 10;
                }
            }
            ParameterText.Text = sql;
            runSQL.Enabled = true;
        }

        /// <summary>
        /// 执行SQL
        /// SAM 2017年3月5日23:01:361
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void runSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(logic.Text))
                {
                    if (SQLHelper.ExecuteNonQuery(logic.Text) > 0)
                        MessageBox.Show("执行成功！", "提示");
                    else
                        MessageBox.Show("执行失败！", "提示");
                }
                else
                    MessageBox.Show("没有要执行的！", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行失败！失败原因：" + ex.ToString(), "提示");
            }
        }

        /// <summary>
        /// 执行SQL
        /// SAM 2017年3月5日23:01:361
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParameterrunSQL_Click(object sender, EventArgs e)
        {
            try
            {
                if (!String.IsNullOrWhiteSpace(ParameterText.Text))
                {
                    if (SQLHelper.ExecuteNonQuery(ParameterText.Text) > 0)
                        MessageBox.Show("执行成功！", "提示");
                    else
                        MessageBox.Show("执行失败！", "提示");
                }
                else
                    MessageBox.Show("没有要执行的！", "提示");
            }
            catch (Exception ex)
            {
                MessageBox.Show("执行失败！失败原因：" + ex.ToString(), "提示");
            }
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreateService_Click(object sender, EventArgs e)
        {
            runSQL.Enabled = false;
            ConfigFile config = ConfigFile.LoadOrCreateFile("config");
            StringBuilder sb = new StringBuilder();
            int n = DateTables.RowCount;
            //获取表名（移除序号的）
            string TableName = DateTables.Rows[0].Cells[0].Value.ToString();
            TableName = TableName.Substring(TableName.IndexOf('.') + 1);
            //获取表的流水号
            string TableID = DateTables.Rows[4].Cells[1].Value.ToString().Replace("[", "").Replace("]", "");
            string Name = "";//函数名
            string BUssiness = "";//业务逻辑层名字

            sb.Append("[HttpPost]\r\n");
            sb.Append("[Authenticate]\r\n");
            sb.Append("public object " + Name + "(JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append(" DataLogerService.writeURL(request.Value<string>(\"Token\"), request.ToString());\r\n");
            sb.Append("bool isDelete = false;\r\n");
            sb.Append("bool isInsert = false;\r\n");
            sb.Append("bool isUpdate = false;\r\n");

            sb.Append("object deleted = null;\r\n");
            sb.Append("object Insert = null;\r\n");
            sb.Append("object Update = null;\r\n");

            sb.Append("foreach (JProperty i in request.Children())\r\n");
            sb.Append("{\r\n");
            sb.Append("if (i.Name != \"Token\" && ((JArray)i.Value).Count > 0)\r\n");
            sb.Append("{\r\n");
            sb.Append("switch (i.Name)\r\n");
            sb.Append("{\r\n");
            sb.Append("case \"deleted\": isDelete = true; break;\r\n");
            sb.Append("case \"inserted\": isInsert = true; break;\r\n");
            sb.Append("case \"updated\": isUpdate = true; break;\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");
            sb.Append("if (isDelete)\r\n");
            sb.Append("deleted = " + BUssiness + "BussinessService." + Name + "delete(request.Value<string>(\"Token\"), (JArray)request.Value<JArray>(\"deleted\"));\r\n");
            sb.Append("if (isInsert)\r\n");
            sb.Append("Insert = " + BUssiness + "BussinessService." + Name + "insert(request.Value<string>(\"Token\"), (JArray)request.Value<JArray>(\"inserted\"));\r\n");
            sb.Append("if (isUpdate)\r\n");
            sb.Append("Update = " + BUssiness + "BussinessService." + Name + "update(request.Value<string>(\"Token\"), (JArray)request.Value<JArray>(\"updated\"));\r\n");
            sb.Append("\r\n");
            sb.Append("return new { inserted = Insert, updated = Update, deleted = deleted };\r\n");
            sb.Append(" }\r\n");


            //新增
            sb.Append("public static object " + Name + "insert(string Token, JArray jArray)\r\n");
            sb.Append("{\r\n");
            sb.Append("int success = 0;\r\n");
            sb.Append("int fail = 0;\r\n");
            sb.Append("string failIDs = null;\r\n");
            sb.Append("string msg = null;\r\n");
            sb.Append("string companyID = UtilBussinessService.getCompany(Token)[\"OrganizationID\"].ToString();\r\n");
            sb.Append("string userid = UtilBussinessService.detoken(Token);\r\n");
            sb.Append("JObject data = null;\r\n");
            sb.Append("" + TableName + " Model = null;\r\n"); //相关表实体
            sb.Append("for (int i = 0; i < jArray.Count; i++)\r\n");
            sb.Append("{\r\n");
            sb.Append(" data = (JObject)jArray[i];\r\n");
            //判断是否重复
            //实体新对象
            //赋值
            sb.Append("if(" + TableName + "Service.insert(userid, Model))\r\n");//执行插入语句
            sb.Append("success++;\r\n");
            sb.Append("else\r\n");
            sb.Append("{\r\n");
            sb.Append("failIDs = str(failIDs, data.Value<string>(\"" + TableID + "\"));\r\n");
            sb.Append("fail++;\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");
            sb.Append("return new { success = success, fail = fail, failIDs = failIDs, msg = msg };\r\n");
            sb.Append("}\r\n");

            //更新
            sb.Append("public static object " + Name + "update(string Token, JArray jArray)\r\n");
            sb.Append("{\r\n");
            sb.Append("int success = 0;\r\n");
            sb.Append("int fail = 0;\r\n");
            sb.Append("string failIDs = null;\r\n");
            sb.Append("string msg = null;\r\n");
            sb.Append("string companyID = UtilBussinessService.getCompany(Token)[\"OrganizationID\"].ToString();\r\n");
            sb.Append("string userid = UtilBussinessService.detoken(Token);\r\n");
            sb.Append("JObject data = null;\r\n");
            sb.Append("" + TableName + " Model = null;\r\n"); //相关表实体
            sb.Append("for (int i = 0; i < jArray.Count; i++)\r\n");
            sb.Append("{\r\n");
            sb.Append(" data = (JObject)jArray[i];\r\n");
            //判断是否重复
            //获取实体
            //赋值        
            sb.Append("if(" + TableName + "Service.update(userid, Model))\r\n");//执行更新语句
            sb.Append("  success++;\r\n");
            sb.Append("else\r\n");
            sb.Append("{\r\n");
            sb.Append("failIDs = str(failIDs, data.Value<string>(\"" + TableID + "\"));\r\n");
            sb.Append("fail++;\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");
            sb.Append("return new { success = success, fail = fail, failIDs = failIDs, msg = msg };\r\n");
            sb.Append("}\r\n");



            //删除
            sb.Append("public static object " + Name + "delete(string Token, JArray jArray)\r\n");
            sb.Append("{\r\n");
            sb.Append("int success = 0;\r\n");
            sb.Append("int fail = 0;\r\n");
            sb.Append("string failIDs = null;\r\n");
            sb.Append("string msg = null;\r\n");
            sb.Append("string companyID = UtilBussinessService.getCompany(Token)[\"OrganizationID\"].ToString();\r\n");
            sb.Append("string userid = UtilBussinessService.detoken(Token);\r\n");
            sb.Append("JObject data = null;\r\n");
            sb.Append("" + TableName + " Model = null;\r\n"); //相关表实体
            sb.Append("for (int i = 0; i < jArray.Count; i++)\r\n");
            sb.Append("{\r\n");
            sb.Append(" data = (JObject)jArray[i];\r\n");
            //获取实体 
            sb.Append("Model.Status = Framework.SystemID + \"0201213000189\";\r\n");
            sb.Append("if(" + TableName + "Service.update(userid, Model))\r\n");//执行更新语句
            sb.Append("  success++;\r\n");
            sb.Append("else\r\n");
            sb.Append("{\r\n");
            sb.Append("failIDs = str(failIDs, data.Value<string>(\"" + TableID + "\"));\r\n");
            sb.Append("fail++;\r\n");
            sb.Append("}\r\n");
            sb.Append("}\r\n");
            sb.Append("return new { success = success, fail = fail, failIDs = failIDs, msg = msg };\r\n");
            sb.Append("}\r\n");






            //新增
            sb.Append("[HttpPost]\r\n");
            sb.Append("[Authenticate]\r\n");
            sb.Append("public object " + Name + "Add(JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string Token = request.Value<string>(\"Token\");\r\n");
            sb.Append("DataLogerService.writeURL(Token, request.ToString());\r\n");
            sb.Append("return " + BUssiness + "BussinessServiceService." + Name + "Add(Token, request);\r\n");
            sb.Append("}\r\n");


            sb.Append("public static object " + Name + "Add(string token, JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string userId = UtilBussinessService.detoken(token);\r\n");
            sb.Append("string CompanyID = UtilBussinessService.getCompany(token)[\"OrganizationID\"].ToString();\r\n");
            sb.Append("\r\n");//判断重复
            //sb.Append("{\r\n");
            //sb.Append("" + TableName + " Model = " + TableName + "Service.get(request.Value<string>(\""+TableID+"\"));\r\n");
            //赋值
            sb.Append("if(" + TableName + "Service.insert(userid, Model))\r\n");//执行更新语句
            sb.Append("return new { status = \"200\", msg = \"添加成功!\" };\r\n");
            sb.Append("else\r\n");
            sb.Append("return new { status = \"410\", msg = \"添加失败!\" };\r\n");
            //sb.Append("}\r\n");
            //sb.Append("return new { status =\"441\", msg = \"已存在代号!\" };\r\n");
            sb.Append("}\r\n");



            //修改
            sb.Append("[HttpPost]\r\n");
            sb.Append("[Authenticate]\r\n");
            sb.Append("public object " + Name + "Update(JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string Token = request.Value<string>(\"Token\");\r\n");
            sb.Append("DataLogerService.writeURL(Token, request.ToString());\r\n");
            sb.Append("return " + BUssiness + "BussinessServiceService." + Name + "Update(Token, request);\r\n");
            sb.Append("}\r\n");


            sb.Append("public static object " + Name + "Update(string token, JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string userId = UtilBussinessService.detoken(token);\r\n");
            sb.Append("string CompanyID = UtilBussinessService.getCompany(token)[\"OrganizationID\"].ToString();\r\n");
            //sb.Append("\r\n");//判断重复
            //sb.Append("{\r\n");
            sb.Append("" + TableName + " Model = " + TableName + "Service.get(request.Value<string>(\"" + TableID + "\"));\r\n");
            //赋值
            sb.Append("if(" + TableName + "Service.update(userid, Model))\r\n");//执行更新语句
            sb.Append("return new { status = \"200\", msg = \"修改成功!\" };\r\n");
            sb.Append("else\r\n");
            sb.Append("return new { status = \"410\", msg = \"修改失败!\" };\r\n");
            //sb.Append("}\r\n");
            //sb.Append("return new { status =\"441\", msg = \"已存在代号!\" };\r\n");
            sb.Append("}\r\n");


            //删除
            sb.Append("[HttpPost]\r\n");
            sb.Append("[Authenticate]\r\n");
            sb.Append("public object " + Name + "Delete(JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string Token = request.Value<string>(\"Token\");\r\n");
            sb.Append("DataLogerService.writeURL(Token, request.ToString());\r\n");
            sb.Append("return " + BUssiness + "BussinessServiceService." + Name + "Delete(Token, request);\r\n");
            sb.Append("}\r\n");


            sb.Append("public static object " + Name + "Delete(string token, JObject request)\r\n");
            sb.Append("{\r\n");
            sb.Append("string userId = UtilBussinessService.detoken(token);\r\n");
            sb.Append("string CompanyID = UtilBussinessService.getCompany(token)[\"OrganizationID\"].ToString();\r\n");
            sb.Append("" + TableName + " Model = " + TableName + "Service.get(request.Value<string>(\"" + TableID + "\"));\r\n");
            sb.Append("Model.Status = Framework.SystemID + \"0201213000189\";\r\n");
            sb.Append("if(" + TableName + "Service.update(userid, Model))\r\n");//执行更新语句
            sb.Append("return new { status = \"200\", msg = \"删除成功!\" };\r\n");
            sb.Append("else\r\n");
            sb.Append("return new { status = \"410\", msg = \"删除失败!\" };\r\n");
            sb.Append("}\r\n");

            logic.Text = sb.ToString();
        }

        /// <summary>
        /// 参数类型
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParType_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(Start.Text) || String.IsNullOrWhiteSpace(End.Text))
            {
                //开始和结束不些就什么都不做
            }
            else
            {
                ConfigFile con = ConfigFile.LoadOrCreateFile("config");
                ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
                string filename = config["FileName"]; //读取文件
                DataTable dt = GeneralService.CreateParTypeDataTable();
                DataRow dr = null;
                int start = int.Parse(Start.Text);
                int end = int.Parse(End.Text);

                //起止由界面添加，由于实际查询是从0开始的，为了方便。起止对应界面的排序。由系统自动减1
                start = start - 1;
                end = end - 1;
                IWorkbook wk = null;
                using (FileStream fs = new FileStream(@filename, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))   //打开.xls文件
                {
                    //xls和xlsx需要不同的获取函数
                    if (filename.EndsWith(".xls"))
                        wk = new HSSFWorkbook(fs);
                    else if (filename.EndsWith(".xlsx"))
                        wk = new XSSFWorkbook(fs);
                    //读取excel的第几个页签
                    ISheet sheet = wk.GetSheetAt(string.IsNullOrWhiteSpace(config["ParType"].ToString()) ? 0 : int.Parse(config["ParType"]) - 1);
                    for (int j = start; j <= end; j++)
                    {
                        dr = dt.NewRow();
                        IRow row = sheet.GetRow(j);
                        ICell cell = null;
                        if (row != null)
                        {
                            cell = row.GetCell(1);
                            dr["流水号"] = cell.StringCellValue;
                            cell = row.GetCell(2);
                            dr["参数类型"] = cell.StringCellValue;

                        }
                        dt.Rows.Add(dr);
                    }

                }
                DateTables.DataSource = dt;
                for (int i = 0; i < DateTables.Columns.Count; i++)
                {
                    DateTables.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                }
                TabControl.SelectedTab = TabControl.TabPages[1];
            }
        }

        /// <summary>
        /// 生成参数类型的SQL
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParTypeSQL_Click(object sender, EventArgs e)
        {
            ConfigFile con = ConfigFile.LoadOrCreateFile("config");
            ConfigFile config = ConfigFile.LoadOrCreateFile(con["Home"] + "config");
            int n = DateTables.RowCount;
            string sqlAAA = null;
            string sql = null;
            if (con["Home"].ToString() == "EMO" || con["Home"].ToString() == "MES")
            {
                sqlAAA = "INSERT [SYS_ParameterType] ([SystemID], [ParameterTypeID],[TypeName],[IsSystem], [Modifier], [Creator],[CreateTime],[ModifiedTime]) VALUES(N'{0}', N'{1}', N'{2}', 0, N'adminy', N'adminy','{3}','{3}');";
                sql = null;
                for (int x = 0; x < n; x++)
                {
                    sql += string.Format(sqlAAA, 
                        config["SystemID"].ToString(), 
                        DateTables.Rows[x].Cells[0].Value.ToString().Replace("100AA", config["SystemID"].ToString()), 
                        DateTables.Rows[x].Cells[1].Value.ToString(), DateTime.Now.ToString());
                    sql += "\r\n";
                }
            }
            else
            {
                sqlAAA = "INSERT [ParameterType] ([SystemID], [ParameterTypeID],[TypeName],[IsSystem], [Modifier], [Creator],[CreateTime],[ModifiedTime]) VALUES(N'{0}', N'{1}', N'{2}', 0, N'adminy', N'adminy','{3}','{3}');";
                sql = null;
                for (int x = 0; x < n; x++)
                {
                    sql += string.Format(sqlAAA, 
                        config["SystemID"].ToString(),
                        DateTables.Rows[x].Cells[0].Value.ToString().Replace("100AA", config["SystemID"].ToString()),
                        DateTables.Rows[x].Cells[1].Value.ToString(), DateTime.Now.ToString());
                    sql += "\r\n";
                }
            }
            ParameterText.Text = sql;
            runSQL.Enabled = true;
        }

        private void CustomAdvanced_Click(object sender, EventArgs e)
        {
            string conf = ConfigFile.LoadOrCreateFile(ConfigFile.LoadOrCreateFile("config")["Home"] + "config")["connectionString"];
            if (string.IsNullOrWhiteSpace(conf))
            {
                MessageBox.Show("兄弟你还未配置咧,请到配置界面配置数据库链接地址和系统编号", "温馨小提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                CustomAdvancedWin cutsomAdv = new CustomAdvancedWin();
                cutsomAdv.Show();
            }
        }
    }
}
