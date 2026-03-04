using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{

    /// <summary>
    /// Cards held by one player
    /// </summary>
    public class Hand
    {
        private readonly List<Card> cards = new();
        private readonly IReadOnlyList<Card> readOnlyCards;

        public Hand()
        {
            readOnlyCards = cards.AsReadOnly();
        }

        /// <summary>
        /// Gets a read-only view of cards in this hand.
        /// </summary>
        public IReadOnlyList<Card> Cards => readOnlyCards;

        /// <summary>
        /// Adds one card to the hand.
        /// </summary>
        /// <param name="card">Card to add.</param>
        public void Add(Card card)
        {
            ArgumentNullException.ThrowIfNull(card);
            cards.Add(card);
        }

        /// <summary>
        /// Removes all cards from the hand.
        /// </summary>
        public void Clear()
        {
            cards.Clear();
        }

        public override string ToString()
        {
            return cards.Count == 0 ? "[empty]" : string.Join(", ", cards);
        }
    }
}
