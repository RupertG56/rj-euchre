using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RJ.Objects.Common;

namespace RJ.Objects.PokerCards.Test
{
    [TestClass]
    public class DeckTest
    {
        [TestMethod]
        public void DeckCtor1Test()
        {
            // no params constructor
            Deck deck = new Deck();

            PlayingCard aceLow = deck.Cards.Find(t => t.Face == CardFace.AceLow);

            Assert.IsTrue(deck.Cards.Count == 52);
            Assert.IsNotNull(aceLow);
        }

        [TestMethod]
        public void DeckCtor2Test()
        {
            // with param
            Deck deck = new Deck(true);

            PlayingCard aceHigh = deck.Cards.Find(t => t.Face == CardFace.AceHigh);
            PlayingCard aceLow = deck.Cards.Find(t => t.Face == CardFace.AceLow);

            Assert.IsTrue(deck.Cards.Count == 52);
            Assert.IsNotNull(aceHigh);
            Assert.IsNull(aceLow);
        }

        [TestMethod]
        public void EuchreDeckCtorTest()
        {
            EuchreDeck deck = new EuchreDeck();

            Assert.IsTrue(deck.Cards.Count == 24);
        }

        [TestMethod]
        public void ShuffledDeckTest()
        {
            Deck deck = new Deck(true);
            deck.Shuffle();

            PlayingCard notShuffled = deck.Cards.First();
            PlayingCard shuffled = deck.ShuffledDeck.First();

            Assert.AreNotEqual(notShuffled, shuffled);
        }

        [TestMethod]
        public void YatesShuffleTest()
        {
            Deck deck = new Deck(true);
            deck.YatesShuffle();

            PlayingCard notShuffled = deck.Cards.First();
            PlayingCard shuffled = deck.ShuffledDeck.First();

            Assert.AreNotEqual(notShuffled, shuffled);
        }

        [TestMethod]
        public void InsertHighIndexWithEmptyFillTest()
        {
            List<string> testList = new List<string>(52);
            testList.EmptyFill(52);

            testList.Insert(20, "test");

            Assert.IsNotNull(testList[20]);
        }
    }
}
