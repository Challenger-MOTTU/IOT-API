using Challenger.Infrastructure.ComputerVision;
using Microsoft.AspNetCore.Mvc;

namespace Challenger.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VisionController : ControllerBase
    {
        private readonly RoboflowService _roboflowService;

        public VisionController(RoboflowService roboflowService)
        {
            _roboflowService = roboflowService;
        }

        /// <summary>
        /// Envia uma imagem para o Roboflow e retorna as detecções.
        /// </summary>
        /// <param name="file">Imagem enviada (form-data).</param>
        [HttpPost("analyze")]
        public async Task<IActionResult> Analyze([FromForm] IFormFile file)
        {
            if (file == null || file.Length == 0)
                return BadRequest("Nenhum arquivo enviado.");

            using var stream = file.OpenReadStream();
            var result = await _roboflowService.AnalyzeImageAsync(stream);

            return Ok(result);
        }
    }
}