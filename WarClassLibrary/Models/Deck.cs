using System;
using System.Collections.Generic;
using System.Text;
using static WarClassLibrary.Models.Ranks;
using static WarClassLibrary.Models.Suits;

namespace WarClassLibrary.Models
{
    /// <summary>
    /// Standard playing card deck of 52 cards, with 4 suits and 13 ranks
    /// </summary>
    public class Deck
    {
        //holds a stack of cards
        //Code credit: code based off of/using https://github.com/etsucs-scott/card-games/blob/main/CardGames.Core/Models/Deck.cs

        private readonly List<Card> cards = new();
        /// <summary>
        /// counts the cards in the deck
        /// </summary>
        public int Count => cards.Count;

        /// <summary>
        /// Creates a full standard deck
        /// </summary>
        public Deck()
        {

            foreach (Suit suit in Enum.GetValues<Suit>())
            {
                foreach (Rank rank in Enum.GetValues<Rank>())
                {
                    cards.Add(new Card(suit, rank));
                }
            }
        }

        /// <summary>
        /// Shuffles Cards in deck
        /// </summary>
        public void Shuffle()
        {
            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(0, i + 1);
                (cards[i], cards[j]) = (cards[j], cards[i]);
            }
        }


        /// <summary>
        /// Draws card from the deck's top
        /// </summary>
        public Card Draw()
        {             if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }
            Card card = cards[^1];
            cards.RemoveAt(cards.Count - 1);
            return card;

            //distribute all cards to players after shuffling in gameplay loop
        }


    }
}
