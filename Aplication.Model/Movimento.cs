using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Model
{
    public class Movimento
    {
        public Int64 Id { get; set; }

        public Caixa Caixa { get; set; }
        public Int32 CaixaId { get; set; }

        public Double? Entrada { get; set; }
        public Double? Saida { get; set; }

        public DateTime DataHora { get; set; }

    }
}
