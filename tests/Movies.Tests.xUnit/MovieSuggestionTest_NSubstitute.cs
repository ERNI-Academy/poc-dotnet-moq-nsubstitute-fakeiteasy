using NSubstitute;

namespace Movies.Tests.xUnit;

public class MovieSuggestionTest_NSubstitute
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(false, 7.99)]
    [InlineData(true, 8)]
    [InlineData(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = Substitute.For<IMovieScore>();
        movieScore.Score(Arg.Any<string>()).Returns(score);
        var movieSuggestion = new MovieSuggestion(movieScore);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        movieScore.Received().Score(title);
        Assert.Equal(isGood, expected);
    }
}