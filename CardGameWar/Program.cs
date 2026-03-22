//Code credit: much code based from/using https://github.com/etsucs-scott/card-games
//Coding/debugging assistance provided by GitHup Copilot throughout development on most processes.

//When COMs are made, they'll just have a naming scheme of COM1, COM2, etc.
using WarClassLibrary.Gameloop;
using WarClassLibrary.Models;

internal class Program
{
    private static void Main()
    {
        LoopLogic.PlayGame(); 

        


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






