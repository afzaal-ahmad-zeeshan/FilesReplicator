using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FilesReplicator.Exceptions
{
internal class StructureException : Exception
    {
        public StructureException(string message) : base(message)
        {
        }
    }
}
