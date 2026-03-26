using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{
    public class PlayedCards 
    {
        // holds a dictionary<string, Card> of Each rounds played cards, used to determine the winner of each round
        //will be added to winner's hand at back of queue
        public Dictionary<Player, Card> playedCards = new Dictionary<Player, Card>();

        //A read only version
        public IReadOnlyDictionary<Player, Card> Played => playedCards;

        public void Add(Player player, Card card)
        {
            ArgumentNullException.ThrowIfNull(player);
            ArgumentNullException.ThrowIfNull(card);
            playedCards[player] = card;



        }

        public void clear()
        {
            playedCards.Clear();
        }
        
    }
}
