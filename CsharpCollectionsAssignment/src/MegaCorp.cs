using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using CsharpCollectionsAssignment.hierarchy;
using CsharpCollectionsAssignment.model;

namespace CsharpCollectionsAssignment
{

    public class MegaCorp : IHierarchy<ICapitalist, FatCat>
    {
        List<ICapitalist> MasterList = new List<ICapitalist>();
        /**
         * Adds a given element to the hierarchy.
         * <p>
         * If the given element is already present in the hierarchy,
         * do not add it and return false
         * <p>
         * If the given element has a parent and the parent is not part of the hierarchy,
         * add the parent and then add the given element
         * <p>
         * If the given element has no parent but is a Parent itself,
         * add it to the hierarchy
         * <p>
         * If the given element has no parent and is not a Parent itself,
         * do not add it and return false
         *
         * @param capitalist the element to add to the hierarchy
         * @return true if the element was added successfully, false otherwise
         */
        public bool Add(ICapitalist element)
        {
            if (Has(element) ||element == null)
            {
                return false;
            }

            if(element is WageSlave && element.GetParent() == null)
            {
                return false;
            }

            if(!Has(element.GetParent()))
            {
                MasterList.Add(element.GetParent());
                MasterList.Add(element);
                return true;
            }

            MasterList.Add(element);
            return true;
        }

        /**
         * @param capitalist the element to search for
         * @return true if the element has been added to the hierarchy, false otherwise
         */
        public bool Has(ICapitalist element)
        {
            return MasterList.Contains(element);
        }

        /**
         * @return all elements in the hierarchy,
         * or an empty set if no elements have been added to the hierarchy
         */
        public ISet<ICapitalist> GetElements()
        {
            HashSet<ICapitalist> Capitalists = new HashSet<ICapitalist>();
            foreach (ICapitalist i in MasterList)
            {
                if (i != null)
                {
                    Capitalists.Add(i);
                }
              
            }

            return Capitalists;
        }

        /**
         * @return all parent elements in the hierarchy,
         * or an empty set if no parents have been added to the hierarchy
         */
        public ISet<FatCat> GetParents()
        {
            HashSet<FatCat> Capitalists = new HashSet<FatCat>();
            IEnumerable<FatCat> query = from item in GetElements()
                                        where (item.HasParent())||(item is FatCat&&item.GetParent() == null)
                                        select item.GetParent();
            foreach (FatCat i in query)
            {
                Capitalists.Add(i);
            }

            return Capitalists;
        }

        /**
         * @param fatCat the parent whose children need to be returned
         * @return all elements in the hierarchy that have the given parent as a direct parent,
         * or an empty set if the parent is not present in the hierarchy or if there are no children
         * for the given parent
         */
        public ISet<ICapitalist> GetChildren(FatCat parent)
        {
            HashSet<ICapitalist> Capitalists = new HashSet<ICapitalist>();
            IEnumerable<ICapitalist> query = from item in GetElements()
                                             where item.HasParent() && item.GetParent().Equals(parent)
                                             select item;
            foreach (ICapitalist i in query)
            {
                Capitalists.Add(i);
            }
           
            return Capitalists;
        }

        /**
         * @return a map in which the keys represent the parent elements in the hierarchy,
         * and the each value is a set of the direct children of the associate parent, or an
         * empty map if the hierarchy is empty.
         */
        public IDictionary<FatCat, ISet<ICapitalist>> GetHierarchy()
        {
            Dictionary<FatCat, ISet<ICapitalist>> Hierarchy = new Dictionary<FatCat, ISet<ICapitalist>>();
            IEnumerable<FatCat> Parents = from item in GetParents()
                                          select item;                              
            foreach(var p in Parents)
            {
                 Hierarchy.Add(p, GetChildren(p));
            }
            
            return Hierarchy;
        }

        /**
         * @param capitalist
         * @return the parent chain of the given element, starting with its direct parent,
         * then its parent's parent, etc, or an empty list if the given element has no parent
         * or if its parent is not in the hierarchy
         */
        public IList<FatCat> GetParentChain(ICapitalist element)
        {
            List<FatCat> ParentChain = new List<FatCat>();
            while (element.HasParent() && element.GetParent().Equals(null))
            {
                ParentChain.Add((FatCat)element);
                element = element.GetParent();
            }

            ParentChain.Add((FatCat)element);
            return ParentChain;
        }
    }

}