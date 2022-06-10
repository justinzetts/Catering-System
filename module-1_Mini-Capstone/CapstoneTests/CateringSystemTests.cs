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

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

       // [DataTestMethod]
       //[DataRow( app = new CateringItem("Appetizer", 4.5, "A2", 10 ))]
       // public void CateringItemShouldBeAddedToCateringItemsDictionary()
       // {
       //     CateringSystem op = new CateringSystem();
       //     CateringItem appetizer = new CateringItem();
            


       //         op.AddCateringItem()

       // }

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>

        //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>
        [TestMethod]
        public void IfBalanceIsNineteenNinetyFiveShouldReturnCorrectChange()
        {
            CateringSystem op = new CateringSystem();
            op.Balance = 19.95;

            string result= op.ReturnMoney();
            string expected = $"Your change will be returned as follows: {0} Twenty Dollar Bill(s), {1} Ten Dollar Bill(s)," +
                $"{1} Five Dollar Bill(s), {4} One Dollar Bill(s), {3} Quarter(s), {2} Dime(s), & {0} Nickel(s).";

            Assert.AreEqual(expected, result);
            Assert.AreEqual(op.Balance, 0);
        }
        [TestMethod]
        public void IfBalanceIsFiveCentsShouldReturn1OneNickelString()
        {
            CateringSystem op = new CateringSystem();
            op.Balance = .05;

            string result = op.ReturnMoney();
            string expected = $"Your change will be returned as follows: {0} Twenty Dollar Bill(s), {0} Ten Dollar Bill(s)," +
                $"{0} Five Dollar Bill(s), {0} One Dollar Bill(s), {0} Quarter(s), {0} Dime(s), & {1} Nickel(s).";

            Assert.AreEqual(expected, result);
            Assert.AreEqual(op.Balance, 0);
        }
        [TestMethod]
        public void IfBalanceIsOneThousandDollarsShouldReturn50Twenties()
        {
            CateringSystem op = new CateringSystem();
            op.Balance = 1000;

            string result = op.ReturnMoney();
            string expected = $"Your change will be returned as follows: {50} Twenty Dollar Bill(s), {0} Ten Dollar Bill(s)," +
                $"{0} Five Dollar Bill(s), {0} One Dollar Bill(s), {0} Quarter(s), {0} Dime(s), & {0} Nickel(s).";

            Assert.AreEqual(expected, result);
            Assert.AreEqual(op.Balance, 0);
        }
    }



    //Actual:<Your change will be returned as follows: 0 Twenty Dollar Bill(s), 1 Ten Dollar Bill(s),1 Five Dollar Bill(s), 4 One Dollar Bill(s), 3 Quarter(s), 1 Dime(s), & 1 Nickel(s).>
  //Expected:<Your change will be returned as follows: 0 Twenty Dollar Bill(s), 1 Ten Dollar Bill(s),1 Five Dollar Bill(s), 4 One Dollar Bill(s), 3 Quarter(s), 2 Dime(s), & 0 Nickel(s).>
}
