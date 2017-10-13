using System;
using System.IO;
using System.Reflection;

namespace OrganizacaoArquivos
{
    public abstract class OrganizacaoArquivo : IOrganizacaoArquivo
    {
        protected Arquivo dados;

        public OrganizacaoArquivo(String caminhoArqDados)
        {
            dados = new Arquivo(caminhoArqDados);
            dados.abrir(FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        public OrganizacaoArquivo(String caminhoArqDados, FileAccess permissaoAcesso)
        {
            dados = new Arquivo(caminhoArqDados);
            dados.abrir(FileMode.OpenOrCreate, permissaoAcesso);
        }

        ~OrganizacaoArquivo()
        {
            dados.fechar();
        }

        public void finalizar()
        {
            dados.fechar();
        }

        protected Object obterPropriedade(Object registro, String attr)
        {
            Type tipoRegistro = registro.GetType();
            PropertyInfo atributo = tipoRegistro.GetProperty(attr);

            return atributo.GetValue(registro);
        }

        public abstract object consultar(object registro, string attrId);
        public abstract void inserir(object registro, string attrId);
    }
}
