
namespace YSWTool.Model
{
    using System;
    public class SYS_Table
    {
        public int ID { get; set; }
        public string SystemID { get; set; }
        public string TableID { get; set; }
        public string MenuID { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string Comments { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
