﻿using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class CombustivelController : Controller
    {
        // GET: Combustivel
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            CombustivelBL bl = new CombustivelBL();
            List<Model> models = bl.GetData();
            List<CombustivelModels> combustiveis = new List<CombustivelModels>();
            models.ForEach(row => combustiveis.Add((CombustivelModels)row));
            return View(combustiveis);
        }

        // GET: Combustivel/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            CombustivelModels combustivel = new CombustivelModels(id);
            return View(combustivel);
        }

        // GET: Combustivel/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            CombustivelModels combustivel = new CombustivelModels();
            return View(combustivel);
        }

        // POST: Combustivel/Create
        [HttpPost]
        public ActionResult Create(CombustivelModels combustivel)
        {
            try
            {
                combustivel.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Combustivel/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            CombustivelModels combustivel = new CombustivelModels(id);
            return View(combustivel);
        }

        // POST: Combustivel/Edit/5
        [HttpPost]
        public ActionResult Edit(CombustivelModels combustivel)
        {
            try
            {
                combustivel.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Combustivel/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            CombustivelModels combustivel = new CombustivelModels(id);
            return View(combustivel);
        }

        // POST: Combustivel/Delete/5
        [HttpPost]
        public ActionResult Delete(CombustivelModels combustivel)
        {
            try
            {
                combustivel.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
