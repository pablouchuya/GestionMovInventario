function limpiarFormulario() {
    $('#txtCod_CIA').val('').prop('readonly', false);
    $('#txtCompania_Venta_3').val('').prop('readonly', false);
    $('#txtAlmacen_Venta').val('').prop('readonly', false);
    $('#txtTipo_Movimiento').val('').prop('disabled', false);
    $('#txtTipo_Documento').val('').prop('disabled', false);
    $('#txtNro_Documento').val('').prop('readonly', false);
    $('#txtCod_Item_2').val('').prop('readonly', false);
    $('#txtProveedor').val('').prop('readonly', false);
    $('#txtAlmacen_Destino').val('').prop('readonly', false);
    $('#txtCantidad').val('').prop('readonly', false);
    $('#txtDoc_Ref_1').val('').prop('readonly', false);
    $('#txtDoc_Ref_2').val('').prop('readonly', false);
    $('#txtDoc_Ref_3').val('').prop('readonly', false);
    $('#txtDoc_Ref_4').val('').prop('readonly', false);
    $('#txtDoc_Ref_5').val('').prop('readonly', false);
    $('#txtFecha_Transaccion').val('').prop('readonly', true);
    $('#btnGuardar').show();
    $('#btnActualizar').hide();
}

function obtenerDatosFormulario() {
    return {
        Cod_CIA: $('#txtCod_CIA').val(),
        Compania_Venta_3: $('#txtCompania_Venta_3').val(),
        Almacen_Venta: $('#txtAlmacen_Venta').val(),
        Tipo_Movimiento: $('#txtTipo_Movimiento').val(),
        Tipo_Documento: $('#txtTipo_Documento').val(),
        Nro_Documento: $('#txtNro_Documento').val(),
        Cod_Item_2: $('#txtCod_Item_2').val(),
        Proveedor: $('#txtProveedor').val(),
        Almacen_Destino: $('#txtAlmacen_Destino').val(),
        Cantidad: parseInt($('#txtCantidad').val()),
        Doc_Ref_1: $('#txtDoc_Ref_1').val(),
        Doc_Ref_2: $('#txtDoc_Ref_2').val(),
        Doc_Ref_3: $('#txtDoc_Ref_3').val(),
        Doc_Ref_4: $('#txtDoc_Ref_4').val(),
        Doc_Ref_5: $('#txtDoc_Ref_5').val(),
        Fecha_Transaccion: $('#txtFecha_Transaccion').val()
    };
}
function listarMovimientos() {
    const filtro = {
        FechaInicio: $('#filtroFechaInicio').val(),
        FechaFin: $('#filtroFechaFin').val(),
        Tipo_Movimiento: $('#filtroTipoMovimiento').val(),
        Nro_Documento: $('#filtroNroDocumento').val()
    };

    $.ajax({
        url: '/MovInventario/ConsultarMovInventario',
        type: 'GET',
        data: filtro,
        success: function (data) {
            let html = '';
            data.forEach(m => {
                html += `<tr>
                    <td>${m.Cod_CIA}</td>
                    <td>${m.Compania_Venta_3}</td>
                    <td>${m.Almacen_Venta}</td>
                    <td>${m.Tipo_Movimiento}</td>
                    <td>${m.Tipo_Documento}</td>
                    <td>${m.Nro_Documento}</td>
                    <td>${m.Cod_Item_2}</td>
                    <td>${m.Proveedor}</td>
                    <td>${m.Almacen_Destino}</td>
                    <td>
                        <button class="btn btn-sm btn-primary" onclick="abrirModalEditar('${m.Cod_CIA}','${m.Compania_Venta_3}','${m.Almacen_Venta}','${m.Tipo_Movimiento}','${m.Tipo_Documento}','${m.Nro_Documento}','${m.Cod_Item_2}')">
                            <i class="bi bi-pencil"></i>
                        </button>
                        <button class="btn btn-sm btn-danger" onclick="eliminarMovimiento('${m.Cod_CIA}','${m.Compania_Venta_3}','${m.Almacen_Venta}','${m.Tipo_Movimiento}','${m.Tipo_Documento}','${m.Nro_Documento}','${m.Cod_Item_2}')">
                            <i class="bi bi-trash"></i>
                        </button>
                    </td>
                </tr>`;
            });

            $('#tablaMovimientos tbody').html(html);
        },
        error: function () {
            alert("Error al cargar los movimientos.");
        }
    });
}

function crearMovimiento() {
    const model = obtenerDatosFormulario();

    if ($("#txtCod_CIA").val().trim() === "") {
        alert("El campo Cod. CIA es obligatorio.");
        $("#txtCod_CIA").focus();
        return;
    }

    if ($("#txtCompania_Venta_3").val().trim() === "") {
        alert("El campo Compañía Venta es obligatorio.");
        $("#txtCompania_Venta_3").focus();
        return;
    }

    if ($("#txtAlmacen_Venta").val().trim() === "") {
        alert("El campo Almacén Venta es obligatorio.");
        $("#txtAlmacen_Venta").focus();
        return;
    }

    if ($("#txtTipo_Movimiento").val().trim() === "") {
        alert("Debe seleccionar un Tipo de Movimiento.");
        $("#txtTipo_Movimiento").focus();
        return;
    }

    if ($("#txtTipo_Documento").val().trim() === "") {
        alert("Debe seleccionar un Tipo de Documento.");
        $("#txtTipo_Documento").focus();
        return;
    }

    if ($("#txtNro_Documento").val().trim() === "") {
        alert("El campo Nro. Documento es obligatorio.");
        $("#txtNro_Documento").focus();
        return;
    }

    if ($("#txtCod_Item_2").val().trim() === "") {
        alert("El campo Cod. Item es obligatorio.");
        $("#txtCod_Item_2").focus();
        return;
    }


    $.ajax({
        url: '/MovInventario/InsertarMovInventario',
        method: 'POST',
        data: model,
        success: function (res) {
            if (res.success) {
                $('#modalMovInventario').modal('hide');
                listarMovimientos();
                alert("Movimiento creado exitosamente.");
            }
        },
        error: function () {
            alert("Error al crear el movimiento.");
        }
    });
}

function abrirModalEliminar(Cod_CIA, Compania_Venta_3, Almacen_Venta, Tipo_Movimiento, Tipo_Documento, Nro_Documento, Cod_Item_2) {
    $('#modalEliminar').modal('show');
}

function abrirModalEditar(Cod_CIA, Compania_Venta_3, Almacen_Venta, Tipo_Movimiento, Tipo_Documento, Nro_Documento, Cod_Item_2) {
    $.ajax({
        url: '/MovInventario/ObtenerPorMovInventario',
        method: 'GET',
        data: { Cod_CIA, Compania_Venta_3, Almacen_Venta, Tipo_Movimiento, Tipo_Documento, Nro_Documento, Cod_Item_2 },
        success: function (m) {
            console.log(m);
            $('#txtCod_CIA').val(m.Cod_CIA).prop('readonly', true);
            $('#txtCompania_Venta_3').val(m.Compania_Venta_3).prop('readonly', true);
            $('#txtAlmacen_Venta').val(m.Almacen_Venta).prop('readonly', true);
            $('#txtTipo_Movimiento').val(m.Tipo_Movimiento).prop('disabled', true);
            $('#txtTipo_Documento').val(m.Tipo_Documento).prop('disabled', true);
            $('#txtNro_Documento').val(m.Nro_Documento).prop('readonly', true);
            $('#txtCod_Item_2').val(m.Cod_Item_2).prop('readonly', true);
            $('#txtProveedor').val(m.Proveedor);
            $('#txtAlmacen_Destino').val(m.Almacen_Destino);
            $('#txtCantidad').val(m.Cantidad);
            $('#txtDoc_Ref_1').val(m.Doc_Ref_1);
            $('#txtDoc_Ref_2').val(m.Doc_Ref_2);
            $('#txtDoc_Ref_3').val(m.Doc_Ref_3);
            $('#txtDoc_Ref_4').val(m.Doc_Ref_4);
            $('#txtDoc_Ref_5').val(m.Doc_Ref_5);
            const fecha = new Date(m.Fecha_Transaccion);
            const fechaFormateada = fecha.toISOString().split('T')[0];

            $('#txtFecha_Transaccion').val(fechaFormateada).prop('readonly', true);

            $('#btnGuardar').hide();
            $('#btnActualizar').show();
            $('#modalMovInventario').modal('show');
        },
        error: function () {
            alert("Error al obtener datos del movimiento.");
        }
    });
}

// Guardar edición
function actualizarMovimiento() {
    const model = obtenerDatosFormulario();

    if ($("#txtCompania_Venta_3").val().trim() === "") {
        alert("El campo Compañía Venta es obligatorio.");
        $("#txtCompania_Venta_3").focus();
        return;
    }

    if ($("#txtAlmacen_Venta").val().trim() === "") {
        alert("El campo Almacén Venta es obligatorio.");
        $("#txtAlmacen_Venta").focus();
        return;
    }

    if ($("#txtTipo_Movimiento").val().trim() === "") {
        alert("Debe seleccionar un Tipo de Movimiento.");
        $("#txtTipo_Movimiento").focus();
        return;
    }

    if ($("#txtTipo_Documento").val().trim() === "") {
        alert("Debe seleccionar un Tipo de Documento.");
        $("#txtTipo_Documento").focus();
        return;
    }

    if ($("#txtNro_Documento").val().trim() === "") {
        alert("El campo Nro Documento es obligatorio.");
        $("#txtNro_Documento").focus();
        return;
    }

    if ($("#txtCod_Item_2").val().trim() === "") {
        alert("El campo Cod Item es obligatorio.");
        $("#txtCod_Item_2").focus();
        return;
    }


    $.ajax({
        url: '/MovInventario/ActualizarMovInventario',
        method: 'POST',
        data: model,
        success: function (res) {
            if (res.success) {
                $('#modalMovInventario').modal('hide');
                listarMovimientos();
                alert("Movimiento actualizado exitosamente.");
            }
        },
        error: function () {
            alert("Error al actualizar el movimiento.");
        }
    });
}

// Eliminar
function eliminarMovimiento(Cod_CIA, Compania_Venta_3, Almacen_Venta, Tipo_Movimiento, Tipo_Documento, Nro_Documento, Cod_Item_2) {
    if (confirm("¿Seguro de eliminar el movimiento?")) {
        $.ajax({
            url: '/MovInventario/EliminarMovInventario',
            method: 'POST',
            data: { Cod_CIA, Compania_Venta_3, Almacen_Venta, Tipo_Movimiento, Tipo_Documento, Nro_Documento, Cod_Item_2 },
            success: function (res) {
                if (res.success) {
                    listarMovimientos();
                    alert("Movimiento eliminado exitosamente.");
                }
            },
            error: function () {
                alert("Error al eliminar el movimiento.");
            }
        });
    }
}


$(function () {
    listarMovimientos();
    $('#btnGuardar').click(crearMovimiento);
    $('#btnActualizar').click(actualizarMovimiento);
    $('#btnBuscar').click(listarMovimientos);
    $('#btnNuevo').click(function () {
        limpiarFormulario();
        $('#modalMovInventario').modal('show');
    });
    $('#btnCerraModal').click(function () {
        $('#modalMovInventario').modal('hide');
    });
    $('#btnLimpiarFiltros').on('click', function () {
        $('#filtroFechaInicio').val('');
        $('#filtroFechaFin').val('');
        $('#filtroTipoMovimiento').val('');
        $('#filtroNroDocumento').val('');
        $('#btnBuscar').click();
    });

});
