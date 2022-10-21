using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
internal class Resource
    {
        public string Id { get; set; } = null!;
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public bool CanRename { get; set; } = true;
        public bool HasParentNodeName { get; set; } = true; 
    }
}
