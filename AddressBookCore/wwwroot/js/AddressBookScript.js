$(document).ready(function () {
    $('#cancel').click(hideForm);
    $('.contacts').on('click', '.contact', showContactInfo);
});

function hideForm() {
    $('#overlay').hide(100);
}

function showContactInfo() {
    $('<%=contact-info.ClientID%>').show();
}

function confirmDelete() {
    if (confirm("do you want to delete")) {
        return true;
    }
    else {
        return false;
    }
}