# SimuladorDeFuncoesDeBanco


## Pré-requisitos
Antes de executar o simulador de funções de banco, é necessário configurar o ambiente e restaurar o banco de dados PostgreSQL com o backup fornecido. Siga as instruções abaixo para realizar a configuração corretamente:

1. Após clonar o projeto você poderá encontrar um arquivo de backup SQL localizado no caminho SimuladorDeFuncoesDeBanco.Tests/Banco/dbSimuladorFuncBanco.sql.

2. Restaure o banco de dados PostgreSQL a partir do arquivo de backup SQL

3. Com pgAdmin aberto va em Databases e crie um banco com o nome "pgBancSimFuncBanc" e salve.

![image](https://user-images.githubusercontent.com/77450396/226703544-7a0d9630-9587-4e82-ad73-c9b78be3a082.png)
![image](https://user-images.githubusercontent.com/77450396/226703867-26d203d4-6b71-4026-84d2-fb11043dbc38.png)

4. Com o banco criado, va em restore.

![image](https://user-images.githubusercontent.com/77450396/226704322-570bee35-4d97-4e5a-8e16-72c9f99456fc.png)

5. Em restore procure pelo arquivo no campo filnemane 

![image](https://user-images.githubusercontent.com/77450396/226704939-a4e060f8-e473-4b1a-9a6f-4cf71d20112d.png)

6. Na aba "Data/Objects", em "Sections", habilite os campos "Pre-Data","Data" e "Post-data" e clique em restore.

![image](https://user-images.githubusercontent.com/77450396/226705895-4e206da6-3c15-493a-9d6b-95cfddad78b2.png)

Com o banco restaurado agora o projeto está pronto para ser iniciado.

## Observação

Se você tiver problemas de compilação relacionados à string de conexão, siga estas etapas:

1. Abra o arquivo appsettings.json no projeto SimuladorDeFuncoesBanco.

2. Encontre a chave "ConnectionString" e substitua seu valor pelos dados de conexão da conta cadastrada no PostgreSQL e restaurados do arquivo de backup do banco de dados "dbSimuladorFuncBanco.sql".

3. Exemplo de string de conexão:

"ConnectionString": "Server=localhost;Port=5432;Database=pgBancSimFuncBanc;User Id=postgres;Password=1;"

4. Salve o arquivo appsettings.json e compile.

- A porta usada para a conexão é 5432. Esta é a porta padrão para conexões ao PostgreSQL.

- O nome do banco de dados é "pgBancSimFuncBanc". Este é o banco de dados que o aplicativo irá se conectar.

- O nome de usuário usado para autenticar na conexão é "postgres".

- A senha usada para autenticar na conexão é "1"


![image](https://user-images.githubusercontent.com/77450396/226912821-09ce82f1-4e9f-4fe8-846b-b022c28f8c23.png)


# Requests GraphQl
Para testar as requisiões eu recomendo a utilização do Postman ou do Banana Cake Pop.

## Observação
O banco possui apenas uma tabela chamada "conta" com apenas uma linha contendo os dados, o unico número de conta existente no sistema é '12345'

## Configuração
Postman:
1. Após compilar o projeto, abra o Postman.
2. Configure o tipo da requisição para POST.
3. Insira o endpoint "https://localhost:7176/graphql".
4. Vá na aba "Body" e marque GraphQl.

![image](https://user-images.githubusercontent.com/77450396/226717694-6f313282-d072-47a7-9db9-b8b6932d8377.png)

As requisições estão prontas para serem chamadas no Postman.

Banana Cake Pop:
1. Após compilar o projeto, abra o Banana Cake Pop.
2. Clique em create document.
3. No campo schema endpoint insira o endpoint "https://localhost:7176/graphql".

![image](https://user-images.githubusercontent.com/77450396/226719213-dafa2ce8-77fc-4923-88b7-f349d8c5e5c6.png)

As requisições estão prontas para serem chamadas no Banana Cake Pop.

## Requests
Abaixo, você encontrará uma lista das requisições disponíveis para uso da API

Requisição sacar
```
mutation{
  sacar(numero: 12345,valor: 10) {
    numero,
    saldo
  }
}
```
Resposta:

```
{
  "data": {
    "sacar": {
      "numero": 12345,
      "saldo": 40
    }
  }
}
```

Requisição sacar erro "saldo insuficiente"

```
mutation {
  sacar(numero:12345, valor: 100000) {
    numero
    saldo
  }
}
```

Resposta:
```
{
  "errors": [
    {
      "message": "Saldo insuficiente!"
    }
  ]
}
```

Requisição depositar:

```
mutation {
  depositar(numero:12345, valor: 50) {
    numero
    saldo
  }
}
```
Resposta:

```
{
  "data": {
    "depositar": {
      "numero": 12345,
      "saldo":  90
    }
  }
}
```

Requisição obterConta:

```
query {
  obterConta(numero: 12345) {
    saldo
    numero
    nomeUsuario
  }
}
```
Resposta:

```
{
  "data": {
    "obterConta": {
      "saldo": 90,
      "numero": 12345,
      "nomeUsuario": "Pedro Henrique"
    }
  }
}
```

# Bônus

1. Ao compilar o projeto irá também abrir uma UI que realiza as operações de sacar, depositar, mostrando na tela as informações da conta.

2. Em qualquer uma das requests caso a requisição seja feita com um número de conta inexistente irá ocasionar na resposta de erro:

```
{
  "errors": [
    {
      "message": "Número de conta não encontrado"
    }
  ]
}
```
3. Nas mutations "sacar" ou "depositar" caso a requisição seja feita com um número  negativo no campo valor irá ocasionar na respota de erro:

```
{
  "errors": [
    {
      "message": "Números negativos não são permitidos"
    }
  ]
}
```
