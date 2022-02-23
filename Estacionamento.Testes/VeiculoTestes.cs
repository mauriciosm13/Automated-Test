using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using Xunit;

namespace Estacionamento.Testes
{
    public class VeiculoTestes
    {
        [Fact]
        public void TesteVeiculoAcelerarComParametro10()
        {
            //Arrange
            var veiculo = new Veiculo();
            //Act
            veiculo.Acelerar(10);
            //Assert
            Assert.Equal(100, veiculo.VelocidadeAtual);
        }
        [Fact]
        public void TesteVeiculoFrearComParametro10()
        {
            var veiculo = new Veiculo();
            veiculo.Frear(10);
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }
        [Fact(Skip = "Teste não implementado")]
        public void ValidaNomeProprietarioDoVeiculo()
        {


        }

        [Fact]
        public void FichaInformacaoVeiculo()
        {
            //Arrange
            var veiculo = new Veiculo();

            veiculo.Proprietario = "Isabella";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Vermelho";
            veiculo.Modelo = "Palio";
            veiculo.Placa = "EEN-9037";
            //Act
            string dados = veiculo.ParaString();

            //Assert
            Assert.Contains("Ficha do Veículo", dados);
        }
    }
}
