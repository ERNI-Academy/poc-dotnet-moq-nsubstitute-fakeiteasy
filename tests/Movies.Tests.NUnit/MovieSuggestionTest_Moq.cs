using Moq;

namespace Movies.Tests.NUnit;

public class MovieSuggestionTest_Moq
{

    [TestCase(false, 0)]
    [TestCase(false, 7.99)]
    [TestCase(true, 8)]
    [TestCase(true, 10)]
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
        Assert.That(isGood, Is.EqualTo(expected));
    }
}