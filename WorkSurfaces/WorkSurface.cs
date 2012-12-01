using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml;

namespace WorkSurfaces
{
    [Serializable()]
    public class WorkSurface
    {
        //List Objects        
        LinkedList<WorkWindow> windows;
        Area area;

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
            public int X
            {
                get { return x; }
                set { x = value; }
            }
            public int Y
            {
                get { return y; }
                set { y = value; }
            }
            public int Width
            {
                get { return width; }
                set { width = value; }
            }
            public int Height
            {
                get { return height; }
                set { height = value; }
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
        public XmlElement SerializeToXML(XmlDocument doc)
        {          
            //Create Root
            XmlElement root = doc.CreateElement("WorkSurface");

            //Add area
            XmlElement areaEl = doc.CreateElement("Area");
            areaEl.SetAttribute("x", this.area.X.ToString());
            areaEl.SetAttribute("y", this.area.Y.ToString());
            areaEl.SetAttribute("width", this.area.Width.ToString());
            areaEl.SetAttribute("height", this.area.Height.ToString());
            root.AppendChild(areaEl);

            XmlElement windowsEl = doc.CreateElement("Windows");
            foreach (WorkWindow ww in windows)
            {
                XmlElement windowEl = doc.CreateElement("WorkWindow");
                XmlElement areaEl2 = doc.CreateElement("Area");
                areaEl2.SetAttribute("x", ww.window.Left.ToString());
                areaEl2.SetAttribute("y", ww.window.Top.ToString());
                areaEl2.SetAttribute("width", ww.window.ActualWidth.ToString());
                areaEl2.SetAttribute("height", ww.window.ActualHeight.ToString());
                windowEl.AppendChild(areaEl2);

                XmlElement wi = ww.data.SerializeToXML(doc);
                windowEl.AppendChild(wi);

                windowsEl.AppendChild(windowEl);
            }
            root.AppendChild(windowsEl);
            return root;

        }
        public void LoadFromFile()
        {
        }

    }
}
