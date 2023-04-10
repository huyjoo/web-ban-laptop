using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;

namespace Ictshop.Controllers
{
    public class SanphamController : Controller
    {
        Qlbanhang db = new Qlbanhang();

        // GET: Sanpham
        public ActionResult dell()
        {
            var dell = db.Sanphams.Where(n=>n.Mahang==1).Take(4).ToList();
           return PartialView(dell);
        }
        public ActionResult asus()
        {
            var asus = db.Sanphams.Where(n => n.Mahang == 2).Take(4).ToList();
            return PartialView(asus);
        }
        public ActionResult macbook()
        {
            var macbook = db.Sanphams.Where(n => n.Mahang == 3).Take(4).ToList();
            return PartialView(macbook);
        }

        
        //public ActionResult dttheohang()
        //{
        //    var mi = db.Sanphams.Where(n => n.Mahang == 5).Take(4).ToList();
        //    return PartialView(mi);
        //}
        public ActionResult xemchitiet(int Masp=0)
        {
            var chitiet = db.Sanphams.SingleOrDefault(n=>n.Masp==Masp);
            if (chitiet == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(chitiet);
        }

    }

}