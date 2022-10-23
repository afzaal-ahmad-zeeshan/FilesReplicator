using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Models
{
internal class Resource
    {
        public string FileName { get; set; } = null!;
        public string FilePath { get; set; } = null!;
        public bool HardcodedName { get; set; } = true;
    }
}
