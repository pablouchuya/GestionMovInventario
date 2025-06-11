using GestionMovInventario.Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionMovInventario.Entidades.Response;
using GestionMovInventario.Entidades.Request;
using GestionMovInventario.Models;

namespace GestionMovInventario.Controllers
{
    public class MovInventarioController : Controller
    {
        private readonly MovInventarioBL bl = new MovInventarioBL();

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult ConsultarMovInventario(FiltroMovInventarioModel model)
        {
            try
            {
                FiltrarMovInventario entidad = new FiltrarMovInventario();
                entidad.FechaInicio = model.FechaInicio;
                entidad.FechaFin = model.FechaFin;
                entidad.Tipo_Movimiento = model.Tipo_Movimiento;
                entidad.Nro_Documento = model.Nro_Documento;

                List<ListarMovInventario> lista = new List<ListarMovInventario>();
                lista = bl.ConsultarMovInventario(entidad).OrderBy(f => f.Fecha_Transaccion).ToList();
                return Json(lista, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al listar Movimiento Inventario: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public JsonResult ObtenerPorMovInventario(MovInventarioModel model)
        {
            try
            {
                MovInventario entidad = new MovInventario();
                entidad.Cod_CIA = model.Cod_CIA;
                entidad.Compania_Venta_3 = model.Compania_Venta_3;
                entidad.Almacen_Venta = model.Almacen_Venta;
                entidad.Tipo_Movimiento = model.Tipo_Movimiento;
                entidad.Tipo_Documento = model.Tipo_Documento;
                entidad.Nro_Documento = model.Nro_Documento;
                entidad.Cod_Item_2 = model.Cod_Item_2;

                ListarMovInventario row = new ListarMovInventario();
                row = bl.ObtenerPorMovInventario(entidad);
                return Json(row, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al obtener Movimiento Inventario: " + ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult InsertarMovInventario(RegistroMovInventarioModel model)
        {
            try
            {
               if (string.IsNullOrWhiteSpace(model.Cod_CIA) ||
               string.IsNullOrWhiteSpace(model.Compania_Venta_3) ||
               string.IsNullOrWhiteSpace(model.Almacen_Venta) ||
               string.IsNullOrWhiteSpace(model.Tipo_Movimiento) ||
               string.IsNullOrWhiteSpace(model.Tipo_Documento) ||
               string.IsNullOrWhiteSpace(model.Nro_Documento) ||
               string.IsNullOrWhiteSpace(model.Cod_Item_2))
               {
                    return Json(new { success = false, message = "Campos requeridos incompletos." });
               }

                RegistrarMovInventario entidad = new RegistrarMovInventario();
                entidad.Cod_CIA = model.Cod_CIA;
                entidad.Compania_Venta_3 = model.Compania_Venta_3;
                entidad.Almacen_Venta = model.Almacen_Venta;
                entidad.Tipo_Movimiento = model.Tipo_Movimiento;
                entidad.Tipo_Documento = model.Tipo_Documento;
                entidad.Nro_Documento = model.Nro_Documento;
                entidad.Cod_Item_2 = model.Cod_Item_2;
                entidad.Proveedor = model.Proveedor;
                entidad.Almacen_Destino = model.Almacen_Destino;
                entidad.Cantidad = model.Cantidad;
                entidad.Doc_Ref_1 = model.Doc_Ref_1;
                entidad.Doc_Ref_2 = model.Doc_Ref_2;
                entidad.Doc_Ref_3 = model.Doc_Ref_3;
                entidad.Doc_Ref_4 = model.Doc_Ref_4;
                entidad.Doc_Ref_5 = model.Doc_Ref_5;

                bl.InsertarMovInventario(entidad);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al crear Movimiento Inventario: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult ActualizarMovInventario(RegistroMovInventarioModel model)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(model.Cod_CIA) ||
               string.IsNullOrWhiteSpace(model.Compania_Venta_3) ||
               string.IsNullOrWhiteSpace(model.Almacen_Venta) ||
               string.IsNullOrWhiteSpace(model.Tipo_Movimiento) ||
               string.IsNullOrWhiteSpace(model.Tipo_Documento) ||
               string.IsNullOrWhiteSpace(model.Nro_Documento) ||
               string.IsNullOrWhiteSpace(model.Cod_Item_2))
                {
                    return Json(new { success = false, message = "Campos requeridos incompletos." });
                }

                RegistrarMovInventario entidad = new RegistrarMovInventario();
                entidad.Cod_CIA = model.Cod_CIA;
                entidad.Compania_Venta_3 = model.Compania_Venta_3;
                entidad.Almacen_Venta = model.Almacen_Venta;
                entidad.Tipo_Movimiento = model.Tipo_Movimiento;
                entidad.Tipo_Documento = model.Tipo_Documento;
                entidad.Nro_Documento = model.Nro_Documento;
                entidad.Cod_Item_2 = model.Cod_Item_2;
                entidad.Proveedor = model.Proveedor;
                entidad.Almacen_Destino = model.Almacen_Destino;
                entidad.Cantidad = model.Cantidad;
                entidad.Doc_Ref_1 = model.Doc_Ref_1;
                entidad.Doc_Ref_2 = model.Doc_Ref_2;
                entidad.Doc_Ref_3 = model.Doc_Ref_3;
                entidad.Doc_Ref_4 = model.Doc_Ref_4;
                entidad.Doc_Ref_5 = model.Doc_Ref_5;

                bl.ActualizarMovInventario(entidad);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al actualizar Movimiento Inventario: " + ex.Message });
            }
        }

        [HttpPost]
        public JsonResult EliminarMovInventario(MovInventarioModel model)
        {
            try
            {
                MovInventario entidad = new MovInventario();
                entidad.Cod_CIA = model.Cod_CIA;
                entidad.Compania_Venta_3 = model.Compania_Venta_3;
                entidad.Almacen_Venta = model.Almacen_Venta;
                entidad.Tipo_Movimiento = model.Tipo_Movimiento;
                entidad.Tipo_Documento = model.Tipo_Documento;
                entidad.Nro_Documento = model.Nro_Documento;
                entidad.Cod_Item_2 = model.Cod_Item_2;

                bl.EliminarMovInventario(entidad);
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Error al eliminar Movimiento Inventario: " + ex.Message });
            }
        }

    }
}