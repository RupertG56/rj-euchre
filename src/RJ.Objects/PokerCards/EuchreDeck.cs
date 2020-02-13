using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Objects.PokerCards
{
    public class EuchreDeck : Deck
    {
        private int dealIndex = 0;
        private int currentCardIndex = 0;
        private int dealCount = 0;

        private PlayingCard[] redScoringCards;
        public PlayingCard[] RedScoringCards
        {
            get { return redScoringCards.Select(c => c.Copy()).ToArray(); }
        }

        private PlayingCard[] blackScoringCards;
        public PlayingCard[] BlackScoringCards
        {
            get { return blackScoringCards.Select(c => c.Copy()).ToArray(); }
        }

        public PlayingCard TopCardOfLastFour
        {
            get { return shuffledDeck.Skip(currentCardIndex).First(); }
        }

        public int[] DealingPattern;


        public EuchreDeck()
            : base(true)
        {
            redScoringCards = cards.Where(c => (int)c.Suit < 3 && (int)c.Face == 5).ToArray();
            blackScoringCards = cards.Where(c => (int)c.Suit > 2 && (int)c.Face == 5).ToArray();

            cards = cards.Where(c => (int)c.Face > 8).ToList();
            DealingPattern = new int[] { 2, 3 };
        }

        public List<PlayingCard> DealNextCards()
        {
            ++dealCount;

            List<PlayingCard> dealtCards = shuffledDeck.Skip(currentCardIndex)
                .Take(DealingPattern[dealIndex])
                .ToList();

            currentCardIndex += DealingPattern[dealIndex];

            dealIndex = dealIndex == 0 ? 1 : 0;

            if (dealCount == 4)
            {
                dealIndex = 1;
                dealCount = 0;
            }

            return dealtCards;
        }
    }
}
