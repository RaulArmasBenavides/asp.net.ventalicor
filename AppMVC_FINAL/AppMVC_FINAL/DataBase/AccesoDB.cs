
using System.Configuration;

namespace AppMVC_FINAL.DataBase
{
    public class AccesoDB
    {
        //propiedad
        public string CadenaConexion { get; set; }

        //constructor
        public AccesoDB()
        {
            CadenaConexion = ConfigurationManager.ConnectionStrings["Vfacturacion"].ConnectionString;
        }
    }
}
