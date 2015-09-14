using FYPPharmAssistant.Models.InventoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FYPPharmAssistant.Controllers
{
    public class TESTController : Controller
    {
        // GET: TEST
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ChamForm()
        {
            Manufacturer m = new Manufacturer();
            return View(m);
        }
    }
}