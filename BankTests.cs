using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatedBalance()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            //Act
            account.Debit(debitAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited Correctly");
        }

        [TestMethod]

        public void Debit_GreaterThanBalance_ArgumentOutOfRange() 
        {

            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.0;
            BankAccount account = new BankAccount("John", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                //Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown");

        
        }
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("John", beginningBalance);

            //Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.DebitAmountLessThanZero);
                return;
            }
            Assert.Fail("The expected exception was not thrown");
           
        }

        [TestMethod]
        public void Credit_AmountGreaterThanZero_UpdateBalance()
        {
            //Assert
            double beginningBalance = 11.99;
            double creditAmount = 5.00;
            BankAccount account = new BankAccount("John", beginningBalance);

            //Act
            account.Credit(creditAmount);

            //Assert
            double actual = account.Balance;
            Assert.AreEqual(11.99 + 5.00, actual);
        }

        [TestMethod]
        public void Credit_AmountLessThanZero_ThrowArgumentOutOfRange()
        {
            //Arrange
            double beginningBalance = 11.99;
            double creditAmount = -10;
            BankAccount account = new BankAccount("John", beginningBalance);

            //Act
            try
            {
                account.Credit(creditAmount);
            }
            catch(System.ArgumentOutOfRangeException e)
            {
                StringAssert.Contains(e.Message, BankAccount.CreditAmountLessThanZero);
            }
            //Assert
            
        }

    }
}
