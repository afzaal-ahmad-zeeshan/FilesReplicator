using FilesReplicator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Navigation;
using System.Xml.Linq;

namespace FilesReplicator.Data
{
    internal class Seed
    {
        private int totalCalls;
        private int _level;
        private int maxLevel = 3;

        public Tree MakeTree()
        {
            var tree = new Tree();

            // Set the tree
            tree.ParentDirectory = "./";

            // Prepare some children.
            int count = 5;
            var children = new List<Node>();
            for (int i = 0; i < count; i++)
            {
                var _node = _getNode(i, 1);

                if (_node != null)
                {
                    children.Add(_node);
                }
            }

            tree.Nodes = children;
            //MessageBox.Show($"_getNode was called {totalCalls} times.");
            return tree;
        }

        private Node _getNode(int index, int level)
        {
            if (level > maxLevel)
            {
                return null;
            }

            totalCalls++;
            var random = new Random();
            var node = new Node();
            node.Name = $"Node {index}";

            // randomize this
            node.IsDirectory = random.Next(2) == 1; // Is directory if value is zero.

            if (node.IsDirectory)
            {
                int _count = random.Next(5);
                var children = new List<Node>();
                // add child nodes
                for (int j = 0; j < _count; j++)
                {
                    var _node = _getNode(j, level + 1);

                    if (_node != null)
                    {
                        children.Add(_node);
                    }
                }

                node.Children = children;
            }

            return node;
        }

        public string GetStructure()
        {
            return File.ReadAllText("./Data/dummy.structure");
        }
    }
}
