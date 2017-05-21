using Gigs1.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;
using Gigs1.Dtos;

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
        public IHttpActionResult Attend(AttendanceDto dto)
        {
            var userId = User.Identity.GetUserId();

            var exists = _context.Attendances.Any(a => a.AttendeeId == userId && a.GigId == dto.GigId);

            if (exists)
            {
                return BadRequest("The attendance already exists.");
            }
            var attendence = new Attendance
            {
                GigId = dto.GigId,
                AttendeeId = userId
            };
            _context.Attendances.Add(attendence);
            _context.SaveChanges();

            return Ok();
        }
    }
}
