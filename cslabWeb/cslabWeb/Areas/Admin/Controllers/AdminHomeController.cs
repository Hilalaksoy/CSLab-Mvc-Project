﻿using cslabWeb.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace cslabWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        
        // GET: Admin/Home
        public ActionResult Index()
        {
            AdminContext db = new AdminContext();
            List<Log> asd = db.logs.ToList();
            return View(asd);
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(AdminCs admin)
        {
            using (AdminContext db = new AdminContext())
            {
                var adm = db.admins.Single(u => u.Username == admin.Username && u.Password == admin.Password);
                if(adm != null)
                {
                    Session["Id"] = adm.Id.ToString();
                    Session["Username"] = adm.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("","Kullanıcı adı veya parola hatalı. ");
                }
            }
                return View();
        }
        public ActionResult LoggedIn()
        {
            if(Session["UserId"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }
    }
}