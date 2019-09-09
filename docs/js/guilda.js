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
    try {
        var template = $('script[type="text/template"]').html();

        template = template.replace("@imagem", aventureiro.imagem || "");
        template = template.replace("@nome", aventureiro.nome);
        template = template.replace("@sexo", (aventureiro.sexo || "M") === "M" ? "Masculino" : "Feminino");

        if (aventureiro.classes) {
            var classes = aventureiro.classes.map((classe) => {
                return classe.classe + " " + (classe.subclasse ? classe.subclasse + " " : "") + "(" + classe.nivel + ")";
            });
            template = template.replace("@classe", "Classe" + (classes.length > 1 ? "s: " : ": ") + classes.join("|"));
        } else {
            template = template.replace("@classe", "");
        }

        template = template.replace("@nivel", aventureiro.nivel);
        template = template.replace("@xp", aventureiro.xp + "/" + (aventureiro.nivel > 4 ? "8" : "4"));

        template = template.replace("@casa_nome", casaNome(aventureiro.casa));
        template = template.replace("@casa", aventureiro.casa);

        
        template = template.replace("@faccao_nome", faccaoNome(aventureiro.faccao));
        template = template.replace("@faccao_renome", aventureiro.renome || 0);
        template = template.replace("@faccao", aventureiro.faccao || "");

        if (aventureiro.tesouro) {
            var pdts = [];
            if (aventureiro.tesouro.t1) pdts.push(aventureiro.tesouro.t1 + " Tier 1");
            if (aventureiro.tesouro.t2) pdts.push(aventureiro.tesouro.t2 + " Tier 2");
            if (aventureiro.tesouro.t3) pdts.push(aventureiro.tesouro.t3 + " Tier 3");
            if (aventureiro.tesouro.t4) pdts.push(aventureiro.tesouro.t4 + " Tier 4");
            template = template.replace("@pdts", pdts.join("|"));
        } else {
            template = template.replace("@pdts", "-");
        }

        if (aventureiro.dinheiro) {
            var dinheiro = [];
            if (aventureiro.dinheiro.pp) dinheiro.push(aventureiro.dinheiro.pp + "PL");
            if (aventureiro.dinheiro.po) dinheiro.push(aventureiro.dinheiro.po + "PO");
            if (aventureiro.dinheiro.ep) dinheiro.push(aventureiro.dinheiro.ep + "PE");
            if (aventureiro.dinheiro.sp) dinheiro.push(aventureiro.dinheiro.sp + "PP");
            if (aventureiro.dinheiro.cp) dinheiro.push(aventureiro.dinheiro.cp + "PC");
            template = template.replace("@dinheiro", dinheiro.join("|"));
        } else {
            template = template.replace("@dinheiro", " - ");
        }

        if (aventureiro.itens_magicos) {
            var itens = aventureiro.itens_magicos.map((item) => { return item.item; }).join("|");
            template = template.replace("@itens", itens);
        } else {
            template = template.replace("@itens", "-");
        }

        template = template.replace("@update", aventureiro.update ? new Date(Date.parse(aventureiro.update)).toLocaleString() : "Desconhecido");

        $("#records").append(template);
    } catch (ex) {
        console.error(ex);
    }
}

function casaNome(casa) {
    return casa === "superbia" ? "Supérbia" :
            casa === "tenacitas" ? "Tenácitas" :
                casa === "unio" ? "Únio" :
                    casa === "vigil" ? "Vigil" : "";
}

function faccaoNome(faccao) {
    return faccao === "harpistas" ? "Harpistas" :
        faccao === "enclave" ? "Enclave Esmeralda" :
            faccao === "zhentarim" ? "Zhentarim" : "";
}
