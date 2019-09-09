$().ready(function () {
    $.getJSON("./aventureiros.json", function (data) {
        console.log(data);
        $("#text").html(data["text"]);
    });
});