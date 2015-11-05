using prjVendeCarro.BL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Models
{
    public class SelectListModels
    {
        public static SelectList Marcas
        {
            get
            {
                MarcaBL bl = new MarcaBL();
                List<Model> models = bl.GetData();

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "0", Text = string.Empty, Selected = true });
                models.ForEach(row => list.Add(new SelectListItem()
                {
                    Value = row.Id.ToString(),
                    Text = ((MarcaModels)row).Nome
                }));
                return new SelectList(list, "Value", "Text", 1);
            }
        }
        public static SelectList Combustiveis
        {
            get
            {
                CombustivelBL bl = new CombustivelBL();
                List<Model> models = bl.GetData();

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "0", Text = string.Empty, Selected = true });
                models.ForEach(row => list.Add(new SelectListItem()
                {
                    Value = row.Id.ToString(),
                    Text = ((CombustivelModels)row).Nome
                }));
                return new SelectList(list, "Value", "Text", 1);
            }
        }
        public static SelectList Modelos(MarcaModels marca)
        {
            return Modelos(marca == null ? 0 : marca.Id);
        }
        public static SelectList Modelos(int idMarca)
        {
            ModeloBL bl = new ModeloBL();
            List<Model> models = bl.GetDataByMarca(idMarca);

            List<SelectListItem> list = new List<SelectListItem>();
            list.Add(new SelectListItem() { Value = "0", Text = string.Empty, Selected = true });
            models.ForEach(row => list.Add(new SelectListItem()
            {
                Value = row.Id.ToString(),
                Text = ((ModeloModels)row).Nome
            }));
            return new SelectList(list, "Value", "Text", 1);
        }
        public static SelectList Estados
        {
            get
            {
                EstadoBL bl = new EstadoBL();
                List<Model> models = bl.GetData();

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "0", Text = string.Empty, Selected = true });
                models.ForEach(row => list.Add(new SelectListItem()
                {
                    Value = row.Id.ToString(),
                    Text = ((EstadoModels)row).Nome
                }));
                return new SelectList(list, "Value", "Text", 1);
            }
        }
        public static SelectList UsuarioTipos
        {
            get
            {
                UsuarioTipoBL bl = new UsuarioTipoBL();
                List<Model> models = bl.GetData();

                List<SelectListItem> list = new List<SelectListItem>();
                list.Add(new SelectListItem() { Value = "0", Text = string.Empty, Selected = true });
                models.ForEach(row => list.Add(new SelectListItem()
                {
                    Value = row.Id.ToString(),
                    Text = ((UsuarioTipoModels)row).Nome
                }));
                return new SelectList(list, "Value", "Text", 1);
            }
        }
        
    }
}