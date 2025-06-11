using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GestionMovInventario.Models
{
    public class FiltroMovInventarioModel
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Tipo_Movimiento { get; set; }
        public string Nro_Documento { get; set; }
    }
}