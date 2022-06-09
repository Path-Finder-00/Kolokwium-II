using kolokwiumII.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumII.Services
{
    public interface IDbService
    {
        public Task<IEnumerable<SomeSortOfAlbum>> GetAlbum(int id);
    }
}
