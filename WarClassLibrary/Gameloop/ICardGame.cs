using WarClassLibrary.Models;

namespace WarClassLibrary.Gameloop
{

    /// <summary>
    /// Defines the basic lifecycle and shared data for a card game hand.
    /// </summary>
    public interface ICardGame
    {
        /// <summary>
        /// Gets the game name.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets the current deck used by the game.
        /// </summary>
        Deck Deck { get; }

        /// <summary>
        /// Gets the players seated in the game.
        /// </summary>
        Player[] Players { get; }

        /// <summary>
        /// Sets up a new hand.
        /// </summary>
        void StartHand();

        /// <summary>
        /// Executes game-specific hand logic and determines results.
        /// </summary>
        void PlayHand();

        /// <summary>
        /// Finalizes the hand.
        /// </summary>
        void EndHand();
    }

}
