using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class CidadeController : Controller
    {
        // GET: Cidade
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            CidadeBL bl = new CidadeBL();
            List<Model> models = bl.GetData();
            List<CidadeModels> cidades = new List<CidadeModels>();
            models.ForEach(row => cidades.Add((CidadeModels)row));
            return View(cidades);
        }

        // GET: Cidade/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            CidadeModels cidade = new CidadeModels(id);
            return View(cidade);
        }

        // GET: Cidade/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            CidadeModels cidade = new CidadeModels();
            return View(cidade);
        }

        // POST: Cidade/Create
        [HttpPost]
        public ActionResult Create(CidadeModels cidade)
        {
            try
            {
                cidade.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Cidade/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            CidadeModels cidade = new CidadeModels(id);
            return View(cidade);
        }

        // POST: Cidade/Edit/5
        [HttpPost]
        public ActionResult Edit(CidadeModels cidade)
        {
            try
            {
                cidade.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Cidade/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            CidadeModels cidade = new CidadeModels(id);
            return View(cidade);
        }

        // POST: Cidade/Delete/5
        [HttpPost]
        public ActionResult Delete(CidadeModels cidade)
        {
            try
            {
                cidade.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
