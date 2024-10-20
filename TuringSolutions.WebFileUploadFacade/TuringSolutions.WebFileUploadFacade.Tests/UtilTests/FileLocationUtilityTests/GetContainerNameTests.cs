using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileLocationUtilityTests;
public class GetContainerNameTests
{
    [Test]
    [TestCase("container/path/path/image.png", "container", Description = "container path file format")]
    [TestCase("containerWithoutPath/image.png", "containerWithoutPath", Description = "container (no path) file format")]
    public void GetContainerName_With_Valid_FileLocation_Returns_Correct_ContainerName(string fileLocation, string expectedContainerName)
    {
        var containerName = fileLocation.GetContainerName();

        Assert.That(containerName, Is.EqualTo(expectedContainerName));
    }

    [Test]
    [TestCase("https://reserveasetest.blob.core.windows.net/instructionletter/0c20221a-ee0f-4363-b738-228877f90cc8.jpg", "instructionletter")]
    [TestCase("https://turingsolutions.nl/container/path/path/image.png", "container")]
    public void GetContainerName_With_FileLocation_As_Url_Returns_Correct_ContainerName(string fileLocation, string expectedContainerName)
    {
        var containerName = fileLocation.GetContainerName();

        Assert.That(containerName, Is.EqualTo(expectedContainerName));
    }
}
