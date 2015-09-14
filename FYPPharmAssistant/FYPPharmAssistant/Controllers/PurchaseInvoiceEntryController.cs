using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FYPPharmAssistant.ViewModel;
using FYPPharmAssistant.Models.PurchaseModel;
using FYPPharmAssistant.Models.InventoryModel;
using FYPPharmAssistant.DAL;
using FYPPharmAssistant.Repository;

namespace FYPPharmAssistant.Controllers
{
    public class PurchaseInvoiceEntryController : Controller
    {
        Item _item = new Item();        
        Stock _stock = new Stock();
        MyContext db = new MyContext();
        private PurchaseInvoiceEntryRepository repo = new PurchaseInvoiceEntryRepository();
        List<PurchaseInvoiceEntryViewModel> tempList = MyProductList.GetInstance();
       // List<PurchaseInvoiceEntryViewModel> tempList = new List<PurchaseInvoiceEntryViewModel>();

        // GET: PurchaseInvoiceEntry
        public ActionResult Index()
        {
            var vm = new PurchaseInvoiceEntryViewModel();      
            return View(vm);
        }

        [HttpPost]
        public ActionResult Index(PurchaseInvoiceEntryViewModel vm)
        {            
            try
            {
                Purchase _purchase = new Purchase() { 
                    SupplierID = vm.SelectedSupplierValue,
                    ID = vm.PurchaseID +"("+ vm.SelectedSupplierValue+")",
                    Date = vm.InvocingDate,
                    Amount = vm.Amount,
                    Discount = vm.Discount,
                    Tax = vm.Tax,
                    GrandTotal = vm.GrandTotal,
                    IsPaid = vm.IsPaid,
                    LastUpdated = DateTime.Now,
                    Description = vm.Remarks        
                };                

                PurchaseItem _purchaseItem = new PurchaseItem()
                {
                    PurchaseID = _purchase.ID,
                    ItemID = vm.SelectedItemvalue,
                    Batch = vm.BatchNo,
                    Qty = vm.Qty,
                    CostPrice = vm.CostPrice,
                    SellingPrice = vm.SellingPrice,
                    Expiry = vm.Expiry
                };            
                           
            
                /*
                 * Add  purchase
                 * Add  PurchaseItem
                 * Add  Stock                 
                 */ 

                db.Purchases.Add(_purchase);
                db.PurchaseItems.Add(_purchaseItem);
                db.SaveChanges();
                repo.InsertOrUpdateInventory(vm);
            }
            catch(Exception ex)
            {
                ViewBag.SaveException = "Record couldn't be saved! Please check if record has already been entered! Thank you!!";
                return View(vm);
            }
            
            ViewBag.SuccessMsg = "Successfully Saved ! Cheers!";
            return RedirectToAction("Index","PurchaseItem");
        }


        [HttpPost]
        [ValidateAjax]
        public JsonResult InsertIntoPurchase(PurchaseInvoiceEntryViewModel vm)
        {   
            Purchase _purchase = new Purchase(){
                ID = vm.PurchaseID + "(" + vm.SelectedSupplierValue + ")",
                Date =vm.InvocingDate,
                SupplierID = vm.SelectedSupplierValue,
                Amount =vm.Amount,
                Discount = vm.Discount,
                Tax=vm.Tax,
                GrandTotal =vm.GrandTotal,
                Description =vm.Remarks        
             };

            int response = repo.InsertIntoPurchase(_purchase);
            if (response == 1)
            {
                string invoiceId = vm.PurchaseID + "(" + vm.SelectedSupplierValue + ")";
                return Json(invoiceId);
            }
            else
            {
                return Json("Invoice Number Already exists!");
            }
        }

        public JsonResult AddToTempList( PurchaseInvoiceEntryViewModel vm)
        {
            tempList.Add(vm);
            return Json(tempList);
        }
    }

    public class MyProductList : List<PurchaseInvoiceEntryViewModel>
    {
       
        public static  MyProductList GetInstance()
        {
            MyProductList _P = new MyProductList();
            return _P;

        }
    }
}