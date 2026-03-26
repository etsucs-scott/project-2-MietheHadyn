using System.Collections;

namespace WarClassLibrary.Models
{

    /// <summary>
    /// Cards held by one player
    /// </summary>
    public class Hand : IEnumerable
    {
        private readonly Queue<Card> cards = new();
        private readonly IReadOnlyCollection<Card> readOnlyCards;

        public Hand()
        {
            readOnlyCards = cards;
        }

        /// <summary>
        /// Gets a read-only view of cards in this hand.
        /// </summary>
        public IReadOnlyCollection<Card> Cards => readOnlyCards;

        ///<summary>
        ///Adds one card to the hand.
        ///</summary>
        public void Add(Card card)
        {
            ArgumentNullException.ThrowIfNull(card);
            cards.Enqueue(card);
        }

        ///<summary>
        ///Attempts to remove and return the card at the front of the hand.
        ///</summary>
        public bool TryPull(out Card card)
        {
            return cards.TryDequeue(out card);
        }

        ///<summary>
        ///Count number of cards in the hand.
        ///</summary>
        public int Count => cards.Count;

        ///<summary>
        ///Removes all cards from the hand.
        ///</summary>
        public void Clear()
        {
            cards.Clear();
        }

        public override string ToString()
        {
            return cards.Count == 0 ? "[empty]" : string.Join(", ", cards);
        }


        

        public IEnumerator GetEnumerator()
        {
            return cards.GetEnumerator();

        }
    }
}
