using Microsoft.AspNetCore.Mvc;


namespace IDORAPI.Application.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpGet("/")]
        public IActionResult GetUploadPage()
        {
            try
            {
                string filePath = Path.Combine("templates", "index.html");
                if (!System.IO.File.Exists(filePath))
                {
                    return NotFound("Файл index.html не найден.");
                }

                string htmlContent = System.IO.File.ReadAllText(filePath);
                return Content(htmlContent, "text/html");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Внутренняя ошибка сервера: {ex.Message}");
            }
        }
    }
}