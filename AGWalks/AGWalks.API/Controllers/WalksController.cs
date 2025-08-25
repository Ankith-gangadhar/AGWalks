using AGWalks.API.Models.Domain;
using AGWalks.API.Models.DTO;
using AGWalks.API.Repositories;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;

namespace AGWalks.API.Controllers
{
    // api/walks
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }
        // CREATE A WALK
        // POST : https://localhost:7097/api/walks
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddWalkRequestDto addWalkRequestDto)
        {
            //Map DTO to Domain Model
            var walkDomainModel = mapper.Map<Walk>(addWalkRequestDto);
            await walkRepository.CreateAsync(walkDomainModel);  
            
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }

        // GET WALKS
        // GET : https://localhost:7097/api/walks
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var walksDomainModel = await walkRepository.GetAllAsync();
            return Ok(mapper.Map<List<WalkDto>>(walksDomainModel));
        }

        // GET WALKS
        // GET : https://localhost:7097/api/walks{id}
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var walkDomainModel = await walkRepository.GetByIdAsync(id);
            if (walkDomainModel == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<WalkDto>(walkDomainModel));
        }
    }
}
