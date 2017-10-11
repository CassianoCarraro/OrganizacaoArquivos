using System;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;

namespace OrganizacaoArquivos
{
    public class OASequencial : IOrganizacaoArquivo
    {
        private Arquivo dados;

        public OASequencial(String caminhoArqDados)
        {
            dados = new Arquivo(caminhoArqDados);
        }

        public object consultar(Object consulta)
        {
            throw new NotImplementedException();
        }

        public void inserir(Object registro, String attrId)
        {
            dados.abrir(FileMode.OpenOrCreate, FileAccess.ReadWrite);

            Object registroArq = dados.obterResgistro();
            if (registroArq == null)
            {
                dados.gravar(registro);
            } else
            {
                Type tipoRegistro = registro.GetType();
                PropertyInfo atributo = tipoRegistro.GetProperty(attrId);
                Int32 idReg = (Int32)atributo.GetValue(registro);

                Type tipoRegistroArq = registroArq.GetType();
                PropertyInfo atributoArq = tipoRegistroArq.GetProperty(attrId);

                String DEBUG = "";

                do
                {
                    Int32 idRegArq = (Int32)atributo.GetValue(registroArq);

                    DEBUG += idRegArq + "-";

                    /*if (idReg < idRegArq)
                    {
                        dados.gravar(registro);
                    }*/

                    dados.avancar(256);
                    registroArq = dados.obterResgistro();

                    /*if (registroArq == null)
                    {
                        dados.gravar(registro);
                    }*/
                } while (registroArq != null);

                throw new Exception(DEBUG);
            }

            dados.fechar();

            /*long pos = 0;
            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

            using (FileStream fs = new FileStream(BASE_PATH + nomeArq, FileMode.Append))
            {
                MemoryStream stream = new MemoryStream();
                bformatter.Serialize(stream, obj);

                fs.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
                pos = fs.Position - Colaborador.TAM_REG;
                fs.WriteByte(Convert.ToByte('\n'));

                stream.Close();
            }

            if (pos > 0)
            {
                pos--;
            }

            using (StreamWriter fs = new StreamWriter(BASE_PATH + nomeArqIdx, true))
            {
                fs.WriteLine(obj.Numero.ToString().PadLeft(10, '0') + ":" + pos.ToString().PadLeft(10, '0'));
            }*/
        }
    }
}
