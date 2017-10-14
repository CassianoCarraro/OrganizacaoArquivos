using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;


namespace OrganizacaoArquivos.Tests
{
    [TestClass]
    public class OAAcessoDiretoTests
    {
        private const String ARQ_DADOS_TESTE = "C:/Users/daniel/Desktop/organArq/acesso_direto_teste";

        [TestMethod]
        public void consultarTest()
        {
            Cleanup();

            gerarArquivo(3, ARQ_DADOS_TESTE);
            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(ARQ_DADOS_TESTE, FileAccess.Read);

            Colaborador colaborador0 = new Colaborador(0);
            Colaborador colaborador1 = new Colaborador(1);
            Colaborador colaborador2 = new Colaborador(2);
            Colaborador colaborador3 = new Colaborador(3);
            Colaborador colaboradorm1 = new Colaborador(-1);

            Colaborador colaboradorConsulta;

            colaboradorConsulta = (Colaborador)oaAcessoDireto.consultar(colaborador0, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador0.Numero);

            colaboradorConsulta = (Colaborador)oaAcessoDireto.consultar(colaborador1, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador1.Numero);

            colaboradorConsulta = (Colaborador)oaAcessoDireto.consultar(colaborador2, "Numero");
            Assert.AreEqual(colaboradorConsulta.Numero, colaborador2.Numero);

            colaboradorConsulta = (Colaborador)oaAcessoDireto.consultar(colaborador3, "Numero");
            Assert.AreEqual(colaboradorConsulta, null);

            colaboradorConsulta = (Colaborador)oaAcessoDireto.consultar(colaboradorm1, "Numero");
            Assert.AreEqual(colaboradorConsulta, null);

            oaAcessoDireto.finalizar();
        }

        [TestMethod]
        public void inserirTest()
        {
            Cleanup();

            Int32 qtdReg = 100;
            gerarArquivo(qtdReg, ARQ_DADOS_TESTE);

            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(ARQ_DADOS_TESTE, FileAccess.Read);
            Random aleatorio = new Random(5);

            for (int i = 0; i < qtdReg; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                Colaborador colaboradorBusca = (Colaborador)oaAcessoDireto.consultar(colaborador, "Numero");

                Assert.AreEqual(colaborador.Numero, colaboradorBusca.Numero);
                Assert.AreEqual(colaborador.Nome, colaboradorBusca.Nome);
                Assert.AreEqual(colaborador.Salario, colaboradorBusca.Salario);
            }

            oaAcessoDireto.finalizar();
        }

        private void gerarArquivo(Int32 qtdReg, String caminhoArq)
        {
            OAAcessoDireto oaAcessoDireto = new OAAcessoDireto(caminhoArq);
            Random aleatorio = new Random(5);

            for (int i = 0; i < qtdReg; i++)
            {
                Colaborador colaborador = new Colaborador(i, "João " + i, aleatorio.Next(16, 65), aleatorio.NextDouble() * 1000);
                oaAcessoDireto.inserir(colaborador, "Numero");
            }

            oaAcessoDireto.finalizar();
        }

        [TestCleanup]
        public void Cleanup()
        {
            File.Delete(ARQ_DADOS_TESTE);
        }
    }
}

