using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace AppMVC07.Entity
{
    public class Producto
    {
        //propiedades
        //[Key]
        //[DisplayName("Codigo")]
        //[Required(ErrorMessage = "Ingrese Codigo", AllowEmptyStrings = false)]
        //[RegularExpression("[0-9]{1,3}")]
        public int IdProducto { get; set; }

        [DisplayName("Nombre Producto")]
        [Required(ErrorMessage = "Ingrese Nombre", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string NombreProducto { get; set; }

        [DisplayName("Proveedor")]
        [Required(ErrorMessage = "Seleccione Proveedor", AllowEmptyStrings = false)]
        public int IdProveedor { get; set; }

        [DisplayName("Desc Proveedor")]
        public string DesProveedor { get; set; }

        [DisplayName("Categoria")]
        [Required(ErrorMessage = "Seleccione Categoria", AllowEmptyStrings = false)]
        public int IdCategoria { get; set; }

        [DisplayName("Desc Categoria")]
        public string DesCategoria { get; set; }

        [DisplayName("Uidad Medida")]
        [Required(ErrorMessage = "Ingrese unidad de medida", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        public string UnidadMedida { get; set; }

        [DisplayName("Precio")]
        [Required(ErrorMessage = "Ingrese precio unitario", AllowEmptyStrings = false)]
        [Range(1, double.MaxValue, ErrorMessage = "Valor Minimo 1")]
        public decimal Precio { get; set; }

        [DisplayName("Stock")]
        [Required(ErrorMessage = "Ingrese stock", AllowEmptyStrings = false)]
        [Range(10, double.MaxValue, ErrorMessage = "Valor Minimo 10")]
        public int Stock { get; set; }
    }

}
