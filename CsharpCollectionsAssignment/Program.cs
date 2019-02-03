using CsharpCollectionsAssignment.model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CsharpCollectionsAssignment
{
    class Program
    {
        static void Main(string[] args)
        {
            MegaCorp megaCorp = new MegaCorp();
            FatCat Madea = new FatCat("Madea", 26000);
            FatCat Marie = new FatCat("Marie", 26000);
            FatCat LucasSr = new FatCat("LucasSr", 26000, Marie);
            FatCat Miriam = new FatCat("Miriam", 26000, Marie);
            FatCat Katie = new FatCat("Katie", 26000, Madea);
            FatCat Zack= new FatCat("Zack", 26000, Madea);
            WageSlave Lucas = new WageSlave("Lucas", 26000, LucasSr);
            WageSlave Marcus = new WageSlave("Marcus", 26000, Katie);
            WageSlave Markel = new WageSlave("Markel", 26000, Katie);
            WageSlave Ashley = new WageSlave("Ashley", 26000, Miriam);

            megaCorp.Add(Madea);
            megaCorp.Add(Marie);
            megaCorp.Add(LucasSr);
            megaCorp.Add(Miriam);
            megaCorp.Add(Katie);
            megaCorp.Add(Zack);
            megaCorp.Add(Lucas);
            megaCorp.Add(Marcus);
            megaCorp.Add(Markel);
            megaCorp.Add(Ashley);

            IEnumerable<string> query = from item in megaCorp.GetElements() select item.GetName();
            foreach(var n in query)
            {
                Console.WriteLine(n);
            }
           
        }
    }
}