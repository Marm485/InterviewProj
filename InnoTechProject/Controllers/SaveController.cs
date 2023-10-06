using InnoTechProject.Configuration;
using InnoTechProject.Models;
using InnoTechProject.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using System.Reflection;

namespace InnoTechProject.Controllers
{
    [Route("/[controller]")]
    [ApiController]
    public class SaveController : ControllerBase
    {
        private readonly IImageService _imageService;
        private readonly CustomSettings _customSettings;

        public SaveController(IImageService imageService, IOptions<CustomSettings> customSettings) {
            _imageService = imageService;
            _customSettings = customSettings.Value;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Save([FromBody]SaveRequest request)
        {


            if (request.images is null) 
            {
                return BadRequest();
            }

            return Ok(new
            {
                RequestId = request.RequestId,
                Status = await _imageService.Save(request.images)
            });
        }
    }

}
