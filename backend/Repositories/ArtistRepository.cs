using backend.Data;
using backend.Interfaces;
using backend.Models;
using Microsoft.EntityFrameworkCore;

namespace backend.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ApplicationDBContext _dbContext;
        public ArtistRepository(ApplicationDBContext context)
        {
            _dbContext = context;
        }
        public Task<List<Artist>> GetAllAsync()
        {
            return _dbContext.Artists.ToListAsync();
        }
    }
}