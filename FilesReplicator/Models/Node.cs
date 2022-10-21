using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
    internal class Node
    {
        // Name is a templated string.
        public string Name { get; set; } = null!;

        // Directories get the resources.
        public bool IsDirectory { get; set; } = false;

        // The children for this node. Each child can be a directory or a file.
        public List<Node> Children { get; set; } = new List<Node>();

        public override string ToString()
        {
            // Use the builder for performance and memory optimization.
            StringBuilder builder = new StringBuilder();

            // Is directory?
            builder.Append(IsDirectory ? "+" : "-");
            builder.Append(" ");

            builder.Append(Name);

            // Wrap up
            return builder.ToString();
        }
    }
}
