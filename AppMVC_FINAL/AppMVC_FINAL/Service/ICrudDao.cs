using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AppMVC_FINAL.Service
{
    public interface ICrudDao<T>
    {
        //definir las firmas
        void createComprobante(T t, SqlConnection cn);

        void createComprobanteDetalle(T t, SqlConnection cn);
        void updateComprobante(T t, SqlConnection cn);
        void updateComprobanteDetalle(T t, SqlConnection cn);
        void delete(T t, SqlConnection cn);
        T findForId(T t, SqlConnection cn);
        List<T> readAll(SqlConnection cn);
        List<T> listarComprobante_Producto(T t, SqlConnection cn);
        List<T> listarComprobante_Fecha(T t, SqlConnection cn);
    }
}
