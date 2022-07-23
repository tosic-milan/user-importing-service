using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Domain.Models;

namespace UserImportingService.Application.Common.Interfaces
{
    public interface IStudentRepository
    {
        int SaveStudents(List<Student> students);
    }
}
