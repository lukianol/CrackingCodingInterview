﻿using System;
using System.Collections;
using CrackingCodingInterview.Chapter2;
using NUnit.Framework;

namespace CrackingCodingInterview.Test.Chapter2
{
    [TestFixture]
    public class FindNthToLastTest : TestBase
    {
        [Test]
        [TestCaseSource("TestCases")]
        public int Test(int[] @array, int nth)
        {
            return TestInternal(@array, nth);
        }

        private int TestInternal(int[] @array, int nth)
        {
            LinkedListNode<int> previous = null;
            LinkedListNode<int> head = null;
            for (var index = 0; index < @array.Length; index++)
            {
                var t = @array[index];
                var tmp = new LinkedListNode<int> { Data = t };
                if (previous != null)
                {
                    previous.Next = tmp;
                }
                else
                {
                    head = tmp;
                }

                previous = tmp;
            }

            var cut = new FindNthToLast();

            var result = RunTest(Tuple.Create(head, nth), cut);

            return result.Data;
        }

        public static IEnumerable TestCases
        {
            get 
            { 
                yield return new TestCaseData(new int[] {2,1,2,1,2,1,2,1,2,1,2,1,2,1,2,3}, 0).Returns(3).SetName("0th");
                yield return new TestCaseData(new int[] { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 3, 1}, 1).Returns(3).SetName("1th");
                yield return new TestCaseData(new int[] { 3, 2, 1, 4, 5, 6, 7, 8, 9, 0 }, 2).Returns(8).SetName("2th");
            }
        }
    }


}