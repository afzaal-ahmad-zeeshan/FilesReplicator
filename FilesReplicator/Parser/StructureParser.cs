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
        /// <summary>
        /// Parse the tree with only two levels (level-1 directories for the modules and level-2 directories for the content.
        /// </summary>
        /// <param name="tree"></param>
        /// <param name="compressed"></param>
        /// <returns>The string structure of the Tree element.</returns>
        public static string ToText(Tree tree, bool compressed = false) 
        {
            StringBuilder builder = new StringBuilder();
            builder.AppendLine($"~ {tree.ParentDirectory}");
            var indent = "";

            // Read the tree nodes
            foreach (var node in tree.Nodes)
            {
                indent = "";
                // First-level nodes are always directories for directories.
                builder.AppendLine($"{indent}+ {node.Name}");

                // Second-level nodes are also directories and use the resources.
                foreach (var child in node.Children)
                {
                    indent = "    ";
                    builder.AppendLine($"{indent}+ {child.Name}");

                    // Put the files here.
                    //foreach (var file in tree.Resources)
                    //{
                    //    indent = "        ";
                    //    var extension = file.FileName.Split(".").Last();
                    //    var fileName = file.HardcodedName ? file.FileName : $"{child.Name}.{extension}";
                    //    builder.AppendLine($"{indent}- {fileName}");
                    //}
                }
            }

            builder.Append(Environment.NewLine);

            // put the resources here
            builder.AppendLine("@");
            foreach (var resource in tree.Resources)
            {
                var starter = resource.HardcodedName ? "-" : "^";
                builder.AppendLine($"{starter} {resource.FileName}");
                builder.AppendLine($"{resource.FilePath}");
            }

            return builder.ToString();
        }



        public Tree ParseStructure(string structure)
        {
            Tree tree = new Tree();
            // Structure starts with the root directory

            return tree;
        }
    }
}
