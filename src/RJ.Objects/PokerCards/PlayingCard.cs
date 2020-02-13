using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RJ.Objects.PokerCards
{
    public class PlayingCard
    {
        private const int PRIME = 11;

        private bool _isHashSet = false;
        private int _hash = 1;

        private CardSuit suit;
        public CardSuit Suit
        {
            get { return suit; }
            private set { suit = value; }
        }

        private CardFace face;
        public CardFace Face
        {
            get { return face; }
            private set { face = value; }
        }

        public string Name
        {
            get
            {
                string faceVal = (int)face < 11 && (int)face != 1 ? ((int)face).ToString() : face.ToString()[0].ToString();
                return string.Format("{0}{1}", suit.ToString(), faceVal);
            }
        }

        public PlayingCard(CardSuit suit, CardFace face)
        {
            Suit = suit;
            Face = face;
            GetHashCode();
        }

        public PlayingCard Copy()
        {
            return new PlayingCard(this.suit, this.face);
        }

        public override bool Equals(object obj)
        {
            var card = obj as PlayingCard;
            if (obj == null)
                return false;
            if (Face == card.Face && suit == card.Suit)
                return true;
            return false;
        }

        public override int GetHashCode()
        {
            // we need the hash to not change after it is called once
            // so we will check to see if it has ever been set (using _isHashSet)
            if (!_isHashSet)
            {
                _hash = generateHash(Face.ToString());
                _hash = generateHash(Suit.ToString());

                _isHashSet = true;
            }

            return _hash;
        }

        private int generateHash(string value)
        {
            if (!string.IsNullOrEmpty(value))
                return (PRIME * _hash) + value.GetHashCode();
            return _hash;
        }
    }
}
