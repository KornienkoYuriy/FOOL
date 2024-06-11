using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace РГР
{
    internal class Card
    {
        public string CardRank { get; set; }
        public string CardSuit { get; set; }
        public int CardPower { get; set; }

        public int CheckRank(string rank)
        {
            int power;
            if (rank != "J" && rank != "Q" && rank != "K" && rank != "A")
            {
                try
                {
                    power = Convert.ToInt32(rank);
                }
                catch 
                {
                    power = 0;
                }
            }
            else
            {
                switch (rank)
                {
                    case "J":
                        power = 11;
                        break;
                    case "Q":
                        power = 12;
                        break;
                    case "K":
                        power = 13;
                        break;
                    case "A":
                        power = 14;
                        break;
                    default:
                        power = -1;
                        break;
                }
            }
            return power;
        }
    }
}
