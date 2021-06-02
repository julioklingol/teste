using Microsoft.VisualStudio.TestTools.UnitTesting;
using Application.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Data;
using Aplication.Test;

namespace Application.Controllers.Tests
{
    [TestClass()]
    public class PDVControllerTests
    {
        [TestMethod()]
        public void PagarTest()
        {
            var controller = new PDVController(null, new ApplicationContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationContext>()), new TestHelper().Configuration);

            var teste1 = controller.Pagar(new ModelView.PDV_PagarRequestModel
            {
                Token = "1234",
                Valor_Compra = 100,
                Valor_Pago = 120
            });

            Assert.IsTrue(teste1.Ok);
        }

        [TestMethod()]
        public void GetMovimentosTest()
        {
            var controller = new PDVController(null, new ApplicationContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationContext>()), new TestHelper().Configuration);

            var teste1 = controller.GetMovimentos();

            Assert.IsTrue(teste1.Any());
        }

        [TestMethod()]
        public void GetSaldoTest()
        {
            var controller = new PDVController(null, new ApplicationContext(new Microsoft.EntityFrameworkCore.DbContextOptions<ApplicationContext>()), new TestHelper().Configuration);

            var teste1 = controller.GetSaldo();

            Assert.IsTrue(teste1 > 0);
        }
    }
}