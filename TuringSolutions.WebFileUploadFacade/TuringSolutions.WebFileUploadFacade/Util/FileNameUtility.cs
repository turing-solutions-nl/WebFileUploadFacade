using Microsoft.AspNetCore.StaticFiles;
using TuringSolutions.WebFileUploadFacade.Exceptions;

namespace TuringSolutions.WebFileUploadFacade.Util;

// TODO: better name
public static class FileNameUtility
{
    public static string[] SupportedImageTypes = ["image/jpeg", "image/jpg", "image/png", "image/gif", "image/bmp", "image/webp"];
    public const string DefaultContentType = "application/octet-stream";

    private static readonly FileExtensionContentTypeProvider Provider = new FileExtensionContentTypeProvider();

    public static string GetFileExtension(this string fileNameIncludingContentType)
    {
        int lastDotIndex = fileNameIncludingContentType.LastIndexOf('.');

        var fileNameIncludesDot = lastDotIndex != -1 && lastDotIndex < fileNameIncludingContentType.Length - 1;
        if (!fileNameIncludesDot)
        {
            throw new FileFormatException("File does not contain content type | '.' is missing");
        }

        return fileNameIncludingContentType[(lastDotIndex + 1)..];
    }

    // Returns the content type from the file name e.g. myimage.png -> image/png
    public static string GetContentType(this string fileName)
    {
        if (!Provider.TryGetContentType(fileName, out var contentType))
        {
            contentType = DefaultContentType;
        }
        return contentType;
    }

    public static string GetFileNameFromPath(this string path)
    {
        if (!path.Contains("/")) return path;

        var lastSlashInPathArrayPosition = path.LastIndexOf("/") + 1;
        return path.Substring(lastSlashInPathArrayPosition, (path.Length - lastSlashInPathArrayPosition));
    }
}
