
using System.Reflection.Metadata;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

using IDORAPI.Entities;
using IDORAPI.Infrastructure.Contracts;

using Microsoft.AspNetCore.Mvc;
using IDORAPI.Infrastructure.Contracts;

namespace IDORAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> SaveFile([FromForm] IFormFile file)
        {
            try
            {
                string filePath = await _fileSystemService.SaveFile(file);
                return Ok(new { FilePath = filePath });
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}