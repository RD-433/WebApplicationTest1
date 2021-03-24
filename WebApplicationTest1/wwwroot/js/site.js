// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.


function AddSelect() {
    //var div = document.getElementById("SelectDiv");
    var select2 = document.getElementById("Select 2");
    var select3 = document.getElementById("Select 3");
    if (select2.hidden) {
        select2.hidden = false;
        return;
    }
    else if (select3.hidden) {
        select3.hidden = false;
        return;
    }

}

function RemoveSelect(a) {
    //var div = document.getElementById("SelectDiv");
    var select2 = document.getElementById("Select 2");
    var select3 = document.getElementById("Select 3");
    if (!select3.hidden) {
        select3.hidden = true;
        for (var i = 1; i <= a; i++) {
            
        }
        return;
    }
    else if (!select2.hidden) {
        select2.hidden = true;
        return;
    }

}


// Write your JavaScript code.
