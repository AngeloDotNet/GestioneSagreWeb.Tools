using GestioneSagre.ProblemDetails.Exception;
using Moq;
using NUnit.Framework;

namespace GestioneSagre.ProblemDetails.Tests;

public class UnitTest
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
    private static NotModifiedException CreateNotModifiedException() => new NotModifiedException(message: "Not Modified Exception");
    private static NotAcceptableException CreateNotAcceptableException() => new NotAcceptableException("Not Acceptable Exception");
    private static ConflictException CreateConflictException() => new ConflictException("Conflict Exception");
    private static UnprocessableEntityException CreateUnprocessableEntityException() => new UnprocessableEntityException("Unprocessable Entity Exception");

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

    [Test]
    public void Should_Throw_NotModifiedException()
    {
        expectedErrorMessage = "Not Modified Exception";
        var exception = Assert.Throws<NotModifiedException>(() => throw CreateNotModifiedException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    public void Should_Throw_NotAcceptableException()
    {
        expectedErrorMessage = "Not Acceptable Exception";
        var exception = Assert.Throws<NotAcceptableException>(() => throw CreateNotAcceptableException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    public void Should_Throw_ConflictException()
    {
        expectedErrorMessage = "Conflict Exception";
        var exception = Assert.Throws<ConflictException>(() => throw CreateConflictException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }

    [Test]
    public void Should_Throw_UnprocessableEntityException()
    {
        expectedErrorMessage = "Unprocessable Entity Exception";
        var exception = Assert.Throws<UnprocessableEntityException>(() => throw CreateUnprocessableEntityException());

        Assert.That(exception.Message, Is.EqualTo(expectedErrorMessage));
    }
}