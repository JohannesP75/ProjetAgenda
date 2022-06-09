// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
function activerModifications() {
    console.log('début activerModifications()');
    /*
    // Activation des inputs du formulaire
    document.getElementById("input_lastname").disabled = false;
    document.getElementById("input_firstname").disabled = false;
    document.getElementById("input_email").disabled = false;
    document.getElementById("input_phone").disabled = false;
    if (document.getElementById("input_budget")!=null)
        document.getElementById("input_budget").disabled = false;
    console.log('formulaire activé');
    // Boutons activés
    document.getElementById("input_creer").disabled = false;
    document.getElementById("input_reset").disabled = false;
    console.log('boutons formulaire activés');
    // Bouton a désactiver
    document.getElementById("input_modif").disabled = true;
    // Affichage des valeirs originelles
    */
    var spanOriginalValues = document.getElementsByClassName("original_value");
    for (var i = 0; i < spanOriginalValues.length; i++)
        spanOriginalValues.item(i).removeAttribute("hidden");
    var inputForm = document.getElementsByClassName("form-control");
    for (var i = 0; i < spanOriginalValues.length; i++)
        inputForm.item(i).disabled = false;
    document.getElementById("input_creer").disabled = false;
    document.getElementById("input_reset").disabled = false;

    console.log('fin activerModifications()');
}