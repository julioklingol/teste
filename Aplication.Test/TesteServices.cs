using Aplication.Service;
using Application.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Aplication.Test
{
    [TestClass]
    public class TesteServices
    {
        [TestMethod]
        public void TesteDeTroco()
        {
            var teste1 = TrocoService.Calcular(30);

            Assert.IsTrue(teste1.qtde_nota20 == 1 && teste1.qtde_nota10 == 1, "Correto Troco de 30");

            var teste2 = TrocoService.Calcular(80);

            Assert.IsTrue(teste2.qtde_nota50 == 1 && teste2.qtde_nota20 == 1 && teste2.qtde_nota10 == 1, "Correto Troco de 80");

            var teste3 = TrocoService.Calcular((decimal)30.67);

            Assert.IsTrue(teste3.qtde_nota20 == 1 && 
                          teste3.qtde_nota10 == 1 && 
                          teste3.qtde_moeda50 == 1 && 
                          teste3.qtde_moeda10 == 1 &&
                          teste3.qtde_moeda5 == 1 &&
                          teste3.qtde_moeda1 == 2, "Correto Troco de 80");
        }

    }
}
