using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.Tests.UtilTests.FileNameUtilityTests;
public class GetContentTypeTests
{
    [Test]
    [TestCase("ImJustAnImage.png", "image/png")]
    [TestCase("ImJustAnImage.jpg", "image/jpeg")]
    [TestCase("ImJustAnImage.jpeg", "image/jpeg")]
    [TestCase("ImJustAnImage.pdf", "application/pdf")]
    public void GetContentType_With_Valid_Content_Type_Returns_Correct_ContentType(string fileName, string expectedContentType)
    {
        var contentType = fileName.GetContentType();

        Assert.That(contentType, Is.EqualTo(expectedContentType));
    }

    [Test]
    [TestCase("myfile.notexistingcontenttype")]
    [TestCase("png.skrt")]
    [TestCase("whatisthis.whatisthis")]
    [TestCase("abcfile.abcdefg")]
    public void GetContentType_With_Invalid_Or_Unknown_Content_Type_Returns_Default_ContentType(string fileName)
    {
        var defaultContentType = FileNameUtility.DefaultContentType;

        var contentType = fileName.GetContentType();

        Assert.That(contentType, Is.EqualTo(defaultContentType));
    }

    [Test]
    [TestCase("iufdsdfhsdf")]
    [TestCase("")]
    [TestCase("my/name/png")]
    [TestCase("jpgjpgjpg")]
    public void GetContentType_Without_ContentType_Returns_Default_ContentType(string fileName)
    {
        var defaultContentType = FileNameUtility.DefaultContentType;

        var contentType = fileName.GetContentType();

        Assert.That(contentType, Is.EqualTo(defaultContentType));
    }
}
