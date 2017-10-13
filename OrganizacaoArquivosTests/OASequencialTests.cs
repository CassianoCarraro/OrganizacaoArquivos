using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace OrganizacaoArquivos.Tests
{
    [TestClass()]
    public class OASequencialTests
    {

        [TestMethod()]
        public void consultarTest()
        {
            String caminhoArqTeste = "C:/Users/Cassiano/Desktop/trab_oa/sequencial_teste_consulta";
            File.Delete(caminhoArqTeste);

            gerarArquivo(3, caminhoArqTeste);

            OASequencial oaSequencial = new OASequencial(caminhoArqTeste, FileAccess.Read);

            Colaborador colaborador0 = new Colaborador(0);
            Colaborador colaborador1 = new Colaborador(1);
            Colaborador colaborador2 = new Colaborador(2);
            Colaborador colaborador3 = new Colaborador(3);
            Colaborador colaboradorm1 = new Colaborador(-1);

            Colaborador colaboradorConsulta;

            colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaborador0, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador0.Numero);

            colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaborador1, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador1.Numero);

            colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaborador2, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador2.Numero);

            colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaborador3, "Numero");
            Assert.AreEqual(colaboradorConsulta, null);

            colaboradorConsulta = (Colaborador)oaSequencial.consultar(colaboradorm1, "Numero");
            Assert.AreEqual(colaboradorConsulta, null);

            oaSequencial.finalizar();
        }

        [TestMethod()]
        public void inserirTest()
        {
            String caminhoArqTeste = "C:/Users/Cassiano/Desktop/trab_oa/sequencial_teste_insercao";
            File.Delete(caminhoArqTeste);
            Int32 qtdReg = 100;

            gerarArquivo(qtdReg, caminhoArqTeste);

            OASequencial oaSequencial = new OASequencial(caminhoArqTeste, FileAccess.Read);
            Random aleatorio = new Random(5);

            for (int i = 0; i < qtdReg; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                Colaborador colaboradorBusca = (Colaborador)oaSequencial.consultar(colaborador, "Numero");
                
                Assert.AreEqual(colaborador.Numero, colaboradorBusca.Numero);
                Assert.AreEqual(colaborador.Nome, colaboradorBusca.Nome);
                Assert.AreEqual(colaborador.Salario, colaboradorBusca.Salario);
            }

            oaSequencial.finalizar();
        }

        private void gerarArquivo(Int32 qtdReg, String caminhoArq)
        {
            OASequencial oaSequencial = new OASequencial(caminhoArq);
            Random aleatorio = new Random(5);

            for (int i = 0; i < qtdReg; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                oaSequencial.inserir(colaborador, "Numero");
            }

            oaSequencial.finalizar();
        }
    }
}