using System;
using System.IO;
using System.Runtime.Serialization;

namespace OrganizacaoArquivos
{
    class Arquivo
    {
        private String caminhoArquivo;
        private FileStream fs;
        private long pos;

        public Arquivo(String caminhoArquivo)
        {
            this.caminhoArquivo = caminhoArquivo;
        }

        public long Pos
        {
            get { return pos; }
        }

        public long Tamanho
        {
            get { return fs.Length; }
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

        public void posicionarFim()
        {
            fs.Seek(0, SeekOrigin.End);
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

                pos += ((Registro)registro).Tamanho;

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

        public void gravar(Object obj, long pos, long regLen)
        {
            long offset;
            Object objArqTmp;

            for (offset = pos; offset < fs.Length; offset += regLen)
            {
                posicionar(offset);
                objArqTmp = obterResgistro();
                posicionar(offset);
                gravar(obj);

                obj = objArqTmp;
            }

            posicionarFim();
            gravar(obj);
        }

        public void gravarFim(Object obj)
        {
            posicionarFim();
            gravar(obj);
        }
    }
}