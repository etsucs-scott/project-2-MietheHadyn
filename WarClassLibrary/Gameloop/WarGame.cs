//Code credit: much code based from/using https://github.com/etsucs-scott/card-games

using WarClassLibrary.Gameloop;
using WarClassLibrary.Models;

internal class WarGame : ICardGame
{
    private readonly Player[] players;

    /// <summary>
    /// Gets the game name.
    /// </summary>
    string ICardGame.Name => "War";
    public string Name = "War";

    /// <summary>
    /// Gets the current deck.
    /// </summary>
    public Deck Deck { get; protected set; }

    /// <summary>
    /// Gets the players seated in this game.
    /// </summary>
    public Player[] Players => players.ToArray();

    /// <summary>
    /// Gets a read-only view of players.
    /// </summary>
    public IReadOnlyList<Player> PlayersView => Array.AsReadOnly(players);

    

    /// <summary>
    /// Creates a base game with a name and players.
    /// </summary>
    protected WarGame(string name, Player[] players)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Game name cannot be null, empty, or whitespace.", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(players);

        if (players.Length == 0)
        {
            throw new ArgumentException("At least one player is required.", nameof(players));
        }

        if (players.Any(player => player is null))
        {
            throw new ArgumentException("Players cannot contain null entries.", nameof(players));
        }

        Name = name;
        this.players = players.ToArray();
        Deck = new Deck();
    }
    /// <summary>
    /// Clears every player's hand.
    /// </summary>
    protected void ResetHands()
    {
        foreach (Player player in players)
        {
            player.Hand.Clear();
        }
    }

    /// <summary>
    /// Deals a specific number of cards to one player.
    /// </summary>
    protected void DealTo(Player player, int numberOfCards)
    {
        ArgumentNullException.ThrowIfNull(player);

        if (numberOfCards <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfCards), "Cards dealt must be greater than zero.");
        }

        EnsureDeckHasCards(numberOfCards);

        for (int i = 0; i < numberOfCards; i++)
        {
            player.Hand.Add(Deck.Draw());
        }
    }

    /// <summary>
    /// Ensures the deck has enough cards for an operation.
    /// </summary>
    protected void EnsureDeckHasCards(int neededCards)
    {
        if (neededCards <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(neededCards), "Needed cards must be greater than zero.");
        }

        if (Deck.Count < neededCards)
        {
            throw new InvalidOperationException(
                $"Deck does not contain enough cards. Needed {neededCards}, available {Deck.Count}.");
        }
    }

    /// <summary>
    /// Recreates and shuffles the deck for a new hand.
    /// </summary>
    protected void CreateAndShuffleDeck()
    {
        Deck = new Deck();
        Deck.Shuffle();
    }

    /// <summary>
    /// Validates that the given player belongs to this game table.
    /// </summary>
    protected void EnsurePlayerInGame(Player player)
    {
        ArgumentNullException.ThrowIfNull(player);

        if (!players.Contains(player))
        {
            throw new InvalidOperationException($"Player is not part of this {Name} table.");
        }
    }

    /// <summary>
    /// Begins a new hand in the game, initializing the state for subsequent gameplay actions.
    /// </summary>
    public void StartHand()
    {
        //place a card, dequeued from the top
    }
    /// <summary>
    /// Plays a single hand in the current game session.
    /// </summary>
    public void PlayHand()
    {

    }
    /// <summary>
    /// Ends the current hand and performs any necessary cleanup or state updates.
    /// </summary>
    public void EndHand()
    {

    }
}