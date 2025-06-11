using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMovInventario.Entidades.Request
{
    public class MovInventario
    {
        public string Cod_CIA { get; set; }
        public string Compania_Venta_3 { get; set; }
        public string Almacen_Venta { get; set; }
        public string Tipo_Movimiento { get; set; }
        public string Tipo_Documento { get; set; }
        public string Nro_Documento { get; set; }
        public string Cod_Item_2 { get; set; }
    }
}
