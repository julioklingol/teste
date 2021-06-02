using System;

namespace Aplication.Service
{
    public static class TrocoService
    {
        public static Troco Calcular(Decimal valor)
        {
            Troco _troco = new Troco();

            _troco.qtde_nota100 = (int)(valor / 100);
            valor = valor - (_troco.qtde_nota100 * 100);

            _troco.qtde_nota50 = (int)(valor / 50);
            valor = valor - (_troco.qtde_nota50 * 50);

            _troco.qtde_nota20 = (int)(valor / 20);
            valor = valor - (_troco.qtde_nota20 * 20);

            _troco.qtde_nota10 = (int)(valor / 10);
            valor = valor - (_troco.qtde_nota10 * 10);

            _troco.qtde_moeda50 = (int)(valor / (Decimal)0.50);
            valor = valor - (_troco.qtde_moeda50 * (Decimal)0.50);

            _troco.qtde_moeda10 = (int)(valor / (Decimal)0.10);
            valor = valor - (_troco.qtde_moeda10 * (Decimal)0.10);

            _troco.qtde_moeda5 = (int)(valor / (Decimal)0.05);
            valor = valor - (_troco.qtde_moeda5 * (Decimal)0.05);

            _troco.qtde_moeda1 = (int)(valor / (Decimal)0.01);

            return _troco;
        }
    }
}
