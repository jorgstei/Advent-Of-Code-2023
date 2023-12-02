namespace Day_2;

public class Game
{
    public int Id { get; }
    public Round[] rounds { get; }

    public Game(string gameInfo)
    {
        var split = gameInfo.Split(':');
        Id = Int32.Parse(split[0].Split(' ')[1]);
        var roundStrings = split[1].Split(';');
        rounds = new Round[roundStrings.Length];
        for (int i = 0; i < rounds.Length; i++)
        {
            rounds[i] = new Round(roundStrings[i]);
        }
    }
}