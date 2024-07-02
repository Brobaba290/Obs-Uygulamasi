using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ObsUygulaması.Models;

namespace ObsUygulaması.Controllers
{
    public class DersController : Controller
    {
        private obssaEntities db = new obssaEntities();

        // GET: Ders
        public ActionResult Index()
        {
            var ders = db.Ders.Include(d => d.Ogrenci);
            return View(ders.ToList());
        }

        // GET: Ders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // GET: Ders/Create
        public ActionResult Create()
        {
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad");
            return View();
        }

        // POST: Ders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DersAdı,OgrId")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Ders.Add(ders);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad", ders.OgrId);
            return View(ders);
        }

        // GET: Ders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad", ders.OgrId);
            return View(ders);
        }

        // POST: Ders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DersAdı,OgrId")] Ders ders)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ders).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad", ders.OgrId);
            return View(ders);
        }

        // GET: Ders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ders ders = db.Ders.Find(id);
            if (ders == null)
            {
                return HttpNotFound();
            }
            return View(ders);
        }

        // POST: Ders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ders ders = db.Ders.Find(id);
            db.Ders.Remove(ders);
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
