using System;
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
using System.Text.RegularExpressions;

namespace Homework_4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            submitButton.IsEnabled = false;
        }

        private void zipTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            Regex regexUSA = new Regex(@"^\d{5}(-\d{4})?$");
            Regex regexCan = new Regex(@"^([A-Z]\d[A-Z]\d[A-Z]\d)$");
            if (regexUSA.Match(zipTextBox.Text).Success || regexCan.Match(zipTextBox.Text).Success)
                submitButton.IsEnabled = true;
            else
                submitButton.IsEnabled = false;
        }
    }
}
