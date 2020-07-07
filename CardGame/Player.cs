namespace CardGame
{
    public class Player
    {
        public string Name { get; set; }
        public Deck DrawPile { get; set; }
        public Deck DiscardPile { get; set; }
        public Card DrowedCard { get; set; }

        public Player(string name)
        {
            Name = name;
            DrawPile = new Deck();
            DiscardPile = new Deck();
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
