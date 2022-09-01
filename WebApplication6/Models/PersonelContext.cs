using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebApplication6.Models;

namespace WebApplication6.Models
{
    public class PersonelContext:DbContext
    {
        public PersonelContext():base("comDb")
        {
            Database.SetInitializer(new PersonelInitializer());
        }
        public DbSet<JobTitle> Meslekler { get; set; }
        public DbSet<Location> Konumlar { get; set; }
        public DbSet<Personel> Personeller { get; set; }
        public DbSet<TimeRotation> Vardiyalar { get; set; }
        public DbSet<BloodType> KanGrubu { get; set; }
    }
}