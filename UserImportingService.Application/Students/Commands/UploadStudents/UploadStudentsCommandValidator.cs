using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserImportingService.Application.Students.Commands.UploadStudents
{
    public class UploadStudentsCommandValidator : AbstractValidator<UploadStudentsCommand>
    {
        public UploadStudentsCommandValidator()
        {
            RuleForEach(x => x.Students)
                .SetValidator(new StudentDtoValidator());
        }
    }

    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Middlename).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleForEach(x => x.Parents)
                .SetValidator(new ParentDtoValidator());
        }
    }

    public class ParentDtoValidator : AbstractValidator<Parent>
    {
        public ParentDtoValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
