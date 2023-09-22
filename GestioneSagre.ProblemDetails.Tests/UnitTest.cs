using GestioneSagre.ProblemDetails.Exception;
using Moq;
using NUnit.Framework;

namespace GestioneSagre.ProblemDetails.Tests;

public class Tests
{
    private MockRepository mockRepository;
    private string expectedErrorMessage = string.Empty;

    [SetUp]
    public void Setup()
    {
        this.mockRepository = new MockRepository(MockBehavior.Strict);
    }

    [TearDown]
    public void TearDown()
    {
        mockRepository.VerifyAll();
    }

    private static NotFoundException CreateNotFoundException() => new NotFoundException(message: "Not Found Exception");

    private static BadRequestException CreateBadRequestException() => new BadRequestException(message: "Bad Request Exception");

    [Test]
    public void Should_Throw_NotFoundException()
    {
        expectedErrorMessage = "Not Found Exception";
        var exception = Assert.Throws<NotFoundException>(() => throw CreateNotFoundException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    public void Should_Throw_BadRequestException()
    {
        expectedErrorMessage = "Bad Request Exception";
        var exception = Assert.Throws<BadRequestException>(() => throw CreateBadRequestException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }
}