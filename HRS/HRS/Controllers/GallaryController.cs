using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using HRS.Models;
using HRS.Repository;

namespace HRS.Controllers
{
    public class GallaryController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /Gallary/
        public ActionResult Index()
        {
            return View(db.Gallary.ToList());
        }

        // GET: /Gallary/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallary gallary = db.Gallary.Find(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }

        // GET: /Gallary/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Gallary/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Title,Description")] Gallary gallary)
        {
            if (ModelState.IsValid)
            {
                db.Gallary.Add(gallary);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gallary);
        }

        // GET: /Gallary/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallary gallary = db.Gallary.Find(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }

        // POST: /Gallary/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Title,Description")] Gallary gallary)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gallary).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gallary);
        }

        // GET: /Gallary/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gallary gallary = db.Gallary.Find(id);
            if (gallary == null)
            {
                return HttpNotFound();
            }
            return View(gallary);
        }

        // POST: /Gallary/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gallary gallary = db.Gallary.Find(id);
            db.Gallary.Remove(gallary);
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
