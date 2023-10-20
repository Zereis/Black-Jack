using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameCardLib
{
    public class Hand
    {
        public List<Card> cards;

        public Card LastCard { get; }

        public int NumberOfCards { get; }

        public int Score { get; set; }

        public int handValue { get; set; }

        public void Clear()
        {
            // remove cards from hand
            cards.Clear();
        }
        public void AddCard(Card card)
        {
            if (checkForDupes(card) == false)
            { 
                cards.Add(card);
                if(card.value == Value.Ace)
                {
                    handValue += 1;
                }
                else if (card.value == Value.Two)
                {
                    handValue += 2;
                }
                else if (card.value == Value.Three)
                {
                    handValue += 3;
                }
                else if (card.value == Value.Four)
                {
                    handValue += 4;
                }
                else if (card.value == Value.Five)
                {
                    handValue += 5;
                }
                else if (card.value == Value.Six)
                {
                    handValue += 6;
                }
                else if (card.value == Value.Seven)
                {
                    handValue += 7;
                }
                else if (card.value == Value.Eight)
                {
                    handValue += 8;
                }
                else if (card.value == Value.Nine)
                {
                    handValue += 9;
                }
                else if (card.value == Value.Ten)
                {
                    handValue += 10;
                }
                else if (card.value == Value.Jack)
                {
                    handValue += 10;
                }
                else if (card.value == Value.Queen)
                {
                    handValue += 10;
                }
                else if (card.value == Value.King)
                {
                    handValue += 10;
                }
            }
   
        }
        public bool checkForDupes(Card cardx)
        {
            if (cards.Contains(cardx))
            {
                return true;
            }
            return false;
        }
        public Hand()
        {
            cards = new List<Card>();
        }

        public override string ToString()
        {
            foreach (Card card in cards)
            {
                return string.Join(", ", cards);
            }
            return "Hej";
        }
    }
}
