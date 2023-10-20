using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    internal class Player
    {
        public Hand Hand { get; set; }
        
        public bool isFinished { get; set; }

        public string Name { get; set; }

        public string PlayerID { get; set; }

        public bool Winner { get; set; }

        public Player(string playerID, string name, Hand hand, bool isFinished, bool winner)
        {
            Hand = hand;
            this.isFinished = isFinished;
            Name = name;
            PlayerID = playerID;
            Winner = winner;
        }

        public string ToString()
        {
            return base.ToString();
        }
    }
}
