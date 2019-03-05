namespace YSWTool.Model
{
    using System;
    public class SYS_UserMenuColumn
    {
        public int ID { get; set; }
        public string SystemID { get; set; }
        public string UserMenuColumnID { get; set; }
        public string UserID { get; set; }
        public string MenuID { get; set; }
        public string TableID { get; set; }
        public string Column { get; set; }
        public string ColumnName { get; set; }
        public string CustomizeName { get; set; }
        public string ColumnFrontName { get; set; }
        public int Sequence { get; set; }
        public bool IsEnable { get; set; }
        public bool IsRequired { get; set; }
        public bool Isfixed { get; set; }
        public decimal ColumnNum { get; set; }
        public string Comments { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
