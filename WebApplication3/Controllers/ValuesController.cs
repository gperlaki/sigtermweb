using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            Console.WriteLine($"{DateTime.Now} - {Environment.MachineName} - Request received");

            //System.Diagnostics.Debug.WriteLine($"{DateTime.Now} - {Environment.MachineName} - Request received");

            return Ok("Well, okay then");
        }
    }
}
