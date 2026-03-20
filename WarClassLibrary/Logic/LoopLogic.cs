using System;
using System.Collections.Generic;
using System.Text;
using WarClassLibrary.Models;

namespace WarClassLibrary.Gameloop
{
    public class LoopLogic
    {
        /// <summary>
        /// the more abstract loop of the gameplay
        /// </summary>
        public static void PlayGame()
        {
            //Create a default game with one human and one computer player.
            var human = new Player("Human");
            var computer = new Player("Computer 1");

            ICardGame game = new WarGame("War", new Player[] { human, computer });
            game.Deck.Shuffle();

            game.StartHand();
            game.PlayHand();

            //default, give the played cards to first player.
            Player winner = game.Players.Length > 0 ? game.Players[0] : null;
            if (winner != null)
            {
                game.EndHand(winner);
            }
        }
    }
}
