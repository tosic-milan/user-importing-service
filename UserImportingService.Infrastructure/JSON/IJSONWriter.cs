using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserImportingService.Infrastructure.JSON
{
    public interface IJSONWriter
    {
        void Write(string json);
    }
}
