using System;
using System.Collections.Generic;
using System.Text;

namespace BlackJack
{
    class Hand
    {
        public List<Card> Cards;
        public int total = 0;

        public Hand()
        {
            Cards = new List<Card>();
        }
    }
}
