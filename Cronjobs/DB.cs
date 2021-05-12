using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO; 
using System.Xml;
 
using System.Collections.ObjectModel;
using System.Linq;

namespace Cronjobs {
    class DB {
        public static ObservableCollection<Cron> crons = new ObservableCollection<Cron>();


        public static Action OnChanged;

        public static void Load() {
            crons.Clear();
            if(!File.Exists(AM.DatabaseFile))
                return;
            XmlDocument doc = new XmlDocument();
            doc.Load(AM.DatabaseFile);
            foreach(XmlNode node in doc.DocumentElement.ChildNodes) {
                Cron cron = new Cron();
                foreach(XmlAttribute attribute in node.Attributes) {
                    switch(attribute.Name) {
                        case "Path":
                            cron.FilePath = attribute.Value;
                            break;
                        case "LastRunDate":
                            cron.LastRunDate = DateTime.Parse(attribute.Value, new CultureInfo("tr"));
                            break;
                        case "NextRunDate":
                            cron.NextRunDate = DateTime.Parse(attribute.Value, new CultureInfo("tr"));
                            break;
                        case "DelayMin":
                            cron.DelayMin = int.Parse(attribute.Value);
                            break;
                        case "DelayMax":
                            cron.DelayMax = int.Parse(attribute.Value);
                            break;
                    }
                }
                crons.Add(cron);
            } 
        }

        public static void Save() {
            XmlDocument doc = new XmlDocument();
            XmlNode rootNode = doc.CreateElement("Crons");
            crons.ToList().ForEach(cron => {
                XmlNode cronNode = doc.CreateElement("Cron");
                cronNode.Attributes.Append(NewXmlAttribute(doc, "Path", cron.FilePath));
                cronNode.Attributes.Append(NewXmlAttribute(doc, "LastRunDate", cron.LastRunDate.ToUniversalTime().ToString("u")));
                cronNode.Attributes.Append(NewXmlAttribute(doc, "NextRunDate", cron.NextRunDate.ToUniversalTime().ToString("u")));
                cronNode.Attributes.Append(NewXmlAttribute(doc, "DelayMin", cron.DelayMin.ToString()));
                cronNode.Attributes.Append(NewXmlAttribute(doc, "DelayMax", cron.DelayMax.ToString()));
                rootNode.AppendChild(cronNode);
            });
            doc.AppendChild(rootNode);
            doc.Save(AM.DatabaseFile);
            if(OnChanged != null)
                System.Windows.Application.Current?.Dispatcher?.Invoke(OnChanged);
             
        }

        public static XmlAttribute NewXmlAttribute(XmlDocument doc, string name, string value) {
            XmlAttribute attribute = doc.CreateAttribute(name);
            attribute.Value = value;
            return attribute;
        }



        public static void RunCrons(List<Cron> list) {
            if(list.Count == 0)
                return;
            Random random = new Random();
            list.ForEach(cron => {
                cron.LastRunDate = DateTime.Now;
                cron.NextRunDate = DateTime.Now.AddMinutes(random.Next(cron.DelayMin, cron.DelayMax));
                PM.Run(cron.FilePath); 
            });
            Save();
        }


    }
}
