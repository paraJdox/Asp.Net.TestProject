// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(() => {
    /*====================
     Modal CRUD Operations
    =====================*/
    // the modal(_UserModalPartial) appears in this div 
    let modalArea = $('#modal-area');

    // .data-operation is applied to "Create, Edit, Details, Delete" buttons in Views/Employees/Index.cshtml
    $('.data-operation').click(function () {
        // $(this) === .data-operation
        // this will get the data-url value from .data-operation's data-url attribute
        let url = $(this).data('url');
        let decodedUrl = decodeURIComponent(url);

        // ajax get request
        $.get(decodedUrl).done((data) => {
            // the value "data" is the full markup of the _EmployeeModelPartial(modal)
            modalArea.html(data);
            modalArea.find('.modal').modal('show');

            // see the "data" value here
            // console.log(data);
        });

        /*modalArea.on('click', '.data-operation-execute', function () {
            // $(this) === the div with the id "modal-area"
            let form = $(this).parents('.modal').find('form');
            let controllerName = window.location.pathname.split("/")[1];
            let actionUrl = `${controllerName}/${form.attr('action')}`;

            // the data that you want to send using the form
            let sendData = form.serialize();

            // ajax post request
            $.post(actionUrl, sendData).done(() => {
                // after adding and employee, the modal will be hidden
                modalArea.find('.modal').modal('hide');

                // this reloads the PAGE
                location.reload(true);
            });
        });*/
    });
});