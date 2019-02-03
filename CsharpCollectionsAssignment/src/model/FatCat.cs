using System;
using System.Collections.Generic;

namespace CsharpCollectionsAssignment.model
{
    public class FatCat : ICapitalist
    {
        protected string Name { get; set; }
        protected int Salary { get; set; }
        protected FatCat Owner { get; set; }

        public FatCat(string name, int salary) {
            Name = name;
            Salary = salary;
            Owner = null;
        }

        public FatCat(string name, int salary, FatCat owner) {
            Name = name;
            Salary = salary;
            Owner = owner;
        }

        /**
         * @return the name of the capitalist
         */
        public String GetName() {
            return Name; 
        }

        /**
         * @return the salary of the capitalist, in dollars
         */
        public int GetSalary() {
            return Salary;
        }

        /**
         * @return true if this element has a parent, or false otherwise
         */
        public bool HasParent() {
            return Owner != null ? true : false;
        }

        /**
         * @return the parent of this element, or null if this represents the top of a hierarchy
         */
        public FatCat GetParent() {
            return Owner != null ? Owner : null;
        }

        public override bool Equals(object obj)
        {
            var cat = obj as FatCat;
            return cat != null &&
                   Name == cat.Name &&
                   Salary == cat.Salary &&
                   EqualityComparer<FatCat>.Default.Equals(Owner, cat.Owner);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Salary, Owner);
        }
    }
}