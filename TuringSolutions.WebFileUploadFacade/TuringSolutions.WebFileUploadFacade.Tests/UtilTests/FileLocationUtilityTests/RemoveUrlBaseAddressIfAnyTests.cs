using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileLocationUtilityTests;
public class RemoveUrlBaseAddressIfAnyTests
{
    [Test]
    [TestCase("https://turingsolutions.nl/container/path", "container/path")]
    [TestCase("http://turingsolutions.nl/something", "something")]
    [TestCase("https://turingsolutions.nl/", "")]
    [TestCase("http://turingsolutions.nl/container/path/a/long/image.png", "container/path/a/long/image.png")]
    public void RemoveUrlBaseAddressIfAny_Returns_Input_Without_BaseAddress(string input, string inputWithoutBaseAddress)
    {
        var output = input.RemoveUrlBaseAddressIfAny();

        Assert.That(output, Is.EqualTo(inputWithoutBaseAddress));
    }

    [Test]
    [TestCase("container/")]
    [TestCase("Just a random input")]
    [TestCase("my-cool@image/i.webp")]
    [TestCase("container/path/image.png")]
    public void RemoveUrlBaseAddressIfAny_Without_BaseAddress_Does_Not_Alter_The_Input(string input)
    {
        var output = input.RemoveUrlBaseAddressIfAny();
        
        Assert.That(output, Is.EqualTo(input));
    }
}
