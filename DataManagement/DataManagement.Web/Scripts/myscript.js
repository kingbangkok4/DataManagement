function cd2s(dt) {
    return dt.toISOString();
}

function convertDate2String(dt) {
    return cd2s(dt);
}

function isNumber(evt) {
    evt = (evt) ? evt : window.event;
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57)) {
        return false;
    }
    return true;
}