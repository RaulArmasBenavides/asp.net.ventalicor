using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppMVC_FINAL.Entity
{
    public class ComprobanteDetalle
    {
        public int Id { get; set; }
        public int ComprobanteId { get; set; }

        [DisplayName("Producto")]
        [Required(ErrorMessage = "Ingrese Producto", AllowEmptyStrings = false)]
        public int ProductoId { get; set; }

        public string NombreProducto { get; set; }

        [DisplayName("Cantidad")]
        [Required(ErrorMessage = "Ingrese Cantidad", AllowEmptyStrings = false)]
        public int Cantidad { get; set; }

        [DisplayName("Precio Unitario")]
        [Required(ErrorMessage = "Ingrese Precio Unitario", AllowEmptyStrings = false)]
        public decimal PrecioUitario { get; set; }
        public decimal Monto { get; set; }
        public decimal Igv { get; set; }
        public decimal Total { get; set; }
        public string FechaRegistro { get; set; }

        public string FechaIni { get; set; }
        public string FechaFin { get; set; }

        [DisplayName("Cliente")]
        [Required(ErrorMessage = "Ingrese Cliente", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string Cliente { get; set; }
    }
}