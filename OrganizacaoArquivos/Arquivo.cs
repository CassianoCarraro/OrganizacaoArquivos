using System;
using System.IO;
using System.Runtime.Serialization;

namespace OrganizacaoArquivos
{
    class Arquivo
    {
        private String caminhoArquivo;
        private FileStream fs;

        public Arquivo(String caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public void abrir(FileMode fileMode)
        {
            fs = new FileStream(this.caminhoArquivo, fileMode);
        }

        public void abrir(FileMode fileMode, FileAccess fileAcess)
        {
            fs = new FileStream(this.caminhoArquivo, fileMode, fileAcess);
        }

        public void fechar()
        {
            fs.Close();
        }

        public void posicionar(long pos)
        {
            fs.Seek(pos, SeekOrigin.Begin);
        }

        public void avancar(long pos)
        {
            fs.Seek(pos, SeekOrigin.Current);
        }

        public Object obterResgistro()
        {
            try
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
                Object registro = bformatter.Deserialize(fs);

                return registro;
            } catch (SerializationException)
            {
                return null;
            }
        }

        public void gravar(Object obj)
        {
            MemoryStream stream = new MemoryStream();

            var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
            bformatter.Serialize(stream, obj);

            fs.Write(stream.GetBuffer(), 0, stream.GetBuffer().Length);
        }

        /*public void inserirRegistro(Colaborador obj)
        {
            if (buscaColaborador(obj.Numero) != null)
            {
                return;
            }

            long pos = 0;
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
            }
        }

        public Colaborador lerColaborador(long offset)
        {
            Colaborador colaborador = null;

            using (FileStream fs = new FileStream(BASE_PATH + nomeArq, FileMode.Open, FileAccess.Read))
            {
                var bformatter = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();

                fs.Seek(offset, SeekOrigin.Begin);

                try
                {
                    colaborador = (Colaborador)bformatter.Deserialize(fs);
                }
                catch (SerializationException e)
                {
                    return null;
                }

            }

            return colaborador;
        }

        public List<Colaborador> lerTodosColaboradores()
        {
            List<Colaborador> colaboradores = new List<Colaborador>();

            using (FileStream fs = new FileStream(BASE_PATH + nomeArq, FileMode.Open, FileAccess.Read))
            {
                fs.Seek(0, SeekOrigin.Begin);

                for (int i = 0; i < fs.Length; i++)
                {
                    char c = Convert.ToChar(fs.ReadByte());

                    if (c == '\n')
                    {
                        if (fs.Position < fs.Length)
                        {
                            colaboradores.Add(lerColaborador(fs.Position));
                        }
                    }
                }
            }

            return colaboradores;
        }

        public Colaborador buscaColaborador(Int32 numero)
        {
            Colaborador colaborador = null;

            using (FileStream fs = new FileStream(BASE_PATH + nomeArq, FileMode.Open, FileAccess.Read))
            {
                long ini = 0;
                long fim = fs.Length;
                long meio = 0;
                long offset = 0;

                while (ini <= fim)
                {
                    meio = (ini + fim) / 2;

                    if (meio > Colaborador.TAM_REG)
                    {
                        offset = meio - Colaborador.TAM_REG;
                    }
                    else
                    {
                        offset = 0;
                    }

                    fs.Seek(offset, SeekOrigin.Begin);

                    if (offset > 0)
                    {
                        char c = ' ';
                        while (c != '\n' && fs.Position <= fs.Length)
                        {
                            c = Convert.ToChar(fs.ReadByte());
                        }
                    }

                    if (fs.Position <= fs.Length)
                    {
                        Colaborador colaboradorTmp = lerColaborador(fs.Position);

                        if (colaboradorTmp == null)
                        {
                            return null;
                        }

                        if (colaboradorTmp.Numero == numero)
                        {
                            colaborador = colaboradorTmp;
                            break;
                        }
                        else
                        {
                            if (colaboradorTmp.Numero < numero)
                            {
                                ini = meio + (Colaborador.TAM_REG / 2);
                            }
                            else
                            {
                                fim = meio - (Colaborador.TAM_REG / 2);
                            }
                        }
                    }
                    else
                    {
                        colaborador = null;
                        break;
                    }
                }
            }

            return colaborador;
        }

        public Colaborador buscaColaboradorIndice(Int32 numero)
        {
            Colaborador colaborador = null;

            using (FileStream fs = new FileStream(BASE_PATH + nomeArqIdx, FileMode.Open, FileAccess.Read))
            {
                long ini = 0;
                long fim = fs.Length;
                long meio = 0;

                while (ini <= fim)
                {
                    meio = (ini + fim) / 2;

                    fs.Seek(meio - 11, SeekOrigin.Begin);

                    char c = ' ';
                    String strNumeroTmp = "";
                    String strOffset = "";
                    bool isPtr = false;

                    while (c != '\n' && fs.Position <= fs.Length)
                    {
                        c = Convert.ToChar(fs.ReadByte());
                        Console.WriteLine(c);
                        if (c == ':')
                        {
                            isPtr = true;
                        }
                        else
                        {
                            if (isPtr)
                            {
                                strOffset += c;
                            }
                            else
                            {
                                strNumeroTmp += c;
                            }
                        }
                    }

                    int numeroTmp = Convert.ToInt32(strNumeroTmp);
                    int offset = Convert.ToInt32(strOffset);

                    Console.WriteLine(ini + " - " + fim);

                    if (numeroTmp == numero)
                    {
                        //CHama método leitura dados no offset
                        break;
                    }
                    else
                    {
                        if (numeroTmp < numero)
                        {
                            ini = meio + 1;
                        }
                        else
                        {
                            fim = meio - 1;
                        }
                    }

                    //break;
                }
            }

            return colaborador;
        }*/
    }
}
