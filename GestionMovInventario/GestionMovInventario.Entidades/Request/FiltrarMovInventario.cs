using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMovInventario.Entidades.Request
{
    public class FiltrarMovInventario
    {
        public DateTime? FechaInicio { get; set; }
        public DateTime? FechaFin { get; set; }
        public string Tipo_Movimiento { get; set; }
        public string Nro_Documento { get; set; }
        
    }
}
