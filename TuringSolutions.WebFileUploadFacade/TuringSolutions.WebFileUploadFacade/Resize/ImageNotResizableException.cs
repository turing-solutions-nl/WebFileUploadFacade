namespace TuringSolutions.WebFileUploadFacade.Resize;
public class ImageNotResizableException : Exception
{
    public ImageNotResizableException(string message) : base(message) { }
}
