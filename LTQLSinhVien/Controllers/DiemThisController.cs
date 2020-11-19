using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LTQLSinhVien.Models;

namespace LTQLSinhVien.Controllers
{
    public class DiemThisController : Controller
    {
        private DBConnect db = new DBConnect();

        // GET: DiemThis
        public ActionResult Index()
        {
            var diemThis = db.DiemThis;
            return View(diemThis.ToList());
        }

        // GET: DiemThis/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.Find(id);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            return View(diemThi);
        }

        // GET: DiemThis/Create
        public ActionResult Create()
        {
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV");
            return View();
        }

        // POST: DiemThis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSV,MaMH,KetQua,LanThi")] DiemThi diemThi)
        {
            if (ModelState.IsValid)
            {
                db.DiemThis.Add(diemThi);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // GET: DiemThis/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.Find(id);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // POST: DiemThis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSV,MaMH,KetQua,LanThi")] DiemThi diemThi)
        {
            if (ModelState.IsValid)
            {
                db.Entry(diemThi).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaSV = new SelectList(db.SinhViens, "MaSV", "TenSV", diemThi.MaSV);
            return View(diemThi);
        }

        // GET: DiemThis/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DiemThi diemThi = db.DiemThis.Find(id);
            if (diemThi == null)
            {
                return HttpNotFound();
            }
            return View(diemThi);
        }

        // POST: DiemThis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DiemThi diemThi = db.DiemThis.Find(id);
            db.DiemThis.Remove(diemThi);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
