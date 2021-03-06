﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _01BasicControls
{
    /// <summary>
    /// Interaction logic for Window01.xaml
    /// </summary>
    public partial class Window01 : Window
    {
        public Window01()
        {
            InitializeComponent();
        }

       
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var qryList = from proc in System.Diagnostics.Process.GetProcesses()
                      select proc.ProcessName;

            lst01.ItemsSource = qryList;

            var qryLView = from proc in System.Diagnostics.Process.GetProcesses()
                      select proc;

            lstView.ItemsSource = qryLView;
        }

        private void MyCalendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
