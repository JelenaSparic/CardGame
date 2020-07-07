using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGameUnitTest
{
    [TestClass]
    public class GameUnitTest
    {
        [TestMethod]
        public void Is_Discard_Pile_Shuffled_To_Draw_Pile()
        {
            Game game = new Game();
            game.Deal();
            game.Players[0].DiscardPile.Cards.Push(new Card(1));
            game.Players[0].DiscardPile.Cards.Push(new Card(1));
            int DiscardPileCount = game.Players[0].DiscardPile.Cards.Count;
            game.Players[0].DrawPile.Cards.Clear();
            game.PlayTurn();
            Assert.AreEqual(DiscardPileCount - 1, game.Players[0].DrawPile.Cards.Count);
        }

        [TestMethod]
        public void Does_Higher_Value_Card_Winn()
        {
            Game game = new Game();
            game.Deal();
            int Before = game.Players[0].DiscardPile.Cards.Count;
            game.Players[0].DrawPile.Cards.Push(new Card(10));
            game.Players[1].DrawPile.Cards.Push(new Card(1));
            game.PlayTurn();
            game.Score();
            Assert.AreEqual(Before + 2, game.Players[0].DiscardPile.Cards.Count);
        }

        [TestMethod]
        public void AfterDrawWinnerTakesAll()
        {
            Game game = new Game();
            game.Deal();
            int Before = game.Players[0].DiscardPile.Cards.Count;
            game.Players[0].DrawPile.Cards.Push(new Card(10));
            game.Players[1].DrawPile.Cards.Push(new Card(1));
            game.Players[0].DrawPile.Cards.Push(new Card(5));
            game.Players[1].DrawPile.Cards.Push(new Card(5));
            game.PlayTurn();
            game.Score();
            game.PlayTurn();
            game.Score();
            Assert.AreEqual(Before + 4, game.Players[0].DiscardPile.Cards.Count);

        }


    }
}
