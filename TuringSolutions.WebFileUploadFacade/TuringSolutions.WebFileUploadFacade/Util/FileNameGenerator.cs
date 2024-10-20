namespace TuringSolutions.WebFileUploadFacade.Util;
public static class FileNameGenerator
{
    public static string GenerateRandomFileName(string fileNameAndExtension, out Guid id)
    {
        id = Guid.NewGuid();
        var name = id.ToString();

        var fileExtension = fileNameAndExtension.GetFileExtension();
        if (string.IsNullOrWhiteSpace(fileExtension)) return name;

        return $"{name}.{fileExtension}";
    }
}
