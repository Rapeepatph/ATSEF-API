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
        public void PutGroupProfile(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteGroupProfile(int id)
        {
        }
    }
}
