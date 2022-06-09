using kolokwiumII.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumII.Properties
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsController : ControllerBase
    {
        private readonly IDbService _dbService;

        public AlbumsController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetAlbum(int id)
        {
            var album = await _dbService.GetAlbum(id);

            return Ok(album);
        }


    }
}
