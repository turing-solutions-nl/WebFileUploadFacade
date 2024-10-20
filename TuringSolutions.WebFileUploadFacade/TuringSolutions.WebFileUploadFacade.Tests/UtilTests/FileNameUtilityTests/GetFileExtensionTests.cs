using TuringSolutions.WebFileUploadFacade.Exceptions;
using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileUtilityTests;
public class GetFileExtensionTests
{
    [Test]
    [TestCase("myFile.png", "png", Description = "letters only")]
    [TestCase("32423424/32432423.png", "png", Description = "digits only")]
    [TestCase("11filename03.webp", "webp", Description = "digits and letter")]
    [TestCase("_myfilename/location/d.jpeg", "jpeg", Description = "multiple slashses")]
    [TestCase("this.should.be.possible/path.pdf", "pdf", Description = "multiple dots (for some reason)")]
    public void GetFileExtension_With_Valid_FileName_Returns_Correct_ContentType(string fileNameAndContentType, string expectedContentType)
    {
        var contentType = fileNameAndContentType.GetFileExtension();

        Assert.That(contentType, Is.EqualTo(expectedContentType));
    }

    [Test]
    [TestCase("myFilepng", Description = "no content type")]
    [TestCase("/lol/filename", Description = "no content type")]
    [TestCase("D:/location/png", Description = "no content type")]
    public void GetFileExtension_With_InValid_FileName_Throws_Exception(string fileNameWithoutContentType)
    {
        Assert.Throws<FileFormatException>(() => fileNameWithoutContentType.GetFileExtension());
    }
}
