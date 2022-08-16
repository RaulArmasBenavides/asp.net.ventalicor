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
    public class ComprobanteDao : ICrudDao<ComprobanteDetalle>
    {
        //variables       
        SqlCommand cmd = null;
        public void createComprobante(ComprobanteDetalle t, SqlConnection cn)
        {
            using (cmd=new SqlCommand("Comprobante_Adicionar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Cliente", t.Cliente);
                cmd.Parameters.AddWithValue("@Igv", t.Igv);
                cmd.Parameters.AddWithValue("@Total", t.Total);
                cmd.Parameters.Add("@IdComprobante", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                t.ComprobanteId = (int)cmd.Parameters["@IdComprobante"].Value;
            }
        }

        public void createComprobanteDetalle(ComprobanteDetalle t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("ComprobanteDetalle_Adicionar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", t.ComprobanteId);
                cmd.Parameters.AddWithValue("@ProductoId", t.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", t.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", t.PrecioUitario);
                cmd.Parameters.AddWithValue("@Monto", t.Monto);
                cmd.ExecuteNonQuery();
            }
        }

        public void delete(ComprobanteDetalle t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("Comprobante_Eliminar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", t.ComprobanteId);
                cmd.ExecuteNonQuery();
            }
        }

        //Buscar por codigo
        public ComprobanteDetalle findForId(ComprobanteDetalle t, SqlConnection cn)
        {
            ComprobanteDetalle compDet=null;
            using (cmd = new SqlCommand("Comprobante_Buscar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", t.ComprobanteId);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {                   
                    int posCod = dr.GetOrdinal("Codigo");
                    int posClie = dr.GetOrdinal("Cliente");
                    int posIdProd = dr.GetOrdinal("ProductoId");
                    int posNomPro = dr.GetOrdinal("NombreProducto");
                    int posCant = dr.GetOrdinal("Cantidad");
                    int posPreUni = dr.GetOrdinal("PrecioUitario");
                    int posMont = dr.GetOrdinal("Monto");
                    int posIgv = dr.GetOrdinal("Igv");
                    int posTot = dr.GetOrdinal("Total");
                    int posFv = dr.GetOrdinal("FechaVenta");
                    if (dr.Read())
                    {
                        compDet = new ComprobanteDetalle()
                        {
                            ComprobanteId = dr.GetInt32(posCod),
                            Cliente = dr.GetString(posClie),
                            ProductoId = dr.GetInt32(posIdProd),
                            NombreProducto = dr.GetString(posNomPro),
                            Cantidad = dr.GetInt32(posCant),
                            PrecioUitario = dr.GetDecimal(posPreUni),
                            Monto = dr.GetDecimal(posMont),
                            Igv = dr.GetDecimal(posIgv),
                            Total = dr.GetDecimal(posTot),
                            FechaRegistro = dr.GetString(posFv)
                        };                      
                    }                   
                }
                dr.Close();
            }
            return compDet;
        }

        public List<ComprobanteDetalle> readAll(SqlConnection cn)
        {
            List<ComprobanteDetalle> lista=null;

            using (cmd = new SqlCommand("Comprobante_Listar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();              
                if (dr != null)
                {
                    ComprobanteDetalle compDet;
                    int posCod = dr.GetOrdinal("Codigo");
                    int posClie = dr.GetOrdinal("Cliente");
                    int posIdProd = dr.GetOrdinal("ProductoId");
                    int posNomPro = dr.GetOrdinal("NombreProducto");
                    int posCant = dr.GetOrdinal("Cantidad");
                    int posPreUni = dr.GetOrdinal("PrecioUitario");
                    int posMont = dr.GetOrdinal("Monto");
                    int posIgv = dr.GetOrdinal("Igv");
                    int posTot = dr.GetOrdinal("Total");
                    int posFv = dr.GetOrdinal("FechaVenta");
                    lista = new List<ComprobanteDetalle>();
                    while (dr.Read())
                    {
                        compDet = new ComprobanteDetalle()
                        {
                            ComprobanteId = dr.GetInt32(posCod),
                            Cliente = dr.GetString(posClie),
                            ProductoId = dr.GetInt32(posIdProd),
                            NombreProducto = dr.GetString(posNomPro),
                            Cantidad = dr.GetInt32(posCant),
                            PrecioUitario = dr.GetDecimal(posPreUni),
                            Monto = dr.GetDecimal(posMont),
                            Igv = dr.GetDecimal(posIgv),
                            Total = dr.GetDecimal(posTot),
                            FechaRegistro = dr.GetString(posFv)
                        };
                        lista.Add(compDet);
                    }
                    dr.Close();
                }
            }
            return lista;
        }

        public List<ComprobanteDetalle> listarComprobante_Fecha(ComprobanteDetalle t, SqlConnection cn)
        {
            List<ComprobanteDetalle> lista = null;

            using (cmd = new SqlCommand("Comprobante_Buscar_Fechas", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@FechaIni", t.FechaIni);
                cmd.Parameters.AddWithValue("@FechaFin", t.FechaFin);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    ComprobanteDetalle compDet;
                    int posClie = dr.GetOrdinal("Cliente");
                    int posNomPro = dr.GetOrdinal("NombreProducto");
                    int posCant = dr.GetOrdinal("Cantidad");
                    int posPreUni = dr.GetOrdinal("PrecioUitario");
                    int posMont = dr.GetOrdinal("Monto");
                    int posIgv = dr.GetOrdinal("Igv");
                    int posTot = dr.GetOrdinal("Total");
                    int posFv = dr.GetOrdinal("FechaVenta");
                    lista = new List<ComprobanteDetalle>();
                    while (dr.Read())
                    {
                        compDet = new ComprobanteDetalle()
                        {
                            Cliente = dr.GetString(posClie),
                            NombreProducto = dr.GetString(posNomPro),
                            Cantidad = dr.GetInt32(posCant),
                            PrecioUitario = dr.GetDecimal(posPreUni),
                            Monto = dr.GetDecimal(posMont),
                            Igv = dr.GetDecimal(posIgv),
                            Total = dr.GetDecimal(posTot),
                            FechaRegistro = dr.GetString(posFv)
                        };
                        lista.Add(compDet);
                    }
                    dr.Close();
                }
            }
            return lista;
        }

        public List<ComprobanteDetalle> listarComprobante_Producto(ComprobanteDetalle t, SqlConnection cn)
        {
            List<ComprobanteDetalle> lista = null;

            using (cmd = new SqlCommand("Comprobante_Buscar_Prod", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@Producto", t.NombreProducto);
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    ComprobanteDetalle compDet;
                    int posNomPro = dr.GetOrdinal("NombreProducto");
                    int posCant = dr.GetOrdinal("Cantidad");
                    int posPreUni = dr.GetOrdinal("PrecioUitario");
                    int posMont = dr.GetOrdinal("Monto");
                    int posIgv = dr.GetOrdinal("Igv");
                    int posTot = dr.GetOrdinal("Total");
                    int posFv = dr.GetOrdinal("FechaVenta");
                    lista = new List<ComprobanteDetalle>();
                    while (dr.Read())
                    {
                        compDet = new ComprobanteDetalle()
                        {
                            NombreProducto = dr.GetString(posNomPro),
                            Cantidad = dr.GetInt32(posCant),
                            PrecioUitario = dr.GetDecimal(posPreUni),
                            Monto = dr.GetDecimal(posMont),
                            Igv = dr.GetDecimal(posIgv),
                            Total = dr.GetDecimal(posTot),
                            FechaRegistro = dr.GetString(posFv)
                        };
                        lista.Add(compDet);
                    }
                    dr.Close();
                }
            }
            return lista;
        }

        public void updateComprobante(ComprobanteDetalle t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("Comprobante_Actualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", t.ComprobanteId);
                cmd.Parameters.AddWithValue("@Cliente", t.Cliente);
                cmd.Parameters.AddWithValue("@Igv", t.Igv);
                cmd.Parameters.AddWithValue("@Total", t.Total);
                cmd.ExecuteNonQuery();               
            }
        }

        public void updateComprobanteDetalle(ComprobanteDetalle t, SqlConnection cn)
        {
            using (cmd = new SqlCommand("ComprobanteDetalle_Actualizar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@IdComprobante", t.ComprobanteId);
                cmd.Parameters.AddWithValue("@ProductoId", t.ProductoId);
                cmd.Parameters.AddWithValue("@Cantidad", t.Cantidad);
                cmd.Parameters.AddWithValue("@PrecioUnitario", t.PrecioUitario);
                cmd.Parameters.AddWithValue("@Monto", t.Monto);
                cmd.ExecuteNonQuery();
            }
        }

        public List<ComprobanteDetalle> ListarProducto(SqlConnection cn)
        {
            List<ComprobanteDetalle> lista = null;

            using (cmd = new SqlCommand("Producto_Listar", cn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr != null)
                {
                    ComprobanteDetalle compDet;
                    int posCodPro = dr.GetOrdinal("IdProducto");
                    int posNomPro = dr.GetOrdinal("ClienNombreProductote");
                    lista = new List<ComprobanteDetalle>();
                    while (dr.Read())
                    {
                        compDet = new ComprobanteDetalle()
                        {
                            ProductoId = dr.GetInt32(posCodPro),
                            NombreProducto = dr.GetString(posNomPro),
                        };
                        lista.Add(compDet);
                    }
                    dr.Close();
                }
            }
            return lista;
        }
    }
}
