using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace helsinki1952
{
    internal class Reading
    {
        public int racerPlace;
        public int athletes;
        public string sportName;
        public string sportCompatition;
        
        public Reading(string line)
        {
            string[] data = line.Split(' ');
            racerPlace = Convert.ToInt32(data[0]);
            athletes = Convert.ToInt32(data[1]);
            sportName = data[2];
            sportCompatition = data[3];
        }
    }
}
