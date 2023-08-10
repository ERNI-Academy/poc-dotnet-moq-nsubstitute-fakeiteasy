# About POC Moq vs NSubstitute vs FakeItEasy

ERNI PoC to show the differences between Moq vs NSubstitute vs FakeItEasy mocking frameworks.

<!-- ALL-CONTRIBUTORS-BADGE:START - Do not remove or modify this section -->
<!-- ALL-CONTRIBUTORS-BADGE:END -->

## Built With

This section should list any major frameworks that you built your project using. Leave any add-ons/plugins for the acknowledgements section. Here are a few examples.

- [Dotnet](https://dotnet.microsoft.com/)
- [MSTest](https://learn.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)
- [NUnit](https://nunit.org/)
- [xUnit](https://xunit.net/)
- [FakeItEasy](https://fakeiteasy.github.io/)
- [Moq](https://moq.github.io/moq/)
- [NSubstitute](https://nsubstitute.github.io/)

## Getting Started

### Mocking frameworks

Mocking frameworks were born to avoid creating homemade stubs like in the previous example. They have a lot of options for both setting up complex call trees as well as verify that methods and properties on dependencies were in fact called.

There are a lot of options available for .NET developers like us. There seem to be three good options: Moq, NSubstitute, and FakeItEasy. I have used all of them over the years and experienced some of the goods and bads of each framework. In the rest of this post is split into a section per framework were I'll show you how to implement the test above with each mocking framework.

#### Moq
When Moq came out, I was pretty quick to jump aboard. While RhinoMocks was a nice framework, Moq just seemed simpler and had a simpler syntax. In fact, Moq is used to test most of the code on elmah.io. Let's dig in.

Moq has, as the only one of the three, a dedicated Mock class to represent a mock. You use generics to specify the type to mock:
```csharp
var movieScore = new Mock<IMovieScore>();
```

The Mock class has methods for setting up expectations:
```csharp
movieScore.Setup(ms => ms.Score(It.IsAny<string>())).Returns(score);
```

The Setup and Returns methods are used to set up any method calls on the mocks and what they should return. Be aware that a Setup is not a requirement for the specified method to be called, simply a hint.

The set up verification of a method being called with a specific parameter, use the Verify method:
```csharp
movieScore.Verify(ms => ms.Score(title));
```
Advantages

- Widely adopted
- Explicit mocks (if you prefer that)


Disadvantages

- .Object syntax (if you prefer a solution without a dedicated Mock class)
- Setup and verification uses lambdas which makes the code more complex to read
- Issues like this: https://www.reddit.com/r/dotnet/comments/15ljdcc/does_moq_in_its_latest_version_extract_and_send/

#### NSubstitute
NSubstute has been around as long as Moq. I have looked at it a couple of times over the years. To be honest, I don't remember exactly why I didn't saw the benefits until now. Maybe the API changed a lot over the years. After rediscovering NSubstitute, we have used it a lot on elmah.io. Let's take a look at some code.

NSubstitute doesn't have a dedicated class to represent a mock like Moq. In that way, it feels a bit more like RhinoMocks which had a static class to generate mocks. In NSubstitute you use the Substitute class to generate mock objects:
```csharp
var movieScore = Substitute.For<IMovieScore>();
```

Since For returns an implementation of the IMovieScore interface, setting up method calls and their return values simply require you to call the methods directly on the mocked implementation:
```csharp
movieScore.Score(Arg.Any<string>()).Returns(score);
```

The Arg.Any method works exactly the same way as It.IsAny method in Moq, but the line is definitely more condensed and readable. NSubstitute does this (as the only of the three) by adding some clever extension methods on the mocked object.

To verify that a method was called on the mock, you use a similar syntax but with an included Received in front of the method you expect to be called:
```csharp
movieScore.Received().Score(title);
```

Advantages

- The most simple syntax of the three
- Good documentation


Disadvantages

- Static state can cause problems with multiple tests (I've only read about this)

#### FakeItEasy
FakeItEasy is yet another mocking framework for .NET. It was released at around the same time as the other two frameworks but never got the same traction as Moq and NSubstitute. It still has some interesting concepts and I know people that prefer it over the two others. The API is sort of a hybrid between the two other frameworks. The more choices the better. Let's look at some code.

Creating mocks is dine pretty much like NSubstibute using a static factory:
```csharp
var movieScore = A.Fake<IMovieScore>();
```

The Fake method generates the mock object as a direct implementation of the interface (or class). Setting up method invocations and return objects look similar to how it is done with Moq:
```csharp
A.CallTo(() => movieScore.Score(A<string>.Ignored)).Returns(score);
```

The CallTo method accept a lambda with the call to the expected method and the Returns method work as in the other two frameworks. Setting up a method was called verification looks very similar:
```csharp
A.CallTo(() => movieScore.Score(title)).MustHaveHappened();
```

Advantages

- A mock is the real object and doesn't require .Object
- Consistent setup and verification
 
Disadvantages

- Not the same traction as the other two frameworks


## Installation

Installation instructions {{ Name }} by running:

1. Clone the repo

   ```sh
   git clone https://github.com/ERNI-Academy/Project-Name.git
   ```

2. Install packages

    ```sh
    Nuget restore
    ```

3. build

    ```sh
    dotnet build
    ```

4. test

    ```sh
    dotnet test
    ```
    

## Contributing

Please see our [Contribution Guide](CONTRIBUTING.md) to learn how to contribute.

## License

![MIT](https://img.shields.io/badge/License-MIT-blue.svg)

(LICENSE) © 2023 [ERNI - Swiss Software Engineering](https://www.betterask.erni)

## Code of conduct

Please see our [Code of Conduct](CODE_OF_CONDUCT.md)

## Stats

![https://repobeats.axiom.co/api/embed/8a8bd5ddbea48b726436c429bfdb0e06100a67df.svg](https://repobeats.axiom.co/api/embed/8a8bd5ddbea48b726436c429bfdb0e06100a67df.svg)

## Follow us

[![Twitter Follow](https://img.shields.io/twitter/follow/ERNI?style=social)](https://www.twitter.com/ERNI)
[![Twitch Status](https://img.shields.io/twitch/status/erni_academy?label=Twitch%20Erni%20Academy&style=social)](https://www.twitch.tv/erni_academy)
[![YouTube Channel Views](https://img.shields.io/youtube/channel/views/UCkdDcxjml85-Ydn7Dc577WQ?label=Youtube%20Erni%20Academy&style=social)](https://www.youtube.com/channel/UCkdDcxjml85-Ydn7Dc577WQ)
[![Linkedin](https://img.shields.io/badge/linkedin-31k-green?style=social&logo=Linkedin)](https://www.linkedin.com/company/erni)

## Contact

📧 [esp-services@betterask.erni](mailto:esp-services@betterask.erni)

## Contributors ✨

Thanks goes to these wonderful people ([emoji key](https://allcontributors.org/docs/en/emoji-key)):

<!-- ALL-CONTRIBUTORS-LIST:START - Do not remove or modify this section -->
<!-- ALL-CONTRIBUTORS-LIST:END -->
This project follows the [all-contributors](https://github.com/all-contributors/all-contributors) specification. Contributions of any kind welcome!
