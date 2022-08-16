using AppMVC_FINAL.Bussines;
using AppMVC_FINAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppMVC_FINAL.Controllers
{
    public class FacturacionController : Controller
    {
        //instanciar objeto de la clase ComprobanteBll
        ComprobanteBll obj = new ComprobanteBll();

        // GET: Facturacion
        public ActionResult Index()
        {
            return View(obj.ComprobanteListar().ToList());
        }


        // GET: Facturacion/Details/5
        public ActionResult Details(int id)
        {
            ComprobanteDetalle comDet = new ComprobanteDetalle();
            comDet.ComprobanteId = id;
            return View(obj.ComprobanteConsultar(comDet));
        }

        // GET: Facturacion/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Facturacion/Create
        [HttpPost]
        public ActionResult Create(ComprobanteDetalle comDet)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    obj.ComprobanteAdicionar(comDet);
                    obj.ComprobanteDetalleAdicionar(comDet);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Facturacion/Edit/5
        public ActionResult Edit(int id)
        {
            ComprobanteDetalle comDet = new ComprobanteDetalle();
            comDet.ComprobanteId = id;
            return View(obj.ComprobanteConsultar(comDet));
        }

        // POST: Facturacion/Edit/5
        [HttpPost]
        public ActionResult Edit(ComprobanteDetalle comDet)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    obj.ComprobanteActualizar(comDet);
                    obj.ComprobanteDetalleActualizar(comDet);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: Facturacion/Delete/5
        public ActionResult Delete(int id)
        {
            ComprobanteDetalle comDet = new ComprobanteDetalle();
            comDet.ComprobanteId = id;
            return View(obj.ComprobanteConsultar(comDet));
        }

        // POST: Facturacion/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                ComprobanteDetalle comDet = new ComprobanteDetalle();
                comDet.ComprobanteId = id;
                if (ModelState.IsValid)
                {
                    obj.ComprobanteEliminar(comDet);
                    return RedirectToAction("Index");
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
