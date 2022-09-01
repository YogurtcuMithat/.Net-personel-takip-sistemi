using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class PersonelInitializer : DropCreateDatabaseIfModelChanges<PersonelContext>
    {
        protected override void Seed(PersonelContext context)
        {
            List<JobTitle> jobTitles = new List<JobTitle>()
            {
                new JobTitle(){JobName="Müdür"},
                new JobTitle(){JobName="Amir"},
                new JobTitle(){JobName="Çalışan"}
            };
            foreach (JobTitle jobTitle in jobTitles)
                context.Meslekler.Add(jobTitle);
            context.SaveChanges();

            List<Location> locations = new List<Location>()
            {
                new Location(){LocationName="1. bölge" ,LocationDepth=103.98},
                new Location(){LocationName="2. bölge" ,LocationDepth=42.5 },
                new Location(){LocationName="3. bölge" ,LocationDepth=452.345},
            };
            foreach (Location location in locations)
                context.Konumlar.Add(location);
            context.SaveChanges();

            List<TimeRotation> rotations = new List<TimeRotation>()
            {
                new TimeRotation(){TimeRotationName="1. vardiya",TimeStart=TimeSpan.FromHours(08.00),TimeEnd=TimeSpan.FromHours(15.59)},
                new TimeRotation(){TimeRotationName="2. vardiya",TimeStart=TimeSpan.FromHours(17.00),TimeEnd=TimeSpan.FromHours(23.59)},
                new TimeRotation(){TimeRotationName="3. vardiya",TimeStart=TimeSpan.FromHours(00.00),TimeEnd=TimeSpan.FromHours(07.59)},
                new TimeRotation(){TimeRotationName="Müdür vardiyası",TimeStart=TimeSpan.FromHours(09.00),TimeEnd=TimeSpan.FromHours(17.00)}
            };
            foreach (var item in rotations)
                context.Vardiyalar.Add(item);
            context.SaveChanges();

            List<BloodType> bloods = new List<BloodType>()
            {
                new BloodType(){BloodName="A Rh+"},
                new BloodType(){BloodName="A Rh-"},
                new BloodType(){BloodName="AB Rh+"},
                new BloodType(){BloodName="AB Rh-"},
                new BloodType(){BloodName="B Rh+"},
                new BloodType(){BloodName="B Rh-"},
                new BloodType(){BloodName="0 Rh+"},
                new BloodType(){BloodName="0 Rh-"},
            };
            foreach (var item in bloods)
                context.KanGrubu.Add(item);
            context.SaveChanges();

            List<Personel> personels = new List<Personel>()
            {
                new Personel(){Name="Mithat", LastName="Yogurtcu",
                PhoneNumber="5303394296",JobTitleId=2,LocationId=3,
                Adress="Çumra",Mail="bilmemki",HereditaryDiseases=null,
                BloodId=2,BirthdayDate=DateTime.Now,TimeRotationId=3,
                UsedDrugs=null, PersonalityNumber="6194200"},
                new Personel(){Name="Mithat", LastName="Yogurtcu",
                PhoneNumber="5303394296",JobTitleId=2,LocationId=3,
                Adress="Konya",Mail="Bilirmisin",HereditaryDiseases="Şeker",
                BloodId=2,BirthdayDate=DateTime.Now,TimeRotationId=3,
                UsedDrugs=null, PersonalityNumber="6194200"},
                new Personel(){Name="Mithat", LastName="Yogurtcu",
                PhoneNumber="5303394296",JobTitleId=2,LocationId=3,
                Adress="Kırıkkale",Mail="yarın",HereditaryDiseases="Astım",
                BloodId=2,BirthdayDate=DateTime.Now,TimeRotationId=3,
                UsedDrugs="insulin", PersonalityNumber="6194200"}
            };
            foreach (var personel in personels)
                context.Personeller.Add(personel);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}