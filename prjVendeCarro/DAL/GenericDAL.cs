using prjVendeCarro.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace prjVendeCarro.DAL
{
    public abstract class GenericDAL
    {
        #region Property
        private string connectionString { get; set; }
        public string Table { get; set; }
        protected Dictionary<string, string> listColumns { get; set; }
        public string Columns
        {
            get
            {
                string list = "";
                foreach (var row in listColumns)
                {
                    list += string.Format("{0} {1},", row.Key, row.Value);
                }
                return list.Trim(',');
            }
        }
        #endregion
        #region Constructor
        public GenericDAL()
        {
            connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            listColumns = new Dictionary<string,string>();
            setTable();
            setColumns();
        }
        #endregion
        #region Method
        public abstract void setTable();
        public abstract void setColumns();
        public List<Model> GetData()
        {
            string query = string.Format("SELECT {0} FROM {1}", Columns, Table);
            List<Model> list = new List<Model>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Model obj = (Model) Activator.CreateInstance(Type.GetType(this.GetType().ToString().Replace("DAL", "Models")), reader);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
        public Model GetById(int Id)
        {
            string query = string.Format("SELECT {0} FROM {1} WHERE Id=@Id", Columns, Table);
            Model obj = (Model)Activator.CreateInstance(Type.GetType(this.GetType().ToString().Replace("DAL", "Models")));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.Add(new SqlParameter("@Id", Id));
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    if (reader.Read())
                    {
                        obj = (Model)Activator.CreateInstance(Type.GetType(this.GetType().ToString().Replace("DAL", "Models")), reader);
                    }
                }
            }
            return obj;
        }
        public List<Model> GetByQuery(string query, List<SqlParameter> parameters)
        {
            List<Model> list = new List<Model>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Model obj = (Model)Activator.CreateInstance(Type.GetType(this.GetType().ToString().Replace("DAL", "Models")), reader);
                        list.Add(obj);
                    }
                }
            }
            return list;
        }
        public void Insert(Model model)
        {
            List<string> listColumnsParameters = getListColumnsParameters();
            List<string> listColumns = new List<string>(this.listColumns.Keys);
            List<object> listValues = getListPropertyValues(model);
            listColumnsParameters.Remove("@Id");
            listColumns.Remove("Id");
            listValues.Remove(listValues[0]);
            string strParameters = string.Join(",", listColumnsParameters);
            string columns = string.Join(",", listColumns);
            string query = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", Table, columns, strParameters);
            List<SqlParameter> parameters = new List<SqlParameter>();
            int i = 0;
            foreach (object value in listValues)
            {
                parameters.Add(new SqlParameter(listColumnsParameters[i], value ?? DBNull.Value));
                i++;
            }
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Update(Model model)
        {
            List<string> listColumnsParameters = getListColumnsParameters();
            List<string> listColumns = new List<string>(this.listColumns.Keys);
            List<object> listValues = getListPropertyValues(model);
            listColumnsParameters.Remove("@Id");
            listColumns.Remove("Id");
            listValues.Remove(listValues[0]);
            string fields = "";
            int i = 0;
            foreach (string column in listColumns)
            {
                fields += string.Format("{0} = {1},", column, listColumnsParameters[i]);
                i++;
            }
            fields = fields.Trim(',');
            string query = string.Format("UPDATE {0} SET {1} WHERE Id = @Id", Table, fields);
            List<SqlParameter> parameters = new List<SqlParameter>();
            i = 0;
            foreach (object value in listValues)
            {
                parameters.Add(new SqlParameter(listColumnsParameters[i], value ?? DBNull.Value));
                i++;
            }
            parameters.Add(new SqlParameter("@Id", model.Id));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        public void Delete(Model model)
        {
            string query = string.Format("DELETE FROM {0} WHERE Id = @Id", Table);
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@Id", model.Id));
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddRange(parameters.ToArray());
                    connection.Open();
                    command.ExecuteNonQuery();
                }
            }
        }
        private List<object> getListPropertyValues(Model model)
        {
            List<object> values = new List<object>();
            foreach (string column in listColumns.Values)
            {
                if (model.GetType().GetProperty(column) != null)
                {
                    values.Add(model.GetType().GetProperty(column).GetValue(model));
                }
            }
            return values;
        }
        private List<string> getListColumnsParameters()
        {
            List<string> parameters = new List<string>();
            foreach (string column in listColumns.Values)
            {
                parameters.Add(string.Format("@{0}", column));
            }
            return parameters;
        }
        protected void addColumn(string key, string value = null)
        {
            if (value == null) value = key;
            listColumns.Add(key, value);
        }
        #endregion
    }
}