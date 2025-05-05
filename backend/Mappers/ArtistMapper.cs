using backend.Dtos.Artist;
using backend.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace backend.Mappers
{
    public static class ArtistMapper
    {
        public static ArtistDto ToArtistDto(this Artist artistModel)
        {
            return new ArtistDto
            {
                Id = artistModel.Id,
                Name = artistModel.Name,
            };
        }

        public static Artist ToArtist(this CreateArtistRequestDto artistRequestDto)
        {
            return new Artist
            {
                Name = artistRequestDto.Name,
                Description = artistRequestDto.Description,
                Genre = artistRequestDto.Genre
            };
        }
    }
}