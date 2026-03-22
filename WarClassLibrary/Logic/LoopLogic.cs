using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
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
            Player defail = new Player("default"); //default winner player if something goes wrong
            List<Player> players = new List<Player>();
            Player human = Player.CreateHumanPlayer();
            List<Player> bots = Player.CreateCompPlayer().ToList();
            players.Add(human);
            players.AddRange(bots);
            Deck deck = new Deck();
            deck.Shuffle();
            int RountCnt = 0;


            
            WarGame War = new WarGame("War", players);


            while (deck.Count > 0)
            {


                foreach (var player in players)
                {
                    Player gettingCard = player;
                    War.DealTo(gettingCard, 1);
                    Console.WriteLine($"card dealt to {gettingCard.Name}");
                }  
            }

            Player winner = defail;

            while (RountCnt is < 10000 || players.Count > 1)
            {
                War.StartHand();
                War.PlayHand();
                War.EndHand(winner);

                RountCnt++;
            }

            if (RountCnt == 10000)
            {
                //winner is the player with the most cards
                winner = players.OrderByDescending(p => p.Hand.Cards.Count).FirstOrDefault();
                Console.WriteLine($"Game end due to maximum round limit, winner: {winner}");
            }
            else if (players.Count == 1)
            {
                Console.WriteLine($"One player remains! winner is {players}");
            }
        }

        public static void DealTest() //temp test method to test dealing cards to player, delet later?
        {
            List<Player> players = new List<Player>();
            Player human = Player.CreateHumanPlayer();
            players.Add(human);
            Deck deck = new Deck();
            deck.Shuffle();
            WarGame War = new WarGame("War", players);

            War.DealTo(human, 1);
            Console.WriteLine(human.Hand);
        }
    }
}
