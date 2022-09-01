using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication6.Models
{
    public class JobTitle
    {
        [Key]
        public int JobTitleId { get; set; }
        public string JobName { get; set; }
        public List<Personel> personelJobName { get; set; }
    }
}