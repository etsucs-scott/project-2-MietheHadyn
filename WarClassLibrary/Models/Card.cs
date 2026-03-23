using WarClassLibrary.Models;
using static WarClassLibrary.Models.Ranks;
using static WarClassLibrary.Models.Suits;

namespace WarClassLibrary
{
    /// <summary>
    /// card, with a suit and rank
    /// </summary>
    public class Card 
    {

        /// <summary>
        /// gets the suit of the card
        /// </summary>
        public Suits.Suit Suit { get; }

        /// <summary>
        /// gets the rank of the card
        /// </summary>
        public Ranks.Rank Rank { get; }

        public Card(Suit suit, Rank rank)
        {
            Suit = suit;
            Rank = rank;
        }

        public override string ToString()
        {
            return $"{Rank} of {Suit}";
        }

        /// <summary>
        /// Compares the current instance with another PlayedCards object and returns an integer that indicates whether
        /// the current instance precedes, follows, or occurs in the same position in the sort order as the other
        /// object.
        /// </summary>
        
    }
}
