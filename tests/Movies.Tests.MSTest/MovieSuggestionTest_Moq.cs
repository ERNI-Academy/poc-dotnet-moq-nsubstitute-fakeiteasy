using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace Movies.Tests.MSTest;

[TestClass]
public class MovieSuggestionTest_Moq
{
    [DataTestMethod]
    [DataRow(false, 0)]
    [DataRow(false, 7.99)]
    [DataRow(true, 8)]
    [DataRow(true, 10)]
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
        Assert.AreEqual(isGood, expected);
    }
}