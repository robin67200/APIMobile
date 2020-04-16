using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace APIMOBILE.Models
{
    public class DonorPhoto
    {
        public int Id { get; set; }
        public string ImagePath { get; set; }

        [ForeignKey("Donor")]
        public int DonorId { get; set; }
        public Donor Donor { get; set; }

        [NotMapped]
        public byte[] ImageArray { get; set; }

        public int Age { get; set; }
        public string Gender { get; set; }

    }
}