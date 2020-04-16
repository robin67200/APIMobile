using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIMOBILE.Models
{
    public class Donor
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public ICollection<DonorPhoto> DonorPhotos { get; set; }
        
    }
}