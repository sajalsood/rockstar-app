using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rockstar.Models;
using Newtonsoft.Json;

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

        //[HttpGet]
        //public SongViewModel Get(int id)
        //{
        //    return Songs.First(x => x.Id == id);
        //}

        [HttpGet]
        [Route("all")]
        public async Task<List<SongViewModel>> GetAll()
        {
            Console.WriteLine("here");
            List<SongViewModel> songs = new List<SongViewModel>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:5001/api/Songs/all"))
                {
                    Console.WriteLine(response);

                    string apiResponse =  await response.Content.ReadAsStringAsync();
                    songs = JsonConvert.DeserializeObject<List<SongViewModel>>(apiResponse);
                }
            }

            return songs;
        }
    }
}
