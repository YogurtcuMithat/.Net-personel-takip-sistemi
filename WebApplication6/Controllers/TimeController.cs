using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;


namespace WebApplication6.Controllers
{
    public class TimeController : Controller
    {
        private PersonelContext db = new PersonelContext();

        // GET: Time
        public ActionResult Index()
        {
            return View(db.Vardiyalar.ToList());
        }

        // GET: Time/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRotation timeRotation = db.Vardiyalar.Find(id);
            if (timeRotation == null)
            {
                return HttpNotFound();
            }
            return View(timeRotation);
        }

        // GET: Time/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Time/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TimeRotationId,TimeRotationName,TimeStart,TimeEnd")] TimeRotation timeRotation)
        {
            if (ModelState.IsValid)
            {
                db.Vardiyalar.Add(timeRotation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(timeRotation);
        }

        // GET: Time/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRotation timeRotation = db.Vardiyalar.Find(id);
            if (timeRotation == null)
            {
                return HttpNotFound();
            }
            return View(timeRotation);
        }

        // POST: Time/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TimeRotationId,TimeRotationName,TimeStart,TimeEnd")] TimeRotation timeRotation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(timeRotation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(timeRotation);
        }

        // GET: Time/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TimeRotation timeRotation = db.Vardiyalar.Find(id);
            if (timeRotation == null)
            {
                return HttpNotFound();
            }
            return View(timeRotation);
        }

        // POST: Time/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TimeRotation timeRotation = db.Vardiyalar.Find(id);
            db.Vardiyalar.Remove(timeRotation);
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
