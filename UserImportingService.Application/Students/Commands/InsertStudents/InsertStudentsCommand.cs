using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Interfaces;
using UserImportingService.Domain.Models;

namespace UserImportingService.Application.Students.Commands.InsertStudents
{
    public class InsertStudentsCommand : IRequest<int>
    {
        public List<StudentDto> Users { get; set; }
    }

    public class InsertStudentsCommandHandler : IRequestHandler<InsertStudentsCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public InsertStudentsCommandHandler( IStudentRepository studentRepository, IMapper mapper )
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }

        public Task<int> Handle(InsertStudentsCommand request, CancellationToken cancellationToken)
        {
            var students = _mapper.Map<List<Student>>(request.Users);
            var studentsCount = _studentRepository.SaveStudents(students);
            return Task.FromResult(studentsCount);
        }
    }
}
