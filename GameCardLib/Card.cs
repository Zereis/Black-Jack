using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{
    public class Card
    {
        public Suites suit { get; set; }
        public Value value { get; set; }

        public Card(Suites suit, Value value)
        {
            this.suit = suit;
            this.value = value;
        }

        public override string ToString()
        {
            return suit.ToString() + " " + value.ToString();
        }
    }
}
