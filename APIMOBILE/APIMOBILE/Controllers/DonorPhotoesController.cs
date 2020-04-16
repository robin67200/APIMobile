using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using APIMOBILE.Helper;
using APIMOBILE.Models;
using Newtonsoft.Json;

namespace APIMOBILE.Controllers
{
    [Authorize]
    public class DonorPhotoesController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IHttpActionResult Post([FromBody] DonorPhoto donorPhoto)
        {
            var stream = new MemoryStream(donorPhoto.ImageArray);
            var guid = Guid.NewGuid().ToString();
            var file = String.Format("{0}.jpg", guid);
            var folder = "~/Content/Users";
            var fullPath = String.Format("{0}/{1}", folder, file);
            var response = FilesHelper.UploadPhoto(stream, folder, file);
            if (response)
            {
                donorPhoto.ImagePath = fullPath;
            }
            var user = new DonorPhoto()
            {
                ImagePath = donorPhoto.ImagePath,
                DonorId = donorPhoto.DonorId,
                Age = donorPhoto.Age,
                Gender = donorPhoto.Gender
            };

            db.DonorPhotoes.Add(user);
            db.SaveChanges();
            return StatusCode(HttpStatusCode.Created);
        }
        [AllowAnonymous]
        public IEnumerable<DonorPhoto> GetByDonor(string username)
        {
            var don = db.DonorPhotoes.Where(x => x.Donor.Username == username).ToList();

            return don;
        }
    }
}