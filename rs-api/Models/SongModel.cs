using System;

namespace Rockstar.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Artist { get; set; }
        public string ImageUrl { get; set; }
        public string Lyrics { get; set; }
    }
}
