﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpCollectionsAssignmentTests.generators
{
    class MemberDataAggregator
    {
        private static Random random = new Random();

        public static IEnumerable<object[]> GenerateFatCatNameAndSalary()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { CapitalistGenerator.GenerateFatCatName(), CapitalistGenerator.GenerateSalary() }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateFatCatNameAndSalaryAndParent()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { CapitalistGenerator.GenerateFatCatName(), CapitalistGenerator.GenerateSalary(), CapitalistGenerator.GenerateFatCat() }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateWageSlaveNameAndSalary()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { CapitalistGenerator.GenerateWageSlaveName(), CapitalistGenerator.GenerateSalary() }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateWageSlaveNameAndSalaryAndParent()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { CapitalistGenerator.GenerateWageSlaveName(), CapitalistGenerator.GenerateSalary(), CapitalistGenerator.GenerateFatCat() }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorp(int depth = 0)
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(depth) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndWageSlave(int wageSlaveDepth = 0)
        {
            wageSlaveDepth = wageSlaveDepth >= 0 ? wageSlaveDepth : GenerateSemiRandomSize();

            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateWageSlaveAtDepth(wageSlaveDepth) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndFatCat(int fatCatDepth = 0)
        {
            fatCatDepth = fatCatDepth >= 0 ? fatCatDepth : GenerateSemiRandomSize();

            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateFatCatAtDepth(fatCatDepth) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndCapitalist(int capitalistDepth, int megaCorpDepth = 0)
        {
            capitalistDepth = capitalistDepth >= 0 ? capitalistDepth : GenerateSemiRandomSize();

            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(megaCorpDepth), CapitalistGenerator.GenerateCapitalistAtDepth(capitalistDepth) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndCapitalists(int capitalistDepth)
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateCapitalists(GenerateSemiRandomSize()) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndFatCatAndCapitalist()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateFatCat(), CapitalistGenerator.GenerateCapitalist() }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndFatCatAndCapitalists()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateFatCat(), CapitalistGenerator.GenerateCapitalists(GenerateSemiRandomSize()) }
            };

            return list;
        }

        public static IEnumerable<object[]> GenerateMegaCorpAndFatCatAndTwoSetsOfCapitalists()
        {
            List<object[]> list = new List<object[]>
            {
                new object[] { MegaCorpGenerator.GenerateMegaCorp(), CapitalistGenerator.GenerateFatCat(),
                    CapitalistGenerator.GenerateCapitalists(GenerateSemiRandomSize()), CapitalistGenerator.GenerateCapitalists(GenerateSemiRandomSize()) }
            };

            return list;
        }

        /*
         * Utility
         */
        private static int GenerateSemiRandomSize()
        {
            return random.Next(5, 20);
        }

    }
}
