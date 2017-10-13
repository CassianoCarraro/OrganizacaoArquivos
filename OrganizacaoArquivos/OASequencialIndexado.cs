using System;
using System.IO;

namespace OrganizacaoArquivos
{
    public class OASequencialIndexado : OrganizacaoArquivo
    {
        private OASequencial oaIndices;

        public OASequencialIndexado(String caminhoArqDados, String caminhoArqIndices) : base(caminhoArqDados)
        {
            oaIndices = new OASequencial(caminhoArqIndices);
        }

        public OASequencialIndexado(String caminhoArqDados, String caminhoArqIndices, FileAccess permissaoAcesso) : base(caminhoArqDados, permissaoAcesso)
        {
            oaIndices = new OASequencial(caminhoArqIndices, permissaoAcesso);
        }

        public override object consultar(object registro, string attrId)
        {
            Int32 idRegArq = (Int32)obterPropriedade(registro, attrId);
            Indice indice = new Indice(idRegArq);

            Indice indiceArq = (Indice)oaIndices.consultar(indice, "Numero");

            if (indiceArq != null)
            {
                dados.posicionar(indiceArq.Pos);

                return dados.obterResgistro();
            }

            return null;
        }

        public override void inserir(object registro, string attrId)
        {
            Int64 pos = dados.Tamanho;
            Int32 idRegArq = (Int32)obterPropriedade(registro, attrId);

            dados.gravarFim(registro);

            Indice indice = new Indice(idRegArq, pos);
            oaIndices.inserir(indice, "Numero");
        }

        public new void finalizar()
        {
            base.finalizar();
            oaIndices.finalizar();
        }
    }
}
