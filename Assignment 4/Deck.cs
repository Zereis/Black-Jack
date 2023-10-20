using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_4
{
    class Deck
    {
        public List<Card> cards = new List<Card>();
        int amountOfDecksToCreate;
        public Suites Suit { get; }
        public Value Value { get; }
        public void FillDeck()
        {
            Suites[] suits = Enum.GetValues(typeof(Suites)) as Suites[];
            Value[] values = Enum.GetValues(typeof(Value)) as Value[];

            for (int k = 0; k < amountOfDecksToCreate; k++)
            {
                for (int j = 0; j < values.Length; j++)
                {
                    for (int i = 0; i < suits.Length; i++)
                    {
                        cards.Add(new Card(suits[i], values[j]));
                    }
                }
            }
        }
        private static Random rng = new Random();
        public List<Card> Shuffle(List<Card> list)
        {
            // Lambda statement
            cards = list.OrderBy(a => rng.Next()).ToList();

            return cards;
        }
        public bool GameIsDone { get; set; }
        public Deck(int amountOfDecks)
        {
            cards = new List<Card>();
            this.amountOfDecksToCreate = amountOfDecks;
        }

        // When Players or dealers hit a card then removes one card from deck
        public void removeCard(Card card, List<Card> list)
        {
            if(list.Contains(card))
            {
                list.Remove(card);
                cards.Remove(card);
            }
 
        }
        // When dealer or players start the game both player get two card then
        // Two card will be removed from the deck
        public void RemoveTwoCard(int pos, List<Card> list)
        {
            for (int i = pos; i < 2; i++)
                list.RemoveAt(pos);
        }

        public override string ToString()
        {
            foreach (Card car in cards)
            {
                return car.ToString();
            }
            return null; ;
        }
    }
}
