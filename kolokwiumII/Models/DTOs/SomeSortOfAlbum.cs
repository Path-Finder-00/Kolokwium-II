using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace kolokwiumII.Models.DTOs
{
    public class SomeSortOfAlbum
    {
        public string AlbumName { get; set; }
        public DateTime PublishDate { get; set; }
        public int IdMusicLabel { get; set; }
        public IEnumerable<SomeSortOfTrack> Tracks { get; set; }
    }
}
