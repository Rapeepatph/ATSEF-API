extern alias MySqlConnectorAlias;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ATSEFAPI.DBModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ATSEFAPI.Model;
//using System.Data.SqlClient;
using System.Globalization;
using Microsoft.Extensions.Configuration;
using System.Data.Common;
//using MySql.Data.MySqlClient;

namespace ATSEFAPI.Controllers
{
    
    //[Produces("application/json")]
    [Authorize(Policy = "ApiUser")]
    [Route("api/FlightProfiles")]
    public class FlightProfilesController : Controller
    {
        private readonly ATSEF_DBContext _context;
        private readonly ClaimsPrincipal _caller;
        private readonly IConfiguration _iconfiguraton;


        //public FlightProfilesController(ATSEF_DBContext context, UserManager<AppUser> userManager, IHttpContextAccessor httpContextAccessor)
        public FlightProfilesController(ATSEF_DBContext context, IHttpContextAccessor httpContextAccessor,IConfiguration iconfiguraton)
        {
            _caller = httpContextAccessor.HttpContext.User;
            _context = context;
            _iconfiguraton = iconfiguraton;
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
        // GET: api/FlightProfiles/strtDate/endDate/arrival
        [HttpGet("{strtDate}/{endDate}/{arrival}")]
        public async Task<IActionResult> GetFlightProfileGroup(DateTime strtDate, DateTime endDate,string arrival)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            List<FlightGroup> result = new List<FlightGroup>();
            string[] ArrivalAirports = arrival.Split(',');
            
            foreach (string airport in ArrivalAirports)
            {
                var flightProfiles = new List<FlightGroupDetail>();
                string constring = _iconfiguraton.GetSection("ConnectionStrings").GetSection("ATSEFEntities").Value;
                string commandInput = "SELECT count(*),ARRIVAL,RUNWAY_HEADING,AIRCRAFT,SECOND_ENTRY_SECTOR,min(SECOND_TRAVEL_TIME),max(SECOND_TRAVEL_TIME),AVG(SECOND_TRAVEL_TIME),39 as P15, 40 as P20,48 as P80 ,50 as P85 FROM ATSEF_DB.FLIGHT_PROFILE where ARRIVAL = '" + airport + "' and ARRIVAL_TIME between '" + strtDate.ToString("yyyy-MM-dd",
                                CultureInfo.InvariantCulture) + "' and '" + endDate.ToString("yyyy-MM-dd",
                                CultureInfo.InvariantCulture) + "' group by AIRCRAFT,RUNWAY_HEADING,SECOND_ENTRY_SECTOR;";

                //string commandInput = "SELECT count(*),ARRIVAL,RUNWAY_HEADING,AIRCRAFT,SECOND_ENTRY_SECTOR ,min(SECOND_TRAVEL_TIME),max(SECOND_TRAVEL_TIME),AVG(SECOND_TRAVEL_TIME), 40 as P20,48 as P80 FROM ATSEF_DB.FLIGHT_PROFILE where ARRIVAL='VTBS' and ARRIVAL_TIME between '2018-01-01' and '2018-01-27' group by AIRCRAFT,RUNWAY_HEADING,SECOND_ENTRY_SECTOR  ;";
                try
                {
                    using (DbConnection connection = new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection(constring))
                    {
                         connection.Open();
                        using (DbCommand command = new MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlCommand(commandInput, (MySqlConnectorAlias::MySql.Data.MySqlClient.MySqlConnection)connection))
                        {
                            using (DbDataReader reader = command.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var groupDetail = new FlightGroupDetail()
                                    {
                                        Amount = (long)reader["count(*)"],
                                        Arrival = reader["ARRIVAL"]==DBNull.Value?"": (string)reader["ARRIVAL"],
                                        RunwayHeading = (reader["RUNWAY_HEADING"]== DBNull.Value? "": (string)(reader["RUNWAY_HEADING"])),
                                        Aircraft = (reader["AIRCRAFT"]== DBNull.Value? "":(string)(reader["AIRCRAFT"])),
                                        SecondEntrySector = (int)reader["SECOND_ENTRY_SECTOR"],
                                        Min = (long)reader["min(SECOND_TRAVEL_TIME)"],
                                        Max = (long)reader["max(SECOND_TRAVEL_TIME)"],
                                        Avg = (decimal)reader["AVG(SECOND_TRAVEL_TIME)"],
                                        P15 = (long)reader["P15"],
                                        P20 = (long)reader["P20"],
                                        P80 = (long)reader["P80"],
                                        P85 = (long)reader["P85"]

                                    };
                                    flightProfiles.Add(groupDetail);
                                }
                            }
                        }
                        //DbCommand command = new MySql.Data.MySqlClient.MySqlCommand(commandInput, (MySql.Data.MySqlClient.MySqlConnection)connection);
                    }
                }
                catch(Exception e)
                {
                    throw e;
                }

                //var flightProfiles = await _context.FlightProfile.Where(m => m.ArrivalTime >= strtDate && m.ArrivalTime <= endDate && m.Arrival == airport)
                //    .GroupBy(a => new { a.Aircraft, a.RunwayHeading, a.SecondEntrySector })
                //    .Select(group => new FlightGroupDetail
                //    {
                //        Aircraft = group.Key.Aircraft,
                //        RunwayHeading = group.Key.RunwayHeading,
                //        Amount = group.Count(),
                //        Arrival = airport,
                //        SecondEntrySector = group.Key.SecondEntrySector,

                //    }).ToListAsync();
                

                if (flightProfiles == null)
                {
                    return NotFound();
                }
                FlightGroup flightGroup = new FlightGroup
                {
                    Arrival = airport,
                    StartTime = strtDate,
                    EndingTime = endDate,
                    ListFlightGroups = flightProfiles
                };
                 result.Add(flightGroup);
            }
            
            
            return Ok(result);
        }
        // GET: api/FlightProfiles/arrival/strtDate/endDate/aircraft/runwayHeading/entrySector
        [HttpGet("{arrival}/{strtDate}/{endDate}/{aircraft}/{runwayHeading}/{entrySector}")]
        public async Task<IActionResult> GetFlightProfileGroupDetails(string arrival,DateTime strtDate, DateTime endDate,string aircraft,string runwayHeading,int entrySector)
        {
            var result = new List<FlightProfile>();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if (runwayHeading == "X")
            {
                 result = await _context.FlightProfile.Where(m => m.ArrivalTime >= strtDate && m.ArrivalTime <= endDate && m.Arrival == arrival
                                                            && m.Aircraft == aircraft && (m.RunwayHeading == ""||m.RunwayHeading==null) && m.SecondEntrySector == entrySector).ToListAsync();
            }
            else
            {
                 result = await _context.FlightProfile.Where(m => m.ArrivalTime >= strtDate && m.ArrivalTime <= endDate && m.Arrival == arrival
                                                            && m.Aircraft == aircraft && m.RunwayHeading == runwayHeading && m.SecondEntrySector == entrySector).ToListAsync();
            }
            
            


            return Ok(result);
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