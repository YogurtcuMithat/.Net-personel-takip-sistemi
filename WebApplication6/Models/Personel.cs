using System;
using System.ComponentModel.DataAnnotations;

namespace WebApplication6.Models
{
    public class Personel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Mail { get; set; }
        public string Adress { get; set; }
        public string HereditaryDiseases { get; set; }
        public string UsedDrugs { get; set; }
        public DateTime BirthdayDate { get; set; }
        public string PersonalityNumber { get; set; }




        public int TimeRotationId { get; set; }
        public TimeRotation TimeName { get; set; }
        public int BloodId { get; set; }
        public BloodType bloodType { get; set; }
        public int JobTitleId { get; set; }
        public JobTitle JobName { get; set; }
        public int LocationId { get; set; }
        public Location LocationName { get; set; }

    }
}