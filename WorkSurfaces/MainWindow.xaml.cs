using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.IO;

namespace WorkSurfaces
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //WorkItemWindow myFirstWindow = new WorkItemWindow(WorkItemWindow.Type.Note, "this is a little note");
            //myFirstWindow.Left = 300;

            //WorkItemWindow mySecondWindow = new WorkItemWindow(WorkItemWindow.Type.Image, @"C:\temp\awarepoint-w.jpg");
            //mySecondWindow.Left = 600;

            //myFirstWindow.Show();
            //mySecondWindow.Show();

            WorkItem myWi1 = new ImageItem(@"c:\temp\finger.jpg");
            WorkItem myWi2 = new NoteItem("this is a little note");
            WorkSurface myWs = new WorkSurface(0, 0, 1680, 1050);
            myWs.AddItem(myWi1);
            myWs.AddItem(myWi2);
            XmlDocument myDoc = new XmlDocument();
            XmlElement contents = myWs.SerializeToXML(myDoc);
            myDoc.AppendChild(contents);
            try
            {
                FileStream fileStream =
                  new FileStream("WorkSurfaces.xml", FileMode.Create);
                XmlTextWriter textWriter =
                  new XmlTextWriter(fileStream, Encoding.UTF8);
                textWriter.Formatting = Formatting.Indented;
                myDoc.Save(textWriter);
                fileStream.Close();
                
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("XMLFile path is not valid", "WorkSurfaces.xml", ex);
                throw argEx;
            }
            catch (System.Exception ex)
            {
                System.ArgumentException argEx = new System.ArgumentException("XML File write failed", "WorkSurfaces.xml", ex);
                throw argEx;
            }


            


            //1680x1050;
        }

    }
}
