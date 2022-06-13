using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TranVanQuyen_1911062548.Models;

namespace TranVanQuyen_1911062548.Controllers
{
    public class SinhVienController : Controller
    {
        // GET: SinhVien
        Test01DataContext data = new Test01DataContext();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListSinhVien() 
        {
            var all_sinhvien = from ss in data.SinhViens select ss;
            return View(all_sinhvien);
        }
        public ActionResult Detail(string id)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            return View(D_sinhvien);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(FormCollection collection, SinhVien sv)
        {
            var E_masv = collection["MaSV"];
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];


            if (string.IsNullOrEmpty(E_masv))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                sv.MaSV = E_masv.ToString();
                sv.HoTen = E_hoten;
                sv.GioiTinh = E_gioitinh;
                sv.NgaySinh = E_ngaysinh;
                sv.Hinh = E_hinh.ToString();
                sv.MaNganh = E_manganh;

                data.SinhViens.InsertOnSubmit(sv);
                data.SubmitChanges();
                return RedirectToAction("ListSinhvien");
            }
            return this.Create();
        }
        //Edit
        public ActionResult Edit(string id)
        {
            var E_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(E_sinhvien);
        }
        [HttpPost]
        public ActionResult Edit(string id, FormCollection collection)
        {
            var E_masv = data.SinhViens.First(m => m.MaSV == id);
            var E_hoten = collection["HoTen"];
            var E_gioitinh = collection["GioiTinh"];
            var E_ngaysinh = Convert.ToDateTime(collection["NgaySinh"]);
            var E_hinh = collection["Hinh"];
            var E_manganh = collection["MaNganh"];


            E_masv.MaSV = id;

            if (string.IsNullOrEmpty(E_hoten))
            {
                ViewData["Error"] = "Don't empty!";
            }
            else
            {
                E_masv.MaSV = E_masv.ToString();
                E_masv.HoTen = E_hoten;
                E_masv.GioiTinh = E_gioitinh;
                E_masv.NgaySinh = E_ngaysinh;
                E_masv.Hinh = E_hinh.ToString();
                E_masv.MaNganh = E_manganh;
                UpdateModel(E_masv);
                data.SubmitChanges();
                return RedirectToAction("ListSinhVien");
            }
            return this.Edit(id);
        }
        //DeleTe
        public ActionResult Delete(string id)
        {
            var D_sinhvien = data.SinhViens.First(m => m.MaSV == id);
            return View(D_sinhvien);
        }
        [HttpPost]
        public ActionResult Delete(string id, FormCollection collection)
        {
            var D_sinhvien = data.SinhViens.Where(m => m.MaSV == id).First();
            data.SinhViens.DeleteOnSubmit(D_sinhvien);
            data.SubmitChanges();
            return RedirectToAction("ListSinhVien");
        }

        //EnđElêt
        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }

    }
}