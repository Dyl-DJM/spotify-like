using backend.Data;
using backend.Dtos.Artist;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly IArtistRepository _artistRepo;
        private readonly ApplicationDBContext _dbContext;
        public ArtistController(ApplicationDBContext context, IArtistRepository repository)
        {
            _artistRepo = repository;
            _dbContext = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var artists = await _artistRepo.GetAllAsync();
            var artistDto = artists.Select(a => a.ToArtistDto());

            return Ok(artists);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var artist = await _artistRepo.GetByIdAsync(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist.ToArtistDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateArtistRequestDto artistRequestDto)
        {
            var artistModel = artistRequestDto.ToArtist();
            await _artistRepo.CreateAsync(artistModel);
            return CreatedAtAction(nameof(GetById), new { id = artistModel.Id }, artistModel.ToArtistDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArtistRequestDto updateDto)
        {
            var artistModel = await _artistRepo.UpdateAsync(id, updateDto);

            if (artistModel == null)
            {
                return NotFound();
            }

            return Ok(artistModel.ToArtistDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var artistModel = await _artistRepo.DeleteAsync(id);

            if (artistModel == null)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}