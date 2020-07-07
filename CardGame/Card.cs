namespace CardGame
{
    public class Card
    {
        private readonly int value;

        public Card(int value)
        {
            this.value = value;
        }

        public int GetValue()
        {
            return value;
        }

        public override string ToString()
        {
            return value.ToString();
        }
    }
}
