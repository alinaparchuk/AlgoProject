using AlgoProject.Model;
using AlgoProject.ViewModel.SortingTypes;
using NUnit.Framework;
using System;
using Xunit;


namespace AlgoProject.UnitTests
{
    public class SortingHandlerTest
    {
        private SortingHandler sortingHandler;

        [SetUp]
        public void Setup()
        {
            sortingHandler = new SortingHandler();
        }

        [Test]
        public void GetClassSort_GoodExtension_ReturnBubbleSort()
        {
            //Arrange
            var testBubbleSort = sortingHandler.GetClassSort(TypeSort.BubbleSort);

            bool result = (testBubbleSort is BubbleSort);

            NUnit.Framework.Assert.IsTrue(result);
        }


        [TestCase(TypeSort.MergeSort, false)]
        [TestCase(TypeSort.QuickSort, false)]
        public void GetClassSort_BadExtension_ReturnNotBubbleSort(TypeSort typeSort, bool expected)
        {
            //Arrange
            var testNotBubbleSort = sortingHandler.GetClassSort(typeSort);
            //Act
            bool result = (testNotBubbleSort is BubbleSort);
            //Assert
            NUnit.Framework.Assert.AreEqual(expected, result);
        }

        [TestCase(TypeSort.GnomeSort)]
        public void GetClassSort_NonExistentType_Throws(TypeSort typeSort)
        {
            //нужно ли изменять enum для теста?
            //Act
            var ex = NUnit.Framework.Assert.Catch<Exception>(() => sortingHandler.GetClassSort(typeSort));
          
            //Assert
            StringAssert.Contains($"Such type is not supported { typeSort}", ex.Message);
        }

        [Test]
        public void ResultComposer_GoodExtension_ReturnTrueSortModel()
        {
            //Arrange
            var testSortModel = sortingHandler.ResultComposer(10000, TypeSort.BubbleSort, "00:00:00.306");
            //Act
            bool result = (testSortModel is SortModel);
            //Assert
            NUnit.Framework.Assert.IsTrue(result);
        }
    }
}