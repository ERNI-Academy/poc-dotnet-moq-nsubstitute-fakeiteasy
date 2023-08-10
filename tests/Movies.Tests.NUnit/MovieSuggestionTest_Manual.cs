namespace Movies.Tests.NUnit;

public class MovieSuggestionTest_Manual
{

    [TestCase(false, 0)]
    [TestCase(false, 7.99)]
    [TestCase(true, 8)]
    [TestCase(true, 10)]
    public void CanSuggest(bool expected, double score)
    {
        // Arrange
        var movieScore = new MovieScoreStub(score);
        var movieSuggestion = new MovieSuggestion(movieScore);
        var title = Guid.NewGuid().ToString();

        // Act
        var isGood = movieSuggestion.IsGoodMovie(title);

        // Assert
        Assert.That(isGood, Is.EqualTo(expected));
    }
}