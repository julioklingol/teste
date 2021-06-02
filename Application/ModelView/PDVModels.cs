using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.ModelView
{
    public class PDV_PagarRequestModel : RequestBase
    {
        public Decimal Valor_Compra { get; set; }
        public Decimal Valor_Pago { get; set; }

        public override void Valida(IConfiguration configuration)
        {
            base.Valida(configuration);

            if (this.Valor_Compra <= 0)
            {
                throw new Exception("Valor da compra inválido");
            }

            if (this.Valor_Compra <= 0)
            {
                throw new Exception("Valor pago inválido");
            }

            if (this.Valor_Pago < this.Valor_Compra)
            {
                throw new Exception("Valor pago insuficiente");
            }
        }

        public Decimal GetTroco()
        {
            return Valor_Pago - Valor_Compra;
        }
    }

    public class PDV_PagarResponseModel : ResponseBase
    {
        public Decimal Troco { get; set; }
    }
}
