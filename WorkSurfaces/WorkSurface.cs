using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using System.Xml;
using System.Xml.Schema;

namespace WorkSurfaces
{
    public class WorkSurface : IXmlSerializable
    {
        //List Objects
        public LinkedList<WorkWindow> windows;
        public Area area;
        public struct WorkWindow
        {
            public WorkItem data;
            public WorkItemWindow window;
            public WorkWindow(WorkItem d, WorkItemWindow w)
            {
                data = d;
                window = w;
            }
        }
        public struct Area
        {
            int x;
            int y;
            int width;
            int height;
            public Area(int x, int y, int width, int height)
            {
                this.x = x;
                this.y = y;
                this.width = width;
                this.height = height;
            }

        }
        public WorkSurface()
        {
            windows = new LinkedList<WorkWindow>();
        }
        public WorkSurface(int x, int y, int width, int height)
        {
            area = new Area(x, y, width, height);
            windows = new LinkedList<WorkWindow>();
        }
        public void AddItem(WorkItem wi)
        {
            WorkItemWindow newWindow = new WorkItemWindow(wi);
            WorkWindow newWorkWindow= new WorkWindow(wi, newWindow);
            newWindow.Show();
            windows.AddLast(newWorkWindow);
        }
        public void RemoveItem()
        {
        }
        private void OnDocumentRecognized()
        {
        }
        public void SaveToFile()
        {

          XmlSerializer serializer = new XmlSerializer(typeof(WorkSurface));
          TextWriter textWriter = new StreamWriter(@"C:\temp\workSurface.xml");
          serializer.Serialize(textWriter, this);
          textWriter.Close();

        }
        public void LoadFromFile()
        {
        }

        public XmlSchema GetSchema()
        {
            return null;
        }

        public void ReadXml(XmlReader reader)
        {
            throw new System.NotImplementedException();
        }

        public void WriteXml(XmlWriter writer)
        {
            writer.WriteStartElement("Windows");
            foreach (var item in windows)
            {
                //XmlSerializer serializer = new XmlSerializer(typeof(WorkSurface));
                writer.WriteElementString("Item", item.window.Width.ToString());
            }
            writer.WriteEndElement();
        }
    }
}
