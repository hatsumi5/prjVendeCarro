﻿using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class EstadoController : Controller
    {
        // GET: Estado
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            EstadoBL bl = new EstadoBL();
            List<Model> models = bl.GetData();
            List<EstadoModels> estados = new List<EstadoModels>();
            models.ForEach(row => estados.Add((EstadoModels)row));
            return View(estados);
        }

        // GET: Estado/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            EstadoModels estado = new EstadoModels(id);
            return View(estado);
        }

        // GET: Estado/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            EstadoModels estado = new EstadoModels();
            return View(estado);
        }

        // POST: Estado/Create
        [HttpPost]
        public ActionResult Create(EstadoModels estado)
        {
            try
            {
                estado.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Estado/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            EstadoModels estado = new EstadoModels(id);
            return View(estado);
        }

        // POST: Estado/Edit/5
        [HttpPost]
        public ActionResult Edit(EstadoModels estado)
        {
            try
            {
                //EstadoModels estado = new EstadoModels(collection);
                estado.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Estado/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            EstadoModels estado = new EstadoModels(id);
            return View(estado);
        }

        // POST: Estado/Delete/5
        [HttpPost]
        public ActionResult Delete(EstadoModels estado)
        {
            try
            {
                estado.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
