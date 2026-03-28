namespace WarClassLibrary.Models
{
    public class Player 
    {
        /// <summary>
        /// Gets the display name of the player.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the player's current hand.
        /// </summary>
        public Hand Hand { get; }


        private readonly Player[] players;
        /// <summary>
        /// Gets the players seated in this game.
        /// </summary>
        public Player[] Players => players.ToArray();

        /// <summary>
        /// Gets a read-only view of players.
        /// </summary>
        public IReadOnlyList<Player> PlayersView => Array.AsReadOnly(players);

        /// <summary>
        /// Removes a player from the list of players.
        /// </summary>
        public void RemovePlayer(Player player, Player[] players)
        {
            //get the index of the player to remove
            int index = players.IndexOf(player);
            
            players[index] = null;
        }
        /// Creates a player with an empty hand.
        /// </summary>
        /// <param name="name">Player name.</param>
        public Player(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Player name cannot be null, empty, or whitespace.", nameof(name));
            }

            this.Name = name;
            Hand = new Hand();
        }

        public override string ToString()
        {
            return $"{Name} | Hand: {Hand}";
        }

      

        /// <summary>
        /// Creates the human player by prompting for a name.
        /// </summary>
        public static Player CreateHumanPlayer()
        {
            Console.WriteLine("What is the player's name?");
            string? name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                name = "Human";
            }

            Player humanPlayer = new Player(name);
            return humanPlayer;
        }

        /// <summary>
        /// Creates 1-3 computer players based on user input.
        /// Returns an empty array when the input is invalid.
        /// </summary>
        public static Player[] CreateCompPlayer()
        {
            const int minComp = 1;
            const int maxComp = 3;
            Console.WriteLine("How many computers? (between 1 and 3)");
            string? input = Console.ReadLine();
            if (!int.TryParse(input, out int numComp) || numComp < minComp || numComp > maxComp)
            {
                Console.WriteLine("Invalid number of computers. Please enter a number between 1 and 3.");
                return Array.Empty<Player>();
            }

            var comps = new Player[numComp];
            for (int i = 0; i < numComp; i++)
            {
                comps[i] = new Player($"Computer {i + 1}");
            }

            return comps;
        }

    }

}
