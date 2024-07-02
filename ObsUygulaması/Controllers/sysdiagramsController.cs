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
    public class sysdiagramsController : Controller
    {
        private obssaEntities db = new obssaEntities();

        // GET: sysdiagrams
        public ActionResult Index()
        {
            return View(db.sysdiagrams.ToList());
        }

        // GET: sysdiagrams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: sysdiagrams/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "name,principal_id,diagram_id,version,definition")] sysdiagrams sysdiagrams)
        {
            if (ModelState.IsValid)
            {
                db.sysdiagrams.Add(sysdiagrams);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // POST: sysdiagrams/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "name,principal_id,diagram_id,version,definition")] sysdiagrams sysdiagrams)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sysdiagrams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sysdiagrams);
        }

        // GET: sysdiagrams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            if (sysdiagrams == null)
            {
                return HttpNotFound();
            }
            return View(sysdiagrams);
        }

        // POST: sysdiagrams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sysdiagrams sysdiagrams = db.sysdiagrams.Find(id);
            db.sysdiagrams.Remove(sysdiagrams);
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
