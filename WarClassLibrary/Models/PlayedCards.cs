using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{
    public class PlayedCards
    {
        // holds a dictionary<string, Card> of Each rounds played cards, used to determine the winner of each round
        //will be added to winners hands at back of queue
        public Dictionary<string, Card> playedCards = new Dictionary<string, Card>();

        //A read only version
        public IReadOnlyDictionary<string, Card> Played => playedCards;

        public void Add(string playerName, Card card)
        {
            ArgumentNullException.ThrowIfNull(playerName);
            ArgumentNullException.ThrowIfNull(card);
            playedCards[playerName] = card;
            

        }

    }
}
