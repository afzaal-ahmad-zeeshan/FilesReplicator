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
        public string GetStructure()
        {
            return File.ReadAllText("./Data/dummy.structure"); 
        }

        public string GetSapling()
        {
            return File.ReadAllText("./Data/sapling.structure");
        }

        public Tree MakeTwoLevelTree() 
        {
            var tree = new Tree();

            // Set the tree
            tree.ParentDirectory = "C:\\Users\\afzaa\\Downloads\\";

            // Prepare some children.
            var random = new Random();
            int count = random.Next(3, 6);
            var children = new List<Node>();
            for (int i = 0; i < count; i++)
            {
                var node = new Node
                {
                    Name = "Directory " + random.Next(5000),
                    IsDirectory = true,
                };

                // add children for each node
                int _count = random.Next(5, 7);
                var _children = new List<Node>();
                for (int j = 0; j < _count; j++)
                {
                    var _node = new Node
                    {
                        Name = "Directory " + random.Next(5000),
                        IsDirectory = true,
                    };

                    _children.Add(_node);
                }

                node.Children = _children;
                children.Add(node);
            }

            tree.Nodes = children;

            // pick random files
            var resources = new List<Resource>();
            resources.Add(new Resource
            {
                FilePath = "C:\\Users\\afzaa\\Downloads\\exercise-01.zip",
                FileName = "exercise-01.zip",
                HardcodedName = true,
            });
            resources.Add(new Resource
            {
                FilePath = "C:\\Users\\afzaa\\Downloads\\demo.zip",
                FileName = "demo.zip",
                HardcodedName = false,
            });

            tree.Resources = resources;
            return tree;
        }
    }
}
