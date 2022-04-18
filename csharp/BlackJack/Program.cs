using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack
{
    class Program
    {
        static void Main(string[] args)
        {
            var deck = new Deck();
            var hand = new List<Card>();
            var total = 0;

            while (total <= 21)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    var card = deck.Cards.Dequeue();
                    hand.Add(card);
                    total = hand.Sum(x => Math.Min(x.Rank, 10));
                    string rank = card.PrsRank();
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, rank, total);
                    if (total > 21)
                    {
                        Console.WriteLine("You loose!");
                        break;
                    }
                    else if (total == 21) 
                    {
                        Console.WriteLine("You win!");
                        break;
                    }
                }
                else if (read == "Stand")
                {
                    break;
                }
            }
        }
    }
}
