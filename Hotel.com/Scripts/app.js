function cargarCompra(idn) {
    document.getElementById("txtCodigoCompra").value = idn;
}
function editarCompra(idLibro, idCompra) {
    window.location.href = 'reservarLibro.aspx?idLibro=' + idLibro + '&idCompra=' + idCompra;
}
function cargarLibro(id) {
    document.getElementById("txtcodigo").value = id;
}
