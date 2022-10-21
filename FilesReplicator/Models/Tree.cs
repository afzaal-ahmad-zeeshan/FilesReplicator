using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
    internal class Tree
    {
        public string ParentDirectory { get; set; } = string.Empty;
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<Resource> Resources { get; set; } = new List<Resource>();

        // Properties
        public int Level { get; set; } = 0;
        public int LongestBranch { get; set; } = 0;
    }
}
