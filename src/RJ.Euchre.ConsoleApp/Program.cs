using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Objects.PokerCards;

namespace RJ.Euchre.ConsoleApp
{
    public class Program
    {
        static void Main(string[] args)
        {
            var program = new Program();
            program.DealCards();
            program.WriteHands();
            program.WriteTopCard();

            Console.ReadKey();
        }

        private EuchreDeck deck;
        private List<Hand> hands;

        public Program()
        {
            deck = new EuchreDeck();
            hands = new List<Hand>()
            {
                new Hand(5),
                new Hand(5),
                new Hand(5),
                new Hand(5)
            };
        }

        public void DealCards()
        {
            deck.YatesShuffle();
            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < hands.Count; y++)
                {
                    var hand = hands[y];

                    hand.ReceiveCards(deck.DealNextCards());
                }
            }
        }

        public void WriteHands()
        {
            for (int y = 0; y < hands.Count; y++)
            {
                var hand = hands[y];
                Console.WriteLine("Hand {0} ----------------------------\r\n", y + 1);
                foreach (var card in hand.Cards)
                {
                    Console.WriteLine("\t{0} of {1}", card.Face, card.Suit);
                }
                Console.WriteLine("");
            }
        }

        public void WriteTopCard()
        {
            Console.WriteLine("Possible Trump Suit {0}. Card: {1}", deck.TopCardOfLastFour.Suit, deck.TopCardOfLastFour.Face);
        }

        public void WriteJsonDictionaryForCardFaces()
        {

        }
    }
}
