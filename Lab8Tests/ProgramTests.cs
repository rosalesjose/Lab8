using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lab8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestMethods
{
    [TestClass()]
    public class ProgramTests
    {
        [TestMethod()]
        public void GetInput()
        {
            Assert.AreEqual(4, Program.GetNumbers("3"));
            Assert.AreNotEqual(6, Program.GetNumbers("9"));
        }
    }
}

