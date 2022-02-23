using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Testes
{
    public class PatioTestes
    {
        [Fact]
        public void ValidaFaturamentoEstacionamento()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Isabella";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Palio";
            veiculo.Placa = "EEN-9037";

            estacionamento.RegistrarEntradaVeiculo(veiculo);
            estacionamento.RegistrarSaidaVeiculo(veiculo.Placa);
            //Act
            double faturamento = estacionamento.TotalFaturado();

            //Assert
            Assert.Equal(2, faturamento);
        }
        [Theory]

        [InlineData("Isabella", "EEN-9037", "Preto", "Gol")]
        [InlineData("Carlos", "EAS-4576", "Branco", "Siena")]
        [InlineData("Marcos", "DAS-1230", "Verde", "i30")]
        [InlineData("Pedro", "DKD-1530", "Vermelho", "Uno")]
        public void ValidaFaturamentoEstacionamentoMuitosVeiculos(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
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
        [Theory]

        [InlineData("Isabella", "EEN-9037", "Preto", "Gol")]
        public void LocalizVeiculoPatioPorPlaca(string proprietario, string placa, string cor, string modelo)
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = proprietario;
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = cor;
            veiculo.Modelo = modelo;
            veiculo.Placa = placa;

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            //Act 
            var consulta = estacionamento.PesquisaVeiculo(veiculo.Placa);

            //Assert
            Assert.Equal(placa, consulta.Placa);

        }

        [Fact]
        public void AlterarDadosVeiculo()
        {
            //Arrange
            var estacionamento = new Patio();
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Isabella";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Palio";
            veiculo.Placa = "EEN-9037";

            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "Isabella";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Cor = "Azul";
            veiculoAlterado.Modelo = "Palio";
            veiculoAlterado.Placa = "EEN-9037";
            //Act
            Veiculo retorno = estacionamento.AlterarDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(retorno.Cor, veiculoAlterado.Cor);
        }
    }
}
