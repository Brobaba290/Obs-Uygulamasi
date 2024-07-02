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
    public class NotsController : Controller
    {
        private obssaEntities db = new obssaEntities();

        // GET: Nots
        public ActionResult Index()
        {
            var not = db.Not.Include(n => n.Ders).Include(n => n.Ogrenci);
            return View(not.ToList());
        }

        // GET: Nots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Not.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        // GET: Nots/Create
        public ActionResult Create()
        {
            ViewBag.DersId = new SelectList(db.Ders, "Id", "DersAdı");
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad");
            ViewBag.OgrenciId = new SelectList(db.Ogrenci, "Id", "No");

            return View();
        }

        // POST: Nots/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Vize1,Vize2,Final,GeçtiMiKaldiMi,OgrId,DersId,OgrenciId")] Not not)
        {
            if (ModelState.IsValid)
            {
                db.Not.Add(not);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.DersId = new SelectList(db.Ders, "Id", "DersAdı", not.DersId);
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad", not.OgrId);
            ViewBag.OgrenciId = new SelectList(db.Ogrenci, "Id", "No",not.Ogrenci);
            return View(not);
        }

        // GET: Nots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Not.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            ViewBag.DersId = new SelectList(db.Ders, "Id", "DersAdı", not.DersId);
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad");
            ViewBag.OgrenciId = new SelectList(db.Ogrenci, "Id", "No");
            return View(not);
        }

        // POST: Nots/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Vize1,Vize2,Final,GeçtiMiKaldiMi,OgrId,DersId,OgrenciId")] Not not)
        {
            if (ModelState.IsValid)
            {
                db.Entry(not).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.DersId = new SelectList(db.Ders, "Id", "DersAdı", not.DersId);
            ViewBag.OgrId = new SelectList(db.Ogrenci, "Id", "AdSoyad", not.OgrId);
            return View(not);
        }

        // GET: Nots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Not not = db.Not.Find(id);
            if (not == null)
            {
                return HttpNotFound();
            }
            return View(not);
        }

        // POST: Nots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Not not = db.Not.Find(id);
            db.Not.Remove(not);
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
