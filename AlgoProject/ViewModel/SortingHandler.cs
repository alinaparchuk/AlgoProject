using AlgoProject.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoProject.ViewModel.SortingTypes
{
    public class SortingHandler
    {
        private ISort strategySort;

        /// <summary>Sorting handler constructor</summary>
        /// <param name="execute">Executable command method</param>
        /// <param name="canExecute">Method allowing command execution</param>
        public SortingHandler()
        { }


        /// <summary>Sorting handler constructor.</summary>
        /// <param name="strategySort"><see cref="ISort"/> class</param>
        public SortingHandler(ISort strategySort)
        {
            this.strategySort = strategySort;
        }

        /// <summary>Get class by sort type.</summary>
        /// <param name="strategySort">Type of sort.</param>
        public ISort GetClassSort(TypeSort sortType)
        {
            ISort sortingStrategy = sortType switch
            {
                TypeSort.BubbleSort => new BubbleSort(),
                TypeSort.QuickSort => new QuickSort(),
                TypeSort.MergeSort => new MergeSort(),
                _ => throw new NotSupportedException($"Such type is not supported {sortType}"),
            };

            return sortingStrategy;
        }

        /// <summary>Assembles data into <see cref="SortModel"./></summary>
        /// <param name="numberOfElements">User-selected number of array elements."/> </param>
        /// <param name="sortType">User-selected sort type"/> </param>
        /// <param name="elapsedTime"> The time it takes to sort the array."/> </param>
        public SortModel ResultComposer(int numberOfElements, TypeSort sortType, string elapsedTime)
        {
            return new SortModel
            {
                SelectedNumberElements = numberOfElements,
                SelectedTypeSort = sortType,
                ElapsedTime = elapsedTime
            };
        }

        /// <summary>Setting a sorting strategy.</summary>
        /// <param name="strategySort">Type of sort.</param>
        public void SetSortStrategy(ISort strategySort)
        {
            this.strategySort = strategySort;
        }

        /// <summary>Processing of received data</summary>
        /// <param name="sortType">User-selected sort type"/> </param>
        /// <param name="numberOfElements"> The time it takes to sort the array."/> </param>
        /// <returns>Completed data in<see cref="SortModel"/>.</returns>
        public SortModel Handle(TypeSort sortType, int numberOfElements)
        {
            ISort sortingStrategy = this.GetClassSort(sortType);

            this.SetSortStrategy(sortingStrategy);

            // I'm array generator.
            // I can generate you an int array if you say how many elements you need. :)
            // 
            int[] dataArray = new GeneratingArray().FillArray(numberOfElements);


            // I'm sorting time calculator.
            // To executed I need: sorting type (instance of some ISort), what do I need to sort :)
            //
            string elapsedTime = new TimeCalculating().Calculate(sortingStrategy.Sort, dataArray);

            // I'm result composer.
            // Give methe information and I'll take care of SortModel creation.
            //
            return ResultComposer(numberOfElements, sortType, elapsedTime);            
        }
    }
}
