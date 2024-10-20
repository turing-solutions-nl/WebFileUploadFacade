using TuringSolutions.WebFileUploadFacade.Resize;

namespace TuringSolutions.WebFileUploadFacade.Tests.ResizeTests.ImageDimensionResizerTests;
public class CalculateResizeValueTests
{
    [Test]
    [TestCase(300, 300)]
    [TestCase(800, 100)]
    [TestCase(1, 2)]
    [TestCase(82, 12)]
    public void Resize_Of_Image_That_Are_Lower_Than_Max_Size_Does_Not_Change_Dimension(int originalWidth, int originalHeight)
    {
        var resizedDimension = ImageDimensionResizer.CalculateResizeValue(originalWidth, originalHeight);

        Assert.Multiple(() =>
        {
            Assert.That(originalWidth, Is.EqualTo(resizedDimension.Width));
            Assert.That(originalHeight, Is.EqualTo(resizedDimension.Height));
            Assert.That(resizedDimension.ValuesDifferFromOriginal, Is.False);
        });
    }

    [Test]
    [TestCase(2500, 999)]
    [TestCase(2000, 500)]
    [TestCase(1001, 100)]
    [TestCase(9999, 1000)]
    public void Resize_Of_Image_Where_WidthIsMoreThanHeight_Does_Not_Resize_Width_Below_75Percent_Of_Desired_Size(int originalWidth, int originalHeight)
    {
        var desiredMinSize = ImageDimensionResizer.DEFAULT_MAX_IMAGE_WIDTH_IN_PIXELS * (0.75);
        var resizedDimension = ImageDimensionResizer.CalculateResizeValue(originalWidth, originalHeight);

        Assert.Multiple(() =>
        {
            Assert.That(resizedDimension.Width >= desiredMinSize, Is.True);
            Assert.That(resizedDimension.Width <= ImageDimensionResizer.DEFAULT_MAX_IMAGE_WIDTH_IN_PIXELS, Is.True);
            Assert.That(resizedDimension.ValuesDifferFromOriginal, Is.True);
        });
    }

    [Test]
    [TestCase(999, 2500)]
    [TestCase(500, 2000)]
    [TestCase(100, 1001)]
    [TestCase(1000, 9999)]
    public void Resize_Of_Image_Where_HeightIsMoreThanWidth_Does_Not_Resize_Height_Below_75Percent_Of_Desired_Size(int originalWidth, int originalHeight)
    {
        var desiredMinSize = ImageDimensionResizer.DEFAULT_MAX_IMAGE_HEIGHT_IN_PIXELS * (0.75);
        var resizedDimension = ImageDimensionResizer.CalculateResizeValue(originalWidth, originalHeight);

        Assert.Multiple(() =>
        {
            Assert.That(resizedDimension.Height >= desiredMinSize, Is.True);
            Assert.That(resizedDimension.Height <= ImageDimensionResizer.DEFAULT_MAX_IMAGE_HEIGHT_IN_PIXELS, Is.True);
            Assert.That(resizedDimension.ValuesDifferFromOriginal, Is.True);
        });
    }
}
