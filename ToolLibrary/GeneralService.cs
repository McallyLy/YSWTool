using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSWTool.Model;

namespace ToolLibrary
{
    /// <summary>
    /// 通用函数类
    /// </summary>
    public class GeneralService
    {
        /// <summary>
        /// 创建一个空的DataTable，用以生成表结构内容的表格
        /// SAM 2017年3月2日23:22:55
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateTableDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("序号", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("字段", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("说明", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("数据类型", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("是否空", Type.GetType("System.String"));
            DataColumn dc6 = new DataColumn("默认值", Type.GetType("System.String"));
            DataColumn dc7 = new DataColumn("新增", typeof(bool));
            DataColumn dc8 = new DataColumn("编辑", typeof(bool));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            dt.Columns.Add(dc6);
            dt.Columns.Add(dc7);
            dt.Columns.Add(dc8);
            return dt;
        }

        /// <summary>
        /// 创建一个空的DataTable，用以生成参数内容的表格
        /// SAM 2017年3月2日23:22:55
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateParameterDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("参数流水", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("代号", Type.GetType("System.String"));
            DataColumn dc3 = new DataColumn("名称", Type.GetType("System.String"));
            DataColumn dc4 = new DataColumn("父参数名称", Type.GetType("System.String"));
            DataColumn dc5 = new DataColumn("父参数流水", Type.GetType("System.String"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            dt.Columns.Add(dc3);
            dt.Columns.Add(dc4);
            dt.Columns.Add(dc5);
            return dt;
        }

        /// <summary>
        /// 创建一个空的DataTable，用以生成参数类型内容的表格
        /// </summary>
        /// <returns></returns>
        public static DataTable CreateParTypeDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn dc1 = new DataColumn("流水号", Type.GetType("System.String"));
            DataColumn dc2 = new DataColumn("参数类型", Type.GetType("System.String"));
            dt.Columns.Add(dc1);
            dt.Columns.Add(dc2);
            return dt;
        }

        /// <summary>
        /// 将list转成DataTable
        /// SAM 2017年3月31日15:39:18
        /// 复制自网上
        /// </summary>
        /// <param name="tableList"></param>
        /// <returns></returns>
        public static DataTable HashTableToDataTable(List<Hashtable> tableList)
        {
            DataTable dt = new DataTable();
            if (tableList != null && tableList.Count > 0)
            {
                //把Key 添加到Table中 成为列名称
                foreach (string item in tableList[0].Keys)
                {
                    dt.Columns.Add(item, typeof(string));
                }
                for (int i = 0; i < tableList.Count; i++)
                {
                    Hashtable ht = tableList[i];
                    DataRow dr = dt.NewRow();

                    foreach (DictionaryEntry de in ht)
                    {
                        //把Value 添加到对应的列名下边
                        if (de.Value == null)
                            dr[de.Key.ToString()] = "";
                        else
                            dr[de.Key.ToString()] = de.Value.ToString();
                    }
                    dt.Rows.Add(dr);

                }
            }

            return dt;
        }
        /// <summary>
        /// 根据DataTable 返回实体类
        /// Mcally 2019年1月18日15:47:37
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static T  ToEntity<T>(DataTable dt) where T: SYS_Menus,new()
        {
            T tt = new T()
            {
                ID = Convert.ToInt32(dt.Rows[0]["ID"]),
                SystemID = Convert.ToString(dt.Rows[0]["SystemID"]),
                MenuID = Convert.ToString(dt.Rows[0]["MenuID"]),
                ParentMenuID = Convert.ToString(dt.Rows[0]["ParentMenuID"]),
                Name = Convert.ToString(dt.Rows[0]["Name"]),
                NickName = Convert.ToString(dt.Rows[0]["NickName"]),
                IconClass = Convert.ToString(dt.Rows[0]["IconClass"]),
                IconURL = Convert.ToString(dt.Rows[0]["IconURL"]),
                IsVisible = Convert.ToBoolean(dt.Rows[0]["IsVisible"]),
                IsEnable = Convert.ToBoolean(dt.Rows[0]["IsEnable"]),
                IsParameter = Convert.ToBoolean(dt.Rows[0]["IsParameter"]),
                Sequence = Convert.ToInt32(dt.Rows[0]["Sequence"]),
                Comments = Convert.ToString(dt.Rows[0]["Comments"]),
                Modifier = Convert.ToString(dt.Rows[0]["Modifier"]),
                ModifiedTime = Convert.ToDateTime(dt.Rows[0]["ModifiedTime"]),
                Creator = Convert.ToString(dt.Rows[0]["Creator"]),
                CreateTime = Convert.ToDateTime(dt.Rows[0]["CreateTime"])
            };


            return tt;
        }
    }
}
