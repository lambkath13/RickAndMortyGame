namespace RickAndMortyGame;

public class LazyMorty : MortyBase
{
    public override List<int> ChooseBoxes(int totalBoxes, int hiddenBox, int rickChoice)
    {
        var remaining = new List<int> { rickChoice };

        if (rickChoice == hiddenBox)
        {
            int other = (rickChoice + 1) % totalBoxes;
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