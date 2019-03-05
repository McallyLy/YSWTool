
using System;
using System.Data;
using System.Data.SqlClient;
using ToolLibrary;
using YSWTool.Model;
using YSWTool.Service;

namespace YSWTool.Service
{
    public class SYS_TableService 
    {

        public static bool insert(SYS_Table Model)
        {
            ConfigFile config = ConfigFile.LoadOrCreateFile(ConfigFile.LoadOrCreateFile("config")["Home"] + "config");
            try
            {
                string sql = string.Format(@"insert[SYS_Table]([TableID],[MenuID],
                                            [Code],[Name],[Comments],
                                            [Modifier],[ModifiedTime],[Creator],
                                            [CreateTime],[SystemID]) values
                                             (@TableID,@MenuID,
                                            @Code,@Name,@Comments,'{0}','{1}','{0}','{1}','{2}')", config["SystemID"]+"0041213000000", DateTime.Now, config["SystemID"]);

                                                            SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@TableID",SqlDbType.VarChar),
                    new SqlParameter("@MenuID",SqlDbType.VarChar),
                    new SqlParameter("@Code",SqlDbType.NVarChar),
                    new SqlParameter("@Name",SqlDbType.NVarChar),
                     new SqlParameter("@Comments",SqlDbType.NVarChar),
                    };

                parameters[0].Value = (Object)Model.TableID ?? DBNull.Value;
                parameters[1].Value = (Object)Model.MenuID ?? DBNull.Value;
                parameters[2].Value = (Object)Model.Code ?? DBNull.Value;
                parameters[3].Value = (Object)Model.Name ?? DBNull.Value;
                parameters[4].Value = (Object)Model.Comments ?? DBNull.Value;

                return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
            }
            catch (Exception ex)
            {
                
                return false;
            }
        }

        //    public static SYS_Table get(string TableID)
        //    {
        //        string sql = string.Format(@"select Top 1 * from [SYS_Table] where [TableID] = '{0}'  and [SystemID] = '{1}' ", TableID, Framework.SystemID);

        //        DataTable dt = SQLHelper.ExecuteDataTable(sql, CommandType.Text);

        //        if (dt.Rows.Count == 0)
        //            return null;
        //        else
        //            return ToEntity(dt.Rows[0]);
        //    }

        public static bool CheckEntity(string Code)
        {
            string sql = string.Format(@"select * from SYS_Table where Code='{0}' and SystemID='{1}' ", Code.Trim(), 10039);

            DataTable dt = SQLHelper.ExecuteDataTable(sql, CommandType.Text);

            if (dt.Rows.Count == 0)
                return false;
            else
                return true;
        }
    }
}

