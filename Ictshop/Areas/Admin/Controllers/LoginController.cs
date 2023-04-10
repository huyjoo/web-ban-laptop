using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
using PagedList;
using PagedList.Mvc;
using System.IO;
namespace Ictshop.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // GET: Admin/Login
        public ActionResult Index()
        {
            
            return View();
        }


        public ActionResult Dangnhap()
        {
            return View();

        }


        [HttpPost]
        public ActionResult Dangnhap(FormCollection userlog)
        {
            string userMail = userlog["Email"].ToString();
            string password = userlog["Matkhau"].ToString();
            var islogin = db.Admins.SingleOrDefault(x => x.Email.Equals(userMail) && x.Matkhau.Equals(password));

            if (islogin != null)
            {
               
                    Session["use"] = islogin;
                    return RedirectToAction("index","home", "home");

               
            }
            else
            {
                ViewBag.Fail = "Đăng nhập thất bại";
                return View();
            }

        }




    }
}