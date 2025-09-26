using RickAndMortyGame;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            var config = ArgumentParser.Parse(args);
            var morty = MortyLoader.Load(config.MortyName);
            var game = new Game(config.Boxes, morty);
            game.Run();
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}
