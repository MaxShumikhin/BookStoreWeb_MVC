var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": { url: '/admin/category/getall' },
        "columns": [
            { data: 'name', "width": "35%" },
            { data: 'displayOrder', "width": "35%" },
            {
                data: 'id',
                "render": function (data) {
                    return `<div class="btn-group" role="group">
                        <a href="/admin/category/upsert?id=${data}" class="button edit-button"> <i class="bi bi-pencil-square"></i> Edit </a>
                        <button class="button" onclick="Delete('/admin/category/delete/${data}', this)">
                            <div class="trash">
                                <div class="top">
                                    <div class="paper"></div>
                                </div>
                                <div class="box"></div>
                                <div class="check">
                                    <svg viewBox="0 0 8 6">
                                        <polyline points="1 3.4 2.71428571 5 7 1"></polyline>
                                    </svg>
                                </div>
                            </div>
                            <span> Delete </span>
                        </button>
                    </div>`;
                },
                "width": "30%"
}
        ]
    });
}

function Delete(url, buttonElement) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            buttonElement.classList.add('delete');
            $.ajax({
                url: url,
                type: 'DELETE',
                success: function (data) {
                    setTimeout(() => {
                        buttonElement.classList.remove('delete');
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }, 3200);
                }
            });
        }
    });
}