using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileLocationUtilityTests;
public class GetPathTests
{
    [Test]
    [TestCase("container/path/path/image.png", "path/path/image.png", Description = "container path file format")]
    [TestCase("containerWithoutPath/image.png", "image.png", Description = "container (no path) file format")]
    public void GetContainerName_With_Valid_FileLocation_Returns_Correct_ContainerName(string fileLocation, string expectedContainerName)
    {
        var containerName = fileLocation.GetPath();

        Assert.That(containerName, Is.EqualTo(expectedContainerName));
    }

    [Test]
    [TestCase("https://reserveasetest.blob.core.windows.net/instructionletter/0c20221a-ee0f-4363-b738-228877f90cc8.jpg", "0c20221a-ee0f-4363-b738-228877f90cc8.jpg")]
    [TestCase("https://turingsolutions.nl/container/path/path/image.png", "path/path/image.png")]
    public void GetContainerName_With_FileLocation_As_Url_Returns_Correct_ContainerName(string fileLocation, string expectedContainerName)
    {
        var containerName = fileLocation.GetPath();

        Assert.That(containerName, Is.EqualTo(expectedContainerName));
    }
}
