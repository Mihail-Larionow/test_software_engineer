using Microsoft.VisualStudio.TestTools.UnitTesting;
using staff_schedule;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Тест
namespace staff_schedule.Tests
{
    [TestClass()]
    public class ScheduleTests
    {
        
        [TestMethod()]
        [DataRow(1d, "КБ", "Инженер-конструктор")]
        [DataRow(100d, "Отдел разработки", "Инженер-программист")]
        [DataRow(10000d, "Технологический отдел", "Инженер-технолог")]
        public void allIsGood_isGood(double num, String firstText, String secondText)
        {
            //Act
            bool actual = Schedule.allIsGood(Convert.ToDecimal(num), firstText, secondText);

            //Assert
            Assert.AreEqual(true, actual);
        }

        [TestMethod()]
        [DataRow(0d, "КБ", "Инженер-конструктор")]
        [DataRow(100d, "", "Инженер-программист")]
        [DataRow(10000d, "Технологический отдел", "")]
        public void allIsGood_isBad(double num, String firstText, String secondText)
        {
            //Act
            bool actual = Schedule.allIsGood(Convert.ToDecimal(num), firstText, secondText);

            //Assert
            Assert.AreEqual(false, actual);
        }
    }
}