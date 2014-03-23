using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.EventDBContext__MvcEvent;
namespace TestMVC.Controllers
{
    public class EventController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Events/

        public ActionResult Index()
        {
            return View(db.Events.ToList());
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(string name = "")
        {
            Event myEvent = db.Events.Find(name);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        //
        // GET: /Movie/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Movie/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Event myEvent)
        {
            if (ModelState.IsValid)
            {
                db.Events.Add(myEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(myEvent);
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(string name = "")
        {
            Event myEvent = db.Events.Find(name);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Event myEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(myEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(myEvent);
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(string name = "")
        {
            Event myEvent = db.Events.Find(name);
            if (myEvent == null)
            {
                return HttpNotFound();
            }
            return View(myEvent);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        {
            Event myEvent = db.Events.Find(name);
            db.Events.Remove(myEvent);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}