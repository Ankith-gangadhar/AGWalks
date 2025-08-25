using AGWalks.API.Data;
using AGWalks.API.Models.Domain;
using AGWalks.API.Models.DTO;
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
            //Get data from database - Domain Models
            var regionsDomain = dbContext.Regions.ToList();

            //Map domain models to DTO
            var regionsDto = new List<RegionDto>();
            foreach (var regionDomain in regionsDomain)
            {
                regionsDto.Add(new RegionDto()
                {
                    Id = regionDomain.Id,
                    Code = regionDomain.Code,
                    Name = regionDomain.Name,
                    RegionImageUrl = regionDomain.RegionImageUrl
                });
            }
            
            //Return DTOs
            return Ok(regionsDto);
        }

        //GET SINGLE REGION (Get Region by ID)
        //GET: https://localhost:7097/api/regions{id}
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id); find is used specifically for primary keys
            //Get region Data from database -- Domain Model
            var regionDomain = dbContext.Regions.FirstOrDefault(x => x.Id == id); //Can be used as universal

            if (regionDomain == null)
            {   
                return NotFound();
            }

            //Map domain models to DTO
            var regiondto = new RegionDto
            {
                Id = regionDomain.Id,
                Code = regionDomain.Code,
                Name = regionDomain.Name,
                RegionImageUrl = regionDomain.RegionImageUrl
            };

            //Return DTO to client
            return Ok(regiondto);
        }
    }
}
