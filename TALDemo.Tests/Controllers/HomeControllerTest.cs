using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TALDemo;
using TALDemo.Controllers;
using TALDemo.Models;


namespace TALDemo.Tests.Controllers
{
    
    [TestClass]
    public class HomeControllerTest
    {

        [TestMethod]
        public void CalculateReturnsPremium()
        {
            // Arrange
            HomeController controller = new HomeController();
            MemberModel data = new MemberModel
            {
                MemberId = "MEM0000001",
                DeathSumInsured = 50000,
                Age = 30,
                SelectedOccupationCode = "Doctor"
            };

            // Act            
            var result = controller.CallPremiumCalculation(data.MemberId, data.DeathSumInsured, data.Age, data.SelectedOccupationCode);

            // Assert
            Assert.AreEqual(18000.00, result);
        }

        [TestMethod]
        public void CalculateReturnsNoMember()
        {
            // Arrange
            HomeController controller = new HomeController();
            MemberModel data = new MemberModel
            {
                MemberId = "MEM0000002",
                DeathSumInsured = 50000,
                Age = 30,
                SelectedOccupationCode = "Doctor"
            };

            // Act
            var result = controller.CallPremiumCalculation(data.MemberId, data.DeathSumInsured, data.Age, data.SelectedOccupationCode);

            // Assert
            Assert.AreEqual(-1, result);
        }


    }
    
}