namespace YSWTool.Model
{

using System;
    public class SYS_Menus 
    {
        public int ID { get; set; }
        public string SystemID { get; set; }
        public string MenuID { get; set; }
        public string ParentMenuID { get; set; }
        public string Name { get; set; }
        public string NickName { get; set; }
        public string URL { get; set; }
        public string IconClass { get; set; }
        public string IconURL { get; set; }
        public bool IsVisible { get; set; }
        public bool IsEnable { get; set; }
        public bool IsParameter { get; set; }
        public int Sequence { get; set; }
        public string Comments { get; set; }
        public string Modifier { get; set; }
        public DateTime ModifiedTime { get; set; }
        public string Creator { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
