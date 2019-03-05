
using System;
using System.Data;
using System.Data.SqlClient;
using ToolLibrary;
using YSWTool.Model;
using YSWTool.Service;

namespace YSWTool.Service
{
    public class SYS_UserMenuColumnService 
    {

        public static bool insert( SYS_UserMenuColumn Model)
        {
            ConfigFile config = ConfigFile.LoadOrCreateFile(ConfigFile.LoadOrCreateFile("config")["Home"] + "config");
            try
            {
                string sql = string.Format(@"insert[SYS_UserMenuColumn]([UserMenuColumnID],[UserID],
                [MenuID],[TableID],[Column],
                [ColumnName],[CustomizeName],[ColumnFrontName],[Sequence],[IsEnable],
                [IsRequired],[Isfixed],[ColumnNum],
                [Comments],[Modifier],[ModifiedTime],
                [Creator],[CreateTime],[SystemID]) values
                 (@UserMenuColumnID,@UserID,
                @MenuID,@TableID,@Column,
                @ColumnName,@CustomizeName,@ColumnFrontName,@Sequence,@IsEnable,
                @IsRequired,@Isfixed,@ColumnNum,@Comments,'{0}','{1}','{0}','{1}','{2}')", config["SystemID"] + "0041213000000", DateTime.Now, config["SystemID"]);

                SqlParameter[] parameters = new SqlParameter[]{
                    new SqlParameter("@UserMenuColumnID",SqlDbType.VarChar),
                    new SqlParameter("@UserID",SqlDbType.VarChar),
                    new SqlParameter("@MenuID",SqlDbType.VarChar),
                    new SqlParameter("@TableID",SqlDbType.VarChar),
                    new SqlParameter("@Column",SqlDbType.NVarChar),
                    new SqlParameter("@ColumnName",SqlDbType.NVarChar),
                    new SqlParameter("@CustomizeName",SqlDbType.NVarChar),
                    new SqlParameter("@IsEnable",SqlDbType.Bit),
                    new SqlParameter("@IsRequired",SqlDbType.Bit),
                    new SqlParameter("@Isfixed",SqlDbType.Bit),
                    new SqlParameter("@Sequence",SqlDbType.Int),
                    new SqlParameter("@ColumnNum",SqlDbType.Decimal),
                    new SqlParameter("@Comments",SqlDbType.NVarChar),
                    new SqlParameter("@ColumnFrontName",SqlDbType.NVarChar)
                    };

                parameters[0].Value = (Object)Model.UserMenuColumnID ?? DBNull.Value;
                parameters[1].Value = (Object)Model.UserID ?? DBNull.Value;
                parameters[2].Value = (Object)Model.MenuID ?? DBNull.Value;
                parameters[3].Value = (Object)Model.TableID ?? DBNull.Value;
                parameters[4].Value = (Object)Model.Column ?? DBNull.Value;
                parameters[5].Value = (Object)Model.ColumnName ?? DBNull.Value;
                parameters[6].Value = (Object)Model.CustomizeName ?? DBNull.Value;
                parameters[7].Value = (Object)Model.IsEnable ?? DBNull.Value;
                parameters[8].Value = (Object)Model.IsRequired ?? DBNull.Value;
                parameters[9].Value = (Object)Model.Isfixed ?? DBNull.Value;
                parameters[10].Value = (Object)Model.Sequence ?? DBNull.Value;
                parameters[11].Value = (Object)Model.ColumnNum ?? DBNull.Value;
                parameters[12].Value = (Object)Model.Comments ?? DBNull.Value;
                parameters[13].Value = (Object)Model.ColumnFrontName ?? DBNull.Value;

                return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
            }
            catch (Exception ex)
            {
               
                return false;
            }
        }

    }
}

