using System;
using System.IO;
using System.Reflection;

namespace OrganizacaoArquivos
{
    public class OASequencial : IOrganizacaoArquivo
    {
        private Arquivo dados;

        public OASequencial(String caminhoArqDados, FileAccess permissaoAcesso)
        {
            dados = new Arquivo(caminhoArqDados);
            dados.abrir(FileMode.OpenOrCreate, permissaoAcesso);
        }

        public OASequencial(String caminhoArqDados)
        {
            dados = new Arquivo(caminhoArqDados);
            dados.abrir(FileMode.OpenOrCreate, FileAccess.ReadWrite);
        }

        ~OASequencial()
        {
            dados.fechar();
        }

        public object consultar(Object registro, String attrId)
        {
            Int32 tamanhoRegistro = ((Registro)registro).Tamanho;
            Int32 idRegistroTmp;
            Int32 idRegistro = (Int32)obterPropriedade(registro, attrId);
            Object registroTmp;

            long ini = 0;
            long fim = dados.Tamanho;
            long meio = 0;
            
            dados.posicionar(0);

            while (ini <= fim && ini < dados.Tamanho)
            {
                meio = (ini + fim) / 2;

                if ((meio / (tamanhoRegistro / 2)) % 2 != 0)
                {
                    meio -= tamanhoRegistro / 2;
                }

                dados.posicionar(meio);
                registroTmp = dados.obterResgistro();
                idRegistroTmp = (Int32)obterPropriedade(registroTmp, attrId);

                if (idRegistro == idRegistroTmp)
                {
                    return registroTmp;
                } else
                {
                    if (idRegistroTmp < idRegistro)
                    {
                        ini = meio + tamanhoRegistro;
                    } else
                    {
                        fim = meio - tamanhoRegistro;
                    }
                }                
            }

            return null;
        }

        public void inserir(Object registro, String attrId)
        {
            dados.posicionar(0);
            Object registroArq = dados.obterResgistro();
            if (registroArq == null)
            {
                dados.gravar(registro);
            } else
            {
                if (verificarInserirFim(registro, attrId))
                {
                    dados.gravarFim(registro);
                } else
                {
                    Int32 idReg = (Int32)obterPropriedade(registro, attrId);

                    do
                    {
                        Int32 idRegArq = (Int32)obterPropriedade(registroArq, attrId);

                        if (idReg <= idRegArq)
                        {
                            dados.gravar(registro, dados.Pos - ((Registro)registro).Tamanho, ((Registro)registro).Tamanho);

                            break;
                        }
                        else
                        {
                            dados.posicionar(dados.Pos);
                            registroArq = dados.obterResgistro();
                            if (registroArq == null)
                            {
                                dados.gravarFim(registro);
                            }
                        }
                    } while (registroArq != null);
                }
            }
        }

        public void finalizar()
        {
            dados.fechar();
        }

        private Boolean verificarInserirFim(Object registro, String attrId)
        {
            Int32 idReg = (Int32)obterPropriedade(registro, attrId);

            dados.posicionarFim();
            dados.avancar(-((Registro)registro).Tamanho);

            Object registroArq = dados.obterResgistro();
            Int32 idRegFimArq = (Int32)obterPropriedade(registroArq, attrId);

            return (idReg >= idRegFimArq);
        }

        private Object obterPropriedade(Object registro, String attr)
        {
            Type tipoRegistro = registro.GetType();
            PropertyInfo atributo = tipoRegistro.GetProperty(attr);

            return atributo.GetValue(registro);
        }
    }
}