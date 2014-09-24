using System;
using System.Collections.Generic;
using System.Linq;

namespace BSTree
{
    /// <summary>
    /// Class for Binary Search Tree.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BSTClass<T> : IEnumerable<T> where T : IComparable<T>
    {
        /// <summary>
        /// Class for tree element.
        /// </summary>
        private class BSTreeNode
        {
            public T Key { get; set; }

            public BSTreeNode(T value)
            {
                this.Key = value;
            }

            public BSTreeNode LeftChild { get; set; }

            public BSTreeNode RightChild { get; set; }
        }

        private BSTreeNode root;

        /// <summary>
        /// Check if tree is empty.
        /// </summary>
        /// <returns>true, if empty</returns>
        public bool IsEmpty()
        {
            return root == null;
        }

        /// <summary>
        /// Check, if element is in the tree.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <param name="nodeToCheck"></param>
        /// <returns></returns>
        private bool ExistsInTree(T keyToCheck, BSTreeNode nodeToCheck)
        {
            if (nodeToCheck == null)
                return false;
            else
            {
                if (nodeToCheck.Key.CompareTo(keyToCheck) == 0)
                {
                    return true;
                }
                else
                {
                    if (nodeToCheck.Key.CompareTo(keyToCheck) > 0)
                    {
                        return ExistsInTree(keyToCheck, nodeToCheck.LeftChild);
                    }
                    else
                    {
                        return ExistsInTree(keyToCheck, nodeToCheck.RightChild);
                    }
                }
            }
        }

        /// <summary>
        /// User can check if element is in the tree.
        /// </summary>
        /// <param name="keyToCheck"></param>
        /// <returns></returns>
        public bool IsInTree(T keyToCheck)
        {
            return ExistsInTree(keyToCheck, root);
        }

        /// <summary>
        /// Insert key to tree.
        /// </summary>
        /// <param name="keyToInsert"></param>
        public void Insert(T keyToInsert)
        {
            if (IsEmpty())
            {
                root = new BSTreeNode(keyToInsert);
            }
            else
            {
                var nodeToCompare = root;
                while (true)
                {
                    if (nodeToCompare.Key.CompareTo(keyToInsert) > 0)
                    {
                        if (nodeToCompare.LeftChild == null)
                        {
                            nodeToCompare.LeftChild = new BSTreeNode(keyToInsert);
                            return;
                        }
                        nodeToCompare = nodeToCompare.LeftChild;
                    }
                    else
                    {
                        if (nodeToCompare.Key.CompareTo(keyToInsert) == 0)
                            return;
                        else
                        {
                            if (nodeToCompare.RightChild == null)
                            {
                                nodeToCompare.RightChild = new BSTreeNode(keyToInsert);
                                return;
                            }
                            nodeToCompare = nodeToCompare.RightChild;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Removes element from tree.
        /// </summary>
        /// <param name="keyToRemove"></param>
        /// <param name="root"></param>
        /// <returns></returns>
        private BSTreeNode Remove(T keyToRemove, BSTreeNode root)
        {
            if (root == null)
            {
                return null;
            }
            else
            {
                if (root.Key.CompareTo(keyToRemove) > 0)
                {
                    root.LeftChild = Remove(keyToRemove, root.LeftChild);
                }
                else
                {
                    if (root.Key.CompareTo(keyToRemove) < 0)
                    {
                        root.RightChild = Remove(keyToRemove, root.RightChild);
                    }
                    else
                    {
                        if (root.RightChild == null && root.LeftChild == null)
                        {
                            return null;
                        }
                        else
                        {
                            if (root.LeftChild == null)
                            {
                                return root.RightChild;
                            }
                            else
                            {
                                if (root.RightChild == null)
                                {
                                    return root.LeftChild;
                                }
                                else
                                {
                                    if (root.RightChild.LeftChild == null)
                                    {
                                        var temp = root.LeftChild;
                                        root = root.RightChild;
                                        root.LeftChild = temp;
                                        return root;
                                    }
                                    else
                                    {
                                        var cur = root.RightChild;
                                        while (cur.LeftChild.LeftChild != null)
                                        {
                                            cur = cur.LeftChild;
                                        }
                                        var temp = root.LeftChild;
                                        root = root.RightChild;
                                        cur.LeftChild.LeftChild = temp;
                                        return root;
                                    }
                                }
                            }
                        }
                    }
                }
                return root;
            }
        }

        /// <summary>
        /// Removes element from tree by user's order.
        /// </summary>
        /// <param name="keyToRemove"></param>
        public void RemoveKey(T keyToRemove)
        {
            root = Remove(keyToRemove, root);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new BSTEnumerator(this);
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Class for tree's enumerator.
        /// </summary>
        private class BSTEnumerator : IEnumerator<T>
        {
            private int numerator = -1;
            private BSTClass<T> tree;
            private List<T> listForTree = new List<T>();

            public BSTEnumerator(BSTClass<T> tree)
            {
                this.tree = tree;
                treeToList(tree.root);
            }

            /// <summary>
            /// Add tree to list ascending.
            /// </summary>
            /// <param name="elementToPaste"></param>
            private void treeToList(BSTreeNode elementToPaste)
            {
                if (tree.root == null)
                    return;

                if (elementToPaste != null)
                    listForTree.Add(elementToPaste.Key);

                if (elementToPaste.LeftChild != null)
                    treeToList(elementToPaste.LeftChild);

                if (elementToPaste.RightChild != null)
                    treeToList(elementToPaste.RightChild);
            }

            public T Current
            {
                get { return listForTree.ElementAt(numerator); }
            }

            public void Dispose()
            {
            }

            object System.Collections.IEnumerator.Current
            {
                get { return Current; }
            }

            public bool MoveNext()
            {
                if (listForTree.Count() == 0 || listForTree.First() == null)
                    return false;
                if (listForTree.ElementAt(1) == null)
                {
                    Reset();
                    return false;
                }
                numerator++;
                return !(listForTree.Count() == numerator);
            }

            public void Reset()
            {
                numerator = -1;
            }
        }
    }
}
