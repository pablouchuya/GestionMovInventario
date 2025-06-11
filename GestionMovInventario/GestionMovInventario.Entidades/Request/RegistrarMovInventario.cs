using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionMovInventario.Entidades.Request
{
    public class RegistrarMovInventario
    {
        [Required(ErrorMessage = "El campo Cod. CIA es obligatorio")]
        [StringLength(5)]
        public string Cod_CIA{ get; set; }

        [Required(ErrorMessage = "El campo Compañia Venta 3 es obligatorio")]
        [StringLength(5)]
        public string Compania_Venta_3 { get; set; }

        [Required(ErrorMessage = "El campo Almacen Venta es obligatorio")]
        [StringLength(10)]
        public string Almacen_Venta { get; set; }

        [Required(ErrorMessage = "El campo Tipo Movimiento es obligatorio")]
        [StringLength(2)]
        public string Tipo_Movimiento { get; set; }

        [Required(ErrorMessage = "El campo Tipo Documento es obligatorio")]
        [StringLength(2)]
        public string Tipo_Documento { get; set; }

        [Required(ErrorMessage = "El campo Nro. Documento es obligatorio")]
        [StringLength(50)]
        public string Nro_Documento { get; set; }

        [Required(ErrorMessage = "El campo Cod Item 2 es obligatorio")]
        [StringLength(50)]
        public string Cod_Item_2 { get; set; }

        [StringLength(100)]
        public string Proveedor { get; set; }

        [StringLength(50)]
        public string Almacen_Destino { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "La cantidad debe ser un valor positivo")]
        public int? Cantidad { get; set; }

        [StringLength(50)]
        public string Doc_Ref_1 { get; set; }
        [StringLength(50)]
        public string Doc_Ref_2 { get; set; }
        [StringLength(50)]
        public string Doc_Ref_3 { get; set; }
        [StringLength(50)]
        public string Doc_Ref_4 { get; set; }
        [StringLength(50)]
        public string Doc_Ref_5 { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Fecha_Transaccion { get; set; }
    }
}
