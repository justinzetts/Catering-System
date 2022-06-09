using System;
using System.Collections.Generic;
using System.Text;
using Capstone.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class CateringSystemTests
    {
        [DataTestMethod]
        [DataRow(10)]
        [DataRow(1000)]
        [DataRow(0)]
        public void AddMoneyShouldWork(int a)
        {
            // Arrange
            CateringSystem sut = new CateringSystem();

            // Act
            sut.AddMoney(a);

            // Assert
            Assert.AreEqual(a, sut.Balance);
        }

        [TestMethod]
        public void AddMoneyShouldNotChangeBalance()
        {
            // Arrange
            CateringSystem sut = new CateringSystem();
            int deposit = -5;

            // Act
            sut.AddMoney(deposit);

            // Assert
            Assert.AreEqual(0, sut.Balance);
        }


    }
}
