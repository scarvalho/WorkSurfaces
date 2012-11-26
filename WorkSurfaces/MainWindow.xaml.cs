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
            WorkItemWindow myFirstWindow = new WorkItemWindow(WorkItemWindow.Type.Note, "this is a little note");
            myFirstWindow.Left = 300;

            WorkItemWindow mySecondWindow = new WorkItemWindow(WorkItemWindow.Type.Image, @"C:\temp\awarepoint-w.jpg");
            mySecondWindow.Left = 600;

            myFirstWindow.Show();
            mySecondWindow.Show();

            WorkItem myWi1 = new ImageItem(@"C:\temp\awarepoint-w.jpg");
            WorkItem myWi2 = new NoteItem("this is a little note");
            WorkSurface myWs = new WorkSurface(0, 0, 1680, 1050);
            myWs.AddItem(myWi1);
            myWs.AddItem(myWi2);
            myWs.SaveToFile();

            


            //1680x1050;
        }

    }
}
