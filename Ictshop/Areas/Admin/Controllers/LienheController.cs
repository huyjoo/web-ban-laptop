using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ictshop.Areas.Admin.Controllers
{
    public class LienheController : Controller
    {
        // GET: Admin/Lienhe
        public ActionResult Index()
        {

            if (Session["use"] == null || Session["use"].ToString() == "")
            {
                return RedirectToAction("Dangnhap", "Login", "Login");
            }

            return View();
        }
    }
}