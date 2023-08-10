namespace Movies;

public class MovieSuggestion : IMovieSuggestion
{
    private readonly IMovieScore movieScore;

    public MovieSuggestion(IMovieScore movieScore)
    {
        this.movieScore = movieScore;
    }

    public bool IsGoodMovie(string title)
    {
        var score = movieScore.Score(title);
        return score >= 8;
    }
}
