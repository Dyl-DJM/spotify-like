using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Data;
using backend.Dtos.Artist;
using backend.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/artists")]
    [ApiController]
    public class ArtistController : ControllerBase
    {
        private readonly ApplicationDBContext _dbContext;
        public ArtistController(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var artists = _dbContext.Artists.ToList()
                .Select(a => a.ToArtistDto());
            return Ok(artists);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            var artist = _dbContext.Artists.Find(id);
            if (artist == null)
            {
                return NotFound();
            }
            return Ok(artist.ToArtistDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateArtistRequestDto artistRequestDto)
        {
            var artistModel = artistRequestDto.ToArtist();
            _dbContext.Artists.Add(artistModel);
            _dbContext.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = artistModel.Id }, artistModel.ToArtistDto());
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] UpdateArtistRequestDto artistRequestDto)
        {
            var artistModel = _dbContext.Artists.FirstOrDefault(x => x.Id == id);

            if (artistModel == null)
            {
                return NotFound();
            }

            artistModel.Name = artistRequestDto.Name;
            artistModel.Description = artistRequestDto.Description;
            artistModel.Genre = artistRequestDto.Genre;

            _dbContext.SaveChanges();

            return Ok(artistModel.ToArtistDto());
        }
    }
}