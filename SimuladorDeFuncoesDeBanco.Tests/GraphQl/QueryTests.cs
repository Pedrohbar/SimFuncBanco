using HotChocolate;
using SimuladorDeFuncoesDeBanco.Data.Repositories.GraphQl;
using SimuladorDeFuncoesDeBanco.Models;

namespace SimuladorDeFuncoesDeBanco.Tests
{
    public class QueryTests
    {
        [Fact]
        public void ObterContaContaExiste()
        {
            Query query = new Query();
            int numeroConta = 12345;

            Conta conta = query.ObterConta(numeroConta);

            Assert.NotNull(conta);
            Assert.Equal(numeroConta, conta.Numero);
        }

        [Fact]
        public void ObterContaContaNaoEncontrada()
        {
            Query query = new Query();
            
            int numeroConta = -1;
            Assert.Throws<GraphQLException>(() => query.ObterConta(numeroConta));
        }
    }
}