using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Ictshop.Models;
namespace Ictshop.Controllers
{
    public class UserController : Controller
    {
        Qlbanhang db = new Qlbanhang();
        // ĐĂNG KÝ
        //GET: Register

        public ActionResult Dangky()
        {
            return View();
        }

        //POST: Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangky(Nguoidung _user)
        {
            if (ModelState.IsValid)
            {
                var check = db.Nguoidungs.FirstOrDefault(s => s.Email == _user.Email);
                if (check == null)
                {
                    _user.Matkhau = GetMD5(_user.Matkhau);
                    db.Configuration.ValidateOnSaveEnabled = false;
                    db.Nguoidungs.Add(_user);
                    db.SaveChanges();
                    if (ModelState.IsValid)
                    {
                        return RedirectToAction("Dangnhap");
                    }
                    return View("Dangky");
                }
                else
                {
                    ViewBag.error = "Email already exists";
                    return View();
                }


            }
            return View();


        }

        public ActionResult Dangnhap()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Dangnhap(string email, string password)
        {
            if (ModelState.IsValid)
            {


                var f_password = GetMD5(password);
                var data = db.Nguoidungs.Where(s => s.Email.Equals(email) && s.Matkhau.Equals(f_password)).ToList();
                if (data.Count() > 0)
                {
                    Session["use"] = data;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.loi = "Đăng nhập thất bại";
                    return RedirectToAction("Dangnhap");
                }
            }
            return View();
        }


        //Logout
        public ActionResult Logout()
        {
            Session.Clear();//remove session
            return RedirectToAction("Login");
        }



        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }



    }
}