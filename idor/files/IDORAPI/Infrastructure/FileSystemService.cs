using IDORAPI.Infrastructure.Contracts;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace IDORAPI.Infrastructure
{
    public class FileSystemService : IFileSystemService
    {
        string fileDir = "/home/files";
        int fileNameCounter = 0;

        public async Task<string> GetFile(string fileName)
        {
            string filePath = $"{fileDir}/{fileName}";
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("The specified file does not exist.", fileName);
            }

            using (var reader = new StreamReader(filePath))
            {
                return await reader.ReadToEndAsync();
            }
        }

        public async Task<string> SaveFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                throw new ArgumentException("The uploaded file is empty.", nameof(file));
            }

            fileNameCounter++;
            string fileName = fileNameCounter.ToString() + Path.GetExtension(file.FileName);
            string filePath = $"{fileDir}/{fileName}";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return filePath;
        }
    }
}
