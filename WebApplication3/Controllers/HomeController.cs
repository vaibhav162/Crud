using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
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
        public ActionResult Add(FormCollection pro)    
        {
            HttpPostedFileBase postedFile = Request.Files["Image"];
          
           var id = pro["Id"].ToString();
            var productTitle = pro["ProductTitle"].ToString();
            var Image = "Upload" + "/" + postedFile.FileName;
            var price = pro["Price"].ToString();
            var stock = pro["Stock"].ToString();
            Product product = new Product()
            {
                //id = Convert.ToInt32(id),
                productTitle = productTitle,
                Image = Image,
                price = Convert.ToInt32(price),
                stock = Convert.ToInt32(stock),
            };
           
           
            string imgName = postedFile.FileName;

            String path = @"D:\Crud\WebApplication3\Upload\";//Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            //save image
            string imgPath = Path.Combine(path, imgName);
            postedFile.SaveAs(imgPath);
            return Json(proDB.Add(product), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetbyID(int ID)
        {
        
            var Product = proDB.ListAll().Find(x => x.id.Equals(ID));
            return Json(Product, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(FormCollection prod)
        {
            HttpPostedFileBase postedFile = Request.Files["Image"];
            var id = prod["Id"].ToString();
            var productTitle = prod["ProductTitle"].ToString();
            var Image = "Upload" + "/" + postedFile.FileName;
            var price = prod["Price"].ToString();
            var stock = prod["Stock"].ToString();
            Product pro = new Product()
            {
                id = Convert.ToInt32(id),
                productTitle = productTitle,
                Image = Image,
                price = Convert.ToInt32(price),
                stock = Convert.ToInt32(stock),
            };


            string imgName = postedFile.FileName;

            String path = @"D:\Crud\WebApplication3\Upload\";//Path

            //Check if directory exist
            if (!System.IO.Directory.Exists(path))
            {
                System.IO.Directory.CreateDirectory(path); //Create directory if it doesn't exist
            }

            //save image
            string imgPath = Path.Combine(path, imgName);
            postedFile.SaveAs(imgPath);
            return Json(proDB.Update(pro), JsonRequestBehavior.AllowGet);
        }
        public JsonResult Delete(int ID)
        {
            return Json(proDB.Delete(ID), JsonRequestBehavior.AllowGet);
        }
    }
}