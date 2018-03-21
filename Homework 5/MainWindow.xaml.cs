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

namespace Homework_5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> xList = new List<string>();
        List<string> oList = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            xList.Clear();
            oList.Clear();
            foreach(Button button in uxGrid.Children )
            {
                button.IsEnabled = true;
                button.Content = null;
            }
            uxTurn.Text = "X's turn";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;

            if (uxTurn.Text == "X's turn")
            {
                if (button.Content == null)
                {
                    int rowX = Convert.ToInt16(button.Tag.ToString().Substring(0, 1));
                    int columnX = Convert.ToInt16(button.Tag.ToString().Substring(2, 1));
                    xList.Add(button.Tag.ToString());
                    button.Content = "X";                    
                    uxTurn.Text = "O's turn";
                    winner("X", xList);
                }
            }
            else if (uxTurn.Text == "O's turn")
            {
                if (button.Content == null)
                {
                    int rowO = Convert.ToInt16(button.Tag.ToString().Substring(0, 1));
                    int columnO = Convert.ToInt16(button.Tag.ToString().Substring(2, 1));
                    oList.Add(button.Tag.ToString());
                    button.Content = "O";
                    uxTurn.Text = "X's turn";
                    winner("O", oList);
                }
            }            
        }

        private void winner(string player, List<string> list)
        {
            if 
                ((list.Contains("0,0") && list.Contains("0,1") && list.Contains("0,2")) ||                 
                (list.Contains("1,0") && list.Contains("1,1") && list.Contains("1,2")) ||
                (list.Contains("2,0") && list.Contains("2,1") && list.Contains("2,2")) ||
                (list.Contains("0,0") && list.Contains("1,0") && list.Contains("2,0")) ||
                (list.Contains("0,1") && list.Contains("1,1") && list.Contains("2,1")) ||
                (list.Contains("0,2") && list.Contains("1,2") && list.Contains("2,2")) ||
                (list.Contains("0,0") && list.Contains("1,1") && list.Contains("2,2")) ||
                (list.Contains("0,2") && list.Contains("1,1") && list.Contains("2,0")))
            {
                foreach (Button button in uxGrid.Children)
                    button.IsEnabled = false;
                uxTurn.Text = player + " is winner";
                MessageBox.Show(player + " wins!");                
            }


            
        }

    }
}
