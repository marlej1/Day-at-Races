using Day_at_Races.Models;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Day_at_Races
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        Guy Joe, Bob, Al;
        DispatcherTimer timer;
        GreyHound winner;
       List<GreyHound> greyHounds;

        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            InitializeGuys();
            InitializeGreyHouds();
           
            timer.Tick += TickStarted;
            timer.Interval = new TimeSpan(0, 0, 0, 0, 20);          
        }

        private void InitializeGuys()
        {
            Joe = new Guy { Name = "Joe", Cash = 45 };
            Bob = new Guy { Name = "Bob", Cash = 45 };
            Al = new Guy { Name = "Al", Cash = 45 };
            FirstRadiotbn.DataContext = Joe;
            SecondRadiobtn.DataContext = Bob;
            ThirdRadionbtn.DataContext = Al;
        }
        private void InitializeGreyHouds()
        {
            greyHounds = new List<GreyHound>
            {
                new GreyHound{  Image = DogImage1, Name="Dog 1" },
                new GreyHound {  Image = DogImage2, Name="Dog 2"  },
                new GreyHound{  Image = DogImage3, Name="Dog 3"  },
                new GreyHound{ Image = DogImage4 , Name="Dog 4" }
            };
        }

        private void RaceBtn_Click(object sender, RoutedEventArgs e)
        {
            Random rnd = new Random();

            foreach (var greyhound in greyHounds)
            {
                greyhound.Speed = rnd.Next(1, 20);
            }
            
            timer.IsEnabled = !timer.IsEnabled;
        }

        private void TickStarted(object sender, EventArgs e)
        {
            Canvas.SetLeft(DogImage1, Canvas.GetLeft(DogImage1) + greyHounds[0].Speed);
            Canvas.SetLeft(DogImage2, Canvas.GetLeft(DogImage2) + greyHounds[1].Speed);
            Canvas.SetLeft(DogImage3, Canvas.GetLeft(DogImage3) + greyHounds[2].Speed);
            Canvas.SetLeft(DogImage4, Canvas.GetLeft(DogImage4) + greyHounds[3].Speed);

         
           if(Canvas.GetLeft(DogImage1) > this.Width - 160)
            {
                winner = greyHounds[0];                     
            }
           else if(Canvas.GetLeft(DogImage2) > this.Width - 160)
            {
                winner = greyHounds[1];            
            }
            else if (Canvas.GetLeft(DogImage3) > this.Width - 160)
            {
                winner = greyHounds[2];         
            }
            else if (Canvas.GetLeft(DogImage4) > this.Width - 160)
            {
                winner = greyHounds[3];            
            }
            CheckWinnerAndReset();
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
            var selecetedIndex = DogComboBox.SelectedIndex;

            if (item != null)
            {
                if (FirstRadiotbn.IsChecked == true)
                {
                    if (Joe.PlaceBet(Int32.Parse(BetTextBox.Text), selecetedIndex))                   
                        FirstTextBox.Text = string.Format("Joe bets {0} on {1}", BetTextBox.Text, item.Content);
                    else
                        FirstTextBox.Text = string.Format("Joe does't have enough money to place this bet");
                }
                else if (SecondRadiobtn.IsChecked == true)
                {
                    if (Bob.PlaceBet(Int32.Parse(BetTextBox.Text), selecetedIndex))
                        SecondTextBox.Text = string.Format("Bob bets {0} on {1}", BetTextBox.Text, item.Content);
                    else
                        SecondTextBox.Text = string.Format("Bob does't have enough money to place this bet");                  
                }
                   
                else if (ThirdRadionbtn.IsChecked == true)
                {
                    if (Al.PlaceBet(Int32.Parse(BetTextBox.Text), selecetedIndex))
                        ThirdTextBox.Text = string.Format("Al bets {0} on {1}", BetTextBox.Text, item.Content);
                    else
                        FirstTextBox.Text = string.Format("Al does't have enough money to place this bet");
                }              
           }                      
        }
        private void CheckWinnerAndReset()
        {
            if (winner != null)
            {
                timer.IsEnabled = false;
                MessageBox.Show(winner.Name + " has won the race");

                Canvas.SetLeft(DogImage1, 0);
                Canvas.SetLeft(DogImage2, 0);
                Canvas.SetLeft(DogImage3, 0);
                Canvas.SetLeft(DogImage4, 0);



                winner = null;
           }


        }



    }
}
