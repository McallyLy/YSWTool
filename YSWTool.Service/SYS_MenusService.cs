
 using System.Data;
using ToolLibrary;
using YSWTool.Model;

namespace YSWTool.Service
{
    public class SYS_MenusService 
    {

        //public static bool insert(string userId, SYS_Menus Model)
        //{
        //    try
        //    {
        //        string sql = string.Format(@"insert[SYS_Menus]([MenuID],[ParentMenuID],
        //        [Name],[NickName],[URL],
        //        [IconClass],[IconURL],[IsVisible],
        //        [IsEnable],[Sequence],[Comments],[IsParameter],
        //        [Modifier],[ModifiedTime],[Creator],
        //        [CreateTime],[SystemID]) values
        //         (@MenuID,@ParentMenuID,
        //        @Name,@NickName,@URL,
        //        @IconClass,@IconURL,@IsVisible,
        //        @IsEnable,@Sequence,@Comments,@IsParameter,'{0}','{1}','{0}','{1}','{3}')", userId,DateTime.UtcNow,DateTime.Now,Framework.SystemID); 

        //         SqlParameter[] parameters = new SqlParameter[]{
					   //             new SqlParameter("@MenuID",SqlDbType.VarChar),
					   //             new SqlParameter("@ParentMenuID",SqlDbType.VarChar),
					   //             new SqlParameter("@Name",SqlDbType.VarChar),
					   //             new SqlParameter("@NickName",SqlDbType.NVarChar),
					   //             new SqlParameter("@URL",SqlDbType.VarChar),
					   //             new SqlParameter("@IconClass",SqlDbType.VarChar),
					   //             new SqlParameter("@IconURL",SqlDbType.VarChar),
					   //             new SqlParameter("@IsVisible",SqlDbType.Bit),
					   //             new SqlParameter("@IsEnable",SqlDbType.Bit),
        //                            new SqlParameter("@Sequence",SqlDbType.Int),
        //                            new SqlParameter("@Comments",SqlDbType.VarChar),
        //                            new SqlParameter("@IsParameter",SqlDbType.Bit),
        //                            };

        //        parameters[0].Value = (Object)Model.MenuID ?? DBNull.Value;
        //        parameters[1].Value = (Object)Model.ParentMenuID ?? DBNull.Value;
        //        parameters[2].Value = (Object)Model.Name ?? DBNull.Value;
        //        parameters[3].Value = (Object)Model.NickName ?? DBNull.Value;
        //        parameters[4].Value = (Object)Model.URL ?? DBNull.Value;
        //        parameters[5].Value = (Object)Model.IconClass ?? DBNull.Value;
        //        parameters[6].Value = (Object)Model.IconURL ?? DBNull.Value;
        //        parameters[7].Value = (Object)Model.IsVisible ?? DBNull.Value;
        //        parameters[8].Value = (Object)Model.IsEnable ?? DBNull.Value;
        //        parameters[9].Value = (Object)Model.Sequence ?? DBNull.Value;
        //        parameters[10].Value = (Object)Model.Comments ?? DBNull.Value;
        //        parameters[11].Value = (Object)Model.IsParameter ?? DBNull.Value;
        //        return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        DataLogerService.writeerrlog(ex);
        //        return false;
        //    }
        //}

        //public static bool update(string userId, SYS_Menus Model)
        //{
        //    try
        //    {
        //        string sql = String.Format(@"update[SYS_Menus] set {0},
        //        [ParentMenuID]=@ParentMenuID,[Name]=@Name,[NickName]=@NickName,
        //        [URL]=@URL,[IconClass]=@IconClass,[IconURL]=@IconURL,[IsVisible]=@IsVisible,
        //        [IsEnable]=@IsEnable,[Sequence]=@Sequence,[Comments]=@Comments,[IsParameter]=@IsParameter where [MenuID]=@MenuID", UniversalService.getUpdate(userId));
        //         SqlParameter[] parameters = new SqlParameter[]{
					   //             new SqlParameter("@MenuID",SqlDbType.VarChar),
					   //             new SqlParameter("@ParentMenuID",SqlDbType.VarChar),
					   //             new SqlParameter("@Name",SqlDbType.VarChar),
					   //             new SqlParameter("@NickName",SqlDbType.NVarChar),
					   //             new SqlParameter("@URL",SqlDbType.VarChar),
					   //             new SqlParameter("@IconClass",SqlDbType.VarChar),
					   //             new SqlParameter("@IconURL",SqlDbType.VarChar),
					   //             new SqlParameter("@IsVisible",SqlDbType.Bit),
					   //             new SqlParameter("@IsEnable",SqlDbType.Bit),
					   //             new SqlParameter("@Sequence",SqlDbType.Int),
					   //             new SqlParameter("@Comments",SqlDbType.NVarChar),
        //                            new SqlParameter("@IsParameter",SqlDbType.Bit),
        //                            };

        //        parameters[0].Value =Model.MenuID;
        //        parameters[1].Value = (Object)Model.ParentMenuID ?? DBNull.Value;
        //        parameters[2].Value = (Object)Model.Name ?? DBNull.Value;
        //        parameters[3].Value = (Object)Model.NickName ?? DBNull.Value;
        //        parameters[4].Value = (Object)Model.URL ?? DBNull.Value;
        //        parameters[5].Value = (Object)Model.IconClass ?? DBNull.Value;
        //        parameters[6].Value = (Object)Model.IconURL ?? DBNull.Value;
        //        parameters[7].Value = (Object)Model.IsVisible ?? DBNull.Value;
        //        parameters[8].Value = (Object)Model.IsEnable ?? DBNull.Value;
        //        parameters[9].Value = (Object)Model.Sequence ?? DBNull.Value;
        //        parameters[10].Value = (Object)Model.Comments ?? DBNull.Value;
        //        parameters[11].Value = (Object)Model.IsParameter ?? DBNull.Value;
        //        return SQLHelper.ExecuteNonQuery(sql, CommandType.Text, parameters) > 0;
        //    }
        //    catch (Exception ex)
        //    {
        //        DataLogerService.writeerrlog(ex);
        //        return false;
        //    }
        //}

        //public static SYS_Menus get(string MenuID)
        //{
        //    string sql = string.Format(@"select Top 1 * from [SYS_Menus] where [MenuID] = '{0}'  and [SystemID] = '{1}' ", MenuID, Framework.SystemID);

        //    DataTable dt = SQLHelper.ExecuteDataTable(sql, CommandType.Text);

        //    if (dt.Rows.Count == 0)
        //    return null;
        //    else
        //    return ToEntity(dt.Rows[0]);
        //}

        //public static bool delete(string MenuID)
        //{
        //    try
        //    {
        //        string sql = string.Format(@"delete from [SYS_Menus] where [MenuID] = '{0}'  and [SystemID] = '{1}' ", MenuID, Framework.SystemID);

        //        return SQLHelper.ExecuteNonQuery(sql, CommandType.Text) > 0;
        //    }

        //    catch (Exception ex)
        //    {

        //         DataLogerService.writeerrlog(ex);
        //         return false;
        //    }
        //}
        
        /// <summary>
        /// 主要用于进阶查询自定义的MenuID
        /// Mcally 2019年1月16日08:55:16
        /// </summary>
        /// <param name="URL"></param>
        /// <returns></returns>
        public static SYS_Menus getEntity(string URL)
        {
            string sql = string.Format(@"select Top 1 * from [SYS_Menus] 
      where [URL] like '{0}'  and [SystemID] = '{1}' ", "%" + URL.Trim() + "%", 10039);

            DataTable dt = SQLHelper.ExecuteDataTable(sql, CommandType.Text);

            if (dt.Rows.Count == 0)
                return null;
            else
                return GeneralService.ToEntity<SYS_Menus>(dt);
           
        }

    }

}

