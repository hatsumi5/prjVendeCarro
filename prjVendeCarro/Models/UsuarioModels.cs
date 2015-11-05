using prjVendeCarro.BL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prjVendeCarro.Models
{
    public class UsuarioModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Usuario")]
        public string Nome { get; set; }
        [Required]
        [Display(Name="Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [Display(Name="CPF")]
        [DisplayFormat(ApplyFormatInEditMode=true, DataFormatString="{0:###.###.###-##}")]
        [MaxLength(11)]
        public string CPF { get; set; }
        [Required]
        [Display(Name="Tipo do Usuário")]
        [ForeignKey("Tipo")]
        public int idTipo { get; set; }
        public UsuarioTipoModels Tipo {
            get { return new UsuarioTipoModels(idTipo); }
            set { this.idTipo = value.Id; }
        }
        #endregion
        #region Constructor
        public UsuarioModels() : base() { }
        public UsuarioModels(int id) : base(id) { }
        public UsuarioModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
    public class UsuarioTipoModels : Model
    {
        #region Property
        [Required]
        [Display(Name="Tipo do Usuário")]
        public string Nome { get; set; }
        #endregion
        #region Constructor
        public UsuarioTipoModels() : base() { }
        public UsuarioTipoModels(int id) : base(id) { }
        public UsuarioTipoModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Nome; }
    }
    public enum TelefoneTipo
    {
        RESIDENCIAL,
        CELULAR,
        COMERCIAL,
        OUTRO
    }
    public class TelefoneModels : Model
    {
        #region Property
        [Required]
        [ForeignKey("Usuario")]
        public int idUsuario { get; set; }
        public UsuarioModels Usuario {
            get { return new UsuarioModels(idUsuario); }
            set { this.idUsuario = value.Id; }
        }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public string tipo { get; set; }
        public TelefoneTipo Tipo {
            get {
                TelefoneTipo t;
                switch (tipo) {
                    case "RES" :
                        t = TelefoneTipo.RESIDENCIAL;
                        break;
                    case "CEL" :
                        t = TelefoneTipo.CELULAR;
                        break;
                    case "COM" :
                        t = TelefoneTipo.COMERCIAL;
                        break;
                    default :
                        t = TelefoneTipo.OUTRO;
                        break;
                }
                return t;
            }
            set
            {
                tipo = value.ToString().Substring(0, 3);
            }
        }
        #endregion
        #region Constructor
        public TelefoneModels() : base() { }
        public TelefoneModels(int id) : base(id) { }
        public TelefoneModels(SqlDataReader reader) : base(reader) { }
        #endregion
        public override string ToString() { return Telefone; }
    }
}