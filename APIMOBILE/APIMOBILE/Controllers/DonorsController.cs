using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using APIMOBILE.Helper;
using APIMOBILE.Models;

namespace APIMOBILE.Controllers
{
    [Authorize]
    public class DonorsController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult Post([FromBody] Donor donorUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new Donor()
            {
                Username = donorUser.Username,
            };

            db.Donors.Add(user);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        [AllowAnonymous]
        public Task<Donor> GetByName(string username)
        {
            var don = db.Donors.FirstOrDefaultAsync(p => p.Username == username);
            return don;
        }

        public async Task<IEnumerable<Donor>> GetAll()
        {
            var all =  await db.Donors.OrderByDescending(user => user.Id).ToListAsync();

            return all;
        }
    }
}