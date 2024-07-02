using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ObsUygulaması.Models
{
    public class DuyurusController : Controller
    {
        private obssaEntities db = new obssaEntities();

        // GET: Duyurus
        public ActionResult Index()
        {
            return View(db.Duyuru.ToList());
        }

        // GET: Duyurus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // GET: Duyurus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Duyurus/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Baslik,Icerik,Tarih")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                duyuru.Tarih = DateTime.Now;
                db.Duyuru.Add(duyuru);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(duyuru);
        }

        // GET: Duyurus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Duyurus/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Icerik,Tarih")] Duyuru duyuru)
        {
            if (ModelState.IsValid)
            {
                db.Entry(duyuru).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(duyuru);
        }

        // GET: Duyurus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Duyuru duyuru = db.Duyuru.Find(id);
            if (duyuru == null)
            {
                return HttpNotFound();
            }
            return View(duyuru);
        }

        // POST: Duyurus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Duyuru duyuru = db.Duyuru.Find(id);
            db.Duyuru.Remove(duyuru);
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
