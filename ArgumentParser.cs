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
        if (args.Length == 0 || args.Contains("--help"))
        {
            PrintUsage();
            Environment.Exit(0);
        }

        if (args.Length < 2)
        {
            PrintUsage("Error: Not enough arguments.");
            Environment.Exit(1);
        }

        if (!int.TryParse(args[0], out int boxes) || boxes <= 2)
        {
            PrintUsage("Error: The number of boxes must be an integer greater than 2.");
            Environment.Exit(1);
        }

        string mortyName = args[1];
        if (mortyName != "ClassicMorty" && mortyName != "LazyMorty")
        {
            PrintUsage($"Error: Unknown Morty '{mortyName}'.");
            Environment.Exit(1);
        }

        return new GameConfig { Boxes = boxes, MortyName = mortyName };
    }

    private static void PrintUsage(string? error = null)
    {
        if (!string.IsNullOrEmpty(error))
            Console.WriteLine(error);

        Console.WriteLine(@"
Usage:
  dotnet run <boxes> <MortyClass>

Arguments:
  <boxes>       Number of boxes (> 2)
  <MortyClass>  Type of Morty (ClassicMorty | LazyMorty)

Examples:
  dotnet run 3 ClassicMorty
  dotnet run 4 LazyMorty
");
    }
}

