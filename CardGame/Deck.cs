using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame
{
    public class Deck
    {
        public Stack<Card> Cards;

        public Deck()
        {
            Cards = new Stack<Card>();
        }
        public Deck(int cardsInDeck)
        {
            Cards = new Stack<Card>();
            for (int i = 0; i < cardsInDeck; i++)
            {
                Cards.Push(new Card(i % 10 + 1));
            }
        }

        public void Shuffle()
        {
            List<Card> CardsTemp = Cards.ToList();
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = CardsTemp.Count - 1; i > 0; i--)
            {
                int j = r.Next(i + 1);
                Card temp = CardsTemp[i];
                CardsTemp[i] = CardsTemp[j];
                CardsTemp[j] = temp;
            }
            Cards.Clear();
            foreach (Card card in CardsTemp)
            {
                Cards.Push(card);
            }
        }

        public int Count()
        {
            return Cards.Count;
        }

        public override string ToString()
        {
            string deckToString = "{";
            foreach (Card card in Cards)
            {
                deckToString = deckToString + card.ToString() + " ";
            }
            deckToString = deckToString + "}";
            return deckToString;
        }

    }
}
