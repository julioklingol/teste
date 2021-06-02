using System;
using System.Collections.Generic;
using System.Text;

namespace Aplication.Service
{
    public class Troco
    {
        public int qtde_nota100 { get; set; }
        public int qtde_nota50 { get; set; }
        public int qtde_nota20 { get; set; }
        public int qtde_nota10 { get; set; }
        public int qtde_moeda50 { get; set; }
        public int qtde_moeda10 { get; set; }
        public int qtde_moeda5 { get; set; }
        public int qtde_moeda1 { get; set; }

        public override string ToString()
        {
            List<String> trocoLst = new List<String>();
            String retorno = "Entregar: ";

            if (qtde_nota100 != 0)
                trocoLst.Add($"{qtde_nota100} nota(s) de R$100,00");
            
            if (qtde_nota50 != 0)
                trocoLst.Add($"{qtde_nota50} nota(s) de R$50,00");

            if (qtde_nota20 != 0)
                trocoLst.Add($"{qtde_nota20} nota(s) de R$20,00");

            if (qtde_nota10 != 0)
                trocoLst.Add($"{qtde_nota10} nota(s) de R$10,00");

            if (qtde_moeda50 != 0)
                trocoLst.Add($"{qtde_moeda50} moeda(s) de R$0,50");

            if (qtde_moeda10 != 0)
                trocoLst.Add($"{qtde_moeda10} moeda(s) de R$0,10");

            if (qtde_moeda5 != 0)
                trocoLst.Add($"{qtde_moeda5} moeda(s) de R$0,05");

            if (qtde_moeda1 != 0)
                trocoLst.Add($"{qtde_moeda1} moeda(s) de R$0,01");

            if (trocoLst.Count == 0)
                return "Sem troco";
            
            for (int i = 0; i < trocoLst.Count; i++)
            {
                String concat = ", ";

                if (i == trocoLst.Count - 1) concat = ".";
                else if (i == trocoLst.Count - 2) concat = " e ";

                retorno += trocoLst[i] + concat;
            }



            return retorno;
        }
    }
}
