using NSubstitute;

namespace Movies.Tests.MSTest;

[TestClass]
public class MovieSuggestionTest_NSubstitute
{
    [DataTestMethod]
    [DataRow(false, 0)]
    [DataRow(false, 7.99)]
    [DataRow(true, 8)]
    [DataRow(true, 10)]
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
        Assert.AreEqual(isGood, expected);
    }
}