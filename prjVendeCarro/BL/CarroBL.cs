using prjVendeCarro.DAL;
using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjVendeCarro.BL
{
    public class CarroBL : GenericBL
    {
        
    }
    public class MarcaBL : GenericBL
    {
        
    }
    public class ModeloBL : GenericBL
    {
        public List<Model> GetDataByMarca(MarcaModels marca)
        {
            return GetDataByMarca(marca.Id);
        }
        public List<Model> GetDataByMarca(int idMarca)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@idMarca", idMarca));
            return base.dal.GetByQuery(string.Format("SELECT {0} FROM {1} WHERE idMarca = @idMarca", dal.Columns, dal.Table), parameters);
        }
    }
    public class CombustivelBL : GenericBL
    {
        
    }
}