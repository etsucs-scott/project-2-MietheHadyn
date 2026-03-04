using System;
using System.Collections.Generic;
using System.Text;

namespace WarClassLibrary.Models
{
    public class PlayedCards
    {
        // holds a dictionary<string, Card> of Each rounds played cards, used to determine the winner of each round

        Dictionary<string, Card> playedCards = new();
    }
}
