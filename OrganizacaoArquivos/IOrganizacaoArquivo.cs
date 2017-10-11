using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoArquivos
{
    interface IOrganizacaoArquivo
    {
        void inserir(Object registro, String attrId);
        Object consultar(Object consulta);
    }
}
