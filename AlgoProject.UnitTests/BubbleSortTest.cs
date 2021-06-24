using AlgoProject.ViewModel;
using AlgoProject.ViewModel.SortingTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.UnitTests
{
    public class BubbleSortTest
    {
        BubbleSort bubbleSort;

        [SetUp]
        public void Setup()
        {
            bubbleSort = new BubbleSort();
        }

        private static GeneratingArray MakeGenerating()
        {
            return new GeneratingArray();
        }

        [TestCase(1000)]
        [TestCase(5000)]
        public void Sort_ArrayIsSort_ReturnTrue(int volume)
        {
            //Arrange 
            GeneratingArray generating = MakeGenerating();
            var array = generating.FillArray(volume);
            bubbleSort.Sort(array);

            //Act
            bool sorted = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] > array[i + 1])
                {
                    sorted = false;
                    break;
                }
            }

            Assert.IsTrue(sorted);
        }

    }
}
