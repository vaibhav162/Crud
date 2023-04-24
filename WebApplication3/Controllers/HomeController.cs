using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        ProductDB proDB = new ProductDB();
        // GET: Home  
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult List()
        {
            
            return Json(proDB.ListAll(), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Add(Product pro)
        {
           // pro.Image = "~/Upload/" + pro.Image.FileName;
            //store image in folder
            //pro.Image.SaveAs(Server.MapPath("Upload") + "/" + pro.Image.FileName);
            return Json(proDB.Add(pro), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
        
            var Product = proDB.ListAll().Find(x => x.id.Equals(ID));
            return Json(Product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(Product pro)
        {
            return Json(proDB.Update(pro), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(proDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}