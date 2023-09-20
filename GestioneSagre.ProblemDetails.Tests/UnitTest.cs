using GestioneSagre.ProblemDetails.Exception;
using Moq;
using NUnit.Framework;

namespace GestioneSagre.ProblemDetails.Tests;

public class Tests
{
    private MockRepository mockRepository;

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

    private NotFoundException CreateNotFoundException()
    {
        return new NotFoundException("Not Found Exception");
    }

    [Test]
    public void Should_Throw_NotFoundException()
    {
        var expectedErrorMessage = "Not Found Exception";
        var ex = Assert.Throws<NotFoundException>(() => throw this.CreateNotFoundException());

        Assert.That(ex.Message, Is.EqualTo(expectedErrorMessage));
    }
}