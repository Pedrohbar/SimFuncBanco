using Npgsql;
using SimuladorDeFuncoesDeBanco.Models;
using Dapper;

namespace SimuladorDeFuncoesDeBanco.Data.Repositories.GraphQl
{
    public class Query
    {
        public Conta ObterConta(int numero)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();

            DbConfig? dbConfig = config.GetSection("DbConfig").Get<DbConfig>();

            using (var connection = new NpgsqlConnection(dbConfig?.ConnectionString))
            {
                connection.Open();

                var conta = connection.QuerySingleOrDefault<Conta>(
                    $"SELECT * FROM conta " +
                    $"WHERE numero = {numero}");

                connection.Close();

                if (conta == null)
                {
                    throw new GraphQLException("Número de conta não encontrado");
                }

                return new Conta
                {

                    Numero = conta.Numero,
                    NomeUsuario = conta.NomeUsuario,
                    Saldo = conta.Saldo
                };
            }
        }
    }
}