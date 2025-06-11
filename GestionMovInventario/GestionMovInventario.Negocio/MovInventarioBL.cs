using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GestionMovInventario.Datos;
using GestionMovInventario.Entidades.Request;
using GestionMovInventario.Entidades.Response;

namespace GestionMovInventario.Negocio
{
    public class MovInventarioBL
    {
        private readonly MovInventarioDA da = new MovInventarioDA();
        public List<ListarMovInventario> ConsultarMovInventario(FiltrarMovInventario request)
        {
            try
            {
                return da.ConsultarMovInventario(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BL -> ConsultarMovInventario: " + ex.Message, ex);
            }
        }

        public ListarMovInventario ObtenerPorMovInventario(MovInventario request)
        {
            try
            {
                return da.ObtenerPorMovInventario(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BL -> ObtenerPorMovInventario: " + ex.Message, ex);
            }
        }

        public void InsertarMovInventario(RegistrarMovInventario request)
        {
            try
            {
                da.InsertarMovInventario(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BL -> InsertarMovInventario: " + ex.Message, ex);
            }
        }

        public void ActualizarMovInventario(RegistrarMovInventario request)
        {
            try
            {
                da.ActualizarMovInventario(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BL -> ActualizarMovInventario: " + ex.Message, ex);
            }
        }

        public void EliminarMovInventario(MovInventario request)
        {
            try
            {
                da.EliminarMovInventario(request);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en BL -> EliminarMovInventario: " + ex.Message, ex);
            }
        }
    }
}
