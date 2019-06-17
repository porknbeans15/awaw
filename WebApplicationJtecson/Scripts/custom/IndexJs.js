$(document).ready(function () {
    GetAllRecords();

    $('#dateOfBirth').datepicker({
        dateFormat: 'mm-dd-yy',
        onSelect: function (date) {
            $(this).focusout();
        }
    });

    $("input[name='btnSave']").click(function () {

        $('form').validate();
        if ($('form').valid()) {
            if ($('#exampleModalLongTitle #msg').text() == "REGISTER") {
                RegisterRecord();

                $('input[name="Lastname"]').val('');
                $('input[name="Middlename"]').val('');
                $('input[name="Firstname"]').val('');
                $('input[name="BirthdateStr"]').val('');
                $('input[name="Id"]').val('');

                var g = $('input[name="Gender"]');
                $(g[0]).prop("checked", false);
                $(g[1]).prop("checked", false);

            }
            else if ($('#exampleModalLongTitle #msg').text() == "UPDATE") {
                UpdateRecord();
            }

        }

    });

    $("input[name='btnReg']").click(function () {

        if ($('#exampleModalLongTitle #msg').length > 0) {
            $('#exampleModalLongTitle #msg').remove();
        }
        $('#exampleModalLongTitle').append("<div id='msg'>REGISTER</div>");

        $('.modal').modal('toggle');


        $('input[name="Lastname"]').val('');
        $('input[name="Middlename"]').val('');
        $('input[name="Firstname"]').val('');
        $('input[name="BirthdateStr"]').val('');
        $('input[name="Id"]').val('');

        var g = $('input[name="Gender"]');
        $(g[0]).prop("checked", false);
        $(g[1]).prop("checked", false);

    });


    $('table').on('click', 'input[name="btnUpdate"]', function (event) {

        if ($('#exampleModalLongTitle #msg').length > 0) {
            $('#exampleModalLongTitle #msg').remove();
        }
        GetRecord($(this).data('val'));
        $('#exampleModalLongTitle').append("<div id='msg'>UPDATE</div>");


        $('.modal').modal('toggle');




    });


    $('table').on('click', 'input[name="btnDelete"]', function (event) {
        DeleteRecord($(this).data('val'));
    });
});

function RegisterRecord() {
    $.ajax({
        type: "POST",
        url: "/Home/SaveForm",
        data: $('form').serializeArray(),
        traditional: true,
        success: function (data) {
            $('.modal').modal('toggle');
            GetAllRecords();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function UpdateRecord() {
    $.ajax({
        type: "POST",
        url: "/Home/UpdateForm",
        data: $('form').serializeArray(),
        traditional: true,
        success: function (data) {
            $('.modal').modal('toggle');
            GetAllRecords();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function GetRecord(id) {
    $.ajax({
        type: "POST",
        url: "/Home/GetUser",
        data: JSON.stringify({ 'UserID': id }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {
            $('input[name="Lastname"]').val(data.Lastname);
            $('input[name="Middlename"]').val(data.Middlename);
            $('input[name="Firstname"]').val(data.Firstname);
            $('input[name="BirthdateStr"]').val(data.BirthdateStr);
            $('input[name="Id"]').val(data.Id);

            var g = $('input[name="Gender"]');
            if (data.Gender == "M") {
                $(g[0]).prop("checked", true);
            } else if (data.Gender == "F") {
                $(g[1]).prop("checked", true);
            }

        },
        error: function (data) {
            console.log(data);
        }
    });
}

function DeleteRecord(id) {
    $.ajax({
        type: "POST",
        url: "/Home/DeleteUser",
        data: JSON.stringify({ 'UserID': id }),
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            GetAllRecords();
        },
        error: function (data) {
            console.log(data);
        }
    });
}

function GetAllRecords() {
    $.ajax({
        type: "POST",
        url: "/Home/GetAllUser",
        contentType: 'application/json; charset=utf-8',
        success: function (data) {

            if ($('tr').next().next().length > 0) {
                $('tr').next().next().remove();
            }

            for (x = 0; x < data.length; x++) {
                $($("table tr")[1]).after("<tr><td>" + data[x].Id + "</td><td>" + data[x].Lastname + "</td><td>" + data[x].Firstname + "</td><td>" + data[x].Middlename + "</td><td>" + data[x].Gender + "</td><td>" + data[x].BirthdateStr + "</td><td><input type='button' name='btnUpdate' id='btnUpdate' value='UPDATE' class='btn btn-primary' data-val=" + data[x].Id + "><input type='button' name='btnDelete' id='btnDelete' value='DELETE' class='btn btn-primary' data-val=" + data[x].Id + "></td></tr>");

            }
        },
        error: function (data) {
            console.log(data);
        }

    });
}