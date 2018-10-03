using Day_at_Races.Models;
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
using System.Windows.Threading;

namespace Day_at_Races
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Guy Joe, Bob, Al;
     
        DispatcherTimer timer = new DispatcherTimer();

       

        public MainWindow()
        {
           InitializeComponent();
            Joe = new Guy { Name = "Joe", Cash = 45 };
            Bob = new Guy { Name = "Bob", Cash = 45 };
             Al = new Guy { Name = "Al", Cash = 45 };



            timer.Tick += TickStarted;       
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);
        }
        private void RaceBtn_Click(object sender, RoutedEventArgs e)
        {

            timer.IsEnabled = !timer.IsEnabled;
           
        }

        private void TickStarted(object sender, EventArgs e)
        {
            Canvas.SetLeft(DogImage4, Canvas.GetLeft(DogImage4) + 2);
        }

        private void FirstRadiotbn_Checked(object sender, RoutedEventArgs e)
        {
            NameLabel.Content = "Joe";
        }

        private void SecondRadiobtn_Checked(object sender, RoutedEventArgs e)
        {
            NameLabel.Content = "Bob";

        }

        private void ThirdRadionbtn_Checked(object sender, RoutedEventArgs e)
        {
            NameLabel.Content = "Al";
        }

        private void BetButton_Click(object sender, RoutedEventArgs e)
        {

           var item =  DogComboBox.SelectedValue as ComboBoxItem;

            if (item != null)
            {
                if(FirstRadiotbn.IsChecked==true)
                   FirstTextBox.Text = string.Format("Joe bets {0} on {1}", BetTextBox.Text, item.Content);
                else if (SecondRadiobtn.IsChecked == true)
                    SecondTextBox.Text = string.Format("Bob bets {0} on {1}", BetTextBox.Text, item.Content);
                else if (ThirdRadionbtn.IsChecked == true)
                    ThirdTextBox.Text = string.Format("Al bets {0} on {1}", BetTextBox.Text, item.Content);
            }
                

        }

        
    }
}
