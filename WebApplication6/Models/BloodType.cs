using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class BloodType
    {
        [Key]
        public int BloodId { get; set; }
        public string BloodName { get; set; }
    }
}