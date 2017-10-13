using System;

namespace OrganizacaoArquivos
{
    [Serializable]
    public class Indice : Registro
    {
        private Int32 numero;
        private Int64 pos;

        public Indice(Int32 numero) : base(256)
        {
            Numero = numero;
        }

        public Indice(Int32 numero, Int64 pos) : base(256)
        {
            Numero = numero;
            Pos = pos;
        }

        public Int32 Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public Int64 Pos
        {
            get { return pos; }
            set { pos = value; }
        }
    }
}
