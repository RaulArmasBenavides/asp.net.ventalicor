using AppMVC_FINAL.Bussines;
using AppMVC_FINAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC_FINAL.Controllers
{
    public class ConsultaController : Controller
    {
        //instanciar objeto de la clase ComprobanteBll
        ComprobanteBll obj = new ComprobanteBll();

        // GET: Consulta
        public ActionResult Index( string fIni, string fFin)
        {
            if(fIni== null || fFin==null)
            {
                ComprobanteDetalle comDet = new ComprobanteDetalle();
                comDet.FechaIni = "2017/08/01";
                comDet.FechaFin = "2017/08/30";
                return View(obj.ComprobanteListar_Fecha(comDet).ToList());
            }
            else
            {
                ComprobanteDetalle comDet = new ComprobanteDetalle();
                comDet.FechaIni = fIni;
                comDet.FechaFin = fFin;
                return View(obj.ComprobanteListar_Fecha(comDet).ToList());
            }

        }
    }
}