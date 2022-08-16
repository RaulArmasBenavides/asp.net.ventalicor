using AppMVC_FINAL.Entity;
using AppMVC_FINAL.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AppMVC_FINAL.Models
{
    public class UsuarioDao : ICrudUsuDao<Usuarios>
    {
        //variables       
        SqlCommand cmd = null;
       
        public Usuarios validar(Usuarios t, SqlConnection cn)
        {
            Usuarios user = null;
            using (cmd = new SqlCommand("UsuarioValidar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Usuario", t.Usuario);
                cmd.Parameters.AddWithValue("@Clave", t.Clave);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    int posId = dr.GetOrdinal("Id");
                    int posNom = dr.GetOrdinal("Nombres");
                    int posUser = dr.GetOrdinal("Usuario");
                    if (dr.Read())
                    {
                        user = new Usuarios()
                        {
                            Id = dr.GetInt32(posId),
                            Nombre = dr.GetString(posNom),
                            Usuario = dr.GetString(posUser),
                        };
                    }
                }
                dr.Close();
            }
            return user;
        }

    }
}
