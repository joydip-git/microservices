using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlatformService.Data;
using PlatformService.DTOs;
using PlatformService.Models;

namespace PlatformService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepository _repo;
        private readonly IMapper _mapper;
        public PlatformController(IPlatformRepository repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("all")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
        {
            var platforms = _repo.GetAllPlatforms();
            return Ok(_mapper.Map<IEnumerable<PlatformReadDto>>(platforms));
        }

        [HttpGet]
        [Route("{id}", Name = "GetPlatform")]
        public ActionResult<IEnumerable<PlatformReadDto>> GetPlatform(int id)
        {
            var platform = _repo.GetPlatformById(id);
            if (platform != null)
                return Ok(_mapper.Map<PlatformReadDto>(platform));
            else
                return NotFound();
        }

        [HttpPost]
        [Route("create")]
        public ActionResult<PlatformReadDto> CreatePlatform([FromBody] PlatformCreateDto platformCreateDto)
        {
            var platform = _mapper.Map<PlatformCreateDto, PlatformModel>(platformCreateDto);
            _repo.CreatePlatform(platform);
            _repo.SaveChanges();

            var platformReadtDto = _mapper.Map<PlatformReadDto>(platform);
            return CreatedAtRoute(nameof(GetPlatform), new { Id = platformReadtDto.Id }, platformReadtDto);
        }
    }
}