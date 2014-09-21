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

        
        private BSTClass<int> tree;
    }
}
