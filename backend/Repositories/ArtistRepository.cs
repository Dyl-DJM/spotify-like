using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;
using backend.Dtos.Artist;

namespace backend.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ArtistRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }

        public async Task<Artist> CreateAsync(Artist artistModel)
        {
            await _dbContext.Artists.AddAsync(artistModel);
            await _dbContext.SaveChangesAsync();
            return artistModel;
        }

        public async Task<Artist?> DeleteAsync(int id)
        {
            var artistModel = await _dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);
            if (artistModel == null)
            {
                return null;
            }
            _dbContext.Artists.Remove(artistModel);
            await _dbContext.SaveChangesAsync();
            return artistModel;
        }

        public async Task<List<Artist>> GetAllAsync()
        {
            return await _dbContext.Artists.ToListAsync();
        }

        public async Task<Artist?> GetByIdAsync(int id)
        {
            return await _dbContext.Artists.FindAsync(id);
        }

        public async Task<Artist?> UpdateAsync(int id, UpdateArtistRequestDto artistDto)
        {
            var existingArtist = await _dbContext.Artists.FirstOrDefaultAsync(x => x.Id == id);

            if (existingArtist == null)
            {
                return null;
            }

            existingArtist.Name = artistDto.Name;
            existingArtist.Description = artistDto.Description;
            existingArtist.Genre = artistDto.Genre;

            await _dbContext.SaveChangesAsync();

            return existingArtist;
        }
    }
}