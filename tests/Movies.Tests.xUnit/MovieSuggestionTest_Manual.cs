namespace Movies.Tests.xUnit;

public class MovieSuggestionTest_Manual
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(false, 7.99)]
    [InlineData(true, 8)]
    [InlineData(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = new MovieScoreStub(score);
        var movieSuggestion = new MovieSuggestion(movieScore);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        Assert.Equal(isGood, expected);
    }
}