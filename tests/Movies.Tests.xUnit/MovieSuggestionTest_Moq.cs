using Moq;

namespace Movies.Tests.xUnit;

public class MovieSuggestionTest_Moq
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(false, 7.99)]
    [InlineData(true, 8)]
    [InlineData(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = new Mock<IMovieScore>();
        movieScore.Setup(ms => ms.Score(It.IsAny<string>())).Returns(score);
        var movieSuggestion = new MovieSuggestion(movieScore.Object);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        movieScore.Verify(ms => ms.Score(title));
        Assert.Equal(isGood, expected);
    }
}