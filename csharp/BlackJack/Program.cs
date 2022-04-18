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
            var hand = new Hand();
            var total = 0;
            var oldTotal = hand.total;
            Random r = new Random();

            while (total <= 21)
            {
                Console.WriteLine("Stand, Hit");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    int index = r.Next(deck.Cards.Count);
                    var card = deck.Cards[index];
                    Console.WriteLine("index {0}, card {1}", index, card.Rank);
                    deck.Cards.RemoveAt(index);

                    if (card.Rank == 1)
                    {
                        if (hand.total <= 10)
                        {
                            hand.total = hand.total + 11;
                        }
                        else
                        {
                            hand.total = hand.total + 1;
                        }
                        hand.Cards.Add(card);
                    }
                    else
                    {
                        hand.Cards.Add(card);
                        hand.total = hand.total + Math.Min(card.Rank, 10);
                    }
                    string rank = card.PrsRank();
                    Console.WriteLine("Hit with {0} {1}. Total is {2}", card.Suit, rank, hand.total);
                    if (hand.total > 21)
                    {
                        Console.WriteLine("You loose!");
                        break;
                    }
                    else if (hand.total == 21) 
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
