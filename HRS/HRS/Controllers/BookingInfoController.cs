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
    public class BookingInfoController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /BookingInfo/
        public ActionResult Index()
        {
            var bookinginfo = db.BookingInfo.Include(b => b.User);
            return View(bookinginfo.ToList());
        }

        // GET: /BookingInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookinginfo = db.BookingInfo.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinginfo);
        }

        // GET: /BookingInfo/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.User, "ID", "UserName");
            return View();
        }

        // POST: /BookingInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,UserID,FullName,Address,Email,Phone,CheckInTime,CheckOutTime,Comments")] BookingInfo bookinginfo)
        {
            if (ModelState.IsValid)
            {
                db.BookingInfo.Add(bookinginfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserID = new SelectList(db.User, "ID", "UserName", bookinginfo.UserID);
            return View(bookinginfo);
        }

        // GET: /BookingInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookinginfo = db.BookingInfo.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.User, "ID", "UserName", bookinginfo.UserID);
            return View(bookinginfo);
        }

        // POST: /BookingInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,UserID,FullName,Address,Email,Phone,CheckInTime,CheckOutTime,Comments")] BookingInfo bookinginfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bookinginfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.User, "ID", "UserName", bookinginfo.UserID);
            return View(bookinginfo);
        }

        // GET: /BookingInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BookingInfo bookinginfo = db.BookingInfo.Find(id);
            if (bookinginfo == null)
            {
                return HttpNotFound();
            }
            return View(bookinginfo);
        }

        // POST: /BookingInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BookingInfo bookinginfo = db.BookingInfo.Find(id);
            db.BookingInfo.Remove(bookinginfo);
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
