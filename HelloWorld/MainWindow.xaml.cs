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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity;

namespace HelloWorld
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Models.User user = new Models.User();

        public MainWindow()
        {
            InitializeComponent();
            //WindowState = WindowState.Maximized;            
        }

        public override void EndInit()
        {
            base.EndInit();

            //information for user comes from entity framework
            var sample = new SampleEntities();

            sample.Users.Load();

            uxList.ItemsSource = sample.Users.Local;
        }

        private void uxSubmit_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Submitting password: " + uxPassword.Text);

            //close the current window and launch the second window
            var window = new SecondWindow();
            Application.Current.MainWindow = window;
            Close();
            window.Show();
        }
        
        private void enableSubmit()
        {
            if (uxName.GetLineLength(0) > 0 && uxPassword.GetLineLength(0) > 0)
                uxSubmit.IsEnabled = true;
            else
                uxSubmit.IsEnabled = false;
        }

        private void uxName_KeyUp_1(object sender, KeyEventArgs e)
        {
            enableSubmit();
        }

        private void uxPassword_KeyUp_1(object sender, KeyEventArgs e)
        {
            enableSubmit();
        }
    }
}
