let hide = function () {
    var elems = document.getElementById("jumbo");
    var hear = document.getElementById("button_id");
    var displaysettings = hear.style.display;
    //elems.style.display = "none";

    if (hear.firstChild.data == 'Hide Header') {
        elems.style.display = "none";
        hear.firstChild.data = "Show Header";
    } else {
        elems.style.display = "block";
        hear.firstChild.data = "Hide Header";
    }

}