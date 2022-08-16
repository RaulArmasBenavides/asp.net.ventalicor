using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AppMVC_FINAL.Entity
{
    public class Usuarios
    {
        //propiedades
        public int Id { get; set; }

        public string Nombre { get; set; }

        [DisplayName("Usuario")]
        [Required(ErrorMessage = "El usuario es requerido.")]
        public string Usuario { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "El password es requerido."), DisplayName("Password")]
        public string Clave { get; set; }

        public string LoginErrorMessage { get; set; }
    }
}