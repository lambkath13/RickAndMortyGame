using System.Security.Cryptography;

namespace RickAndMortyGame;

public class ClassicMorty : MortyBase
{
    public override List<int> ChooseBoxes(int totalBoxes, int hiddenBox, int rickChoice)
    {
        var remaining = new List<int> { rickChoice };

        if (rickChoice == hiddenBox)
        {
            var other = Enumerable.Range(0, totalBoxes)
                .Where(i => i != rickChoice)
                .OrderBy(_ => RandomNumberGenerator.GetInt32(int.MaxValue))
                .First();

            remaining.Add(other);
        }
        else
        {
            remaining.Add(hiddenBox);
        }

        return remaining;
    }

    public override (double switchProb, double stayProb) CalculateProbabilities(int totalBoxes)
    {
        double stay = 1.0 / totalBoxes;
        double sw = (totalBoxes - 1.0) / totalBoxes;
        return (sw, stay);
    }
}