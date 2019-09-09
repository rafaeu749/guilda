$().ready(function () {
    $.getJSON("/guilda/data/aventureiros.json", function (data) {
        console.log(data);
        $("#text").html(data["text"]);
    });
});