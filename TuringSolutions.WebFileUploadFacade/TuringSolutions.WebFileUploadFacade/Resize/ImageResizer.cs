using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Processing;

namespace TuringSolutions.WebFileUploadFacade.Resize;
public static class ImageResizer
{
    public static byte[] ResizeImage(SixLabors.ImageSharp.Image image, int width, int height)
    {
        // Resize the image to the specified width and height
        image.Mutate(x => x.Resize(width, height));

        using var outputStream = new MemoryStream();

        // Save the image as a JPEG format to the output stream
        image.Save(outputStream, new JpegEncoder());

        return outputStream.ToArray(); // Return resized image as byte array
    }
}
