﻿using Alura.ByteBank.Dados.Repositorio;
using Alura.ByteBank.Dominio.Entidades;
using Alura.ByteBank.Dominio.Interfaces.Repositorios;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Xunit.Abstractions;

namespace Alura.ByteBank.Infraestrutura.Testes
{
    public class ContaCorrenteRepositorioTestes
    {
        public ITestOutputHelper SaidaConsoleTeste;
        private readonly IContaCorrenteRepositorio _repositorio;

        public ContaCorrenteRepositorioTestes(ITestOutputHelper _saidaConsoleTeste)
        {
            SaidaConsoleTeste = _saidaConsoleTeste;
            SaidaConsoleTeste.WriteLine("Construtor invocado.");

            //Injetando dependências no construtor;
            var servico = new ServiceCollection();
            servico.AddTransient<IContaCorrenteRepositorio, ContaCorrenteRepositorio>();

            var provedor = servico.BuildServiceProvider();
            _repositorio = provedor.GetService<IContaCorrenteRepositorio>();

        }
        [Fact]
        public void TestaObterTodasContasCorrentes()
        {
            //Arrange
            //Act
            List<ContaCorrente> lista = _repositorio.ObterTodos();

            //Assert
            Assert.NotNull(lista);
        }

        [Fact]
        public void TestaObterContaCorrentePorId()
        {
            //Arrange
            //Act
            var conta = _repositorio.ObterPorId(1);

            //Assert
            Assert.NotNull(conta);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        public void TestaObterContasCorrentesPorVariosId(int id)
        {
            //Arrange
            //Act
            var conta = _repositorio.ObterPorId(id);

            //Assert
            Assert.NotNull(conta);
        }

        [Fact]
        public void TestaAtualizaSaldoDeterminadaConta()
        {
            //Arrange
            var conta = _repositorio.ObterPorId(1);
            double novoSaldo = 15;
            conta.Saldo = novoSaldo;

            //Act
            var atualizarSaldo = _repositorio.Atualizar(1, conta);

            //Assert
            Assert.True(atualizarSaldo);
        }

        [Fact]
        public void TestaInsereUmaNovaContaCorrenteNoBancoDeDados()
        {
            //Arrange           
            var conta = new ContaCorrente()
            {
                Saldo = 10,
                Identificador = Guid.NewGuid(),
                Cliente = new Cliente()
                {
                    Nome = "Kent Nelson",
                    CPF = "486.074.980-45",
                    Identificador = Guid.NewGuid(),
                    Profissao = "Bancário",
                    Id = 1
                },
                Agencia = new Agencia()
                {
                    Nome = "Agencia Central Coast City",
                    Identificador = Guid.NewGuid(),
                    Id = 1,
                    Endereco = "Rua das Flores,25",
                    Numero = 147
                }
            };

            //Act
            var retorno = _repositorio.Adicionar(conta);

            //Assert
            Assert.True(retorno);

        }
    }
}
