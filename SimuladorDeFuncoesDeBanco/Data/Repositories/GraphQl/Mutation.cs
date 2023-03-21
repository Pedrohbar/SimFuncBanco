using Dapper;
using Npgsql;
using SimuladorDeFuncoesDeBanco.Models;

namespace SimuladorDeFuncoesDeBanco.Data.Repositories.GraphQl
{
    public class Mutation
    {
        public Conta Sacar(
            int numero,
            double valor,
            CancellationToken cancellationToken)
        {
            if (valor < 0)
                throw new GraphQLException("Números negativos não são permitidos");

            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            DbConfig? dbConfig = config.GetSection("DbConfig").Get<DbConfig>();

            var conta = new Query().ObterConta(numero);

            if (conta.Saldo < valor)
                throw new GraphQLException("Saldo insuficiente!");

            using (var connection = new NpgsqlConnection(dbConfig?.ConnectionString))
            {
                connection.Execute(
                $"UPDATE conta " +
                $"SET saldo = {conta.Saldo -= valor} " +
                $"WHERE numero = {numero}");
            }

            return conta;
        }

        public Conta Depositar(
            int numero,
            double valor,
            CancellationToken cancellationToken)
        {
            if (valor < 0)
                throw new GraphQLException("Números negativos não são permitidos");

            var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .Build();

            DbConfig? dbConfig = config.GetSection("DbConfig").Get<DbConfig>();

            var conta = new Query().ObterConta(numero);

            using (var connection = new NpgsqlConnection(dbConfig?.ConnectionString))
            {
                connection.Execute(
                $"UPDATE conta " +
                $"SET saldo = {conta.Saldo += valor} " +
                $"WHERE numero = {numero}");
            }

            return conta;
        }
    }
}