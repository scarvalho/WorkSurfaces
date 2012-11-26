﻿using System;
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
using System.Windows.Shapes;

namespace WorkSurfaces
{
    /// <summary>
    /// Interaction logic for WorkItemWindow.xaml
    /// </summary>
    public partial class WorkItemWindow : Window
    {
        public enum Type
        {
            Image,
            Note
        }
        public WorkItemWindow()
        {
            InitializeComponent();
        }

        public WorkItemWindow(Type type, String value)
        {
            InitializeComponent();
            SetContent(type, value);
        }

        public WorkItemWindow(WorkItem wi)
        {
            InitializeComponent();
            if (wi is ImageItem)
            {
                SetContent(Type.Image, ((ImageItem)wi).FileName);
            }
            else if (wi is NoteItem)
            {
                SetContent(Type.Note, ((NoteItem)wi).Contents);
            }
        }
        //Maybe we shouldn't have a local type - workitem and workitemwindow are pretty coupled.
        public void SetContent(Type type, String value)
        {
            if (type == Type.Image)
            {
                Image content = CreateImageContent(value);
                ContentStackPanel.Children.Add(content);
            }
            else if (type == Type.Note)
            {
                TextBox content = CreateNoteContent(value);
                ContentStackPanel.Children.Add(content);
            }
        }

        private Image CreateImageContent(string FileName)
        {
            // Create Image Element
            Image myImage = new Image();           

            // Create source
            BitmapImage myBitmapImage = new BitmapImage();

            // BitmapImage.UriSource must be in a BeginInit/EndInit block
            myBitmapImage.BeginInit();
            myBitmapImage.UriSource = new Uri(FileName);
            myBitmapImage.EndInit();

            //set image source
            myImage.Source = myBitmapImage;
            myImage.Width = myBitmapImage.PixelWidth;
            myImage.Height = myBitmapImage.PixelHeight;

            return myImage;
        }
        private TextBox CreateNoteContent(string text)
        {
            TextBox myText = new TextBox();
            myText.Text = text;
            myText.MinHeight = 150;
            myText.MinWidth = 300;
            myText.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
            return myText;
        }
        
    }
}
