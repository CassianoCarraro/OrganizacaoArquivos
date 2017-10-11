﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganizacaoArquivos
{
    [Serializable]
    public class Colaborador
    {
        public const int TAM_REG = 256;
        private const int NOME_LEN = 50;

        private Int32 numero;
        private String nome;
        private Int32 idade;
        private Double salario;

        public Colaborador(Int32 numero, String nome, Int32 idade, Double salario)
        {
            Numero = numero;
            Nome = nome;
            Idade = idade;
            Salario = salario;
        }

        public Int32 Numero
        {
            get { return numero; }
            set { numero = value; }
        }

        public String Nome
        {
            get { return nome; }
            set {
                nome = value.Substring(0, (value.Length > NOME_LEN ? NOME_LEN : value.Length)).PadRight(NOME_LEN, ' ');
            }
        }

        public Int32 Idade
        {
            get { return idade; }
            set { idade = value; }
        }

        public Double Salario
        {
            get { return salario; }
            set { salario = value; }
        }
    }
}
