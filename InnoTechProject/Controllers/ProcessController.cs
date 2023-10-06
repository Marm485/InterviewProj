using InnoTechProject.Configuration;
using InnoTechProject.Models;
using InnoTechProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace InnoTechProject.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IImageService _imageService;

        public ProcessController(IImageService imageService)
        {
            _imageService = imageService;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Process([FromBody]ProcessRequest request)
        {


            if (request.FileNames is null)
            {
                return BadRequest();
            }

            return Ok(new
            {
                Images = await _imageService.Process(request.FileNames.ToArray())
            });
        }
    }
}
