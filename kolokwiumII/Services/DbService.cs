using kolokwiumII.Models;
using kolokwiumII.Models.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumII.Services
{
    public class DbService : IDbService
    {
        private readonly MainDbCotext _dbContext;
        public DbService(MainDbCotext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<SomeSortOfAlbum>> GetAlbum(int id)
        {
            return await _dbContext.Albums
                .Include(e => e.Tracks)
                .Where(e => e.IdAlbum == id)
                .Select(e => new SomeSortOfAlbum
                {
                    AlbumName = e.AlbumName,
                    PublishDate = e.PublishDate,
                    IdMusicLabel = e.IdMusicLabel,
                    Tracks = e.Tracks.Select(e => new SomeSortOfTrack
                    {
                        IdTrack = e.IdTrack,
                        TrackName = e.TrackName,
                        Duration = e.Duration
                    }).ToList().OrderByDescending(e => e.Duration)
                })
                .ToListAsync();
        }
    }
}
