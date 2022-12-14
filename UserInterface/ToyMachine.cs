namespace UserInterface;

internal class ToyMachine : IToyMachine
{
    public Present Generate()
    {
        var rnd = new Random();
        var prefixIndex = rnd.Next(0, Prefixes.Count - 1);
        var prefix = Prefixes[prefixIndex];
        var suffixIndex = rnd.Next(0, Suffixes.Count);
        var suffix = Suffixes[suffixIndex];
        string name = $"{prefix} {suffix}";
        return new Present(name);
    }

    public static List<string> Prefixes = new List<string>()
    {
        "Barbie",
        "Paw Patrol",
        "Star Wars",
        "Avengers",
        "Action Force",
        "Lego"
    };

    public static List<string> Suffixes = new List<string>()
    {
        "Game",
        "Doll",
        "Cuddly Toy",
        "Set",
        "Construction Toy"
    };
}

