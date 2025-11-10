using Challenger.Infrastructure.ComputerVision;
using Microsoft.AspNetCore.Mvc;

namespace Challenger.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisionController : ControllerBase
    {
        private readonly RoboflowService _roboflow;
        private readonly ILogger<VisionController> _logger;

        public VisionController(RoboflowService roboflow, ILogger<VisionController> logger)
        {
            _roboflow = roboflow;
            _logger = logger;
        }

        [HttpPost("analyze")]
        [DisableRequestSizeLimit]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> Analyze(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");

            using var ms = new MemoryStream();
            await file.CopyToAsync(ms);
            var bytes = ms.ToArray();

            var resultJson = await _roboflow.AnalyzeAsync(bytes);

            Console.WriteLine($"[ROBOFLOW] RESULTADO: {resultJson}");
            _logger.LogInformation("[ROBOFLOW] RESULTADO: {json}", resultJson);

            return Ok(resultJson);
        }
    }
}