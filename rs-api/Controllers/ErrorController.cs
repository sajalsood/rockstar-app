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
    public class ErrorController : ControllerBase
    {
       [Route("{*url}", Order = 999)]
        public IActionResult Error() 
        {
             return StatusCode(404, "Not Found");
        }
    }
}
