using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LTQLSinhVien.Controllers;
using LTQLSinhVien.Models.ViewModule;
using System.Data;
using System.Data.Entity;
using System.Net;
using LTQLSinhVien.Models;
using PagedList;
using System.Security.Cryptography;
using System.Text;


namespace LTQLSinhVien.Controllers
{
    public class HomeController : Controller
    {
        DBConnect DB = new DBConnect();
        public ActionResult DemoLinq()
        {
            List<ViewModule> query = (from S in DB.SinhViens
                                      join D in DB.DiemThis
                                      on S.MaSV equals D.MaSV
                                      select new ViewModule
                                      {
                                          TenSV = S.TenSV,
                                          DiemThi = D.KetQua

                                      }).ToList<ViewModule>();

            return View(query);
        }
        public ViewResult Pagelist (int? page)
        {
            //so ban ghi hien tai ow moi trang
            var pagesize = 10;
            //lay du lieu
            var model = DB.SinhViens.ToList();
            //neu pagenumber=null thi tra ve trang 1
            int pageNumber = page ?? 1;
            return View(model.ToPagedList(pageNumber, pagesize));
        }
        
        public ActionResult Index()
        {

            return View();
        }


        public ActionResult Login()
        {
            return View(); 
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string email,string password)
        {
            if(ModelState.IsValid)
            {
                var ma_hoa_du_lieu = GETMD5(password);
                var kiem_tra_tai_khoan = DB.SinhViens.Where(s => s.email.Equals(email) && s.password.Equals(ma_hoa_du_lieu)).ToList();
                if(kiem_tra_tai_khoan != null )
                {
                    Session["idSinhVien"] = kiem_tra_tai_khoan.FirstOrDefault().MaSV;
                    Session["tenSV"] = kiem_tra_tai_khoan.FirstOrDefault().TenSV;
                    var checkAdmin = kiem_tra_tai_khoan.FirstOrDefault().role;
                    if(checkAdmin == "Admin")
                    {
                        return RedirectToAction("Index", "Home", new { Area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { Area = "User" });
                    }
                    
                }   
                else
                {
                    ViewBag.LoginErroe = "Đăng nhập không thành công";
                    return RedirectToAction("Login");
                }    
            }    
            return View();
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Login");
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Register(SinhVien sv)
        {
            if (ModelState.IsValid)
            {
                var checkemail = DB.SinhViens.FirstOrDefault(m => m.email == sv.email);
                if(checkemail == null )
                {
                    sv.password = GETMD5(sv.password);
                    DB.Configuration.ValidateOnSaveEnabled = false;
                    DB.SinhViens.Add(sv);
                    DB.SaveChanges();
                    return RedirectToAction("Login");
                }    
                else
                { ViewBag.EmailError = "Email đã tồn tại";
                    return RedirectToAction("Register");
                }    
            }
            return View();
        }

        public static string GETMD5(string pass)
        {
            MD5 md5= new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(pass);
            byte[] targetData = md5.ComputeHash(fromData);
            string mk_da_ma_hoa = null;

            for(int i=0; i<targetData.Length;i++)
            {
                mk_da_ma_hoa += targetData[i].ToString("x2");
            }
            return mk_da_ma_hoa;
        }
    }
}