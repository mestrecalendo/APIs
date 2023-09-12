using Alura.Estacionamento.Modelos;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Teste
{
    public class PatioTestes : IDisposable
    {

        private Veiculo veiculo;
        private Patio estacionamento;
        public ITestOutputHelper SaidaConsoleTeste;

        public PatioTestes(ITestOutputHelper saidaConsoleTeste)
        {
            SaidaConsoleTeste = saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado");
            estacionamento = new Patio();
            veiculo = new Veiculo();
        }

        [Fact(DisplayName = "Assim se coloca um nome personalizado")]
        public void ValidaFaturamentoPatioUmVeiculo()
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = "Octavia Reis";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "asd-9999";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Theory]
        [InlineData("Pedro Silva","GDR-0101", "Azul", "Corsa")]
        [InlineData("Maria Antonieta","AWR-0123", "Preto", "Fusca")]
        [InlineData("Venicios Ronaldo","TRE-3456", "Amarelo", "Opala")]
        public void ValidaFaturamentoPatioVariosVeiculos(string proprioetario, string placa, string cor, string modelo)
        {
            //Arrange
            //var estacionamento = new Patio();
            //var veiculo = new Veiculo();
            veiculo.Proprietario = proprioetario;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);

            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }

        [Fact(DisplayName = "Pular esse teste", Skip = "Assim é o comando para ignorar esse teste")]
        public void ValidaFaturamentoErro()
        {
            //Arrange

            //Act

            //Assert
        }

        public void Dispose()
        {
            SaidaConsoleTeste.WriteLine("Disposeble invocado");
        }
    }

}
