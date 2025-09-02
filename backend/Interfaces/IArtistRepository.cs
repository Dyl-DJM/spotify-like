using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.Dtos.Artist;
using backend.Models;

namespace backend.Interfaces
{
    public interface IArtistRepository
    {
        Task<List<Artist>> GetAllAsync();

        Task<Artist?> GetByIdAsync(int id); // FirstOrDefault can be null

        Task<Artist> CreateAsync(Artist artistModel);

        Task<Artist?> UpdateAsync(int id, UpdateArtistRequestDto artistDto);

        Task<Artist?> DeleteAsync(int id);
    }
}