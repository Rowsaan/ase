using System;
using ASE_Component_I;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace unittest
{
    [TestClass]
    public class GetParameterMethodTest
    {
        [TestMethod]
        public void getParameterTestMethod()
        {
            Form1 form = new Form1();  
            //arrange
            string line = "rectangle(20,30)";
            string[] expectedArray = { "20", "30" };

            //act
            string[] actualArray = form.getParameter(line);

            //assert
            CollectionAssert.AreEqual(expectedArray,actualArray);


        }
    }
}
