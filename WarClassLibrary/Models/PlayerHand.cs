using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{
    public class PlayerHand 
    {
        //holds a Dictionary<string, Hand> keyed by player name
        private readonly Dictionary<string, Hand> playerHands = new Dictionary<string, Hand>();

        ///<summary>
        ///Creates an empty PlayerHand mapping.
        ///</summary>
        public PlayerHand()
        {

        }

        ///<summary>
        ///Creates a PlayerHand mapping from the provided players (keyed by player name).
        ///</summary>
        public PlayerHand(IEnumerable<Player> players)
        {
            ArgumentNullException.ThrowIfNull(players);

            foreach (var p in players)
            {
                if (p is null) continue;
                playerHands[p.Name] = p.Hand;
            }
        }


        /// <summary>
        /// Read-only view of the mapping from player name to their Hand.
        /// </summary>
        public IReadOnlyDictionary<string, Hand> Hands => playerHands;

        ///<summary>
        ///Try get a player's Hand by name.
        ///</summary>
        public bool TryGetHand(string playerName, out Hand hand) => playerHands.TryGetValue(playerName, out hand);

        ///<summary>
        ///Add or replace a player's hand in the mapping.
        ///</summary>
        public void AddOrUpdate(string playerName, Hand hand)
        {
            ArgumentNullException.ThrowIfNull(playerName);
            ArgumentNullException.ThrowIfNull(hand);
            playerHands[playerName] = hand;
        }

    }
}
