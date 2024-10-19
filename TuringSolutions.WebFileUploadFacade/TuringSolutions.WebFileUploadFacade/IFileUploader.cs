using Microsoft.AspNetCore.Http;

namespace TuringSolutions.WebFileUploadFacade;
public interface IFileUploader
{
    Task<FileUploadResult> UploadAndResizeIfNeeded(IFormFile file, string container, string path);
    Task<FileUploadResult> UploadFile(IFormFile file, string container, string pathAndFileName);
    Uri GetTempBlobLink(string container, string path, int expirationTimeInMinutes = 1);
}
