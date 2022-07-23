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

namespace UserImportingService.Application.Students.Commands.UploadStudents
{
    public class UploadStudentsCommand : IRequest<int>
    {
        public List<StudentDto> Students { get; set; }
    }

    public class UploadStudentsCommandHandler : IRequestHandler<UploadStudentsCommand, int>
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IMapper _mapper;

        public UploadStudentsCommandHandler(IStudentRepository studentRepository, IMapper mapper)
        {
            _studentRepository = studentRepository;
            _mapper = mapper;
        }
        public Task<int> Handle(UploadStudentsCommand request, CancellationToken cancellationToken)
        {
            var students = _mapper.Map<List<Student>>(request.Students);
            var studentsCount = _studentRepository.SaveStudents(students);
            return Task.FromResult(studentsCount);
        }
    }
}
