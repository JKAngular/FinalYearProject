using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYPPharmAssistant.DAL;
using FYPPharmAssistant.Models.PurchaseModel;
using FYPPharmAssistant.Repository;

namespace FYPPharmAssistant.Controllers
{
    public class SupplierController : Controller
    {
        private MyContext db = new MyContext();

        // GET: Supplier
        public ActionResult Index()
        {
            return View(db.Suppliers.ToList());
        }

        // GET: Supplier/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // GET: Supplier/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Supplier/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Supplier supplier)
        {
            SupplierRepository repo = new SupplierRepository();
            if (ModelState.IsValid)
            {
                
                int countSupplier = repo.SupplierDuplicationCheck(supplier);
                //if exists. display an error.
                if (countSupplier > 0)
                {
                    ViewBag.DuplicateError = "Already Exists!";
                    return View(supplier);
                }

                int countAbbrevation = repo.SupplierAbbervationCheck(supplier);
                //if yes, display an error
                if (countAbbrevation > 0)
                {
                    ViewBag.AbbrevationDuplicateError = "Already Exists! Choose New.";
                    return View(supplier);
                }
                db.Suppliers.Add(supplier);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);
        }

        // GET: Supplier/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Supplier supplier)
        {

            SupplierRepository repo = new SupplierRepository();
            if (ModelState.IsValid)
            {
                string supplierNameCheck = supplier.Name.ToUpper();                
                string abbrevationCheck = supplier.Abbrevation.ToUpper();               

                supplier.Name = supplierNameCheck;
                supplier.Abbrevation = abbrevationCheck;
                db.Entry(supplier).State = EntityState.Modified;
                db.Suppliers.Add(supplier);                
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(supplier);         
        }

        // GET: Supplier/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Supplier supplier = db.Suppliers.Find(id);
            if (supplier == null)
            {
                return HttpNotFound();
            }
            return View(supplier);
        }

        // POST: Supplier/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Supplier supplier = db.Suppliers.Find(id);
            db.Suppliers.Remove(supplier);
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
