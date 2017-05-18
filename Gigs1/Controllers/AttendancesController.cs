using Gigs1.Models;
using Microsoft.AspNet.Identity;
using System.Web.Http;

namespace Gigs1.Controllers
{

    [Authorize]
    public class AttendancesController : ApiController
    {
        private ApplicationDbContext _context;

        public AttendancesController()
        {
            _context = new ApplicationDbContext();
        }
        [HttpPost]
        public IHttpActionResult Attend([FromBody] int gigId)
        {
            var attendence = new Attendance
            {
                GigId = gigId,
                AttendeeId = User.Identity.GetUserId()
            };
            _context.Attendances.Add(attendence);
            _context.SaveChanges();

            return Ok();
        }
    }
}
