using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_at_Races.Models
{
    public class Guy : INotifyPropertyChanged
    {     
        public string Name { get; set; }
      
        private int _cash;
        public int Cash
        {
            get
            {
                return _cash;
            }
            set
            {
                _cash = value;
                OnPropertyChanged("Cash");
            }
        }

        public Bet MyBet { get; set; }
        

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateLabels()
        {

        }

        public void ClearBet()
        {

        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {

            if(Cash-BetAmount>=0)
            {
                MyBet = new Bet { Amount = BetAmount, Dog = DogToWin };
                return true;
            }
            else
            {
                return false;
            }
               

            
        }

        public void Collect(int winner)
        {

        }
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public override string ToString()
        {
            return Name + " has " + Cash + " bucks.";
        }

    }

}
