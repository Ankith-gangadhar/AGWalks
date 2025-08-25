using AGWalks.API.CustomActionFilters;
using AGWalks.API.Data;
using AGWalks.API.Models.Domain;
using AGWalks.API.Models.DTO;
using AGWalks.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AGWalks.API.Controllers
{
    //https://localhost:7097/api/regions
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AGWalksDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(AGWalksDbContext dbContext, IRegionRepository regionRepository,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        // GET ALL REGIONS
        // GET: https://localhost:7097/api/regions
        [HttpGet]
        [Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAll()
        {
            //Get data from database - Domain Models
            var regionsDomain = await regionRepository.GetAllAsync();

            //Return DTOs
            return Ok(mapper.Map<List<RegionDto>>(regionsDomain));
        }

        // GET SINGLE REGION (Get Region by ID)
        // GET: https://localhost:7097/api/regions{id}
        [HttpGet]
        [Authorize(Roles = "Reader")]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            //var region = dbContext.Regions.Find(id); find is used specifically for primary keys
            //Get region Data from database -- Domain Model
            var regionDomain = await regionRepository.GetByIdAsync(id);

            if (regionDomain == null)
            {   
                return NotFound();
            }

            //Return DTO to client
            return Ok(mapper.Map<RegionDto>(regionDomain));
        }

        // POST To Create a Region
        // POST: https://localhost:7097/api/regions
        [HttpPost]
        [Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddRegionRequestDto addRegionRequestDto)
        {

            //Map DTO to domain
            var regiondomainmodel = mapper.Map<Region>(addRegionRequestDto);

            //Use Domain model to create request
            regiondomainmodel = await regionRepository.CreateAsync(regiondomainmodel);

            //Map Domain to DTO
            var regionDto = mapper.Map<RegionDto>(regiondomainmodel);

            return CreatedAtAction(nameof(GetById), new { id = regiondomainmodel.Id }, regionDto);
        }

        // PUT to udpate a Region
        // PUT: https://localhost:7097/api/regions{id}
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateRegionRequestDto updateRegionRequestDto)
        {

            //Map DTO to Domain Model
            var regionDomainModel = mapper.Map<Region>(updateRegionRequestDto);

            regionDomainModel = await regionRepository.UpdateAsync(id, regionDomainModel);

            if (regionDomainModel == null)
            {
                return NotFound();
            }

            return Ok(mapper.Map<RegionDto>(regionDomainModel));
        }

        //DELETE a Region
        // DELETE: https://localhost:7097/api/regions{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        [Authorize(Roles = "Writer")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            var regionDomainModel = await regionRepository.DeleteAsync(id);
            if (regionDomainModel == null)
            {
                return NotFound();
            }
            
            //Map Domain Model to DTO
            var regionDto = mapper.Map<RegionDto>(regionDomainModel);
            return Ok(regionDto);
        }
    }
}
