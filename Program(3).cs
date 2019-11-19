using System;

namespace HW21._1
{
    public class Tree
    {
        public class TreeNode
        {
            public int Value;
            public int Count = 0;
            public TreeNode Left;
            public TreeNode Right;

            public TreeNode(int Value)
            {
                this.Value = Value;
            }
        }
        public TreeNode Node;

        public void Add(int Value)
        {
            if (Node == null)
            {
                Node = new TreeNode(Value);
                return;
            }
            Add(ref Node, Value);
            
        }
        private void Add(ref TreeNode n, int value)
        {
            if(n == null)
            {
                n = new TreeNode(value);
                n.Count++;
                return;
            }
            if (n.Value > value)
            {
                Add(ref n.Left, value);
            }
            else if (n.Value < value)
            {
                Add(ref n.Right, value);
            }
            else
            {
                throw new Exception($"Узел со значением {value} уже существует");
            }
        }

        public string Display(TreeNode t)
        {
            string result = "";
            if (t.Left != null)
                result += Display(t.Left);

            result += t.Value + " ";

            if (t.Right != null)
                result += Display(t.Right);

            return result;
        }

        public void Find(int num)
        {
            String adress = Convert.ToString(num) + "--->Root";
            if (Node.Value == num)
            {
                Console.WriteLine(adress);
            }
            else
            {
                Find(Node, num, adress);
            }

        }
        private void Find(TreeNode node, int num, String adress)
        {
            if (node == null)
            {
                Console.WriteLine($"Узла со значением {num} в дереве нет");
            }
            else if (node.Value == num)
            {
                Console.WriteLine(adress);
            }
            else if (node.Value > num)
            {
                adress += ".Left";
                Find(node.Left, num, adress);
            }
            else if(node.Value < num)
            {
                adress += ".Right";
                Find(node.Right, num, adress);
            }
        }

        public void Delete(int num)
        {
            if (Node.Value == num)
            {
                Node = null;
                Console.WriteLine($"Узел со значением {num} успешно удален");
            }
            else
            {
                Delete(ref Node, num);
            }
        }
        private void Delete(ref TreeNode node, int num)
        {
            if (node == null)
            {
                Console.WriteLine($"Узла со значением {num} в дереве нет");
            }
            else if (node.Value == num)
            {
                node = null;
                Console.WriteLine($"Узел со значением {num} успешно удален");
            }
            else if (node.Value > num)
            {
                Delete(ref node.Left, num);
            }
            else if (node.Value < num)
            {
                Delete(ref node.Right, num);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Tree tree1 = new Tree();
            tree1.Add(5);
            Console.WriteLine(tree1.Node.Value);
            tree1.Add(3);
            Console.WriteLine(tree1.Node.Left.Value);
            Console.WriteLine(tree1.Display(tree1.Node));
            tree1.Add(8);
            tree1.Add(7);
            tree1.Add(2);
            tree1.Add(1);
            Console.WriteLine(tree1.Display(tree1.Node));
            Console.WriteLine(tree1.Node.Left.Left.Value);
            Console.WriteLine(tree1.Node.Left.Left.Left.Value);
            Console.WriteLine(tree1.Node.Right.Left.Value);
            tree1.Find(10);
            tree1.Find(7);
            tree1.Add(11);
            Console.WriteLine(tree1.Display(tree1.Node));
            tree1.Delete(11);
            Console.WriteLine(tree1.Display(tree1.Node));
        }
    }
}
