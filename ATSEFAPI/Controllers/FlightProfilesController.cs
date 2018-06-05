using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSEFAPI.DBModels;

namespace ATSEFAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/FlightProfiles")]
    public class FlightProfilesController : Controller
    {
        private readonly ATSEF_DBContext _context;

        public FlightProfilesController(ATSEF_DBContext context)
        {
            _context = context;
        }

        // GET: api/FlightProfiles
        [HttpGet]
        public IEnumerable<FlightProfile> GetFlightProfile()
        {
            return _context.FlightProfile;
        }

        // GET: api/FlightProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFlightProfile([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightProfile = await _context.FlightProfile.SingleOrDefaultAsync(m => m.Id == id);

            if (flightProfile == null)
            {
                return NotFound();
            }

            return Ok(flightProfile);
        }

        // PUT: api/FlightProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlightProfile([FromRoute] uint id, [FromBody] FlightProfile flightProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != flightProfile.Id)
            {
                return BadRequest();
            }

            _context.Entry(flightProfile).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlightProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/FlightProfiles
        [HttpPost]
        public async Task<IActionResult> PostFlightProfile([FromBody] FlightProfile flightProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.FlightProfile.Add(flightProfile);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFlightProfile", new { id = flightProfile.Id }, flightProfile);
        }

        // DELETE: api/FlightProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlightProfile([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var flightProfile = await _context.FlightProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (flightProfile == null)
            {
                return NotFound();
            }

            _context.FlightProfile.Remove(flightProfile);
            await _context.SaveChangesAsync();

            return Ok(flightProfile);
        }

        private bool FlightProfileExists(uint id)
        {
            return _context.FlightProfile.Any(e => e.Id == id);
        }
    }
}