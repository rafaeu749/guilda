$().ready(function () {
    $.getJSON("/guilda/data/aventureiros.json", function (data) {
        console.log(data);
        var jsData = JSON.parse(data);
        $("#text").html(data["aventureiros"]);
    });
});