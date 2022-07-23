using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Enums;

namespace UserImportingService.Infrastructure.CSV.Mappers
{
    public interface IMapperProvider
    {
        CSVStudentMapper ProvideMapper(SchoolType type);
    }
}
