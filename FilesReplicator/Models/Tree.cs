using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
    internal class Tree
    {
        public List<Node> Nodes { get; set; } = new List<Node>();
        public List<string> FilePaths { get; set; } = new List<string>();
    }
}
