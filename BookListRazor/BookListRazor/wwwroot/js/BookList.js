var dataTable;

$(document).ready(function () {

    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#DT_load').DataTable({
        "ajax": {
            "url": "/api/book",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "name", "width": "30%" },
            { "data": "author", "width": "20%" },
            { "data": "isbn", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class=text-center">
                    <a href="/BookList/Edit?id=${data}" class='btn btn-success text-white' style='custor:pointer;width:100px;'>
                        Edit
                    </a>
                    &nbsp;
                    <a  class='btn btn-danger text-white' style='cursor:pointer;width:70px;'
                        onclick= "DeleteFunct('/api/book?id='+${data})">
                        Delete
                    </a>
                    </div>`;
                }, " width": "30%"
            }
        ],
        "language": {
            "emptyTable": "no data found"
        },
        "width": "100%"
    });
}

function DeleteFunct(url) {
    swal({
        title: "Are you sure?",
        text: "once deleted, you will not be able to retrive the data",
        icon: "warning",
        buttons:true,
        dangerMode: true
    }).then((willDelete) => {
        if (willDelete) {
            $.ajax({
                type: "DELETE",
                url: url ,
                success: function (datas) {
                    if (datas.success) {
                        toastr.success(datas.message);
                        dataTable.ajax.reload();
                    }
                    else {
                        toastr.error(datas.message);
                    }
                }
            });
        }
    });
}