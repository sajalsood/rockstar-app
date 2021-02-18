using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstar.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Rockstar.Controllers
{
    [ApiController]
    public class SongsController : Controller
    {
        private static readonly string BASE_URL = "https://localhost:5001/api/songs/";

        private readonly ILogger<SongsController> _logger;

        public SongsController(ILogger<SongsController> logger)
        {
            _logger = logger;
        }
       
        [HttpGet]
        [Route("songs")]
        public async Task<List<SongViewModel>> Get()
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

            return songs;
        }

        [HttpGet]
        [Route("/song/{id}")]
        public async Task<SongViewModel> Get(int id)
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

            return song;
        }

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        [Route("error")]
        public IActionResult Error()
        {
            return View();
        }

    }
}
