"use strict";

const interfaceCampos = {
    nomeConta: document.getElementById("nome-conta"),
    numeroConta: document.getElementById("numero-conta"),
    saldoConta: document.getElementById("saldo-conta"),
};

window.onload = async () => {
    await atualizaTelaConta();
    const btnOperacao = document.querySelectorAll(".container-operacao-botoes .botao-operacao");

    btnOperacao.forEach((btn) => {
        btn.addEventListener("click", async () => {
            const modal = new Modal();
            modal.AbrirModal(btn.id);
        });
    });
};

const atualizaTelaConta = async () => {
    const request = new RequestsGraphQl();
    const dadosConta = await request.ConsultarSaldo();

    interfaceCampos.nomeConta.textContent = `Usuario: ${dadosConta.nomeUsuario}`;
    interfaceCampos.numeroConta.textContent = `Número da conta: ${dadosConta.numero.toString()}`;
    interfaceCampos.saldoConta.textContent = `Saldo: ${dadosConta.saldo.toLocaleString("pt-BR", {
        style: "currency",
        currency: "BRL",
    })}`;
};