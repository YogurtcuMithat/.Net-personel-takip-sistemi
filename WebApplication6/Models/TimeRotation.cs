using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class TimeRotation
    {
        [Key]
        public int TimeRotationId { get; set; }
        public string TimeRotationName { get; set; }
        public TimeSpan TimeStart { get; set; }
        public TimeSpan TimeEnd { get; set; }
        public List<Personel> PersonelTimeRotation { get; set; }
    }
}