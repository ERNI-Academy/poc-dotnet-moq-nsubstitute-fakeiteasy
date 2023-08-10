using FakeItEasy;

namespace Movies.Tests.xUnit;

public class MovieSuggestionTest_FakeItEasy
{
    [Theory]
    [InlineData(false, 0)]
    [InlineData(false, 7.99)]
    [InlineData(true, 8)]
    [InlineData(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = A.Fake<IMovieScore>();
        A.CallTo(() => movieScore.Score(A<string>.Ignored)).Returns(score);
        var movieSuggestion = new MovieSuggestion(movieScore);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        A.CallTo(() => movieScore.Score(title)).MustHaveHappened();
        Assert.Equal(isGood, expected);
    }
}