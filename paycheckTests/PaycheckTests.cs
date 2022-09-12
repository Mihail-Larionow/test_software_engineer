using Microsoft.VisualStudio.TestTools.UnitTesting;
using paycheck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace paycheck.Tests
{
    [TestClass()]
    public class PaycheckTests
    {
        [TestMethod()]
        [DataRow(1000d, "Инженер-конструктор")]
        [DataRow(10000d, "Инженер-программист")]
        [DataRow(100000d, "Инженер-технолог")]
        public void allIsGood_isGood(double num, String text)
        {
            //Act
            bool actual = Paycheck.allIsGood(Convert.ToDecimal(num), text);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        [DataRow(0d, "Инженер-конструктор")]
        [DataRow(10000d, "")]
        public void allIsGood_isBad(double num, String text)
        {
            //Act
            bool actual = Paycheck.allIsGood(Convert.ToDecimal(num), text);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}