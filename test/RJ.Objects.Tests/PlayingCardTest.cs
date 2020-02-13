using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RJ.Objects.PokerCards.Test
{
    [TestClass]
    public class PlayingCardTest
    {
        [TestMethod]
        public void HashCodeTest()
        {
            PlayingCard card = new PlayingCard(CardSuit.Clubs, CardFace.Eight);
            PlayingCard otherCard = new PlayingCard(CardSuit.Clubs, CardFace.Eight);

            Assert.AreEqual(card.GetHashCode(), otherCard.GetHashCode());

            otherCard = new PlayingCard(CardSuit.Diamonds, CardFace.Eight);

            Assert.AreNotEqual(card.GetHashCode(), otherCard.GetHashCode());

            card = new PlayingCard(CardSuit.Clubs, CardFace.AceLow);
            otherCard = new PlayingCard(CardSuit.Diamonds, CardFace.Three);

            Assert.AreNotEqual(card.GetHashCode(), otherCard.GetHashCode());
        }

        [TestMethod]
        public void NameTest()
        {
            PlayingCard card = new PlayingCard(CardSuit.Diamonds, CardFace.AceLow);
            string cardNameExpected = "DiamondsA";

            Assert.AreEqual(cardNameExpected, card.Name);

            card = new PlayingCard(CardSuit.Clubs, CardFace.Ten);
            cardNameExpected = "Clubs10";

            Assert.AreEqual(cardNameExpected, card.Name);

            card = new PlayingCard(CardSuit.Spades, CardFace.Jack);
            cardNameExpected = "SpadesJ";

            Assert.AreEqual(cardNameExpected, card.Name);

            card = new PlayingCard(CardSuit.Spades, CardFace.AceHigh);
            cardNameExpected = "SpadesA";

            Assert.AreEqual(cardNameExpected, card.Name);
        }
    }
}
