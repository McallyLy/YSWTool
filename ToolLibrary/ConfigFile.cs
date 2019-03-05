using System;
using System.IO;
using System.Xml;

namespace ToolLibrary
{
    /// <summary>
    /// 本地配置类
    /// SAM 2017年4月1日10:29:43
    /// 读取，设置本地配置
    /// </summary>
    public class ConfigFile
    {
        //-------------------------
        //来源：http://www.cnblogs.com/durow/p/4840672.html
        //保留重点的拿和创建。类型装换等函数移除
        //-------------------------
        protected readonly string configBasePath = "Root/Config";

        /// <summary>
        /// 当前配置文件的完整路径
        /// </summary>
        public string FileName { get; private set; }

        /// <summary>
        /// 获取或设置配置
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>键名对应的值</returns>
        public string this[string key]
        {
            get
            {
                return GetConfigValue(key);
            }
            set
            {
                AddOrSetConfigValue(key, value);
            }
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        protected ConfigFile()
        {
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <param name="filename">配置文件名</param>
        /// <returns>ConfigFile对象</returns>
        public static ConfigFile LoadFile(string filename)
        {
            if (!File.Exists(filename)) return null;
            return new ConfigFile { FileName = filename };
        }

        /// <summary>
        /// 读取或创建配置文件
        /// </summary>
        /// <param name="filename">配置文件名</param>
        /// <returns>ConfigFile对象</returns>
        public static ConfigFile LoadOrCreateFile(string filename)
        {
            if (!File.Exists(filename))
            {
                var config = new ConfigFile { FileName = filename };
                config.CreateFile();
                return config;
            }
            return LoadFile(filename);
        }

        /// <summary>
        /// 创建配置文件，可在子类中重写此方法
        /// </summary>
        protected virtual void CreateFile()
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            doc.AppendChild(dec);
            XmlElement root = doc.CreateElement("Root");
            doc.AppendChild(root);
            root.AppendChild(doc.CreateElement("Config"));
            doc.Save(FileName);
        }

        /// <summary>
        /// 根据Key从配置文件中获取值
        /// </summary>
        /// <param name="key">键名</param>
        /// <returns>获取的值，找不到返回""</returns>
        public string GetConfigValue(string key)
        {
            return GetKeyValue($"{configBasePath}/{key}");
        }

        /// <summary>
        /// 修改Key对应的值，如果Key不存在则添加后存入值
        /// </summary>
        /// <param name="key">Key</param>
        /// <param name="value">要存入的值</param>
        public void AddOrSetConfigValue(string key, string value)
        {
            AddOrSetKeyValue(configBasePath, key, value);
        }

        /// <summary>
        /// 保存key/value键值对
        /// </summary>
        /// <param name="basePath">要保存的根节点路径</param>
        /// <param name="key">要保存的键名</param>
        /// <param name="value">要保存的值</param>
        public void AddOrSetKeyValue(string basePath, string key, string value)
        {
            var doc = GetXmlDocument();
            var node = doc.SelectSingleNode($"{basePath}/{key}");
            if (node == null)
            {
                node = doc.CreateElement(key);
                doc.SelectSingleNode(basePath).AppendChild(node);
            }
            node.InnerText = value;
            doc.Save(FileName);
        }

        /// <summary>
        /// 根据xpath获取值
        /// </summary>
        /// <param name="xpath">要获取的路径</param>
        /// <returns>获取的值</returns>
        public string GetKeyValue(string xpath)
        {
            var doc = GetXmlDocument();
            var node = doc.SelectSingleNode(xpath);
            return node?.InnerText ?? "";
        }

        /// <summary>
        /// 删除Key以及对应的值
        /// </summary>
        /// <param name="key">Key</param>
        public void DeleteConfigKey(string key)
        {
            var doc = GetXmlDocument();
            var node = doc.SelectSingleNode($"{configBasePath}/{key}");
            if (node == null) return;
            doc.SelectSingleNode("Root/Config")?.RemoveChild(node);
            doc.Save(FileName);
        }

        /// <summary>
        /// 读取XML文档
        /// </summary>
        /// <returns></returns>
        private XmlDocument GetXmlDocument()
        {
            XmlDocument doc = new XmlDocument();
            doc.Load(FileName);
            return doc;
        }
    }
}
