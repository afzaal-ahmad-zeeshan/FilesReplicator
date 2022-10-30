using FilesReplicator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Services
{
internal class Replicator
    {
        public static void CreateDirectories(Tree tree) 
        {
            // Create the first-level directories
            foreach (var node in tree.Nodes)
            {
                var directory = Directory.CreateDirectory(_getPath(tree.ParentDirectory, node.Name));

                // Create the second-level directories, and flush the data.
                foreach (var child in node.Children)
                {
                    var container = Directory.CreateDirectory(_getPath(directory.FullName, child.Name));

                    // Flush the resources
                    foreach (var resource in tree.Resources)
                    {
                        string name = "";
                        if (resource.HardcodedName)
                        {
                            name = resource.FileName;
                        } else
                        {
                            var extension = resource.FileName.Split(".").Last();
                            name = container.Name + "." + extension;
                        }
                        File.Copy(resource.FilePath, _getPath(container.FullName, name), true);
                    }
                }
            }
        }

        private static string _getPath(string root, string name)
        {
            return Path.Combine(root, name);
        }
    }
}
