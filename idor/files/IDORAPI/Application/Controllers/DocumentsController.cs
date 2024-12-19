
using Microsoft.AspNetCore.Mvc;
using IDORAPI.Infrastructure.Contracts;

using Microsoft.Extensions.Logging;

namespace IDORAPI.Application.Controllers
{
    [ApiController]
    [Route("api/file")]
    public class FileController : ControllerBase
    {
        private readonly IFileSystemService _fileSystemService;

        public FileController(IFileSystemService fileSystemService)
        {
            _fileSystemService = fileSystemService;
        }

        [HttpGet("{fileName}")]
        public async Task<IActionResult> GetFile(string fileName)
        {
            try
            {
                string content = await _fileSystemService.GetFile(fileName);
                return Ok(content);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: file not found");
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveFile([FromForm] IFormFile file)
        {
            try
            {
                string filePath = await _fileSystemService.SaveFile(file);
                return Ok(new { filePath });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}