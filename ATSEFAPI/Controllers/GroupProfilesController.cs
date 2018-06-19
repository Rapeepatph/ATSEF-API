using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ATSEFAPI.DBModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ATSEFAPI.Controllers
{
    [Authorize(Policy = "ApiUser")]
    [Produces("application/json")]
    [Route("api/GroupProfiles")]
    public class GroupProfilesController : Controller
    {
        private readonly ATSEF_DBContext _context;
        private readonly ClaimsPrincipal _caller;

        //public FlightProfilesController(ATSEF_DBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        public GroupProfilesController(ATSEF_DBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;

        }
        // GET: api/GroupProfiles
        [HttpGet]
        public IEnumerable<GroupProfile> GetGroupProfile()
        {
            return _context.GroupProfile;
        }

        // GET: api/GroupProfiles/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupProfile([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var groups = await _context.GroupProfile.SingleOrDefaultAsync(x => x.Id == id);
            if (groups == null)
            {
                return NotFound();
            }

            return Ok(groups);
        }
        
        // POST: api/GroupProfiles
        [HttpPost]
        public async Task<IActionResult> PostGroupProfile([FromBody]GroupProfile value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            else if (NameGroupProfileExists(value.Name))
            {
                return new StatusCodeResult(StatusCodes.Status409Conflict);
            }
            try
            {
                _context.GroupProfile.Add(value);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
            return CreatedAtAction("GetGroupProfile", new { id = value.Id }, value);
        }
        
        // PUT: api/GroupProfiles/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGroupProfile(int id, [FromBody]GroupProfile groupProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (id != groupProfile.Id)
            {
                return BadRequest();
            }

            try
            {
                var existingActivate = await _context.GroupProfile.Where(x => x.Status == true).SingleOrDefaultAsync(); 
                if(existingActivate != null && existingActivate.Id !=id)
                {
                    existingActivate.Status = false;
                    _context.Entry(existingActivate).State = EntityState.Modified;
                }
                _context.Entry(groupProfile).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw e;
            }
            return NoContent();
        }

        // DELETE: api/GroupProfiles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGroupProfile([FromRoute] uint id)
        {
            var groupProfile = await _context.GroupProfile.SingleOrDefaultAsync(m => m.Id == id);
            if (groupProfile == null)
            {
                return NotFound();
            }
            try
            {
                _context.GroupProfile.Remove(groupProfile);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            try
            {
                var groupStatistics = await _context.GroupStatistic.Where(x => x.ProfileId == groupProfile.Id).ToListAsync();
                _context.GroupStatistic.RemoveRange(groupStatistics);
                await _context.SaveChangesAsync();
            }
            catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok(groupProfile);
        }
        private bool NameGroupProfileExists(string name)
        {
            return _context.GroupProfile.Any(e => e.Name == name);
        }
    }
}
