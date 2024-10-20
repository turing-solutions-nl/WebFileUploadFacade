namespace TuringSolutions.WebFileUploadFacade.Util;
public static class FileLocationUtility
{
    public static string GetContainerName(this string fileLocation)
    {
        fileLocation = fileLocation.RemoveUrlBaseAddressIfAny();

        if (fileLocation.Substring(0, 1) == "/")
        {
            fileLocation = fileLocation[1..];
        }
        return fileLocation.Split("/")[0];
    }

    public static string GetPath(this string fileLocation)
    {
        fileLocation = fileLocation.RemoveUrlBaseAddressIfAny();

        if (fileLocation.Substring(0, 1) == "/")
        {
            fileLocation = fileLocation[1..];
        }
        return fileLocation.Substring(fileLocation.IndexOf('/') + 1);
    }

    public static string RemoveUrlBaseAddressIfAny(this string input)
    {
        if (string.IsNullOrEmpty(input))
        {
            return input; // Return input if it's null or empty
        }

        // Check if the string starts with "http://" or "https://"
        if (input.StartsWith("http://", StringComparison.OrdinalIgnoreCase) ||
            input.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
        {
            // Find the index of the first '/' after the base URL
            int index = input.IndexOf('/', input.IndexOf("://") + 3);
            if (index >= 0)
            {
                // Return the substring starting from the character after the first '/'
                return input.Substring(index + 1);
            }
        }

        return input; // Return the original input if no base address is found
    }
}
