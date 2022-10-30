using FilesReplicator.Exceptions;
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
                builder.Append($"{indent}+ {node.Name}");

                if (node.Children.Count > 0)
                {
                    builder.Append(" >");
                }
                builder.AppendLine();

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

                // Close the children node by adding a new line.
                builder.AppendLine();
            }

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

        public static Tree ParseStructure(string structure)
        {
            Tree tree = new Tree
            {
                Resources = new List<Resource>(),
            };

            // Structure starts with the root directory
            var lines = structure.Split(Environment.NewLine);

            // process each line.
            bool _resources = false; 
            var resources = new List<Resource>();
            for (var index = 0; index < lines.Count(); index++)
            {
                var line = lines[index].Trim();
                // structure starts with ~
                if (line.StartsWith("~"))
                {
                    tree.ParentDirectory = line.Substring(1).Trim();
                } else if (line.StartsWith("+"))
                {
                    // Directory
                    Node currentDirectory;
                    bool hasChildren = line.EndsWith(">");
                    var name = line.Substring(1).Trim();
                    if (hasChildren)
                    {
                        name = name.Substring(0, name.Length - 2).Trim();
                    }
                    currentDirectory = new Node
                    {
                        Name = name,
                        IsDirectory = true,
                    };

                    if (hasChildren)
                    {
                        currentDirectory.Children = new List<Node>();

                        if (index == lines.Count() - 1)
                        {
                            throw new StructureException("");
                        }
                        line = lines[++index].Trim();
                        while (line != "")
                        {
                            if (line.StartsWith("+"))
                            {
                                var node = new Node
                                {
                                    Name = line.Substring(1).Trim(),
                                    IsDirectory = true,
                                };
                                currentDirectory.Children.Add(node);
                            }

                            if (index == lines.Count() - 1)
                            {
                                throw new StructureException("");
                            }
                            line = lines[++index].Trim();
                        }
                    }
                    tree.Nodes.Add(currentDirectory);
                } else if (line.StartsWith("@"))
                {
                    // The resources are starting.
                    _resources = true;
                } else if (line.StartsWith("-"))
                {
                    if (index == lines.Count() - 1)
                    {
                        throw new StructureException("");
                    }
                    // Resource with a fixed name
                    var res = new Resource
                    {
                        FileName = line.Substring(1).Trim(),
                        FilePath = lines[index + 1],
                        HardcodedName = true,
                    };

                    // Increment the index
                    index++;
                    tree.Resources.Add(res);
                } else if (line.StartsWith("^"))
                {
                    if (index == lines.Count() - 1)
                    {
                        throw new StructureException("");
                    }
                    // Resource with a parent's name.
                    var res = new Resource
                        {
                        FileName = line.Substring(1).Trim(),
                        FilePath = lines[index + 1],
                        HardcodedName = false,
                    };

                    // Increment the index
                    index++;
                    tree.Resources.Add(res);
                } else if (line == "" && !_resources)
                {
                    // Reading the first-level directories.
                }
            }

            return tree;
        }
    }
}
