using Microsoft.AspNetCore.Http;

namespace MasterP.Services
{
    public interface IFileStorageService
    {
        Task<string> UploadFileAsync(IFormFile file, string containerName);
        Task DeleteFileAsync(string fileUrl, string containerName);
        Task<string> GetFileUrlAsync(string fileName, string containerName);
    }
} 