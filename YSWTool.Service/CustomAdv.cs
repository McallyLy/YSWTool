using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using ToolLibrary;
using YSWTool.Model;
using YSWTool.Service;

namespace YSWTool.Service
{
    /// <summary>
    /// Mcally 2019年1月18日15:41:58
    /// 根据excel 文档 导出sql到桌面并插入数据库
    /// </summary>
   public  class CustomAdv
    {
       private static  ConfigFile config = null;
        public CustomAdv() {
            
        }
        public static object CustomAdvImport(string filename)
        {
            config = ConfigFile.LoadOrCreateFile(ConfigFile.LoadOrCreateFile("config")["Home"] + "config");
            string reason = null;
            int total = 0;
            int nosuccess = 0;
            int idx = 0;
            string[] title = null;
            SYS_Menus Menus = null;
            SYS_Table table = null;
            SYS_UserMenuColumn userMenuColumn = null;
            StringBuilder sb = new StringBuilder();

            if (filename.EndsWith(".xls") || filename.EndsWith(".xlsx"))
            {
                IWorkbook wk = null;
                using (FileStream fs = File.OpenRead(@filename))   //打开.xls文件
                {
                    if (filename.EndsWith(".xls"))
                        wk = new HSSFWorkbook(fs); //把xls文件中的数据写入wk中
                    else if (filename.EndsWith(".xlsx"))
                        wk = new XSSFWorkbook(fs);//把xlsx文件中的数据写入wk中

                    ISheet sheet = wk.GetSheetAt(0);   //读取第一表数据
                    IRow row = sheet.GetRow(0);//读取第1行数据
                    string one = row.GetCell(0).ToString().Trim();
                    if (one.IndexOf('-') == -1)
                    {
                        return "第一行的格式输入错误:" + one;
                    }
                    else
                    {
                        title = one.Split('-');
                        Menus = SYS_MenusService.getEntity(title[0]);
                    }

                    if (Menus == null)
                    {
                        return   "无对应的菜单程式:" + one;
                    }
                    table = GetSYS_Table(Menus, title);

                    SYS_TableService.insert(table);
                    userMenuColumn = GetSYS_UserMenuColumn(table);
                    sb = CreteFiles(table, null, sb, title.Count() <= 2, true);//保存Table表
                    SaveTxtFile(Menus.MenuID, table.TableID, title[1], title[0]);
                    for (int j = 2; j <= sheet.LastRowNum; j++)  //LastRowNum 是当前表的总行数
                    {
                        ++idx;
                        row = sheet.GetRow(j);  //读取当前行数据
                        if (row.GetCell(0) == null) //如果当前行的第一列没有数据，停止读取
                            break;
                        //如果当前行的第一列没有数据，停止读取，这是判断当row.GetCell不能null然后实际是空字符
                        if (string.IsNullOrWhiteSpace(row.GetCell(0).ToString()))
                            break;
                        total++;

                        if (row != null)
                        {

                            if (CheckNULL(row, 0))// [Column]列字段
                            {
                                if (row.GetCell(0).ToString().IndexOf('-') != -1)
                                {
                                    string[] s = row.GetCell(0).ToString().Trim().Split('-');
                                    SYS_Menus mes = SYS_MenusService.getEntity(s[0]);
                                    if (mes != null)
                                    {
                                        if (title[0] == s[0] && mes.MenuID == Menus.MenuID)
                                        {
                                            table = GetSYS_Table(mes, s);
                                           SYS_TableService.insert(table);
                                            userMenuColumn = GetSYS_UserMenuColumn(table);
                                            sb.Append("END;\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                                            sb = CreteFiles(table, null, sb, false, false);//保存Table表
                                            SaveTxtFile(mes.MenuID, table.TableID, s[1], s[0]);
                                            continue;
                                        }
                                    }

                                }
                                else
                                {
                                    userMenuColumn = GetSYS_UserMenuColumn(table);
                                    userMenuColumn.Column = row.GetCell(0).ToString().Trim();
                                }

                            }
                            else
                            {
                                reason += string.Format("序号[{0}]Column为空;", idx);
                                nosuccess++;
                                continue;
                            }
                            if (CheckNULL(row, 1))// [ColumnName ]列字段
                            {
                                userMenuColumn.ColumnName = row.GetCell(1).ToString().Trim();
                            }
                            else
                            {
                                reason += string.Format("序号[{0}]ColumnName为空;", idx);
                                nosuccess++;
                                continue;
                            }
                            if (CheckNULL(row, 2))// [ColumnFrontName ]列字段
                            {
                                userMenuColumn.ColumnFrontName = row.GetCell(2).ToString().Trim();
                            }
                            else
                            {
                                reason += string.Format("序号[{0}]ColumnFrontName;为空", idx);
                                nosuccess++;
                                continue;
                            }
                            if (CheckNULL(row, 3)) // [Sequence ]列字段
                            {
                                int sq = 0;
                                if (int.TryParse(row.GetCell(3).ToString().Trim(), out sq))
                                {
                                    userMenuColumn.Sequence = sq;
                                }
                                else
                                {
                                    reason += string.Format("序号[{0}] Sequence 请输入数值;", idx);
                                    nosuccess++;
                                    continue;
                                }
                            }
                            else
                            {
                                reason += string.Format("序号[{0}] Sequence 为空;", idx);
                                nosuccess++;
                                continue;
                            }
                            if (CheckNULL(row, 4)) // [ColumnNum ]列字段
                            {
                                userMenuColumn.ColumnNum = Convert.ToDecimal(row.GetCell(4).ToString().Trim());
                            }
                            else
                            {
                                reason += string.Format("序号[{0}] [ColumnNum ]列字段为空;", idx);
                                nosuccess++;
                                continue;
                            }
                            if (CheckNULL(row, 5)) // [IsRequired ]列字段
                            {
                                if (row.GetCell(5).ToString().Trim() == "是")
                                {
                                    userMenuColumn.IsRequired = true;
                                }
                                else
                                {
                                    userMenuColumn.IsRequired = false;
                                }
                            }
                            else
                            {
                                reason += string.Format("序号[{0}] [IsRequired ]列字段为空;", idx);
                                nosuccess++;
                                continue;
                            }
                            SYS_UserMenuColumnService.insert(userMenuColumn);
                            sb = CreteFiles(null, userMenuColumn, sb, false, false);

                        }
                    }
                    sb.Append("\r\n");
                    sb.Append("END;\r\n");
                    SaveFile(sb.ToString(), table.Code);

                }
            }
            return     "错误讯息:"+ reason==null?"无,":reason +  " 失败:"+nosuccess+"条,成功:"+total +"条";
        }


        public static StringBuilder CreteFiles(SYS_Table table, SYS_UserMenuColumn sYS_UserMenuColumn, StringBuilder sb, bool flag, bool fg)
        {
            StringBuilder sbstr = sb;
            string strCrLf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); //表示换行
            if (table != null)
            {
                sbstr.Append("---------------------------------------------------------------------------------------------------------------------\r\n");
                sbstr.Append("-----------------------------------------------------------------------------------------------------------------------\r\n");
                sbstr.Append("-------------------------------" + table.Code + "-" + table.Name + "----------------------------------------------------\r\n");
                sbstr.Append("-------------------------------------------------------------------------------------------------------------------------\r\n");
                sbstr.Append("---------------------------------------------------------------------------------------------------------------\r\n\r\n\r\n");
                sbstr.Append(strCrLf);
                sbstr.Append(strCrLf);
                if (fg)
                {
                    sbstr.Append("declare @systemID varchar(30)\r\n");
                    sbstr.Append("select top 1 @systemID = SystemID from [SYS_Systems] \r\n");

                }

                string str = string.Format(@"If NOT EXISTS(SELECT  * FROM  SYS_Table WHERE  MenuID=@systemID+'{0}' and TableID=@systemID+'{1}' )", SplitStr(table.MenuID), SplitStr(table.TableID));
                sbstr.Append("\r\n");
                sbstr.Append(str);
                sbstr.Append("\r\nBEGIN\r\n");
                string insert = string.Format(@"INSERT INTO [SYS_Table] ([SystemID], [TableID], [MenuID], [Code], [Name],[Comments], [Modifier], [ModifiedTime], [Creator], [CreateTime]) VALUES ( {0}, @systemID+'{1}', @systemID+'{2}','{3}','{4}','{5}',@systemID+'{6}',{7}, @systemID+'{8}', {9})",
                     "@systemID", SplitStr(table.TableID), SplitStr(table.MenuID), table.Code, table.Name, table.Comments, SplitStr(table.Modifier), "GETDATE()", SplitStr(table.Creator), "GETDATE()");
                sbstr.Append(insert);
                sbstr.Append("\r\n");
                sbstr.Append("END;\r\n");
                sbstr.Append(strCrLf);
                sbstr.Append(strCrLf);
                if (flag)
                {
                    sbstr = ButtomRoleStr(sbstr, table.MenuID);
                }
                string str1 = string.Format(@"If NOT EXISTS(SELECT  * FROM  SYS_UserMenuColumn  WHERE  MenuID=@systemID+'{0}' and TableID=@systemID+'{1}' )", SplitStr(table.MenuID), SplitStr(table.TableID));
                sbstr.Append(str1);
                sbstr.Append("\r\nBEGIN\r\n");
            }
            if (sYS_UserMenuColumn != null)
            {
                string insert = string.Format(@"INSERT INTO [SYS_UserMenuColumn] ([SystemID], [UserMenuColumnID],[UserID], [MenuID], [TableID], [Column], [ColumnName], [CustomizeName], [ColumnFrontName],[Sequence], [IsEnable], [IsRequired], [Isfixed], [ColumnNum], [Comments], [Modifier],[ModifiedTime], [Creator], [CreateTime]) VALUES ({0}, @systemID+'{1}',@systemID+'{2}', @systemID+'{3}', @systemID+'{4}','{5}','{6}', '{7}','{8}', {9}, {10}, {11}, {12}, {13}, '{14}', @systemID+'{15}',{16}, @systemID+'{17}', {18})", "@systemID",
                                   SplitStr(sYS_UserMenuColumn.UserMenuColumnID), SplitStr(sYS_UserMenuColumn.UserID),
                                   SplitStr(sYS_UserMenuColumn.MenuID), SplitStr(sYS_UserMenuColumn.TableID), sYS_UserMenuColumn.Column, sYS_UserMenuColumn.ColumnName, sYS_UserMenuColumn.CustomizeName,
                                   sYS_UserMenuColumn.ColumnFrontName, sYS_UserMenuColumn.Sequence, sYS_UserMenuColumn.IsEnable ? 1 : 0, sYS_UserMenuColumn.IsRequired ? 1 : 0,
                                   sYS_UserMenuColumn.Isfixed ? 1 : 0, sYS_UserMenuColumn.ColumnNum, sYS_UserMenuColumn.Comments, SplitStr(sYS_UserMenuColumn.Modifier), "GETDATE()", SplitStr(sYS_UserMenuColumn.Creator), "GETDATE()");
                sbstr.Append(insert);
                sbstr.Append("\r\n");
            }

            return sbstr;

        }
        public static void SaveFile(string str, string FileName)
        {
            Mutex write = new Mutex();
            write.WaitOne();
            if (!string.IsNullOrWhiteSpace(str))
            {
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//当前桌面
                string strCrLf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); //表示换行

                string strBody = strCrLf + str + strCrLf;
                string pathcom = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + "CustomAdvanced");
                DirectoryInfo df = new DirectoryInfo(pathcom);
                if (!df.Exists)
                {
                    df.Create();
                }
                string FilePath = Path.Combine(pathcom, "(All)" + FileName + "CustomAdvanced.sql");
                if (!File.Exists(FilePath))
                {
                    var o = File.Create(FilePath);
                    o.Close();
                }
                try
                {
                    FileInfo fi = new FileInfo(FilePath);

                    using (StreamWriter sw = fi.AppendText())
                    {
                        sw.WriteLine(strBody);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception em)
                {
                    Console.WriteLine(em.Message.ToString());
                }

                write.ReleaseMutex();
            }

        }
        public static SYS_UserMenuColumn GetSYS_UserMenuColumn(SYS_Table tab)
        {
            return new SYS_UserMenuColumn()
            {
                UserMenuColumnID = SQLHelper.getSNID("SYS_UserMenuColumn", 1)[0],
                SystemID = config["SystemID"],
                MenuID = tab.MenuID,
                TableID = tab.TableID,
                Creator = config["SystemID"] + "0041213000000",
                Modifier = config["SystemID"] + "0041213000000",
                UserID = config["SystemID"] + "0041213000000",
                IsEnable = false,
                Isfixed = false,
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now
            };


        }
        public static SYS_Table GetSYS_Table(SYS_Menus menus, string[] title)
        {
            //
            return new SYS_Table()
            {

                TableID = SQLHelper.getSNID("SYS_Table", 1)[0],
                SystemID = config["SystemID"],
                MenuID = menus.MenuID,
                Code = title[0],
                Name = title[1],
                Creator = config["SystemID"] + "0041213000000",
                Modifier = config["SystemID"] + "0041213000000",
                CreateTime = DateTime.Now,
                ModifiedTime = DateTime.Now

            };
        }
        public static bool CheckNULL(IRow row, int num)
        {
            ICell cell = row.GetCell(num);
            if (cell != null && !string.IsNullOrWhiteSpace(cell.ToString()))
            {
                return true;
            }

            return false;
        }
        public static string SplitStr(string str)
        {
            if (!string.IsNullOrWhiteSpace(str))
            {
                return str.Substring(5);
            }
            return null;
        }

        public static StringBuilder ButtomRoleStr(StringBuilder str, string MenuID)
        {
            string strCrLf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); //表示换行
            str.Append(strCrLf);
            str.Append(strCrLf);
            str.Append("\r\n-------------------------------------------------------------------------- 增加按钮-------------------------------------------------------------------------- -");
            str.Append("-------自定义按钮权限\r\n");
            string m = string.Format(@"If NOT EXISTS(select * from SYS_RoleMenuButtonMapping  where MenuID = @systemID + '{0}'  and  RoleID = @systemID + '0601213000003' and ButtonID = @systemID + '008121300001F')", SplitStr(MenuID));
            str.Append(m);
            str.Append("\r\n");
            str.Append("BEGIN\r\n");
            string m1 = string.Format(@"INSERT INTO[SYS_RoleMenuButtonMapping]([SystemID], [MenuID], [RoleID], [ButtonID], [Comments], [Modifier], [ModifiedTime], [Creator], [CreateTime]) VALUES(@systemID, @systemID+'{0}', @systemID+'0601213000003', @systemID+'008121300001F', NULL, @systemID+'0041213000001', GETDATE(), @systemID+'0041213000001', GETDATE())", SplitStr(MenuID));
            str.Append(m1);
            str.Append("\r\n");
            str.Append("END;\r\n");
            str.Append("-------进阶查询按钮权限\r\n");
            string m2 = string.Format(@"If NOT EXISTS(select* from   SYS_RoleMenuButtonMapping where MenuID= @systemID + '{0}'  and RoleID = @systemID + '0601213000003' and ButtonID = @systemID + '0081213000021')", SplitStr(MenuID));
            str.Append(m2);
            str.Append("\r\n");
            str.Append("BEGIN\r\n");
            string m3 = string.Format(@"INSERT INTO[SYS_RoleMenuButtonMapping] ([SystemID], [MenuID], [RoleID], [ButtonID], [Comments], [Modifier], [ModifiedTime], [Creator], [CreateTime]) VALUES(@systemID, @systemID+'{0}', @systemID+'0601213000003', @systemID+'0081213000021', NULL, @systemID+'0041213000001', GETDATE(), @systemID+'0041213000001', GETDATE());", SplitStr(MenuID));
            str.Append(m3);
            str.Append("\r\n");
            str.Append("END;\r\n");
            str.Append("--------增加自定义按钮\r\n");
            string m4 = string.Format(@"If NOT EXISTS(SELECT* FROM  SYS_MenuButtonMapping WHERE  MenuID= @systemID + N'{0}' and ButtonID = @systemID + '008121300001F')", SplitStr(MenuID));
            str.Append(m4);
            str.Append("\r\n");
            str.Append("BEGIN\r\n");
            string m5 = string.Format(@"INSERT INTO[SYS_MenuButtonMapping] ([SystemID], [MenuID], [ButtonID], [Comments], [Modifier], [ModifiedTime], [Creator], [CreateTime]) VALUES(@systemID, @systemID+'{0}', @systemID+'008121300001F', NULL, @systemID+'0041213000001', GETDATE(), @systemID+'0041213000001', GETDATE());", SplitStr(MenuID));
            str.Append(m5);
            str.Append("\r\n");
            str.Append("END;\r\n");
            str.Append("--------增加进阶查询按钮\r\n");
            string m6 = string.Format(@"If NOT EXISTS(SELECT* FROM  SYS_MenuButtonMapping WHERE  MenuID= @systemID + N'{0}' and ButtonID = @systemID + '0081213000021')", SplitStr(MenuID));
            str.Append(m6);
            str.Append("\r\n");
            str.Append("BEGIN\r\n");
            string m7 = string.Format(@"INSERT INTO[SYS_MenuButtonMapping] ([SystemID], [MenuID], [ButtonID], [Comments], [Modifier], [ModifiedTime], [Creator], [CreateTime]) VALUES(@systemID, @systemID+'{0}', @systemID+'0081213000021', NULL, @systemID+'0041213000001', GETDATE(), @systemID+'0041213000001', GETDATE());", SplitStr(MenuID));
            str.Append(m7);
            str.Append("\r\n");
            str.Append("END;\r\n");
            str.Append("---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------");
            str.Append(strCrLf);
            str.Append(strCrLf);

            return str;
        }

        public static void SaveTxtFile(string MenuID, string TableID, string Name, string Code)
        {
            Mutex write = new Mutex();
            StringBuilder txt = new StringBuilder();
            write.WaitOne();
            if (!string.IsNullOrWhiteSpace(TableID))
            {
                txt.Append("-----------------------------------------------------------------------------------------\r\n");
                txt.Append("---------------------------------------" + Code + "-" + Name + "--------------------------------------------\r\n");
                txt.Append("-----------------------------------------------------------------------------------------\r\n");
                txt.Append("MenuID:" + MenuID);
                txt.Append("\r\n");
                txt.Append("TableID:" + TableID);
                txt.Append("\r\n");
                txt.Append("-----------------------------------------------------------------------------------------\r\n");
                txt.Append("-----------------------------------------------------------------------------------------\r\n");
                txt.Append("-----------------------------------------------------------------------------------------\r\n");
                string path = System.Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);//当前桌面
                string strCrLf = Convert.ToChar(13).ToString() + Convert.ToChar(10).ToString(); //表示换行

                string strBody = strCrLf + txt.ToString() + strCrLf;
                string pathcom = Path.Combine(path, DateTime.Now.ToString("yyyyMMdd") + "CustomAdvanced");
                DirectoryInfo df = new DirectoryInfo(pathcom);
                if (!df.Exists)
                {
                    df.Create();
                }
                string FilePath = Path.Combine(pathcom, "(All)CustomAdvancedMenuIDTableID.txt");
                if (!File.Exists(FilePath))
                {
                    var o = File.Create(FilePath);
                    o.Close();
                }
                try
                {
                    FileInfo fi = new FileInfo(FilePath);
                    using (StreamWriter sw = fi.AppendText())
                    {
                        sw.WriteLine(strBody);
                        sw.Flush();
                        sw.Close();
                    }
                }
                catch (Exception em)
                {
                    Console.WriteLine(em.Message.ToString());
                }

                write.ReleaseMutex();
            }

        }

       
           
        
    }
}
