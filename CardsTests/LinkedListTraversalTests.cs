using System;
using System.Collections.Generic;
using Cards;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CardsTests
{
    [TestClass]
    public class LinkedListTraversalTests
    {
        [TestMethod]
        public void FindFifthFromLast_WithIntegerLinkedList_ReturnsInt()
        {
            int[] arr = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            LinkedList<int> list = new LinkedList<int>(arr);

            var nodeVal = LinkedListTraversal.FindFromLast(list, 5);
            Assert.AreEqual(5, nodeVal);
        }

        [TestMethod]
        public void FindFifthFromLast_WithStringLinkedList_ReturnsString()
        {
            string[] arr = { "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            LinkedList<string> list = new LinkedList<string>(arr);

            var nodeVal = LinkedListTraversal.FindFromLast(list, 5);
            Assert.AreEqual("five", nodeVal);
        }

        [TestMethod]
        public void FindFifthFromLast_WithTooShortIntegerLinkedList_ReturnsInt()
        {
            int[] arr = { 1, 2, 3, 4 };
            LinkedList<int> list = new LinkedList<int>(arr);

            var nodeVal = LinkedListTraversal.FindFromLast(list, 5);
            Assert.AreEqual(1, nodeVal);
        }

        [TestMethod]
        public void FindFifthFromLast_WithTooShortStringLinkedList_ReturnsString()
        {
            string[] arr = { "one", "two", "three" };
            LinkedList<string> list = new LinkedList<string>(arr);

            var nodeVal = LinkedListTraversal.FindFromLast(list, 5);
            Assert.AreEqual("one", nodeVal);
        }
    }
}
