using System;
using ASE_Component_I;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace unittest
{
    [TestClass]
    public class MethodTests
    {

        Form1 form;
        [TestInitialize]
        public void Initialize()
        {

            form = new Form1();

        }
        [TestMethod]
        public void checkMethod()
        {
            //Arrange

            string line = "method myMethod(radius)";
            //act

            bool result = form.checkMethod(line);
            //Assert

            Assert.IsTrue(result);
        }


    }
}
