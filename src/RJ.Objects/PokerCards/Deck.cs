using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RJ.Objects.Common;

namespace RJ.Objects.PokerCards
{
    public class Deck
    {
        private const int deckSize = 52;
        private const int ACE_LOW_FACEEND       = 13;
        private const int ACE_HIGH_FACEEND      = 14;
        private const int ACE_LOW_FACESTART     =  1;
        private const int ACE_HIGH_FACESTART    =  2;
        private const int SUIT_MAX = 4;

        protected List<PlayingCard> cards;
        public List<PlayingCard> Cards
        {
            get { return cards.Select(t => t.Copy()).ToList(); }
        }

        protected List<PlayingCard> shuffledDeck;
        public List<PlayingCard> ShuffledDeck
        {
            get { return shuffledDeck.Select(t => t.Copy()).ToList(); }
        }

        public Deck()
            : this(false) { }

        public Deck(bool aceIsHigh)
        {
            cards = new List<PlayingCard>(deckSize);
            shuffledDeck = new List<PlayingCard>(deckSize);
            shuffledDeck.EmptyFill(deckSize);

            setup(aceIsHigh);
        }

        private void setup(bool aceIsHigh)
        {
            int faceStart = aceIsHigh ? ACE_HIGH_FACESTART : ACE_LOW_FACESTART;
            int faceEnd = aceIsHigh ? ACE_HIGH_FACEEND : ACE_LOW_FACEEND;

            for (int i = 1; i <= SUIT_MAX; i++)
            {
                for (int x = faceStart; x <= faceEnd; x++)
                {
                    cards.Add(new PlayingCard((CardSuit)i, (CardFace)x));
                }
            }
        }

        public void Shuffle()
        {
            shuffle(cards);
            shuffle(ShuffledDeck);
        }

        public void YatesShuffle()
        {
            Random rng = new Random((int)DateTime.Now.Ticks);

            shuffledDeck.Clear();
            shuffledDeck.AddRange(cards);

            for (int n = shuffledDeck.Count - 1; n > 0; --n)
            {
                int k = rng.Next(n + 1);
                PlayingCard temp = shuffledDeck[n];
                shuffledDeck[n] = shuffledDeck[k];
                shuffledDeck[k] = temp;
            }
        }

        private void shuffle(List<PlayingCard> deck)
        {
            shuffledDeck.Clear();
            shuffledDeck.EmptyFill(deckSize);

            Random rng = new Random((int)DateTime.Now.Ticks);
            int mark = rng.Next(1, 51);
            int b = 0, c = 0, d = 0;
            int stop = 0;

            do
            {
                stop = 0;
                c = mark;
                d = c - 1;

                do
                {
                    if (shuffledDeck[c] == null)
                    {
                        shuffledDeck[c] = deck[b];
                        b++;
                        stop = 1;
                    }

                    if (shuffledDeck[d] == null && stop == 0)
                    {
                        shuffledDeck[d] = deck[b];
                        b++;
                        stop = 1;
                    }

                    c++;
                    d--;
                } while (d >= 0 && c <= 51 && stop == 0);

                mark = rng.Next(1, 51);
            } while (b < 52);
        }
    }
}
