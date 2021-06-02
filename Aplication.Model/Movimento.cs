using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Model
{
    public class Movimento
    {
        public Int64 Id { get; set; }

        public Decimal? Entrada { get; set; } = 0;
        public Decimal? Saida { get; set; } = 0;

        public DateTime DataHora { get; set; }

    }
}
