//Code credit: much code based from/using https://github.com/etsucs-scott/card-games

using WarClassLibrary;
using WarClassLibrary.Gameloop;
using WarClassLibrary.Models;

public class WarGame : ICardGame
{


    private readonly PlayedCards playedCards = new PlayedCards();
    private readonly PlayerHand playerHandMap;
    private readonly Player[] players;

    /// <summary>
    /// Gets the game name.
    /// </summary>
    public string Name { get; set; }
    public List<Player> Players1 { get; }

    /// <summary>
    /// Gets the current deck.
    /// </summary>
    public Deck Deck { get; protected set; }

    /// <summary>
    /// Gets the players seated in the game.
    /// </summary>
    public Player[] Players => players;

    /// <summary>
    /// Read-only view of players.
    /// </summary>
    public IReadOnlyList<Player> PlayersView => Array.AsReadOnly(players);






    /// <summary>
    /// Creates a base game with a name and players.
    /// </summary>
    public WarGame(string name, List<Player> players)
    {
        bool isEmpty = !players.Any();

        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Game name cannot be null, empty, or whitespace.", nameof(name));
        }

        ArgumentNullException.ThrowIfNull(players);

        if (isEmpty)
        {
            throw new ArgumentException("At least one player is required.", nameof(players));
        }

        if (players.Any(player => player is null))
        {
            throw new ArgumentException("Players cannot contain null entries.", nameof(players));
        }

        Name = name;
        Players1 = players;
        this.players = players.ToArray();
        Deck = new Deck();
        playerHandMap = new PlayerHand(this.players);
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
    public void DealTo(Player gettingCard, int numberOfCards)
    {
        ArgumentNullException.ThrowIfNull(gettingCard);

        numberOfCards = 1;

        if (numberOfCards <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(numberOfCards), "Cards dealt must be greater than zero.");
        }


        bool deckHasCards = EnsureDeckHasCards(numberOfCards);
        try
        {
            gettingCard.Hand.Add(Deck.Draw());
            if (!deckHasCards)
            {
                throw new InvalidOperationException($"Cannot deal {numberOfCards} cards to {gettingCard.Name}. Deck does not contain enough cards.");
            }
            
        }
        catch (InvalidOperationException)
        {
            Console.WriteLine("Deck is now empty");
            return;
            
        }



    }

    /// <summary>
    /// Ensures the deck has enough cards for an operation.
    /// </summary>
    public bool EnsureDeckHasCards(int neededCards)
    {
        if (neededCards <= 0)
        {
            return true;
            throw new ArgumentOutOfRangeException(nameof(neededCards), "Needed cards must be greater than zero.");
        }

        if (Deck.Count < neededCards)
        {
            return false;
            throw new InvalidOperationException(
                $"Deck does not contain enough cards. Needed {neededCards}, available {Deck.Count}.");
        }
        else
        {
            return true;
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
        //check for empty hand
        foreach (var player in players)
        {

            if (player.Hand.Count == 0)
            {
                throw new InvalidOperationException($"Player {player.Name} has no cards left to play.");
                players.ToList().Remove(player);
            }
            else
            {
                Console.WriteLine($"Player {player.Name} has {player.Hand.Count} cards left.");
            }
        }

        //place a card, dequeued from the top
        //for each player: dequeue from player.Hand, add to played cards dictionary, with key as player name and value as card
        foreach (var player in players)
        {
            if (player == null) continue;
            if (player.Hand.TryPull(out Card card))
            {
                playedCards.Add(player.Name, card);
                Console.WriteLine(player.Name, card.ToString());
            }
        }

    }
    /// <summary>
    /// Plays a single hand in the current game session.
    /// </summary>
    public Player PlayHand()
    {
        var winner = PlayersView.First(p => p.Name == playedCards.Played.OrderByDescending(kv => kv.Value.Rank).First().Key);
        bool hasDuplicates = playedCards.playedCards.Count != playedCards.playedCards.Distinct().Count();

        if (hasDuplicates)
        {
            Console.WriteLine("There's a tie! place more cards");
            StartHand();
            PlayHand();
        }

        return winner;

    }
    /// <summary>
    /// Ends the current hand and adds played cards into winner's hand.
    /// </summary>
    public void EndHand(Player winner)
    {
        Console.WriteLine($"Round winner: {winner} recives all played cards");
        foreach (var kv in playedCards.Played)
        {
            Card card = kv.Value;
            winner.Hand.Add(card);
        }
    }
}