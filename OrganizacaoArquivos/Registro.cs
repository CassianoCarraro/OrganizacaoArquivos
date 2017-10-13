using System;

namespace OrganizacaoArquivos
{
    [Serializable]
    public class Registro
    {
        private Int32 tamanho;

        public Registro(Int32 tamanho)
        {
            this.tamanho = tamanho;
        }

        public Int32 Tamanho
        {
            get { return tamanho; }
        }
    }
}