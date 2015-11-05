using prjVendeCarro.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Models
{
    public enum Cambio { Manual, Automático }
    public class MarcaModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Marca")]
        public string Nome { get; set; }
        #endregion
        #region Constructor
        public MarcaModels() : base() { }
        public MarcaModels(int id) : base(id) { }
        public MarcaModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
    public class ModeloModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Modelo")]
        public string Nome { get; set; }
        [Required]
        [Display(Name="Marca")]
        [ForeignKey("Marca")]
        public int idMarca { get; set; }
        public MarcaModels Marca {
            get { return new MarcaModels(idMarca); }
            set { this.idMarca = value.Id; }
        }
        #endregion
        #region Constructor
        public ModeloModels() : base() { }
        public ModeloModels(int id) : base(id) { }
        public ModeloModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
    public class CombustivelModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Combustivel")]
        public string Nome { get; set; }
        #endregion
        #region Constructor
        public CombustivelModels() : base() { }
        public CombustivelModels(int id) : base(id) { }
        public CombustivelModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
    public class CarroModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Carro")]
        public string Nome { get; set; }
        [Required]
        [Display(Name="Marca")]
        [ForeignKey("Marca")]
        public int idMarca { get; set; }
        [Required]
        [Display(Name="Modelo")]
        [ForeignKey("Modelo")]
        public int idModelo { get; set; }
        [Display(Name="Combustível")]
        [ForeignKey("Combustivel")]
        public int idCombustivel { get; set; }
        public MarcaModels Marca {
            get { return new MarcaModels(idMarca); }
            set { this.idMarca = value.Id; }
        }
        public ModeloModels Modelo {
            get { return new ModeloModels(idModelo); }
            set { this.idModelo = value.Id; }
        }
        public CombustivelModels Combustivel {
            get { return new CombustivelModels(idCombustivel); }
            set { this.idCombustivel = value.Id; }
        }
        [Display(Name="Ano")]
        [Range(1900, 2999)]
        public int Ano { get; set; }
        [Display(Name="Cor")]
        public string Cor { get; set; }
        [Display(Name="Foto")]
        public string Foto { get; set; }
        [Display(Name="Preço")]
        public decimal Preco { get; set; }
        [Display(Name="KM")]
        public decimal Km { get; set; }
        [Display(Name="Quantidade de Portas")]
        public int QtdePorta { get; set; }
        public string strCambio { get; set; }
        [Display(Name = "Câmbio")]
        public Cambio Cambio
        {
            get
            {
                switch (strCambio)
                {
                    case "M": return Cambio.Manual;
                    case "A": return Cambio.Automático;
                    default: return new Cambio();
                }
            }
            set
            {
                strCambio = value.ToString().Substring(0, 1);
            }
        }
        [Display(Name="Versão")]
        public string Versao { get; set; }
        #endregion
        #region Constructor
        public CarroModels() : base() { }
        public CarroModels(int id) : base(id) { }
        public CarroModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
}