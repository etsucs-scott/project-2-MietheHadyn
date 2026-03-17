using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{
    public class Player
    {
        /// <summary>
        /// Gets the display name of the player.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the player's current hand.
        /// </summary>
        public Hand Hand { get; }

        /// <summary>
        /// Creates a player with an empty hand.
        /// </summary>
        /// <param name="name">Player name.</param>
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Player name cannot be null, empty, or whitespace.", nameof(name));
            }

            Name = name;
            Hand = new Hand();
        }

        public override string ToString()
        {
            return $"{Name} | Hand: {Hand}";
        }
    }

}
