using System;
using System.Collections.Generic;
using System.Text;
using static WarClassLibrary.Ranks;
using static WarClassLibrary.Suits;

namespace WarClassLibrary
{
    /// <summary>
    /// Standard playing card deck of 52 cards, with 4 suits and 13 ranks
    /// </summary>
    internal class Deck
    {
        //holds a stack of cards
        //Code credit: code based off of/using https://github.com/etsucs-scott/card-games/blob/main/CardGames.Core/Models/Deck.cs

        private readonly List<Card> cards = new();
        /// <summary>
        /// Creates a new full standard deck.
        /// </summary>
         
        public int Count => cards.Count;
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
    }
}
