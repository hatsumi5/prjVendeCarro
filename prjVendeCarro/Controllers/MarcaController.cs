using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class MarcaController : Controller
    {
        // GET: Marca
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            MarcaBL bl = new MarcaBL();
            List<Model> models = bl.GetData();
            List<MarcaModels> marcas = new List<MarcaModels>();
            models.ForEach(row => marcas.Add((MarcaModels)row));
            return View(marcas);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            MarcaModels marca = new MarcaModels(id);
            return View(marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            MarcaModels marca = new MarcaModels();
            return View(marca);
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(MarcaModels marca)
        {
            try
            {
                marca.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            MarcaModels marca = new MarcaModels(id);
            return View(marca);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(MarcaModels marca)
        {
            try
            {
                marca.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            MarcaModels marca = new MarcaModels(id);
            return View(marca);
        }

        // POST: Marca/Delete/5
        [HttpPost]
        public ActionResult Delete(MarcaModels marca)
        {
            try
            {
                marca.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
