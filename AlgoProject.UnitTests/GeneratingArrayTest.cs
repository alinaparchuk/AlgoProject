using AlgoProject.ViewModel;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.UnitTests
{
    public class GeneratingArrayTest
    {
        GeneratingArray generating;

        [SetUp]
        public void Setup()
        {
            generating = new GeneratingArray();
        }

        [TestCase(5000)]
        [TestCase(10000)]
        public void FillArray_GenerateFixLength_ReturnTrue(int volume)
        {
            var testArray = generating.FillArray(volume);

            Assert.AreEqual(volume, testArray.Length);
        }
    }
}
