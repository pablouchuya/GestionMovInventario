using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using GestionMovInventario.Entidades.Request;
using GestionMovInventario.Entidades.Response;

namespace GestionMovInventario.Datos
{
    public class MovInventarioDA
    {
        private readonly string _oCon = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;

        public List<ListarMovInventario> ConsultarMovInventario(FiltrarMovInventario entidad)
        {
            try
            {
                var lista = new List<ListarMovInventario>();
                using (SqlConnection conn = new SqlConnection(_oCon))
                using (SqlCommand cmd = new SqlCommand("SP_CONSULTAR_MOVINVENTARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FECHAINICIO", (object)entidad.FechaInicio ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FECHAFIN", (object)entidad.FechaFin ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", (object)entidad.Tipo_Movimiento ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", (object)entidad.Nro_Documento ?? DBNull.Value);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            lista.Add(new ListarMovInventario
                            {
                                Cod_CIA = reader["COD_CIA"].ToString(),
                                Compania_Venta_3 = reader["COMPANIA_VENTA_3"].ToString(),
                                Almacen_Venta = reader["ALMACEN_VENTA"].ToString(),
                                Tipo_Movimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                                Tipo_Documento = reader["TIPO_DOCUMENTO"].ToString(),
                                Nro_Documento = reader["NRO_DOCUMENTO"].ToString(),
                                Cod_Item_2 = reader["COD_ITEM_2"].ToString(),
                                Proveedor = reader["PROVEEDOR"].ToString(),
                                Almacen_Destino = reader["ALMACEN_DESTINO"].ToString(),
                                Cantidad = reader["CANTIDAD"] as int?,
                                Doc_Ref_1 = reader["DOC_REF_1"].ToString(),
                                Doc_Ref_2 = reader["DOC_REF_2"].ToString(),
                                Doc_Ref_3 = reader["DOC_REF_3"].ToString(),
                                Doc_Ref_4 = reader["DOC_REF_4"].ToString(),
                                Doc_Ref_5 = reader["DOC_REF_5"].ToString(),
                                Fecha_Transaccion = Convert.ToDateTime(reader["Fecha_Transaccion"]).ToString()
                            });
                        }
                    }
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAL -> ConsultarMovInventario: " + ex.Message, ex);
            } 
        }

        public ListarMovInventario ObtenerPorMovInventario(MovInventario entidad)
        {
            try
            {
                ListarMovInventario row = null;
                using (SqlConnection conn = new SqlConnection(_oCon))
                {
                    var cmd = new SqlCommand("SP_OBTENER_MOVINVENTARIO", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", entidad.Cod_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", entidad.Compania_Venta_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", entidad.Almacen_Venta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", entidad.Tipo_Movimiento);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", entidad.Tipo_Documento);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", entidad.Nro_Documento);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", entidad.Cod_Item_2);
                    conn.Open();
                    var reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        row = new ListarMovInventario
                        {
                            Cod_CIA = reader["COD_CIA"].ToString(),
                            Compania_Venta_3 = reader["COMPANIA_VENTA_3"].ToString(),
                            Almacen_Venta = reader["ALMACEN_VENTA"].ToString(),
                            Tipo_Movimiento = reader["TIPO_MOVIMIENTO"].ToString(),
                            Tipo_Documento = reader["TIPO_DOCUMENTO"].ToString(),
                            Nro_Documento = reader["NRO_DOCUMENTO"].ToString(),
                            Cod_Item_2 = reader["COD_ITEM_2"].ToString(),
                            Proveedor = reader["PROVEEDOR"].ToString(),
                            Almacen_Destino = reader["ALMACEN_DESTINO"].ToString(),
                            Cantidad = reader["CANTIDAD"] as int?,
                            Doc_Ref_1 = reader["DOC_REF_1"].ToString(),
                            Doc_Ref_2 = reader["DOC_REF_2"].ToString(),
                            Doc_Ref_3 = reader["DOC_REF_3"].ToString(),
                            Doc_Ref_4 = reader["DOC_REF_4"].ToString(),
                            Doc_Ref_5 = reader["DOC_REF_5"].ToString(),
                            Fecha_Transaccion = Convert.ToDateTime(reader["Fecha_Transaccion"]).ToString()
                        };
                    }
                }
                return row;
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAL -> ObtenerPorMovInventario: " + ex.Message, ex);
            }
        }

        public void InsertarMovInventario(RegistrarMovInventario entidad)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_oCon))
                using (SqlCommand cmd = new SqlCommand("SP_INSERTAR_MOVINVENTARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", entidad.Cod_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", entidad.Compania_Venta_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", entidad.Almacen_Venta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", entidad.Tipo_Movimiento);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", entidad.Tipo_Documento);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", entidad.Nro_Documento);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", entidad.Cod_Item_2);
                    cmd.Parameters.AddWithValue("@PROVEEDOR", (object)entidad.Proveedor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object)entidad.Almacen_Destino ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CANTIDAD", (object)entidad.Cantidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_1", (object)entidad.Doc_Ref_1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_2", (object)entidad.Doc_Ref_2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_3", (object)entidad.Doc_Ref_3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_4", (object)entidad.Doc_Ref_4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_5", (object)entidad.Doc_Ref_5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", entidad.Fecha_Transaccion ?? DateTime.Now);

                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAL -> InsertarMovInventario: " + ex.Message, ex);
            }
        }

        public void ActualizarMovInventario(RegistrarMovInventario entidad)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_oCon))
                using (SqlCommand cmd = new SqlCommand("SP_ACTUALIZAR_MOVINVENTARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", entidad.Cod_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", entidad.Compania_Venta_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", entidad.Almacen_Venta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", entidad.Tipo_Movimiento);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", entidad.Tipo_Documento);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", entidad.Nro_Documento);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", entidad.Cod_Item_2);
                    cmd.Parameters.AddWithValue("@PROVEEDOR", (object)entidad.Proveedor ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ALMACEN_DESTINO", (object)entidad.Almacen_Destino ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CANTIDAD", (object)entidad.Cantidad ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_1", (object)entidad.Doc_Ref_1 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_2", (object)entidad.Doc_Ref_2 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_3", (object)entidad.Doc_Ref_3 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_4", (object)entidad.Doc_Ref_4 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@DOC_REF_5", (object)entidad.Doc_Ref_5 ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@FECHA_TRANSACCION", entidad.Fecha_Transaccion ?? DateTime.Now);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAL -> ActualizarMovInventario: " + ex.Message, ex);
            }
        }

        public void EliminarMovInventario(MovInventario entidad)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(_oCon))
                using (SqlCommand cmd = new SqlCommand("SP_ELIMINAR_MOVINVENTARIO", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@COD_CIA", entidad.Cod_CIA);
                    cmd.Parameters.AddWithValue("@COMPANIA_VENTA_3", entidad.Compania_Venta_3);
                    cmd.Parameters.AddWithValue("@ALMACEN_VENTA", entidad.Almacen_Venta);
                    cmd.Parameters.AddWithValue("@TIPO_MOVIMIENTO", entidad.Tipo_Movimiento);
                    cmd.Parameters.AddWithValue("@TIPO_DOCUMENTO", entidad.Tipo_Documento);
                    cmd.Parameters.AddWithValue("@NRO_DOCUMENTO", entidad.Nro_Documento);
                    cmd.Parameters.AddWithValue("@COD_ITEM_2", entidad.Cod_Item_2);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error en DAL -> EliminarMovInventario: " + ex.Message, ex);
            }
        }
    }
}
