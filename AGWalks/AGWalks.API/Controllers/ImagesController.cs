using AGWalks.API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGWalks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        // POST: api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageRequestUploadDto request)
        {
            ValidateFileUpload(request);

            if(ModelState.IsValid)
            {

            }
            return BadRequest(ModelState);

        }

        private void ValidateFileUpload(ImageRequestUploadDto request)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif" };
            
            if(!allowedExtensions.Contains(Path.GetExtension(request.File.FileName)))
            {
                ModelState.AddModelError("File", "Unsupported file extension");
            }

            if(request.File.Length > 10 * 1024 * 1024) 
            {
                ModelState.AddModelError("File", "File size exceeds the 10MB limit");
            }
        }


    }
}
