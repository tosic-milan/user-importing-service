using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Enums;
using UserImportingService.Domain.Models;

namespace UserImportingService.Application.Common.Interfaces
{
    public interface ICSVParser
    {
        List<UserImportingService.Application.Students.Commands.UploadStudents.StudentDto> ParseCSV(Stream stream, SchoolType type);

    }
}
