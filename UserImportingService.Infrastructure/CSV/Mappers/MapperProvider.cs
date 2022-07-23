using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Enums;

namespace UserImportingService.Infrastructure.CSV.Mappers
{
    public class MapperProvider : IMapperProvider
    {
        public CSVStudentMapper ProvideMapper(SchoolType type)
        {
            switch (type)
            {   
                case SchoolType.PRIVATE_SCHOOL:
                    return new PrivateSchoolMapper();
                case SchoolType.PUBLIC_SCHOOL:
                    return new PublicStudentMapper();
                default:
                    return new PublicStudentMapper();
            }
        }
    }

}
