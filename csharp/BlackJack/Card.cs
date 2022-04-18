namespace BlackJack
{
    public class Card
    {
        public Suit Suit;
        public int Rank;

        public string PrsRank()
        {
            string rank;
            switch (Rank) {
                case 1 :
                    rank = "A";
                    break;
                case 11 :
                    rank = "J";
                    break;
                case 12 :
                    rank = "Q";
                    break;
                case 13 :
                    rank = "K";
                    break;
                default :
                    rank = Rank.ToString();
                    break;
            };
            return rank;
        }
    }
}
