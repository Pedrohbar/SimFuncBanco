using SimuladorDeFuncoesDeBanco.Data.Repositories.GraphQl;
using SimuladorDeFuncoesDeBanco.Models;

namespace SimuladorDeFuncoesDeBanco.Tests.GraphQl
{
    public class MutationTests
    {
        [Fact]
        public void TestSacar()
        {
            Query query = new Query();

            int numeroConta = 12345;
            Conta conta = query.ObterConta(numeroConta);

            Mutation mutation = new Mutation();

            Conta result = mutation.Sacar(12345, 1, default);

            Assert.NotNull(result);
            Assert.Equal(conta.Saldo - 1, result.Saldo);
        }

        [Fact]
        public void TestDepositar()
        {
            Query query = new Query();

            int numeroConta = 12345;
            Conta conta = query.ObterConta(numeroConta);

            Mutation mutation = new Mutation();

            Conta result = mutation.Depositar(12345, 1, default);

            Assert.NotNull(result);
            Assert.Equal(conta.Saldo + 1, result.Saldo);
        }
    }
}