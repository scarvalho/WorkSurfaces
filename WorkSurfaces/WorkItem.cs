using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WorkSurfaces
{
    abstract public class WorkItem
    {
        enum Type
        {
            Document,
            Note,
            Image,
            Tool,
            Unknown
        }

        protected WorkItemWindow window;

        public void Display()
        {
            if (window != null)
                window.Show();
            
        }
        //void move();
        public void Close()
        {
            if (window != null)
                window.Hide();
        }

    }

    class ImageItem : WorkItem
    {
        public string FileName;
        public ImageItem(string name)
        {
            FileName = name;
            
        }
    }

    class NoteItem : WorkItem
    {
        public string Contents;
        public NoteItem(string contents)
        {
            Contents = contents;            
        }
    }
}
