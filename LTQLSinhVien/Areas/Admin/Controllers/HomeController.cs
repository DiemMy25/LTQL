using LTQLSinhVien.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LTQLSinhVien.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        DBConnect DB = new DBConnect();
        // GET: Admin/HOME
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