﻿using System;
using System.Data;
using System.Data.SqlClient;
using ToolLibrary;

namespace YSWTool.Service
{
    /// <summary>  
    /// 针对SQL Server数据库操作的通用类  
    /// 作者：Bobby  
    /// 日期：2014-06-30  
    /// Version:1.0  
    /// 
    /// 针对现有的开发模式，将相关方法转为静态方法
    /// 修改：SAM
    /// 日期：2016年9月23日
    /// </summary>  
    public class SQLHelper
    {
        private static string connectionString = ConfigFile.LoadOrCreateFile(ConfigFile.LoadOrCreateFile("config")["Home"] + "config")["connectionString"];

        /// <summary>  
        /// 执行一个查询,并返回查询结果  
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <returns>返回查询结果集</returns>  
        public static DataTable ExecuteDataTable(string sql, CommandType commandType)
        {
            return ExecuteDataTable(sql, commandType, null);
        }

        /// <summary>  
        /// 执行一个查询,并返回查询结果  
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>  
        /// <returns></returns>  
        public static DataTable ExecuteDataTable(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            //string log = sql;
            DataTable data = new DataTable();//实例化DataTable，用于装载查询结果集  
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType  
                    //如果同时传入了参数，则添加这些参数  
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                            //log = log.Replace(parameter.ParameterName, "'"+parameter.Value.ToString()+ "'");
                        }
                    }

                    //通过包含查询SQL的SqlCommand实例来实例化SqlDataAdapter  
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    //DataLogerService.SAMwriteLog(log);              
                    adapter.Fill(data);//填充DataTable  
                }
            }
            return data;
        }

        /// <summary>  
        ///   执行一个查询,并返回查询结果(SqlDataReader)
        /// </summary>  
        /// <param name="sql">要执行的查询SQL文本命令</param>  
        /// <returns></returns>  
        public static SqlDataReader ExecuteReader(string sql)
        {
            return ExecuteReader(sql, CommandType.Text, null);
        }

        /// <summary>  
        ///   执行一个查询,并返回查询结果(SqlDataReader)
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <returns></returns>  
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType)
        {
            return ExecuteReader(sql, commandType, null);
        }

        /// <summary>  
        ///   执行一个查询,并返回查询结果(SqlDataReader)
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>  
        /// <returns></returns>  
        public static SqlDataReader ExecuteReader(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sql, connection);
            //如果同时传入了参数，则添加这些参数  
            if (parameters != null)
            {
                foreach (SqlParameter parameter in parameters)
                {
                    command.Parameters.Add(parameter);
                }
            }
            connection.Open();
            //CommandBehavior.CloseConnection参数指示关闭Reader对象时关闭与其关联的Connection对象  
            return command.ExecuteReader(CommandBehavior.CloseConnection);
        }

        /// <summary>  
        ///   执行一个查询,并返回查询结果(Object)
        /// </summary>  
        /// <param name="sql">要执行的查询SQL文本命令</param>  
        /// <returns></returns>  
        public static Object ExecuteScalar(string sql)
        {
            return ExecuteScalar(sql, CommandType.Text, null);
        }

        /// <summary>  
        ///    执行一个查询,并返回查询结果(Object)
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <returns></returns>  
        public static Object ExecuteScalar(string sql, CommandType commandType)
        {
            return ExecuteScalar(sql, commandType, null);
        }

        /// <summary>  
        ///    执行一个查询,并返回查询结果(Object)
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>  
        /// <returns></returns>  
        public static Object ExecuteScalar(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            object result = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType  
                    //如果同时传入了参数，则添加这些参数  
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接  
                    result = command.ExecuteScalar();
                }
            }
            return result;//返回查询结果的第一行第一列，忽略其它行和列  
        }

        /// <summary>  
        /// 对数据库执行增删改操作  
        /// </summary>  
        /// <param name="sql">要执行的查询SQL文本命令</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string sql)
        {
            return ExecuteNonQuery(sql, CommandType.Text, null);
        }

        /// <summary>  
        /// 对数据库执行增删改操作  
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string sql, CommandType commandType)
        {
            return ExecuteNonQuery(sql, commandType, null);
        }

        /// <summary>  
        /// 对数据库执行增删改操作  
        /// </summary>  
        /// <param name="sql">要执行的SQL语句</param>  
        /// <param name="commandType">要执行的查询语句的类型，如存储过程或者SQL文本命令</param>  
        /// <param name="parameters">Transact-SQL 语句或存储过程的参数数组</param>  
        /// <returns></returns>  
        public static int ExecuteNonQuery(string sql, CommandType commandType, SqlParameter[] parameters)
        {
            int count = 0;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    command.CommandType = commandType;//设置command的CommandType为指定的CommandType  
                    //如果同时传入了参数，则添加这些参数  
                    if (parameters != null)
                    {
                        foreach (SqlParameter parameter in parameters)
                        {
                            command.Parameters.Add(parameter);
                        }
                    }
                    connection.Open();//打开数据库连接  
                    count = command.ExecuteNonQuery();
                }
            }
            return count;//返回执行增删改操作之后，数据库中受影响的行数  
        }

        /// <summary>  
        /// 返回当前连接的数据库中所有由用户创建的数据库  
        /// </summary>  
        /// <returns></returns>  
        public DataTable GetTables()
        {
            DataTable data = null;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();//打开数据库连接  
                data = connection.GetSchema("Tables");
            }
            return data;
        }
        /// <summary>
        /// 获取流水编号（此方法调用前提是SerialNumber表中已有所有表的初始化数据）
        /// SAM 2016年11月3日18:43:52
        /// </summary>
        /// <param name="tname">表名</param>
        /// <param name="amount">获取流水数量</param>
        /// <returns></returns>
        public static string[] getSNID(string tname, int amount)
        {
            string[] result = null;
            DataRow dr = null;
            int count = 0;                                 //用于更新成功后的返回计数

            SqlConnection conn = dbConnection();
            try
            {
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                SqlTransaction transaction = conn.BeginTransaction();
                cmd.Transaction = transaction;
                cmd.CommandText = String.Format(@"select * from [SYS_SerialNumber] WITH(UPDLock) where [SystemID]='{0}' and [TableName]=N'{1}'", 10039, tname);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dr = ds.Tables[0].Rows[0];
                String number = (String)dr["Number"];
                int id = (int)dr["ID"];
                count = Convert.ToInt32(number, 16);      //赋原值，更新成功后在原值上加计数

                number = String.Format("{0:X}", count + amount).PadLeft(6, '0');

                cmd.CommandText = String.Format(@"UPDATE [dbo].[SYS_SerialNumber] SET [Number]=N'{0}',[Modifier]='{1}',[ModifiedTime]='{2}' WHERE [ID]={3}", number, "adminy", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), id);
                cmd.ExecuteNonQuery();
                transaction.Commit();
            }
            catch (Exception err)
            {

            }
            finally
            {
                conn.Close();
            }

            result = new string[amount];
            string serial = (string)dr["FirstSN"] + dr["TablepropertyID"].ToString().PadLeft(3, '0') + DateTime.Now.ToString((string)dr["DateID"]);
            for (int i = 0; i < amount; i++)
            {
                result[i] = serial + String.Format("{0:X}", count + i + 1).PadLeft(6, '0');
            }
            return result;
        }

        static SqlConnection dbConnection()
        {
            //if (HttpContext.Current != null && HttpContext.Current.Session != null && HttpContext.Current.Session[session_connect] != null)
            //{
            //    SqlConnection conn = (SqlConnection)HttpContext.Current.Session[session_connect];
            //    if (conn.State != ConnectionState.Open)
            //        conn.Open();
            //    return conn;
            //}
            //else
            //{
            SqlConnection conn = new SqlConnection(connectionString);
            if (conn.State != ConnectionState.Open)
                conn.Open();
            //if (HttpContext.Current != null && HttpContext.Current.Session != null)
            //    HttpContext.Current.Session[session_connect] = conn;

            return conn;
            // }
        }

    }
}
