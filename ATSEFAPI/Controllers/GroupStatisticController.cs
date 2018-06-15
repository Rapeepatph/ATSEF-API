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
    [Route("api/GroupStatistic")]
    public class GroupStatisticController : Controller
    {

        private readonly ATSEF_DBContext _context;
        private readonly ClaimsPrincipal _caller;


        //public FlightProfilesController(ATSEF_DBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        public GroupStatisticController(ATSEF_DBContext context, IHttpContextAccessor httpContextAccessor)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
           
        }
        // GET: api/GroupStatistic
        [HttpGet]
        public IEnumerable<GroupStatistic> GetGroupStatistic()
        {
            return _context.GroupStatistic;
        }

        // GET: api/GroupStatistic/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetGroupStatistic([FromRoute] uint id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var groups = await _context.GroupStatistic.SingleOrDefaultAsync(x => x.Id == id);
            if (groups == null)
            {
                return NotFound();
            }

            return Ok(groups);
        }
        
        // POST: api/GroupStatistic
        [HttpPost]
        public async Task<IActionResult> PostGroupStatistic([FromBody]GroupStatistic value)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.GroupStatistic.Add(value);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetGroupStatistic", new { id = value.Id }, value);
        }
        
        // PUT: api/GroupStatistic/5
        [HttpPut("{id}")]
        public void PutGroupStatistic(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void DeleteGroupStatistic(int id)
        {
        }
    }
}
