using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace OrganizacaoArquivos.Tests
{
    [TestClass()]
    public class OASequencialTests
    {
        private const int REGISTROS_TESTE = 100;

        [TestMethod()]
        public void consultarTest()
        {
            /*OASequencial oaSequencial = new OASequencial("C:/Users/Cassiano/Desktop/trab_oa/sequencial_dados2");

            Colaborador colaborador = new Colaborador(2);
            Colaborador colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaborador, "Numero");*/

            Assert.IsTrue(false);
        }

        [TestMethod()]
        public void inserirTest()
        {
            OASequencial oaSequencial = new OASequencial("C:/Users/Cassiano/Desktop/trab_oa/sequencial_dados2");
            Random aleatorio = new Random(5);

            for (int i = 0; i < REGISTROS_TESTE; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                oaSequencial.inserir(colaborador, "Numero");
            }

            /*for (int i = 0; i < REGISTROS_TESTE; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                Colaborador colaboradorBusca = (Colaborador)oaSequencial.consultar(colaborador, "Numero");
            }*/

            Assert.IsTrue(true);
        }
    }
}