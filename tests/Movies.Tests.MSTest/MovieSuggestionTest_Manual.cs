using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Movies.Tests.MSTest;

[TestClass]
public class MovieSuggestionTest_Manual
{
    [DataTestMethod]
    [DataRow(false, 0)]
    [DataRow(false, 7.99)]
    [DataRow(true, 8)]
    [DataRow(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = new MovieScoreStub(score);
        var movieSuggestion = new MovieSuggestion(movieScore);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        Assert.AreEqual(isGood, expected);
    }
}