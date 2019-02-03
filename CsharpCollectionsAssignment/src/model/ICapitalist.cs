using CsharpCollectionsAssignment.hierarchy;
using System.Collections.Generic;
using System.Collections;

namespace CsharpCollectionsAssignment.model
{
    public interface ICapitalist : IHierarchical<ICapitalist, FatCat>
    {
        //List<ICapitalist> IMasterList { get; set; }
        //Stack ILog { get; set; }
        /**
         * @return the name of the capitalist
         */
        string GetName();

        /**
         * @return the salary of the capitalist, in dollars
         */
        int GetSalary();
    }
}