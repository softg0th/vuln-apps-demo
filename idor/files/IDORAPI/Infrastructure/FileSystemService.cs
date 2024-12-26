using IDORAPI.Infrastructure.Contracts;
using System.Security.Cryptography;
using System.Text;

namespace IDORAPI.Infrastructure
{
    public class FileSystemService : IFileSystemService
    {
        string fileDir = "/home/files";
        int fileNameCounter = 2;

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
            string fileHashName = await GenerateMD5(fileNameCounter.ToString());
            string fileName = fileHashName + Path.GetExtension(file.FileName);
            string filePath = $"{fileDir}/{fileName}";

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            return fileName;
        }
        public async Task<string>  GenerateMD5(string input)
        {
            MD5 md5Hasher = MD5.Create();
            byte[] data = md5Hasher.ComputeHash(Encoding.Default.GetBytes(input));
            StringBuilder sBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
