using AppMVC_FINAL.DataBase;
using AppMVC_FINAL.Entity;
using AppMVC_FINAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace AppMVC_FINAL.Bussines
{
    public class ComprobanteBll : AccesoDB
    {      
       public List<ComprobanteDetalle> ComprobanteListar()
        {
            List<ComprobanteDetalle> lista = null;
            using (var cn=new SqlConnection(CadenaConexion) )
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    lista = dao.readAll(cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return lista;
        }

        public List<ComprobanteDetalle> ComprobanteListar_Fecha(ComprobanteDetalle cd)
        {
            List<ComprobanteDetalle> lista = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    lista = dao.listarComprobante_Fecha(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return lista;
        }

        public List<ComprobanteDetalle> ComprobanteListar_Producto(ComprobanteDetalle cd)
        {
            List<ComprobanteDetalle> lista = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    lista = dao.listarComprobante_Producto(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return lista;
        }

        public ComprobanteDetalle ComprobanteConsultar(ComprobanteDetalle cd)
        {
            ComprobanteDetalle pro = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    pro = dao.findForId(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return pro;
        }

        public void ComprobanteAdicionar(ComprobanteDetalle cd)
        {
           using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    dao.createComprobante(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ComprobanteDetalleAdicionar(ComprobanteDetalle cd)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    dao.createComprobanteDetalle(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ComprobanteActualizar(ComprobanteDetalle cd)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    dao.updateComprobante(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ComprobanteDetalleActualizar(ComprobanteDetalle cd)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    dao.updateComprobanteDetalle(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public void ComprobanteEliminar(ComprobanteDetalle cd)
        {
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    dao.delete(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()            
        }

        public List<ComprobanteDetalle> ProductoListar()
        {
            List<ComprobanteDetalle> lista = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                ComprobanteDao dao = null;
                try
                {
                    dao = new ComprobanteDao();
                    cn.Open();
                    lista = dao.ListarProducto(cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return lista;
        }

        public Usuarios validar(Usuarios cd)
        {
            Usuarios user = null;
            using (var cn = new SqlConnection(CadenaConexion))
            {
                UsuarioDao dao = null;
                try
                {
                    dao = new UsuarioDao();
                    cn.Open();
                    user = dao.validar(cd, cn);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }//cn.close()
            return user;
        }


    }
}
