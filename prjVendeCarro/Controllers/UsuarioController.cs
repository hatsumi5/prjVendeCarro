using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this);
            UsuarioBL bl = new UsuarioBL();
            List<Model> models = bl.GetData();
            List<UsuarioModels> usuarios = new List<UsuarioModels>();
            models.ForEach(row => usuarios.Add((UsuarioModels)row));
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Details", id);
            UsuarioModels usuario = new UsuarioModels(id);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Create");
            UsuarioModels usuario = new UsuarioModels();
            return View(usuario);
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(UsuarioModels usuario)
        {
            try
            {
                usuario.Insert();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Edit", id);
            UsuarioModels usuario = new UsuarioModels(id);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(UsuarioModels usuario)
        {
            try
            {
                usuario.Update();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            ViewBag.Breadcrumb = new Breadcrumb().GetBreadcrumb(this, "Delete", id);
            UsuarioModels usuario = new UsuarioModels(id);
            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost]
        public ActionResult Delete(UsuarioModels usuario)
        {
            try
            {
                usuario.Delete();
                return RedirectToAction("Index");
            }
            catch
            {
                return Redirect("/Error");
            }
        }
    }
}
