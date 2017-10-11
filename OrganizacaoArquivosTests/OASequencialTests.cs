using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OrganizacaoArquivos.Tests
{
    [TestClass()]
    public class OASequencialTests
    {
        private OASequencial oaSequencial;

        [TestInitialize()]
        public void initialize()
        {
            oaSequencial = new OASequencial("C:/Users/Cassiano/Desktop/trab_oa/sequencial_dados");
        }

        [TestMethod()]
        public void consultarTest()
        {
            Assert.IsTrue(true);
        }

        [TestMethod()]
        public void inserirTest()
        {
            Colaborador colaborador = new Colaborador(1004, "Ademar", 25, 500);
            oaSequencial.inserir(colaborador, "Numero");

            Assert.IsTrue(false);
        }
    }
}