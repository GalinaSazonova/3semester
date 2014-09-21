using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSTree
{
    public class BSTClass<T> : IEnumerable<T> where T : IComparable<T>
    {
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

        public bool IsEmpty()
        {
            return root == null;
        }

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

        public bool IsInTree(T keyToCheck)
        {
            return ExistsInTree(keyToCheck, root);
        }

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

        public void RemoveKey(T keyToRemove)
        {
            root = Remove(keyToRemove, root);
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        private class BSTEnumerator
        {

        }
    }
}
