using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppMVC_FINAL.Entity
{
    public class Comprobante
    {
        public int Id { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Ingrese Cliente", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Cliente { get; set; }

        [DisplayName("Igv")]
        public decimal Igv { get; set; }

        [DisplayName("Total")]
        public decimal Total { get; set; }
        public string FechaRegistro { get; set; }
    }
}