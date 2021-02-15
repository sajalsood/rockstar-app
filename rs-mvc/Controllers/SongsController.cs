using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Rockstar.Models;

namespace Rockstar.Controllers
{
    [ApiController]
    [Route("songs")]
    public class SongsController : Controller
    {
        private static readonly string BASE_URL = "https://localhost:5001/api/songs/";

        private readonly ILogger<SongsController> _logger;

        public SongsController(ILogger<SongsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SongViewModel> songs = new List<SongViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BASE_URL))
                {
                    string apiResponse =  await response.Content.ReadAsStringAsync();
                    songs = JsonConvert.DeserializeObject<List<SongViewModel>>(apiResponse);
                }
            }

            return View(songs);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Song(int id)
        {
           SongViewModel song = new SongViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(BASE_URL + id))
                {
                    string apiResponse =  await response.Content.ReadAsStringAsync();
                    song = JsonConvert.DeserializeObject<SongViewModel>(apiResponse);
                }
            }

           return View(song);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
