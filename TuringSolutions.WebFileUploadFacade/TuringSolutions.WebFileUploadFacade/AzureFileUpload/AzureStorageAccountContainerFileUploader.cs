using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure.Storage.Sas;
using Microsoft.AspNetCore.Http;
using TuringSolutions.WebFileUploadFacade.Util;

namespace TuringSolutions.WebFileUploadFacade.AzureFileUpload;
public class AzureStorageAccountContainerFileUploader(BlobServiceClient _blobServiceClient) : IFileUploader
{
    public async Task<FileUploadResult> UploadFileAsByteArrayAsync(byte[] bytes, string container, string path, string originalFileNameIncludingExtension, bool generateRandomName = true)
    {
        string newFileNameIncludingExtension = (generateRandomName) ? FileNameGenerator.GenerateRandomFileName(originalFileNameIncludingExtension, out var id) : originalFileNameIncludingExtension;

        var blobClient = GetBlobClient(container, $"{path}/{newFileNameIncludingExtension}".ToLower());

        using (var stream = new MemoryStream(bytes))
        {
            var result = await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = path.GetFileNameFromPath().GetContentType() });
        }

        return new FileUploadResult
        {
            FileName = newFileNameIncludingExtension,
            Url = blobClient.Uri.ToString()
        };
    }

    public async Task<FileUploadResult> UploadFileAsIFormFileAsync(IFormFile file, string container, string path, string? fileNameIncludingExtension = null)
    {

        fileNameIncludingExtension ??= FileNameGenerator.GenerateRandomFileName(file.FileName, out var id);

        var blobClient = GetBlobClient(container, $"{path}/{fileNameIncludingExtension}".ToLower());

        using var stream = file.OpenReadStream();
        var result = await blobClient.UploadAsync(stream, new BlobHttpHeaders { ContentType = file.ContentType });

        return new FileUploadResult
        {
            FileName = fileNameIncludingExtension,
            Url = blobClient.Uri.ToString()
        };
    }

    public Uri GetTempBlobLink(string container, string pathIncludingFileName, int expirationTimeInMinutes = 1)
    {
        var blobClient = GetBlobClient(container, pathIncludingFileName);

        DateTimeOffset expire = new DateTimeOffset(DateTime.Now).ToOffset(TimeSpan.FromMinutes(expirationTimeInMinutes));

        return blobClient.GenerateSasUri(BlobSasPermissions.Read, expire);
    }

    public async Task<bool> DeleteFileAsync(string container, string pathIncludingFileName)
    {
        var blobClient = GetBlobClient(container, pathIncludingFileName);
        return await blobClient.DeleteIfExistsAsync();
    }

    private BlobClient GetBlobClient(string container, string blobLocation)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(container);
        return containerClient.GetBlobClient(blobLocation);
    }
}
