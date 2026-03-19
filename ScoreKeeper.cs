public class ScoreKeeper
{
    public int totalScore { get; private set; }

    public ScoreKeeper()
    {
        totalScore = 0;
    }

    public void AddPoints(int amount){
        totalScore += amount;
    }
}