using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prjVendeCarro.DAL
{
    public class UsuarioDAL : GenericDAL
    {
        public override void setTable()
        {
            base.Table = "Usuario";
        }
        public override void setColumns()
        {
            addColumn("Id");
            addColumn("Nome");
            addColumn("Email");
            addColumn("CPF");
            addColumn("idTipo");
        }
    }
    public class UsuarioTipoDAL : GenericDAL
    {
        public override void setTable()
        {
            base.Table = "UsuarioTipo";
        }
        public override void setColumns()
        {
            addColumn("Id");
            addColumn("Nome");
        }
    }
    public class TelefoneDAL : GenericDAL
    {
        public override void setTable()
        {
            base.Table = "Telefone";
        }
        public override void setColumns()
        {
            addColumn("Id");
            addColumn("idUsuario");
            addColumn("Telefone");
            addColumn("tipo");
        }
    }
}