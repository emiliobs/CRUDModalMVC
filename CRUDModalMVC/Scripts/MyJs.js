$(document).ready(function () {


    $.ajaxSetup({ cache: false });


    $("#openDialog").click(function (e) {
        e.preventDefault();
        var url = $(this).attr('href');


        $("#dialogEdit").dialog({
            title: 'Add Student',
            autoOpen: false,
            resizable: false,
            height: 450,
            width: 500,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).load(url);
            },
            close: function (event, ui) {
                $(this).dialog('close');
            }
        });

        $("#dialogEdit").dialog('open');
        return false;
    });

    $(".editDialog").click(function (e) {
        var url = $(this).attr('href');
        $("#dialogEdit").dialog({
            title: 'Edit Student',
            autoOpen: false,
            resizable: false,
            height: 450,
            width: 500,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).load(url);

            },
            close: function (event, ui) {
                $(this).dialog('close');
            }
        });

        $("#dialogEdit").dialog('open');
        return false;
    });

    $(".confirmDialog").click(function (e) {

        var url = $(this).attr('href');
        $("#dialogConfirm").dialog({
            autoOpen: false,
            resizable: false,
            height: 170,
            width: 350,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            buttons: {
                "OK": function () {
                    $(this).dialog("close");
                    window.location = url;

                },
                "Cancel": function () {
                    $(this).dialog("close");

                }
            }
        });
        $("#dialogConfirm").dialog('open');
        return false;
    });

    $(".viewDialog").click(function (e) {
        var url = $(this).attr('href');
        $("#dialogView").dialog({
            title: 'View Student',
            autoOpen: false,
            resizable: false,
            height: 450,
            width: 400,
            show: { effect: 'drop', direction: "up" },
            modal: true,
            draggable: true,
            open: function (event, ui) {
                $(this).load(url);

            },
            buttons: {
                "Close": function () {
                    $(this).dialog("close");

                }
            },
            close: function (event, ui) {
                $(this).dialog('close');
            }
        });

        $("#dialogView").dialog('open');
        return false;
    });

    $("#btnCancel").click(function (e) {
        $("#dialogEdit").dialog('close');


    });
});