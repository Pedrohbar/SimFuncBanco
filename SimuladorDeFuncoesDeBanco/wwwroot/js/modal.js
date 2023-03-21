"use strict";

const camposModal = {
    modal: document.querySelector('.container-modal-operacao'),
    perguntaOperacao: document.querySelector('.container-modal-operacao h2'),
    saldoAtual: document.getElementById('saldo-atual-modal'),
    valorOperacao: document.getElementById('valor-operacao'),
    botaoConfirma: document.getElementById('botao-confirma'),
    botaoCancela: document.getElementById('botao-cancela')
};

class Modal {
    AbrirModal(operacao) {
        let listenerConfirma;
        camposModal.perguntaOperacao.textContent = operacao === "depositar" ?
            "Insira o valor que deseja depositar" :
            "Insira o valor que deseja sacar";
        camposModal.saldoAtual.textContent = interfaceCampos.saldoConta.textContent;
        listenerConfirma = async () => {
            if (operacao === "depositar") {
                await new RequestsGraphQl().Depositar(camposModal.valorOperacao.value.replace(",", "."));
            } else {
                await new RequestsGraphQl().Sacar(camposModal.valorOperacao.value.replace(",", "."));
            }
            location.reload();
        };

        camposModal.botaoConfirma.addEventListener("click", listenerConfirma);
        camposModal.botaoCancela.addEventListener("click", () => {
            camposModal.botaoConfirma.removeEventListener("click", listenerConfirma);
            camposModal.modal.style.display = "none";
        });

        camposModal.modal.style.display = "flex";
    }
}