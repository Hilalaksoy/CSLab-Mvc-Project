using cslabWeb.Areas.Admin.Models;
using cslabWeb.Filters;
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
        public ActionResult Login(AdminCs admin)
        {
            using (AdminContext db = new AdminContext())
            {
                var adm = db.admins.SingleOrDefault(u => u.Username == admin.Username && u.Password == admin.Password);
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

    }
}