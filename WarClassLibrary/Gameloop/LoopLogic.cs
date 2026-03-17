using System;
using System.Collections.Generic;
using System.Text;
using WarClassLibrary.Models;

namespace WarClassLibrary.Gameloop
{
    public class LoopLogic //this is a draft, mostly to make it exist first, improve and break up later
    {
        public void PlayGame(ICardGame game)
        {
            while (true) //this is a placeholder, we can add a condition to end the game later
            {
                game.StartHand();
                game.PlayHand();
                game.EndHand();
                // Add logic here to determine if the game should continue or end
                // For example, you could check for a winning condition or ask players if they want to play another hand
            }

        } //may or may not need this
    }
}
