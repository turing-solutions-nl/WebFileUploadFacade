namespace TuringSolutions.WebFileUploadFacade.Resize;

/// <summary>
/// Provides functionality for resizing image dimensions while maintaining the aspect ratio.
/// </summary>
public static class ImageDimensionResizer
{
    /// <summary>
    /// The default maximum width for an image in pixels.
    /// </summary>
    public const int DEFAULT_MAX_IMAGE_WIDTH_IN_PIXELS = 1000;

    /// <summary>
    /// The default maximum height for an image in pixels.
    /// </summary>
    public const int DEFAULT_MAX_IMAGE_HEIGHT_IN_PIXELS = 1000;

    /// <summary>
    /// The maximum allowable width for the initial image in pixels.
    /// </summary>
    public const int MAX_IMAGE_INITIAL_WIDTH_IN_PIXELS = 10000;

    /// <summary>
    /// The maximum allowable height for the initial image in pixels.
    /// </summary>
    public const int MAX_IMAGE_INITIAL_HEIGHT_IN_PIXELS = 10000;

    /// <summary>
    /// Calculates the new image dimensions while maintaining the aspect ratio.
    /// </summary>
    /// <param name="originalWidth">The original width of the image in pixels.</param>
    /// <param name="originalHeight">The original height of the image in pixels.</param>
    /// <param name="newWidth">The desired maximum width of the image in pixels. Defaults to <see cref="DEFAULT_MAX_IMAGE_WIDTH_IN_PIXELS"/>.</param>
    /// <param name="newHeight">The desired maximum height of the image in pixels. Defaults to <see cref="DEFAULT_MAX_IMAGE_HEIGHT_IN_PIXELS"/>.</param>
    /// <returns>A <see cref="ResizedValues"/> object that contains the resized width and height of the image.</returns>
    /// <exception cref="ImageNotResizableException">Thrown when the original dimensions exceed the allowable maximum size.</exception>
    public static ResizedValues CalculateResizeValue(
        int originalWidth,
        int originalHeight,
        int newWidth = DEFAULT_MAX_IMAGE_WIDTH_IN_PIXELS,
        int newHeight = DEFAULT_MAX_IMAGE_HEIGHT_IN_PIXELS)
    {
        if (originalWidth > MAX_IMAGE_INITIAL_WIDTH_IN_PIXELS || originalHeight > MAX_IMAGE_INITIAL_HEIGHT_IN_PIXELS)
        {
            throw new ImageNotResizableException("Image width and height exceed the max dimension that an image can have");
        }

        var resizedValues = new ResizedValues
        {
            Width = originalWidth,
            Height = originalHeight,
            ValuesDifferFromOriginal = false
        };

        while (resizedValues.Width > newWidth || resizedValues.Height > newHeight)
        {
            resizedValues.Width = (int)(resizedValues.Width * 0.8);
            resizedValues.Height = (int)(resizedValues.Height * 0.8);
            resizedValues.ValuesDifferFromOriginal = true;
        }

        return resizedValues;
    }
}

/// <summary>
/// Represents the dimensions of the resized image and whether the values differ from the original.
/// </summary>
public class ResizedValues
{
    /// <summary>
    /// Indicates whether the resized dimensions differ from the original image dimensions.
    /// </summary>
    public bool ValuesDifferFromOriginal { get; set; }

    /// <summary>
    /// The width of the resized image in pixels.
    /// </summary>
    public int Width { get; set; }

    /// <summary>
    /// The height of the resized image in pixels.
    /// </summary>
    public int Height { get; set; }
}
