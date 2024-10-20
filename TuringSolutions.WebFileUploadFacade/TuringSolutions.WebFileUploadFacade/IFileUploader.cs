using Microsoft.AspNetCore.Http;

namespace TuringSolutions.WebFileUploadFacade
{
    /// <summary>
    /// Defines methods for uploading files and generating temporary blob links.
    /// </summary>
    public interface IFileUploader
    {
        /// <summary>
        /// Uploads a file to a specified container with the given path and file name.
        /// </summary>
        /// <param name="file">The file to be uploaded.</param>
        /// <param name="container">The blob storage container where the file will be stored.</param>
        /// <param name="path">The path and file name for the uploaded file (including the file name!).</param>
        /// <param name="fileNameIncludingExtension">Optional parameter to set the (new) name of the file. If no value specified, a random filename will be generated.</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="FileUploadResult"/> containing upload details.</returns>
        Task<FileUploadResult> UploadFileAsIFormFileAsync(IFormFile file, string container, string path, string? fileNameIncludingExtension = null);

        /// <summary>
        /// Uploads content as a byte array to a specified container with the given path and file name.
        /// </summary>
        /// <param name="bytes">The content to be uploaded as a byte array.</param>
        /// <param name="container">The blob storage container where the content will be stored.</param>
        /// <param name="path">The path within the container where the content will be stored.</param>
        /// <param name="fileName">The name of the file to be created in the blob storage (including content type!).</param>
        /// <returns>A task representing the asynchronous operation, with a <see cref="FileUploadResult"/> containing upload details.</returns>
        Task<FileUploadResult> UploadFileAsByteArrayAsync(byte[] bytes, string container, string path, string originalFileNameIncludingExtension, bool generateRandomName = true);

        /// <summary>
        /// Generates a temporary URI for accessing a blob.
        /// </summary>
        /// <param name="container">The blob storage container where the file is stored.</param>
        /// <param name="pathIncludingFileName">The path to the file within the container (including the file name!)</param>
        /// <param name="expirationTimeInMinutes">The expiration time for the generated link, in minutes. Defaults to 1 minute.</param>
        /// <returns>A <see cref="Uri"/> for accessing the blob temporarily.</returns>
        Uri GetTempBlobLink(string container, string pathIncludingFileName, int expirationTimeInMinutes = 1);
    }
}
