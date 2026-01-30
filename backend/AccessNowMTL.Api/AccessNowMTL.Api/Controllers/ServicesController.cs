using AccessNowMTL.Api.Data;
using AccessNowMTL.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace AccessNowMTL.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServicesController : ControllerBase
    {
        // GET: /api/Services
        [HttpGet]
        public ActionResult<List<Service>> GetAll()
        {
            return Ok(ServiceRepository.GetAll());
        }

        // GET: /api/Services/{id}
        [HttpGet("{id}")]
        public ActionResult<Service> GetById(int id)
        {
            var service = ServiceRepository.GetById(id);
            if (service == null) return NotFound();

            return Ok(service);
        }

        // GET: /api/Services/search?category=...&borough=...
        [HttpGet("search")]
        public ActionResult<List<Service>> Search(
            [FromQuery] string? category,
            [FromQuery] string? borough)
        {
            var results = ServiceRepository.Search(category, borough);
            return Ok(results);
        }

        // POST: /api/Services
        [HttpPost]
        public ActionResult<Service> Create([FromBody] Service service)
        {
            var created = ServiceRepository.Add(service);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: /api/Services/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Service service)
        {
            bool ok = ServiceRepository.Update(id, service);
            if (!ok) return NotFound();

            return NoContent();
        }

        // DELETE: /api/Services/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool ok = ServiceRepository.Delete(id);
            if (!ok) return NotFound();

            return NoContent();
        }
    }
}
