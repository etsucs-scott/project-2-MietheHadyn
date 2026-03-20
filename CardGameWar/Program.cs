//Code credit: much code based from/using https://github.com/etsucs-scott/card-games

//When COMs are made, they'll just have a naming scheme of COM1, COM2, etc.
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using WarClassLibrary.Gameloop;
using WarClassLibrary.Models;

internal class Program
{
    private static void Main()
    {
        //Create human, create bots, then create instance of the game
        Player human = Player.CreateHumanPlayer();
        Player[] computers = Player.CreateCompPlayer();

        //Build the player list: human + computers
        var playerList = new List<Player> { human };
        playerList.AddRange(computers);
        foreach (var player in playerList) 
        {
            WarGame.DealTo(player, 1);
        }


        LoopLogic.PlayGame();

    }



}


