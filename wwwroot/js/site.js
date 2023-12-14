// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function EnableTextBox(chkId, txtId) {

    if (document.getElementById(chkId).checked == true)
        document.getElementById(txtId).disabled = false
    else {

        document.getElementById(txtId).disabled = true
    }
}