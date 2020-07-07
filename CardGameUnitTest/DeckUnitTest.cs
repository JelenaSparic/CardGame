using CardGame;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardGameUnitTest
{
    [TestClass]
    public class DeckUnitTest
    {
        [TestMethod]
        public void Does_Deck_Have_40_Cards()
        {
            int expected = 40;
            Deck deck = new Deck(40);
            int actual = deck.Count();
            Assert.AreEqual(expected, actual, 0, "Deck doesn't have 40 cards!");

        }

        [TestMethod]
        public void Does_Deck_Shuflle()
        {
            Deck DeckNoShuffle = new Deck(40);
            Deck DeckShuffle = new Deck(40);
            DeckShuffle.Shuffle();
            Assert.AreNotEqual(DeckNoShuffle.ToString(), DeckShuffle.ToString());
        }
    }
}
