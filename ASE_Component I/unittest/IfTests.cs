using System;
using ASE_Component_I;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace unittest
{
    [TestClass]
    public class IfTests
    {

        Form1 form;
        [TestInitialize]
        public void Initialize()
        {

            form = new Form1();
            
        }
        [TestMethod]
        public void checkIf()
        {
            //Arrange

            string line = "if(radius=10)";
            //act

            bool result = form.checkIfElse(line);
            //Assert

            Assert.IsTrue(result);
        }

       
    }
}
