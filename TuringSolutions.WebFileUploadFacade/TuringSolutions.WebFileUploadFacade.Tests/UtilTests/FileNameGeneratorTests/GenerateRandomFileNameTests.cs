using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileNameGeneratorTests;
public class GenerateRandomFileNameTests
{
    [Test]
    [TestCase("myFlileName.jpg", "jpg")]
    [TestCase("with/a/path.png", "png")]
    [TestCase("__sdsad2kLS.webo", "webp")]
    public void GenerateRandomFileName_Generates_Correct_Random_Name(string fileName, string fileExtension)
    {
        var randomFileName = FileNameGenerator.GenerateRandomFileName(fileName, out var id);

        var expectedFileName = $"{id}.{fileExtension}";

        Assert.That(randomFileName, Is.EqualTo(expectedFileName));
    }

    [Test]
    public void GenerateRandomFileName_Does_Not_Generate_The_Same_FileName_Twice()
    {
        var fileName = "myFile.png";

        var randomFileNameOne = FileNameGenerator.GenerateRandomFileName(fileName, out var id1);
        var randomFileNameTwo = FileNameGenerator.GenerateRandomFileName(fileName, out var id2);

        Assert.That(randomFileNameOne, Is.Not.EqualTo(randomFileNameTwo));
        Assert.That(id1, Is.Not.EqualTo(id2));
    }
}
