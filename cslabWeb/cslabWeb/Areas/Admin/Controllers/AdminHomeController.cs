using cslabWeb.Areas.Admin.Models;
using cslabWeb.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace cslabWeb.Areas.Admin.Controllers
{
    
    public class AdminHomeController : Controller
    {
        AdminContext db = new AdminContext();
        // GET: Admin/Home
        [UserAuthenticationFilter]
        public ActionResult Index()
        {
            using (AdminContext db = new AdminContext())
            {
                return View(db.admins.ToList());
            }       
            
        }       
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
         
        [HttpPost]
        public ActionResult Login(AdminCs admin,string Password)
        {
            using (AdminContext db = new AdminContext())
            {
                var md5pass = Crypto.Hash(Password,"MD5");
                var adm = db.admins.SingleOrDefault(u => u.Username == admin.Username && u.Password ==md5pass);
                if (adm != null)
                {
                    Session["Id"] = Guid.NewGuid();
                    Session["Username"] = adm.Username.ToString();
                    return RedirectToAction("LoggedIn");
                }
                else
                {
                    ModelState.AddModelError("", "Kullanıcı adı veya parola hatalı. ");
                }
            }
            return View();


        }
        [UserAuthenticationFilter]
        public ActionResult LoggedIn()
        {                    
           return RedirectToAction("Index");          
        }
        public ActionResult Logout()
        {
            Session["Id"] = null;
            Session.Abandon();
            return RedirectToAction("Login");
        }

        //[UserAuthenticationFilter]
        public ActionResult Create(AdminCs admin,string Password)
        {
            var md5pass = Password;
            if (ModelState.IsValid)
            {
                admin.Password = Crypto.Hash(md5pass, "MD5");
                db.admins.Add(admin);
                db.SaveChanges();
                Session["Id"] = admin.Id;
                Session["Username"] = admin.Username;
                return RedirectToAction("Login");
            }            
            return View();
        }
    }
}