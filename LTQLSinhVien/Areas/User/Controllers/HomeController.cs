using LTQLSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQLSinhVien.Areas.User.Controllers
{
    public class HomeController : Controller
    {
        DBConnect DB = new DBConnect();
        // GET: User/Home
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();
            return Redirect("/Home/Login");
        }
    }
}