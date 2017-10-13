using System;

namespace OrganizacaoArquivos
{
    interface IOrganizacaoArquivo
    {
        void inserir(Object registro, String attrId);
        Object consultar(Object registro, String attrId);
        void finalizar();
    }
}
