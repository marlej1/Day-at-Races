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
        public Bet MyBet { get; set; }
        public int Cash { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void UpdateLabels()
        {

        }

        public void ClearBet()
        {

        }
        public bool PlaceBet(int BetAmount, int DogToWin)
        {
            throw new NotImplementedException();
        }

        public void Collect(int winner)
        {

        }

    }

}
