using ASPNETTestProject.Controllers;
using ASPNETTestProject.Domain.Abstract;
using ASPNETTestProject.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASPNETTestProject.UnitTest
{
    [TestClass]
    public class PortfolioTest
    {
        [TestMethod]
        public void Can_GET()
        {
            // Arrange
            Mock<IPortfolioRepository> mock = new Mock<IPortfolioRepository>();
            mock.Setup(m => m.Portfolios).Returns(new Portfolio[] {
                new Portfolio { PorftfolioID = 1, Name = "P1", Description="desc 1" },
                new Portfolio { PorftfolioID = 2, Name = "P2", Description="desc 1" },
                new Portfolio { PorftfolioID = 3, Name = "P3", Description="desc 1" },
                new Portfolio { PorftfolioID = 4, Name = "P4", Description="desc 1" },
                new Portfolio { PorftfolioID = 5, Name = "P5", Description="desc 1" }
                });
            PortfolioController controller = new PortfolioController(mock.Object);
            // Act
            IEnumerable<Portfolio> result =
            (IEnumerable<Portfolio>)controller.List().Model;
            // Assert
            Portfolio[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name, "P5");
        }
    }
}
