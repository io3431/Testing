using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopAuth.Tests
{
    [TestClass()]
    public class MainWindowTests
    {
        [TestMethod()]
        public void CheckingPasswordTest()
        {
            //Arrange
            //Act
            //Assert
        }
        [TestMethod()]
        public void CheckingPasswordTest1()
        {
            //Arrange
            string password = "1526";
            //Act
            //Assert
        }
        [TestMethod()]
        public void CheckingPasswordTest2()
        {
            //Arrange
            string password = "1518";
            //Act
            //Assert
        }
        [TestMethod()]
        public void CheckingPasswordTest3()
        {
            Assert.Fail();
        }
        [TestMethod()]
        public void CheckingPasswordTest4()
        {
            Assert.Fail();
        }
    }
}