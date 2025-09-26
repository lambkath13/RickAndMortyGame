namespace RickAndMortyGame;

public class Game
{
    private readonly int _boxes;
    private readonly MortyBase _morty;
    private readonly Statistics _stats = new Statistics();

    public Game(int boxes, MortyBase morty)
    {
        _boxes = boxes;
        _morty = morty;
    }
    
    public void Run()
    {
        bool playing = true;
        while (playing)
        {
            Console.WriteLine($"Morty: Hiding the portal gun in one of the {_boxes} boxes...");
            int hiddenBox = RandomFairGenerator.GenerateFairNumber(_boxes);

            Console.WriteLine($"Rick: Choose your box between 0 and {_boxes - 1}:");
            int rickChoice = ReadInt(0, _boxes);

            var remaining = _morty.ChooseBoxes(_boxes, hiddenBox, rickChoice);
            Console.WriteLine($"Morty: I leave these boxes: {string.Join(", ", remaining)}");

            int otherBox = remaining.First(b => b != rickChoice);
            Console.WriteLine($"Rick: You can keep your box ({rickChoice}) or switch to the other box ({otherBox}).");
            Console.WriteLine($"Enter {rickChoice} to stay or {otherBox} to switch:");
            int finalChoice = ReadIntChoice(new[] { rickChoice, otherBox });

            bool switchChoice = finalChoice != rickChoice;

            bool win = finalChoice == hiddenBox;
            if (win)
                Console.WriteLine("Morty: Damn it, you found the portal gun!");
            else
                Console.WriteLine("Morty: Ha! You lost, Rick.");

            _stats.AddResult(win, switchChoice);

            Console.WriteLine("Play another round? (y/n)");
            playing = Console.ReadLine()?.Trim().ToLower() == "y";
        }

        ResultTablePrinter.Print(_stats, _morty.CalculateProbabilities(_boxes));
    }

    private int ReadInt(int min, int max)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int val) && val >= min && val < max)
                return val;
            Console.WriteLine($"Enter a number between {min} and {max - 1}");
        }
    }

    private int ReadIntChoice(int[] validChoices)
    {
        while (true)
        {
            var input = Console.ReadLine();
            if (int.TryParse(input, out int val) && validChoices.Contains(val))
                return val;
            Console.WriteLine($"Enter one of: {string.Join(", ", validChoices)}");
        }
    }
}
