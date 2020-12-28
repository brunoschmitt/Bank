using Bank.Entities.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bank.Test.Entities
{
    [TestClass]
    public class BankAccountTest
    {
        private Mock<IBankAccount> _mock;
        private BankAccount accountMock;

        [TestInitialize]
        public void Inicilizer()
        {
            accountMock = new BankAccount("Kenan Schmitt", 420.00);
            _mock = new Mock<IBankAccount>();
        }


        [TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest_Test_Success()
        {

            _mock.Setup(x => x.AddInterest(It.IsAny<double>()));

            double interest = 0.05;
            double balanceRes = accountMock.Balance + (accountMock.Balance * interest);
            
            double balanceUpdated = accountMock.AddInterest(interest);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddInterest_BalancePlusInterest_Test_Fail()
        {

            _mock.Setup(x => x.AddInterest(It.IsAny<double>()));

            double interest = 0.05;
            double balanceRes = accountMock.Balance + (accountMock.Balance * 0.06);

            double balanceUpdated = accountMock.AddInterest(interest);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_Test_Success()
        {
           
            _mock.Setup(x => x.AddCredit(It.IsAny<double>()));

            double amount = 100.00;
            double balanceRes = accountMock.Balance + amount;

            double balanceUpdated = accountMock.AddCredit(amount);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_Test_Fail()
        {
  
            _mock.Setup(x => x.AddCredit(It.IsAny<double>()));

            double amount = 100.00;
            double balanceRes = accountMock.Balance + 100.50;

            double balanceUpdated = accountMock.AddCredit(amount);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_AddCredit_AmountZero_Test_Fail()
        {
            _mock.Setup(x => x.AddCredit(It.IsAny<double>()));

            double amount = 0;
            Assert.ThrowsException<Exception>(() => accountMock.AddCredit(amount));
        }

        [TestMethod]
        public void BankAccount_Debit_Test_Success()
        {
            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            double amount = 100;
            double balanceRes = accountMock.Balance - amount;

            double balanceUpdated = accountMock.Debit(amount);
            Assert.AreEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_Debit_Test_Fail()
        {
            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            double amount = 100;
            double balanceRes = accountMock.Balance - 100.50;

            double balanceUpdated = accountMock.Debit(amount);
            Assert.AreNotEqual(balanceRes, balanceUpdated);
        }

        [TestMethod]
        public void BankAccount_Debit_AmountZero_Test()
        {
            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            double amount = 0;
            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }

        [TestMethod]
        public void BankAccount_Debit_AmountGreaterThanBalance_Test()
        {
            _mock.Setup(x => x.Debit(It.IsAny<double>()));

            double amount = 500.00;
            Assert.ThrowsException<Exception>(() => accountMock.Debit(amount));
        }





    }
}
