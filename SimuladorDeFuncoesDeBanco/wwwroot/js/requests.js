"use strict";

class RequestsGraphQl {

    ConsultarSaldo() {

        const query = `
      query {
        obterConta(numero: 12345) {
          numero,
          nomeUsuario,
          saldo,
          
        }
      }`;

        const info = fetch('/graphql', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ query }),
        })
            .then(response => response.json())
            .then(data => { return data.data.obterConta})
            .catch(error => console.error(error));

        return info;
    }

    Sacar(valor) {
        const query = `
      mutation {
        sacar(numero: 12345, valor:${valor}) {
          numero,
          saldo
        }
      }`;

        fetch('/graphql', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ query }),
        })
            .then(response => response.json())
            .then(data => { data.data.sacar })
            .catch(error => console.error(error));
    }


    Depositar(valor) {
        const query = `
      mutation {
        depositar(numero: 12345, valor: ${valor}) {
          numero,
          saldo
        }
      }`;

        fetch('/graphql', {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify({ query }),
        })
            .then(response => response.json())
            .then(data => { data.data.depositar })
            .catch(error => console.error(error));
    }

}