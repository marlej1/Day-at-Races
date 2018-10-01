using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_at_Races.Models
{
    public class Bet
    {
        public int Amount { get; set; }
        public int Dog { get; set; } // The amount of cash that was bet
        public Guy Bettor { get; set; }// The number of the dog the bet is on


        public string GetDescription()
        {
            throw new NotImplementedException();

        }

        public int PayOut(int Winner)
        {
            throw new NotImplementedException();
        }
    }
}