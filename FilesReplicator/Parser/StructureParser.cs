using FilesReplicator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Parser
{
internal class StructureParser
    {
        public static string ToText(Tree tree, bool compressed = false)
        {
            StringBuilder content = new StringBuilder();
            content.AppendLine($"~ {tree.ParentDirectory}");

            // Ready the queue
            Queue<Node> nodes = new Queue<Node>();
            foreach (var node in tree.Nodes)
            {
                nodes.Enqueue(node);
            }

            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();

                content.AppendLine(node.ToString());

                foreach (var child in node.Children)
                {
                    nodes.Enqueue(child);
                }
            }

            return content.ToString();
        }

        public static Tree ToTree(string content)
        {
            Tree tree = new Tree();

            return tree;
        }
    }
}
