using System;
using System.Collections.Generic;

namespace CardGame
{
    public class Game
    {
        public const int CARDS_IN_DECK = 40;
        public const int PLAYERS_IN_GAME = 2;

        public List<Player> Players = new List<Player>();
        private Deck Deck = new Deck(CARDS_IN_DECK);
        private Deck DrowedDeck = new Deck();
        public Game()
        {
            for (int i = 1; i <= PLAYERS_IN_GAME; i++)
            {
                Players.Add(new Player("Player " + i.ToString()));
            }
        }

        public void Play()
        {
            Deck.Shuffle();
            Deal();
            while (!IsEndOfGame())
            {
                PlayTurn();
                PrintTurn();
                Score();
            }
            PrintGameScore();
        }
        public void Deal()
        {
            while (Deck.Cards.Count >= PLAYERS_IN_GAME)
            {
                foreach (Player player in Players)
                {
                    player.DrawPile.Cards.Push(Deck.Cards.Pop());
                }
            }
        }

        public void PlayTurn()
        {
            if (Players[0].DrawPile.Cards.Count == 0 && Players[0].DiscardPile.Cards.Count > 0)
            {
                Players[0].DiscardPile.Shuffle();
                foreach (Card card in Players[0].DiscardPile.Cards)
                {
                    Players[0].DrawPile.Cards.Push(card);
                }
                Players[0].DiscardPile.Cards.Clear();
            }
            if (Players[1].DrawPile.Cards.Count == 0 && Players[1].DiscardPile.Cards.Count > 0)
            {
                Players[1].DiscardPile.Shuffle();
                foreach (Card card in Players[1].DiscardPile.Cards)
                {
                    Players[1].DrawPile.Cards.Push(card);
                }
                Players[1].DiscardPile.Cards.Clear();
            }
            foreach (Player player in Players)
            {
                player.DrowedCard = player.DrawPile.Cards.Pop();
                DrowedDeck.Cards.Push(player.DrowedCard);
            }
        }

        public void Score()
        {
            if (Players[0].DrowedCard.GetValue() == Players[1].DrowedCard.GetValue())
            {
                Console.WriteLine("No winner in this round");
            }
            else if (Players[0].DrowedCard.GetValue() > Players[1].DrowedCard.GetValue())
            {
                Console.WriteLine("Player 1 wins this round");
                foreach (Card card in DrowedDeck.Cards)
                {
                    Players[0].DiscardPile.Cards.Push(card);
                }
                DrowedDeck.Cards.Clear();
            }
            else
            {
                Console.WriteLine("Player 2 wins this round");
                foreach (Card card in DrowedDeck.Cards)
                {
                    Players[1].DiscardPile.Cards.Push(card);
                }
                DrowedDeck.Cards.Clear();
            }
            Console.WriteLine();
        }

        public void PrintTurn()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name + " (" + (player.DrawPile.Count() + 1 + player.DiscardPile.Count()).ToString() + "): "
                    + player.DrowedCard.ToString());
            }

        }
        public void PrintGameScore()
        {
            if (Players[0].DiscardPile.Cards.Count == Players[1].DiscardPile.Cards.Count)
            {
                Console.WriteLine("No winner in this game");
            }
            else if (Players[0].DiscardPile.Cards.Count > Players[1].DiscardPile.Cards.Count)
            {
                Console.WriteLine("Player 1 wins the game!");
            }
            else
            {
                Console.WriteLine("Player 2 wins the game!");
            }
        }
        private bool IsEndOfGame()
        {
            if ((Players[0].DrawPile.Cards.Count == 0 && Players[0].DiscardPile.Cards.Count == 0)
                 || (Players[1].DrawPile.Cards.Count == 0 && Players[1].DiscardPile.Cards.Count == 0))
            {
                return true;
            }
            else { return false; }
        }
        public override string ToString()
        {
            return "Game started!";
        }
    }
}
