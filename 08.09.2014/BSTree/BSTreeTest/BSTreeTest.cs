using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BSTree;

namespace BSTreeTest
{
    [TestClass]
    public class BSTreeTest
    {
        [TestInitialize]
        public void Initialize()
        {
            tree = new BSTClass<int>();
        }

        [TestMethod]
        public void EmptyTest()
        {
            Assert.IsTrue(tree.IsEmpty());
        }

        [TestMethod]
        public void InsertTest()
        {
            Assert.IsTrue(tree.IsEmpty());
            tree.Insert(1);
            Assert.IsTrue(tree.IsInTree(1));
        }

        [TestMethod]
        public void ExistCheckingTest1()
        {
            Assert.IsTrue(tree.IsEmpty());
            tree.Insert(12);
            Assert.IsFalse(tree.IsEmpty());
            Assert.IsTrue(tree.IsInTree(12));
            Assert.IsFalse(tree.IsInTree(11));
        }

        [TestMethod]
        public void RemoveTest()
        {
            Assert.IsTrue(tree.IsEmpty());
            tree.Insert(12);
            Assert.IsFalse(tree.IsEmpty());
            Assert.IsTrue(tree.IsInTree(12));
            tree.RemoveKey(12);
            Assert.IsFalse(tree.IsInTree(12));
        }

        [TestMethod]
        public void EnumeratorTest()
        {
            int count = 0;
            foreach (int item in tree)
            {
                ++count;
            }
            Assert.AreEqual(0, count);
        }

        [TestMethod]
        public void EnumeratorTest2()
        {
            tree.Insert(1);
            tree.Insert(2);
            tree.Insert(3);
            tree.Insert(4);
            tree.Insert(5);
            tree.Insert(6);
            int count = 1;
            foreach (var item in tree)
            {
                Assert.AreEqual(count, item);
                count++;
            }
            Assert.AreEqual(count, 7);
        }

        
        private BSTClass<int> tree;
    }
}
