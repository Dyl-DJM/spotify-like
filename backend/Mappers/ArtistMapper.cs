using backend.Dtos.Artist;
using backend.Models;

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
    }
}