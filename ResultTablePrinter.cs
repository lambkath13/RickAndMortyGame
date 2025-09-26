namespace RickAndMortyGame;
using ConsoleTables;
public static class ResultTablePrinter
{
    public static void Print(Statistics stats, (double switchProb, double stayProb) probs)
    {
        var table = new ConsoleTable("Game results", "Rick switched", "Rick stayed");
        table.AddRow("Rounds", stats.Rounds, stats.Rounds)
            .AddRow("Wins", stats.SwitchWins, stats.StayWins)
            .AddRow("P (estimate)", 
                stats.SwitchWins / (double)(stats.Rounds == 0 ? 1 : stats.Rounds),
                stats.StayWins / (double)(stats.Rounds == 0 ? 1 : stats.Rounds))
            .AddRow("P (exact)", probs.switchProb, probs.stayProb);

        table.Write(Format.Alternative);
    }
}
