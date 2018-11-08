using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Collections;

namespace Log_Analysis_Tool
{
    public class Setting
    {      
        public static string xmlpath = "config.xml";

        public XmlDocument doc;

        public CLogInfo log;

        public Setting()
        {
            doc = new XmlDocument();
            log = new CLogInfo();
        }

        public void XML_Read_All()
        {
            XML_Read_Key();
            XML_Read_Code();
        }

        public void XML_Read_Code()
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("Station");
            
            log.iArrCodeNum = new int[nodes.Count];
            log.sALCode = new ArrayList[nodes.Count];
            
            for (int node=0;node<nodes.Count;node++)
            {
                log.sALCode[node] = new ArrayList();
                foreach (XmlElement ele in nodes.Item(node))
                {
                    log.sALCode[node].Add(ele.InnerText);
                }
                log.iArrCodeNum[node] = nodes.Item(node).ChildNodes.Count;
            }
        }

        public void XML_Add_Code(int station_index,string add_node_text)
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodelist = doc.GetElementsByTagName("Station");
            XmlElement errcode = doc.CreateElement("ErrorCode");
            XmlText xmlText = doc.CreateTextNode(add_node_text);
            errcode.AppendChild(xmlText);
            nodelist.Item(station_index).AppendChild(errcode);
            doc.Save(xmlpath);
        }

        public void XML_Del_Code(int station_index,string del_node_text)
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodelist = doc.GetElementsByTagName("Station");
            foreach (XmlElement ele in nodelist.Item(station_index))
            {
                if (ele.InnerText == del_node_text)
                {
                    nodelist.Item(station_index).RemoveChild(ele); //执行完成这条指令，将会退出foreach,因为nodelist.item(station_index)集变了
                }
            }
            doc.Save(xmlpath);          

        }

        public void XML_Read_Key()
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodes = root.GetElementsByTagName("Station");
            log.sArrKey = new string[nodes.Count];
            int index = 0;
            foreach (XmlNode node in nodes)
            {
                string id = ((XmlElement)node).GetAttribute("id");
                log.sArrKey[index] = id;
                index++;
            }
        }

        public void XML_Add_Key(string add_key_text)
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;          
            XmlElement errcode = doc.CreateElement("Station");
            XmlText xmlText = doc.CreateTextNode("");
            errcode.AppendChild(xmlText);
            errcode.SetAttribute("id", add_key_text);
            root.AppendChild(errcode);
            doc.Save(xmlpath);
        }

        public void XML_Del_Key(string del_key_text)
        {
            doc.Load(xmlpath);
            XmlElement root = doc.DocumentElement;
            XmlNodeList nodelist = doc.GetElementsByTagName("Station");
            
            foreach (XmlElement ele in nodelist)
            {
                string id = ele.GetAttribute("id");
                if (id == del_key_text)
                {
                    root.RemoveChild(ele); //执行完成这条指令，将会退出foreach,因为nodelist.item(station_index)集变了
                    break;
                }
            }
            doc.Save(xmlpath);   
        }      
    }
}
