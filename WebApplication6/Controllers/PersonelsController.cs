using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class PersonelsController : Controller
    {
        private PersonelContext db = new PersonelContext();

        // GET: Personels
        public ActionResult Index(string SelectOption)
        {
            //var personeller = db.Personeller.Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
            //return View(personeller.ToList());
            var model = from s in db.Personeller select s;
         
            switch (SelectOption)
            {
                case "v1":
                    model = model.Where(a => a.TimeRotationId == 1).Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
                    break;
                case "v2":
                    model = model.Where(a => a.TimeRotationId == 2).Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
                    break;
                case "v3":
                    model = model.Where(a => a.TimeRotationId == 3).Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
                    break;
                case "v4":
                    model = model.Where(a => a.TimeRotationId == 4).Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
                    break;
                default:
                    model= db.Personeller.Include(p => p.bloodType).Include(p => p.JobName).Include(p => p.LocationName).Include(p => p.TimeName);
                    break;
            }


            return View(model.ToList());
        }
       
        // GET: Personels/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // GET: Personels/Create
        public ActionResult Create()
        {
            ViewBag.BloodId = new SelectList(db.KanGrubu, "BloodId", "BloodName");
            ViewBag.JobTitleId = new SelectList(db.Meslekler, "JobTitleId", "JobName");
            ViewBag.LocationId = new SelectList(db.Konumlar, "LocationId", "LocationName");
            ViewBag.TimeRotationId = new SelectList(db.Vardiyalar, "TimeRotationId", "TimeRotationName");
            return View();
        }

        // POST: Personels/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,LastName,PhoneNumber,Mail,Adress,HereditaryDiseases,UsedDrugs,BirthdayDate,PersonalityNumber,TimeRotationId,BloodId,JobTitleId,LocationId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Personeller.Add(personel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BloodId = new SelectList(db.KanGrubu, "BloodId", "BloodName", personel.BloodId);
            ViewBag.JobTitleId = new SelectList(db.Meslekler, "JobTitleId", "JobName", personel.JobTitleId);
            ViewBag.LocationId = new SelectList(db.Konumlar, "LocationId", "LocationName", personel.LocationId);
            ViewBag.TimeRotationId = new SelectList(db.Vardiyalar, "TimeRotationId", "TimeRotationName", personel.TimeRotationId);
            return View(personel);
        }

        // GET: Personels/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            ViewBag.BloodId = new SelectList(db.KanGrubu, "BloodId", "BloodName", personel.BloodId);
            ViewBag.JobTitleId = new SelectList(db.Meslekler, "JobTitleId", "JobName", personel.JobTitleId);
            ViewBag.LocationId = new SelectList(db.Konumlar, "LocationId", "LocationName", personel.LocationId);
            ViewBag.TimeRotationId = new SelectList(db.Vardiyalar, "TimeRotationId", "TimeRotationName", personel.TimeRotationId);
            return View(personel);
        }

        // POST: Personels/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,LastName,PhoneNumber,Mail,Adress,HereditaryDiseases,UsedDrugs,BirthdayDate,PersonalityNumber,TimeRotationId,BloodId,JobTitleId,LocationId")] Personel personel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(personel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BloodId = new SelectList(db.KanGrubu, "BloodId", "BloodName", personel.BloodId);
            ViewBag.JobTitleId = new SelectList(db.Meslekler, "JobTitleId", "JobName", personel.JobTitleId);
            ViewBag.LocationId = new SelectList(db.Konumlar, "LocationId", "LocationName", personel.LocationId);
            ViewBag.TimeRotationId = new SelectList(db.Vardiyalar, "TimeRotationId", "TimeRotationName", personel.TimeRotationId);
            return View(personel);
        }

        // GET: Personels/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Personel personel = db.Personeller.Find(id);
            if (personel == null)
            {
                return HttpNotFound();
            }
            return View(personel);
        }

        // POST: Personels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Personel personel = db.Personeller.Find(id);
            db.Personeller.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }


}
