namespace Movies.Tests;

public class MovieScoreStub : IMovieScore
{
    private readonly double score;

    public MovieScoreStub(double score)
    {
        this.score = score;
    }

    public double Score(string title)
    {
        return score;
    }
}