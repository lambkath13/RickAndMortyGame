namespace RickAndMortyGame;

public class GameConfig
{
    public int Boxes { get; set; }
    public required string MortyName { get; set; }
}

public static class ArgumentParser
{
    public static GameConfig Parse(string[] args)
    {
        if (args.Length < 2)
            throw new ArgumentException("Invalid arguments. Usage: dotnet run <boxes> <MortyClass>. Example: dotnet run 3 ClassicMorty");

        if (!int.TryParse(args[0], out int boxes) || boxes <= 2)
            throw new ArgumentException("The number of boxes must be an integer greater than 2.");

        string mortyName = args[1];
        return new GameConfig { Boxes = boxes, MortyName = mortyName };
    }
}
