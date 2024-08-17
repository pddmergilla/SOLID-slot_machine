public class Randomizer
{
    private readonly System.Random _random = new System.Random();

    public int Generate()
    {
        return _random.Next(1, 10); // Generates numbers from 1 to 9
    }
}
