using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMovInventario.Entidades.Response
{
    public class ListarMovInventario
    {
        public string Cod_CIA { get; set; }
        public string Compania_Venta_3 { get; set; }
        public string Almacen_Venta { get; set; }
        public string Tipo_Movimiento { get; set; }
        public string Tipo_Documento { get; set; }
        public string Nro_Documento { get; set; }
        public string Cod_Item_2 { get; set; }
        public string Proveedor { get; set; }
        public string Almacen_Destino { get; set; }
        public int? Cantidad { get; set; }
        public string Doc_Ref_1 { get; set; }
        public string Doc_Ref_2 { get; set; }
        public string Doc_Ref_3 { get; set; }
        public string Doc_Ref_4 { get; set; }
        public string Doc_Ref_5 { get; set; }
        public string Fecha_Transaccion { get; set; }
    }
}
