$().ready(function () {
    $.getJSON("/guilda/data/aventureiros.json", function (data) {
    //$.getJSON("/data/aventureiros.json", function (data) {
        data["aventureiros"].forEach(showAventureiro);
    });
});

function getAventureiros() {

}


function showAventureiro(aventureiro) {
    if (!aventureiro) return;
    console.log(aventureiro);

    $("#records").append(
        $("<div>", {
            "id": "test",
            "class": "record rounded-lg shadow p-3 mb-5 bg-white rounded"
        }).append(
            $("<img>", {
                class: "avatar rounded-lg",
                src: aventureiro.imagem
            })
        ).append(
            $("<div>", {
                class: "row"
            }).append(
                $("<div>", {
                    class: "col",
                    html: "Nome: " + aventureiro.nome
                })
            ).append(
                $("<div>", {
                    class: "col",
                    html: "Sexo: " + aventureiro.nome
                })
            )
        )
    );
}

