using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            ModeloBL bl = new ModeloBL();
            List<Model> models = bl.GetData();
            List<ModeloModels> modelos = new List<ModeloModels>();
            models.ForEach(row => modelos.Add((ModeloModels)row));
            return View(modelos);
        }

        // GET: Modelo/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            ModeloModels modelo = new ModeloModels(id);
            return View(modelo);
        }

        // GET: Modelo/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            ModeloModels modelo = new ModeloModels();
            return View(modelo);
        }

        // POST: Modelo/Create
        [HttpPost]
        public ActionResult Create(ModeloModels modelo)
        {
            try
            {
                modelo.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Modelo/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            ModeloModels modelo = new ModeloModels(id);
            return View(modelo);
        }

        // POST: Modelo/Edit/5
        [HttpPost]
        public ActionResult Edit(ModeloModels modelo)
        {
            try
            {
                modelo.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Modelo/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            ModeloModels modelo = new ModeloModels(id);
            return View(modelo);
        }

        // POST: Modelo/Delete/5
        [HttpPost]
        public ActionResult Delete(ModeloModels modelo)
        {
            try
            {
                modelo.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
