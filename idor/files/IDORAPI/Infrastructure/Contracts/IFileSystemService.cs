using System.Threading.Tasks;

namespace IDORAPI.Infrastructure.Contracts;

public interface IFileSystemService
{
    Task<string> GetFile(string sourceFileName);
    Task<string> SaveFile(IFormFile file);
}