using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstar.Models;

namespace Rockstar.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SongsController : ControllerBase
    {
        private static readonly List<SongModel> Songs = new List<SongModel>()
        {
            new SongModel()
            {
                Id = 1,
                Name = "Hotel California",
                Artist = "The Eagles",
                ImageUrl = "the-eagles.jpg",
                Lyrics = @"<div>On a dark desert highway, cool wind in my hair<br>Warm smell of colitas, rising up through the air<br>Up ahead in the distance, I saw a shimmering light<br>My head grew heavy and my sight grew dim<br>I had to stop for the night<br>There she stood in the doorway<br>I heard the mission bell<br>And I was thinking to myself<br>""This could be Heaven or this could be Hell""<br>Then she lit up a candle and she showed me the way<br>There were voices down the corridor<br>I thought I heard them say<br><br>Welcome to the Hotel California<br>Such a lovely place (Such a lovely place)<br>Such a lovely face<br>Plenty of room at the Hotel California<br>Any time of year (Any time of year)<br>You can find it here<br><br>Her mind is Tiffany-twisted, she got the Mercedes bends<br>She got a lot of pretty, pretty boys she calls friends<br>How they dance in the courtyard, sweet summer sweat<br>Some dance to remember, some dance to forget<br><br>So I called up the Captain<br>""Please bring me my wine.""<br>He said, ""We haven't had that spirit here since nineteen sixty nine.""<br>And still those voices are calling from far away<br>Wake you up in the middle of the night<br>Just to hear them say<br><br>Welcome to the Hotel California<br>Such a lovely place (Such a lovely place)<br>Such a lovely face<br>They livin' it up at the Hotel California<br>What a nice surprise (what a nice surprise)<br>Bring your alibis<br><br>Mirrors on the ceiling<br>The pink champagne on ice<br>And she said ""We are all just prisoners here, of our own device""<br>And in the master's chambers<br>They gathered for the feast<br>They stab it with their steely knives<br>But they just can't kill the beast<br><br>Last thing I remember<br>I was running for the door<br>I had to find the passage back to the place I was before<br>""Relax,"" said the night man<br>""We are programmed to receive<br>You can check-out any time you like<br>But you can never leave!""</div>"
            },
            new SongModel() 
            {
                Id = 2,
                Name = "The Show Must Go On",
                Artist = "Queen",
                ImageUrl = "queen-1.jpg",
                Lyrics = @"<div>Empty spaces.<br>What are we living for?<br>Abandoned places.<br>I guess we know the score.<br><br>On and on.<br>Does anybody know what we are looking for?<br><br>Another hero,<br>Another mindless crime<br>Behind the curtain<br>In the pantomime.<br><br>Hold the line.<br>Does anybody want to take it anymore?<br><br>Show must go on.<br>Show must go on.<br>Inside my heart is breaking.<br>My make-up may be flaking.<br>But my smile still stays on.<br><br>Whatever happens,<br>I'll leave it all to chance.<br>Another heartache,<br>Another failed romance.<br><br>On and on.<br>Does anybody know what we are living for?<br><br>I guess I'm learning.<br>I must be warmer now.<br>I'll soon be turning<br>'Round the corner now.<br><br>Outside the dawn is breaking,<br>But inside in the dark I'm aching to be free.<br><br>Show must go on.<br>Show must go on.<br>Inside my heart is breaking.<br>My make-up may be flaking,<br>But my smile still stays on.<br><br>My soul is painted like the wings of butterflies.<br>Fairytales of yesterday will grow but never die.<br>I can fly, my friends.<br><br>Show must go on.<br>Show must go on.<br>I'll face it with a grin.<br>I'm never giving in—<br>Oh—with the show.<br><br>I'll top the bill,<br>I'll overkill.<br>I have to find the will to carry on with the show.<br>On with the show.<br><br>Show must go on.</div>"
            },
            new SongModel() 
            {
                Id = 3,
                Name = "Another Brick In The Wall",
                Artist = "Pink Floyd",
                ImageUrl = "pink-floyd.png",
                Lyrics = @"<div>We don't need no education<br>We don't need no thought control<br>No dark sarcasm in the classroom<br>Teacher, leave them kids alone<br><br>Hey, teacher, leave them kids alone<br><br>All in all it's just another brick in the wall<br>All in all you're just another brick in the wall<br><br><i>[Chorus by pupils from the Fourth Form Music Class Islington Green School, London]</i><br><br>We don't need no education<br>We don't need no thought control<br>No dark sarcasm in the classroom<br>Teachers, leave them kids alone<br><br>Hey, teacher, leave us kids alone<br><br>All in all you're just another brick in the wall<br>All in all you're just another brick in the wall<br><br><i>[Spoken:]</i><br>Wrong! Do it again!<br>Wrong! Do it again!<br>If you don't eat your meat, you can't have any pudding!<br>How can you have any pudding if you don't eat your meat?!<br>You! Yes, you, behind the bike sheds, stand still, laddy!</div>"
            }
        };

        private readonly ILogger<SongsController> _logger;

        public SongsController(ILogger<SongsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public SongModel Get(int id)
        {
            return Songs.First(x => x.Id == id);
        }

        [HttpGet]
        [Route("all")]
        public IEnumerable<SongModel> GetAll() => Songs;
    }
}
