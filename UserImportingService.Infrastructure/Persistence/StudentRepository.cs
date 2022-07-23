using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Interfaces;
using UserImportingService.Domain.Models;
using UserImportingService.Infrastructure.JSON;

namespace UserImportingService.Infrastructure.Persistence
{
    public class StudentRepository : IStudentRepository
    {
        private readonly IJSONWriter _jsonWriter;

        public StudentRepository(IJSONWriter jsonWriter)
        {
            _jsonWriter = jsonWriter;
        }

        public int SaveStudents(List<Student> students)
        {
            var studentsString = JsonSerializer.Serialize(students);
            _jsonWriter.Write(studentsString);
            return students.Count();
        }
    }
}
