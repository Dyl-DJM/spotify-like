using backend.Data;
using backend.Dtos.Artist;
using backend.Interfaces;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
            var artist = await _dbContext.Artists.FindAsync(id);
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
            await _dbContext.Artists.AddAsync(artistModel);
            await _dbContext.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = artistModel.Id }, artistModel.ToArtistDto());
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateArtistRequestDto artistRequestDto)
        {
            var artistModel = await _dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

            if (artistModel == null)
            {
                return NotFound();
            }

            artistModel.Name = artistRequestDto.Name;
            artistModel.Description = artistRequestDto.Description;
            artistModel.Genre = artistRequestDto.Genre;

            await _dbContext.SaveChangesAsync();

            return Ok(artistModel.ToArtistDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var artistModel = await _dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

            if (artistModel == null)
            {
                return NotFound();
            }
            _dbContext.Artists.Remove(artistModel);
            await _dbContext.SaveChangesAsync();

            return NoContent();
        }
    }
}