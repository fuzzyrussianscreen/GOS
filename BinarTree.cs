using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EXAM3
{
    class BinarTree
    {
        public enum Side
        {
            Left,
            Right
        }

        public class BinaryTreeNode<T> where T : IComparable
        {
            public BinaryTreeNode(T data)
            {
                Data = data;
            }
            public T Data { get; set; }
            public BinaryTreeNode<T> LeftNode { get; set; }
            public BinaryTreeNode<T> RightNode { get; set; }

            public BinaryTreeNode<T> ParentNode { get; set; }
            /*
            public Side? NodeSide
            {
                if (ParentNode == null){
                    return Side?)null;
                }else if(ParentNode.LeftNode == this){
        return Side.Left;
    }else{
                return Side.Right;
    }
            }
             */   
                
               public Side? NodeSide =>
                ParentNode == null
                ? (Side?)null
                : ParentNode.LeftNode == this
                    ? Side.Left
                    : Side.Right;

public override string ToString() => Data.ToString();
        }

        public class BinaryTree<T> where T : IComparable
{
    public BinaryTreeNode<T> RootNode { get; set; }


    public BinaryTreeNode<T> Add(BinaryTreeNode<T> node, BinaryTreeNode<T> currentNode = null)
    {
        if (RootNode == null)
        {
            node.ParentNode = null;
            return RootNode = node;
        }

        currentNode = currentNode ?? RootNode;
        node.ParentNode = currentNode;
        int result = node.Data.CompareTo(currentNode.Data);

        if (result == 0)
            return currentNode;
        else
        {
            if (result < 0)
            {
                if (currentNode.LeftNode == null)
                    return currentNode.LeftNode = node;
                else
                    return Add(node, currentNode.LeftNode);
            }
            else
            {
                if (currentNode.RightNode == null)
                    return currentNode.RightNode = node;
                else
                    return Add(node, currentNode.RightNode);
            }
        }
        //return (result = node.Data.CompareTo(currentNode.Data)) == 0
        //    ? currentNode
        //    : result < 0
        //        ? currentNode.LeftNode == null
        //           ? (currentNode.LeftNode = node)
        //           : Add(node, currentNode.LeftNode)
        //       : currentNode.RightNode == null
        //           ? (currentNode.RightNode = node)
        //           : Add(node, currentNode.RightNode);
    }

    public BinaryTreeNode<T> Add(T data)
    {
        return Add(new BinaryTreeNode<T>(data));
    }

    public BinaryTreeNode<T> FindNode(T data, BinaryTreeNode<T> startWithNode = null)
    {
        startWithNode = startWithNode ?? RootNode;
        int result = data.CompareTo(startWithNode.Data);

        if (result == 0)
            return startWithNode;
        else if (result < 0)
            if (startWithNode.LeftNode == null)
                return null;
            else
                return FindNode(data, startWithNode.LeftNode);
        else
            if (startWithNode.RightNode == null)
            return null;
        else
            return FindNode(data, startWithNode.RightNode);

        //return (result = data.CompareTo(startWithNode.Data)) == 0
        //   ? startWithNode
        //   : result < 0
        //       ? startWithNode.LeftNode == null
        //           ? null
        //           : FindNode(data, startWithNode.LeftNode)
        //       : startWithNode.RightNode == null
        //           ? null
        //           : FindNode(data, startWithNode.RightNode);
    }

    public void Remove(BinaryTreeNode<T> node)
    {
        if (node == null)
        {
            return;
        }

        var currentNodeSide = node.NodeSide;
        if (node.LeftNode == null && node.RightNode == null)
        {
            if (currentNodeSide == Side.Left)
            {
                node.ParentNode.LeftNode = null;
            }
            else
            {
                node.ParentNode.RightNode = null;
            }
        }
        else if (node.LeftNode == null)
        {
            if (currentNodeSide == Side.Left)
            {
                node.ParentNode.LeftNode = node.RightNode;
            }
            else
            {
                node.ParentNode.RightNode = node.RightNode;
            }

            node.RightNode.ParentNode = node.ParentNode;
        }
        else if (node.RightNode == null)
        {
            if (currentNodeSide == Side.Left)
            {
                node.ParentNode.LeftNode = node.LeftNode;
            }
            else
            {
                node.ParentNode.RightNode = node.LeftNode;
            }

            node.LeftNode.ParentNode = node.ParentNode;
        }
        else
        {
            switch (currentNodeSide)
            {
                case Side.Left:
                    node.ParentNode.LeftNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    Add(node.LeftNode, node.RightNode);
                    break;
                case Side.Right:
                    node.ParentNode.RightNode = node.RightNode;
                    node.RightNode.ParentNode = node.ParentNode;
                    Add(node.LeftNode, node.RightNode);
                    break;
                default:
                    var bufLeft = node.LeftNode;
                    var bufRightLeft = node.RightNode.LeftNode;
                    var bufRightRight = node.RightNode.RightNode;
                    node.Data = node.RightNode.Data;
                    node.RightNode = bufRightRight;
                    node.LeftNode = bufRightLeft;
                    Add(bufLeft, node);
                    break;
            }
        }
    }

    public void Remove(T data)
    {
        var foundNode = FindNode(data);
        Remove(foundNode);
    }

    public void PrintTree()
    {
        PrintTree(RootNode);
    }
    private void PrintTree(BinaryTreeNode<T> startNode, string indent = "", Side? side = null)
    {
        if (startNode != null)
        {
            var nodeSide = "";
            if (side == null)
                nodeSide = "+";
            else if (side == Side.Left)
                nodeSide = "L";
            else
                nodeSide = "R";

            Console.WriteLine($"{indent} [{nodeSide}]- {startNode.Data}");
            indent += new string(' ', 3);
            PrintTree(startNode.RightNode, indent, Side.Right);
            PrintTree(startNode.LeftNode, indent, Side.Left);
        }
    }
}
public BinarTree()
{
    var binaryTree = new BinaryTree<int>();

    binaryTree.Add(8);
    binaryTree.Add(3);
    binaryTree.Add(10);
    binaryTree.Add(1);
    binaryTree.Add(6);
    binaryTree.Add(4);
    binaryTree.Add(7);
    binaryTree.Add(14);
    binaryTree.Add(16);

    binaryTree.PrintTree();

    Console.WriteLine(new string('-', 40));
    binaryTree.Remove(3);
    binaryTree.PrintTree();

    Console.WriteLine(new string('-', 40));
    binaryTree.Remove(8);
    binaryTree.PrintTree();

    Console.ReadLine();
}
    }
}
