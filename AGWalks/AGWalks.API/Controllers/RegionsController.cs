using AGWalks.API.Data;
using AGWalks.API.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AGWalks.API.Controllers
{
    //https://localhost:7097/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AGWalksDbContext dbContext;

        public RegionsController(AGWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        //GET ALL REGIONS
        //GET: https://localhost:7097/api/regions
        [HttpGet]
        public IActionResult GetAll ()
        {
            var regions = dbContext.Regions.ToList();
            return Ok(regions);
        }

    }
}
