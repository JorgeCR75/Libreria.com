﻿const divModal = document.querySelector('#divModal');

function mostrarMensaje(msj) {

    var modal = "<div class='modal fade' id='myModal' tabindex='-1' aria-labelledby='exampleModalLabel' aria-hidden='true'>" +
        "<div class='modal-dialog modal-dialog-centered modal-sm'>" +
        "<div class='modal-content'>" +
        "<div class='modal-header' Style='background-color:darkorange'>" +
        "<h6 class='modal-title' id='exampleModalLabel' >Mensaje del sistema</h6>" +
        "<button type='button' class='close' data-dismiss='modal' aria-label='Close'>" +
        "<span aria-hidden='true'>&times;</span>" +
        "</button>" +
        "</div>" +
        "<div class='modal-body'>" +
        "" + msj + "" +
        "</div>" +
        "<div class='modal-footer'>   " +
        "<button type='button' Style='background-color:darkorange;' class='btn' data-dismiss='modal'>Ok</button>" +
        "</div>" +
        "</div>" +
        "</div>" +
        "</div>";

    divModal.innerHTML = modal;

    $("#myModal").modal('show');
}
