using Alura.Estacionamento.Alura.Estacionamento.Modelos;
using Alura.Estacionamento.Modelos;
using System;
using Xunit;
using Xunit.Abstractions;

namespace Alura.Estacionamento.Tests
{
    public class VeiculoTeste
    {
        public ITestOutputHelper Output { get; }
        private Veiculo veiculo;
        public Patio estacionamento;

        public VeiculoTeste(ITestOutputHelper output)
        {
            Output = output;
            Output.WriteLine("Execução do  construtor.");
            veiculo = new Veiculo();
            veiculo.Tipo = TipoVeiculo.Automovel;
        }

        [Fact]
        public void TestaVeiculoAcelerarComAceleracao10()
        {
            veiculo.Acelerar(10);

            Assert.Equal(100, veiculo.VelocidadeAtual);

        }

        [Fact]
        public void TestaVeiculoFrearComFreio10()
        {
            //Arrange

            //Act
            veiculo.Frear(10);
            //Assert
            Assert.Equal(-150, veiculo.VelocidadeAtual);
        }

        [Fact]
        public void AlteraDadosVeiculoDeUmDeterminadoVeiculoComBaseNaPlaca()
        {
            //Arrange
            Patio estacionamento = new Patio();//Gerando ticket
            veiculo.Proprietario = "José Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Placa = "ZXC-8524";
            veiculo.Cor = "Verde";
            veiculo.Modelo = "Opala";
            estacionamento.RegistrarEntradaVeiculo(veiculo);

            var veiculoAlterado = new Veiculo();
            veiculoAlterado.Proprietario = "José Silva";
            veiculoAlterado.Tipo = TipoVeiculo.Automovel;
            veiculoAlterado.Placa = "ZXC-8524";
            veiculoAlterado.Cor = "Preto"; //Alterado
            veiculoAlterado.Modelo = "Opala";

            //Act
            var alterado = estacionamento.AlteraDadosVeiculo(veiculoAlterado);

            //Assert
            Assert.Equal(alterado.Cor, veiculoAlterado.Cor);

        }

        [Fact]
        public void GerarFichadeInformaçãodoProprioVeiculo()
        {
            //Arrange
            veiculo.Proprietario = "André Silva";
            veiculo.Tipo = TipoVeiculo.Automovel;
            veiculo.Cor = "Preto";
            veiculo.Modelo = "Fusca";
            veiculo.Placa = "ZXC-8888";

            //Act
            string dadosveiculo = veiculo.ToString();

            //Assert
            Assert.Contains("Ficha do Veículo", dadosveiculo);
        }

        [Fact]
         public void TestaNomeProprietarioComDoisCaracteres()
        {
            //Arrange
            string nomeProprietario = "Ab";
            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo(nomeProprietario)
            );
        }

        [Fact]
        public void TestaQuantidadeCaracteresPlacaVeiculo()
        {
            //Arrange
            string placa = "Ab";
            //Assert
            Assert.Throws<FormatException>(
                //Act
                () => new Veiculo().Placa=placa
            );
        }
    }
}
