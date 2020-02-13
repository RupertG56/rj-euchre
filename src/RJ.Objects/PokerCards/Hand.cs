using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Objects.PokerCards
{
    public class Hand
    {
        public const int DEFAULT_HAND_SIZE = 7;

        private int handSize;

        protected List<PlayingCard> cards;
        public List<PlayingCard> Cards
        {
            get { return cards.Select(c => c.Copy()).ToList(); }
        }

        public int CardsLeft { get { return cards.Count; } }

        public Hand()
            : this(DEFAULT_HAND_SIZE) { }

        public Hand(int handSize)
        {
            this.handSize = handSize;
            cards = new List<PlayingCard>();
        }

        public void ReceiveCard(PlayingCard card)
        {
            cards.Add(card);
        }

        public void ReceiveCards(List<PlayingCard> dealtCards)
        {
            cards.AddRange(dealtCards);
        }
    }
}
