$().ready(function () {
    $.getJSON("./data/aventureiros.json", function (data) {
        console.log(data);
        $("#text").html(data["text"]);
    });
});