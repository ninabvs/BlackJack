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
            var dealerHand = new Hand();
            Random r = new Random();

            //Dealerss first card
            int index = r.Next(deck.Cards.Count);
            var card = deck.Cards[index];
            deck.Cards.RemoveAt(index);

            if (card.Rank == 1)
            {
                if (dealerHand.total <= 10)
                {
                    dealerHand.total = dealerHand.total + 11;
                }
                else
                {
                    dealerHand.total = dealerHand.total + 1;
                }
                dealerHand.Cards.Add(card);
            }
            else
            {
                dealerHand.Cards.Add(card);
                dealerHand.total = dealerHand.total + Math.Min(card.Rank, 10);
            }
            string rank = card.PrsRank();
            Console.WriteLine("Dealer hit with {0} {1}. Total is {2}", card.Suit, rank, dealerHand.total);

            //Player
            Console.WriteLine("\nPlayer's turn");
            while (hand.total <= 21)
            {
                Console.WriteLine("Stand or Hit?");
                string read = Console.ReadLine();
                if (read == "Hit")
                {
                    index = r.Next(deck.Cards.Count);
                    card = deck.Cards[index];
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
                    rank = card.PrsRank();
                    Console.WriteLine("Player hit with {0} {1}. Total is {2}", card.Suit, rank, hand.total);
                }
                else if (read == "Stand")
                {
                    Console.WriteLine("Player stands");
                    break;
                }
            }

            //Dealer
            Console.WriteLine("\nDealer's turn");
            while (dealerHand.total < 17)
            {
                index = r.Next(deck.Cards.Count);
                card = deck.Cards[index];
                deck.Cards.RemoveAt(index);

                if (card.Rank == 1)
                {
                    if (dealerHand.total <= 10)
                    {
                        dealerHand.total = dealerHand.total + 11;
                    }
                    else
                    {
                        dealerHand.total = dealerHand.total + 1;
                    }
                    hand.Cards.Add(card);
                }
                else
                {
                    dealerHand.Cards.Add(card);
                    dealerHand.total = dealerHand.total + Math.Min(card.Rank, 10);
                }
                rank = card.PrsRank();
                Console.WriteLine("Dealer Hit with {0} {1}. Total is {2}", card.Suit, rank, dealerHand.total);
            }

            //And the winner is
            Console.WriteLine("\n");
            if (dealerHand.total > hand.total && dealerHand.total <= 21)
            {
                Console.WriteLine("Dealer wins with {0} against your {1}", dealerHand.total, hand.total);
            }
            else if (dealerHand.total < hand.total && hand.total <= 21)
            {
                Console.WriteLine("Player wins with {1} against dealer's {0}!", dealerHand.total, hand.total);
            }
            else if (hand.total > 21 && dealerHand.total > 21)
            {
                Console.WriteLine("You both loose!");
            }
            else if (hand.total > 21 && dealerHand.total <= 21)
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealerHand.total > 21 && hand.total <= 21)
            {
                Console.WriteLine("Player wins!");
            }
            else if (dealerHand.total == hand.total)
            {
                Console.WriteLine("Draw!");
            }
        }
    }
}
