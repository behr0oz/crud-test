window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "Operation Successful", { timeOut: 10000, allowHtml: true });
    }
    if (type === "error") {
        toastr.error(message, "Operation Failed", { timeOut: 10000, allowHtml: true });
    }
}


window.ShowSwal = (type, message) => {
    if (type === "success") {
        Swal.fire(
            'Success Notification',
            message,
            'success'
        )
    }
    if (type === "error") {
        Swal.fire(
            'Error Notification',
            message,
            'error'
        )
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}

function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}