//Code credit: much code based from/using https://github.com/etsucs-scott/card-games

//When COMs are made, they'll just have a naming scheme of COM1, COM2, etc.
using WarClassLibrary.Gameloop;

internal static class Program
{
    private static void Main()
    {
        LoopLogic.PlayGame(new WarGame(new Player("Player 1"), new Player("Player 2")));
    }
}


