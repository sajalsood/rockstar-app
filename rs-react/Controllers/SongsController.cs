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
    [Route("[controller]")]
    public class SongsController : ControllerBase
    {
        private readonly ILogger<SongsController> _logger;

        public SongsController(ILogger<SongsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<SongViewModel> Get(int id)
        {
           SongViewModel song = new SongViewModel();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync($"https://localhost:5001/api/songs/{id}"))
                {
                    string apiResponse =  await response.Content.ReadAsStringAsync();
                    song = JsonConvert.DeserializeObject<SongViewModel>(apiResponse);
                }
            }

            return song;
        }

        [HttpGet]
        [Route("all")]
        public async Task<List<SongViewModel>> GetAll()
        {
            List<SongViewModel> songs = new List<SongViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/songs/all"))
                {
                    string apiResponse =  await response.Content.ReadAsStringAsync();
                    songs = JsonConvert.DeserializeObject<List<SongViewModel>>(apiResponse);
                }
            }

            return songs;
        }
    }
}
