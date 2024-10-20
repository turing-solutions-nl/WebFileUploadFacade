using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileNameUtilityTests;
public class GetFileNameFromPathTests
{
    [Test]
    [TestCase("myfile.png")]
    [TestCase("RappapaToui.pdf")]
    [TestCase("212332342.png")]
    public void GetFileNameFromPath_Without_Path_Returns_Input_As_Output(string path)
    {
        var fileName = FileNameUtility.GetFileNameFromPath(path);

        Assert.That(fileName, Is.EqualTo(path));
    }

    [Test]
    [TestCase("a/path/myfile.png", "myfile.png")]
    [TestCase("single/single.jpg", "single.jpg")]
    [TestCase("/single/single.jpg", "single.jpg")]
    [TestCase("a/very/long/path/like/really/really/really/long.webm", "long.webm")]
    public void GetFileNameFromPath_With_Path_Returns_Correct_FileName(string path, string expectedFileName)
    {
        var fileName = FileNameUtility.GetFileNameFromPath(path);

        Assert.That(fileName, Is.EqualTo(expectedFileName));
    }
}
