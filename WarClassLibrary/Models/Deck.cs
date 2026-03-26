using System;
using System.Collections.Generic;
using System.Text;
using static WarClassLibrary.Models.Ranks;
using static WarClassLibrary.Models.Suits;

namespace WarClassLibrary.Models
{
    /// <summary>
    /// Standard playing card deck of 52 cards, with 4 suits and 13 ranks
    /// </summary>
    public class Deck
    {
        //holds a stack of cards
        //Code credit: code based off of/using https://github.com/etsucs-scott/card-games/blob/main/CardGames.Core/Models/Deck.cs

        private readonly Stack<Card> cards = new();
        /// <summary>
        /// counts the cards in the deck
        /// </summary>
        public int Count => cards.Count;

        /// <summary>
        /// Creates a full standard deck
        /// </summary>
        public Deck()
        {

            //Build into temporary list in consistent order, then push into stack
            var temp = new List<Card>();
            foreach (Suit suit in Enum.GetValues<Suit>())
            {
                foreach (Rank rank in Enum.GetValues<Rank>())
                {
                    temp.Add(new Card(suit, rank));
                }
            }

            //Push in order so that the last element of temp becomes the top of the stack
            for (int i = 0; i < temp.Count; i++)
            {
                cards.Push(temp[i]);
            }
        }

        /// <summary>
        /// Shuffles Cards in deck
        /// </summary>
        public void Shuffle()
        {
            //Convert to list, shuffle, then rebuild stack so top corresponds to list's last element
            var list = new List<Card>(cards);

            for (int i = list.Count - 1; i > 0; i--)
            {
                int j = Random.Shared.Next(0, i + 1);
                (list[i], list[j]) = (list[j], list[i]);
            }

            cards.Clear();
            for (int i = 0; i < list.Count; i++)
            {
                cards.Push(list[i]);
            }
        }

        



        /// <summary>
        /// Draws card from the deck's top
        /// </summary>
        public  Card Draw()
        {
            if (cards.Count == 0)
            {
                throw new InvalidOperationException("Deck is empty");
            }

            return cards.Pop();
        }


    }
}
