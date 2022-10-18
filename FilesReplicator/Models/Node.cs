using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
    internal class Node
    {
        public string Id { get; set; } = null!;
        public string Name { get; set; } = null!;
        public bool IsDirectory { get; set; }

        // The children for this node. Each child can be a directory or a file.
        public List<Node> Children { get; set; } = new List<Node>();

        // The index for the children starts by zero, if set to true.
        public bool IndexByZero { get; set; } = false;

        public string Separator { get; set; } = " - ";
    }
}
