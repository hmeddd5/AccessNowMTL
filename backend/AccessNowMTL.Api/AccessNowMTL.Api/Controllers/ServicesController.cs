using Microsoft.AspNetCore.Mvc;
using AccessNowMTL.Api.Models;

namespace AccessNowMTL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            var services = new[]
            {
                new Service { Id = 1, Name = "CLSC", Category = "Health" },
                new Service { Id = 2, Name = "Housing Help", Category = "Housing" },
                new Service { Id = 3, Name = "Immigration Help", Category = "Immigration" }
            };

            return Ok(services);
        }
    }
}
