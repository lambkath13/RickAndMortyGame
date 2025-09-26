namespace RickAndMortyGame;

public abstract class MortyBase
{
    public abstract List<int> ChooseBoxes(int totalBoxes, int hiddenBox, int rickChoice);
    public abstract (double switchProb, double stayProb) CalculateProbabilities(int boxes);
}
