using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestMVC.Models;
using TestMVC.CustomerDBContext__MvcCustomer;

namespace TestMVC.Controllers
{
    public class CustomerController : Controller
    {
        private Models_ db = new Models_();

        //
        // GET: /Movie/

        public ActionResult Index()
        {
            return View(db.Customers.ToList());
        }

        //
        // GET: /Movie/Details/5

        public ActionResult Details(string name = "")
        {
            Customer customer = db.Customers.Find(name);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
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
        public ActionResult Create(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Customers.Add(customer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customer);
        }

        //
        // GET: /Movie/Edit/5

        public ActionResult Edit(string name = "")
        {
            Customer customer = db.Customers.Find(name);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Movie/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Customer customer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        //
        // GET: /Movie/Delete/5

        public ActionResult Delete(string name = "")
        {
            Customer customer = db.Customers.Find(name);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //
        // POST: /Movie/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string name)
        {
            Customer customer = db.Customers.Find(name);
            db.Customers.Remove(customer);
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