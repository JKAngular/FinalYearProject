using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FYPPharmAssistant.DAL;
using FYPPharmAssistant.Models.InventoryModel;
using FYPPharmAssistant.Repository;

namespace FYPPharmAssistant.Controllers
{
    public class ManufacturerController : Controller
    {
        private MyContext db = new MyContext();
        ManufacturerRepository repo = new ManufacturerRepository();


        // GET: Manufacturer
        public ActionResult Index()
        {
            return View(db.Manufacturers.ToList());
        }

        // GET: Manufacturer/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // GET: Manufacturer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Manufacturer/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ManufacturerName,Description")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                //check if duplication exists
                int count = repo.ManufacturerDuplicationCheck(manufacturer);
                //if yes throw an error message
                if (count > 0)
                {
                    ViewBag.DuplicateError = "Already Exists!!";
                    return View(manufacturer);
                }
                else
                {
                    //else add new manufacturer and return to Index
                    db.Manufacturers.Add(manufacturer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }                
            }

            return View(manufacturer);
        }

        // GET: Manufacturer/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturer/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ManufacturerName,Description")] Manufacturer manufacturer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manufacturer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(manufacturer);
        }

        // GET: Manufacturer/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            if (manufacturer == null)
            {
                return HttpNotFound();
            }
            return View(manufacturer);
        }

        // POST: Manufacturer/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Manufacturer manufacturer = db.Manufacturers.Find(id);
            db.Manufacturers.Remove(manufacturer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        //using formcollection to create 
        [HttpPost]
        public void InsertBulk(FormCollection coll)
        {
           /*
                Manufacturer m = new Manufacturer();
                m.ManufacturerName = coll["ManufacturerName"];
                m.Description = coll["Description"];
                db.Manufacturers.Add(m);
                db.SaveChanges();
            */
            string[] _name = coll["ManufacturerName"].Split(',');
            string[] _description = coll["Description"].Split(',');
            int count = _name.Count();
            for (int i = 0; i < count; i++)
            {
                Manufacturer manu = new Manufacturer();
                manu.ManufacturerName = _name[i];
                manu.Description = _description[i];
                db.Manufacturers.Add(manu);
                db.SaveChanges();
            }




               /* By Dixanta sir
                * 
                * foreach (var item in coll.Get("ManufacturerName").Split(",".ToArray()))
                {
                    Response.Write(item);
                }*/

            /*int count = coll.Count;


            if (count == 0)
            {
                return View("ChamForm", "Test");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    Manufacturer m = new Manufacturer();
                    m.ManufacturerName = coll["ManufacturerName[""];
                    m.Description = coll["Description[" + i + "]"];
                    db.Manufacturers.Add(m);
                    db.SaveChanges();
                }
            }*/
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
