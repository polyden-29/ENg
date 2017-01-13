using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Okoone_Assignment.Controllers
{
    public class PageController : Controller
    {
        //
        // GET: /Page/

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User u) {
            if (ModelState.IsValid) {
                using (MyDBEntities db = new MyDBEntities()) {
                    db.Users.Add(u);
                    db.SaveChanges();
                    ModelState.Clear();
                    u = null;
                    ViewBag.Message = "User Created";
                }
            }
            return View(u);
        }
        
        public ActionResult Login (){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(UserLogin ul) {
            if (ModelState.IsValid) {
                using (MyDBEntities db = new MyDBEntities()) {
                    var v = db.Users.Where(m => m.Username.Equals(ul.Username) && m.Password.Equals(ul.Password)).FirstOrDefault();
                    if (v != null)
                    {
                        Session["name"] = v.LastName.ToString();
                        return RedirectToAction("LogedUser");
                    }
                    else {
                        ViewBag.InPw="Incorrect Username Or Password";
                    }

                }
            }
            return View(ul);
        }
        public ActionResult LogedUser() {
            return View();
        }
    }
}
