using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserImportingService.Application.Students.Commands.InsertStudents
{
    public class InsertStudentsCommandValidator : AbstractValidator<InsertStudentsCommand>
    {
        public InsertStudentsCommandValidator()
        {
            RuleForEach(v => v.Users).SetValidator(new StudentDtoValidator());
        }
    }

    public class StudentDtoValidator : AbstractValidator<StudentDto>
    {
        public StudentDtoValidator()
        {
            RuleFor(x => x.UserId).NotEmpty();
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Middlename).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.StudentId).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
            RuleFor(x => x.Parent).NotNull()
                .SetValidator(new StudentParentValidator());

        }
    }

    public class StudentParentValidator : AbstractValidator<Parent>
    {
        public StudentParentValidator()
        {
            RuleFor(x => x.Firstname).NotEmpty();
            RuleFor(x => x.Middlename).NotEmpty();
            RuleFor(x => x.Lastname).NotEmpty();
            RuleFor(x => x.Phone).NotEmpty();
        }
    }
}
