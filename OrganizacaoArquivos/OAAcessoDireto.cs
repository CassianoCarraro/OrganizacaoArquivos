using System;
using System.IO;


namespace OrganizacaoArquivos
{
   public class OAAcessoDireto : OrganizacaoArquivo
    {
        const int NUM_BLOCOS = 100;
        const int NUM_REG = 10000;

        public OAAcessoDireto(string caminhoArqDados) : base(caminhoArqDados)
        {
        }

        public OAAcessoDireto(string caminhoArqDados, FileAccess permissaoAcesso) : base(caminhoArqDados, permissaoAcesso)
        {
        }

        public override object consultar(object registro, string attrId)
        {
            Int32 tamanhoRegistro = ((Registro)registro).Tamanho;
            Int32 idRegistroTmp;
            Colaborador colaboradorAux = (Colaborador)registro;
            Int32 idRegistro = colaboradorAux.Numero;
            Object registroTmp;

            long hashGerado = idRegistro % NUM_BLOCOS;
            long posInicial = hashGerado * NUM_REG;
            long pos = 0;

            dados.posicionar(0);

            if(hashGerado < 0 || hashGerado > 100)
            {
                return null;
            }

            while (pos < NUM_REG)
            {
                dados.posicionar(posInicial);
                registroTmp = dados.obterResgistro();
                if (registroTmp == null)
                {
                    break;
                }
                else
                {
                    idRegistroTmp = (Int32)obterPropriedade(registroTmp, attrId);


                    if (idRegistro == idRegistroTmp)
                    {
                        return registroTmp;
                    }
                    else
                    {
                        dados.avancar(pos * ((Registro)registro).Tamanho);
                    }
                    pos++;
                }

                
            }

            return null;
        }

        public override void inserir(object registro, string attrId)
        {
            Int32 idRegistro = (Int32)obterPropriedade(registro, attrId);
            int hashGerado = idRegistro % NUM_BLOCOS;

            if (hashGerado >= 0 && hashGerado <= NUM_BLOCOS)
            {


                long posInicial = hashGerado * NUM_REG;
                dados.posicionar(posInicial);
                Object registroArq = dados.obterResgistro();
                if (registroArq == null)
                {
                    dados.gravar(registro);
                }
                else
                {
                    Int32 idReg = (Int32)obterPropriedade(registro, attrId);
                    for (int i = 0; i < NUM_REG; i++)
                    {
                        Int32 idRegArq = (Int32)obterPropriedade(registroArq, attrId);

                        if (idReg <= idRegArq)
                        {
                            dados.gravar(registro, dados.Pos - ((Registro)registro).Tamanho, ((Registro)registro).Tamanho);

                            break;
                        }
                        else
                        {
                            posInicial += ((Registro)registro).Tamanho;
                            dados.posicionar(posInicial);
                            registroArq = dados.obterResgistro();
                            if (registroArq == null)
                            {
                                dados.gravar(registro);
                            }
                        }
                    }
                }
            }
        }
    }
}
