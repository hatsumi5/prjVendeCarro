using prjVendeCarro.Controllers;
using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Drawing;
using System.IO;

namespace prjVendeCarro.Controllers
{
    public class CarroController : Controller
    {
        
        // GET: Carro
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            CarroBL bl = new CarroBL();
            List<Model> models = bl.GetData();
            List<CarroModels> carros = new List<CarroModels>();
            models.ForEach(row => carros.Add((CarroModels)row));
            return View(carros);
        }

        // GET: Carro/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            CarroModels carro = new CarroModels(id);
            return View(carro);
        }

        // GET: Carro/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            CarroModels carro = new CarroModels();
            return View(carro);
        }

        // POST: Carro/Create
        [HttpPost]
        public ActionResult Create(CarroModels carro, HttpPostedFileBase file)
        {
            try
            {
                if (file != null)
                {
                    string imagem = string.Format("{0}{1}", carro.Id, Path.GetExtension(file.FileName));
                    string caminho = string.Format("{0}\\{1}", HttpContext.Server.MapPath("~/Images"), imagem);
                    file.SaveAs(caminho);
                    carro.Foto = imagem;
                }
                carro.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Carro/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            CarroModels carro = new CarroModels(id);
            return View(carro);
        }

        // POST: Carro/Edit/5
        [HttpPost]
        public ActionResult Edit(CarroModels carro, HttpPostedFileBase file)
        {
            try
            {
                carro.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Carro/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            CarroModels carro = new CarroModels(id);
            return View(carro);
        }

        // POST: Carro/Delete/5
        [HttpPost]
        public ActionResult Delete(CarroModels carro)
        {
            try
            {
                carro.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
        [HttpPost]
        public ActionResult GetModelos(int idMarca)
        {
            SelectList modelos = SelectListModels.Modelos(idMarca);
           return Json(modelos, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public ActionResult UploadFoto(string id)
        {
            HttpPostedFileBase file = Request.Files[0];
            string imagem = string.Format("{0}{1}{2}", "temp_" + DateTime.Now, id, Path.GetExtension(file.FileName));
            string caminho = string.Format("{0}\\{1}", HttpContext.Server.MapPath("~/Images"), imagem);
            file.SaveAs(caminho);
                
            return Json("/Images/" + imagem, JsonRequestBehavior.AllowGet);
        }
    }
}
