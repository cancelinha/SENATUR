using System;
using System.Collections.Generic;

namespace Senai.Senatur.WebApi.Domains
{
    public partial class Pacotes
    {
        public int Pacoteid { get; set; }
        public string Nomepacote { get; set; }
        public string Descricao { get; set; }
        public DateTime Dataida { get; set; }
        public DateTime Datavolta { get; set; }
        public decimal Valor { get; set; }
        public string Ativo { get; set; }
        public string Nomecidade { get; set; }
    }
}
