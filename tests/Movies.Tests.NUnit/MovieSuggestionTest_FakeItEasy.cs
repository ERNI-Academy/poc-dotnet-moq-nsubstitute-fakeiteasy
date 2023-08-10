using FakeItEasy;

namespace Movies.Tests.NUnit;

public class MovieSuggestionTest_FakeItEasy
{

    [TestCase(false, 0)]
    [TestCase(false, 7.99)]
    [TestCase(true, 8)]
    [TestCase(true, 10)]
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
        Assert.That(isGood, Is.EqualTo(expected));
    }
}