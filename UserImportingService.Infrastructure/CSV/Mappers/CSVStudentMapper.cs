using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Students.Commands.UploadStudents;

namespace UserImportingService.Infrastructure.CSV.Mappers
{
    public abstract class CSVStudentMapper : ClassMap<StudentDto>
    {
        public abstract int CoulmnCount();
    }
}
