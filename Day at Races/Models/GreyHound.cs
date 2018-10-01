using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Day_at_Races.Models
{
    class GreyHound
    {
        public int StartingPosition { get; set; }
        public int RacetrackLength { get; set; }
        public int Location { get; set; } = 0;
        public Random Randomizer { get; set; }

        public bool Run()
        {
            throw new NotImplementedException();
        }

        public void TakeStartingPosition()
        {

        }

    }
}
