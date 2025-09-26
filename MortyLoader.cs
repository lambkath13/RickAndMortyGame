namespace RickAndMortyGame;

public static class MortyLoader
{
    public static MortyBase Load(string name)
    {
        return name switch
        {
            "ClassicMorty" => new ClassicMorty(),
            "LazyMorty" => new LazyMorty(),
            _ => throw new ArgumentException($"Morty class '{name}' not found. Available: ClassicMorty, LazyMorty")
        };
    }
}
