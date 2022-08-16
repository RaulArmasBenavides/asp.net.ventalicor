using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppMVC07.Models
{
    public class Cliente
    {
        public string IdCliente { get; set; }
        public string NombreCompañía { get; set; }
        public string Dirección { get; set; }
        public string Ciudad { get; set; }
        public string País { get; set; }
        public string Teléfono { get; set; }
    }
}