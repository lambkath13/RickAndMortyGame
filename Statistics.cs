namespace RickAndMortyGame;

public class Statistics
{
    public int Rounds { get; private set; }
    public int Wins { get; private set; }
    public int Losses => Rounds - Wins;
    public int SwitchWins { get; private set; }
    public int StayWins { get; private set; }

    public void AddResult(bool win, bool switched)
    {
        Rounds++;
        if (win)
        {
            Wins++;
            if (switched) SwitchWins++; else StayWins++;
        }
    }
}
