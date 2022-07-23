using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Domain.Models;

namespace UserImportingService.Application.Mapping
{
    public class StudentMappingProfile: Profile
    {
        public StudentMappingProfile()
        {
            CreateMap<Students.Commands.UploadStudents.StudentDto, Student>()
                .ForMember(s => s.UserId, opt => opt.MapFrom(dto => dto.UserId))
                .ForMember(s => s.Firstname, opt => opt.MapFrom(dto => dto.Firstname))
                .ForMember(s => s.Lastname, opt => opt.MapFrom(dto => dto.Lastname))
                .ForMember(s => s.Middlename, opt => opt.MapFrom(dto => dto.Middlename))
                .ForMember(s => s.Address, opt => opt.MapFrom(dto => dto.Address))
                .ForMember(s => s.StudentId, opt => opt.MapFrom(dto => dto.StudentId))
                .ForMember(s => s.Note, opt => opt.MapFrom(dto => dto.Note))
                .ForMember(s => s.Phone, opt => opt.MapFrom(dto => dto.Phone))
                .ForMember(s => s.Parents, opt => opt.MapFrom(dto => dto.Parents));

            CreateMap<Students.Commands.InsertStudents.StudentDto, Student>()
                .ForMember(s => s.UserId, opt => opt.MapFrom(dto => dto.UserId))
                .ForMember(s => s.Firstname, opt => opt.MapFrom(dto => dto.Firstname))
                .ForMember(s => s.Lastname, opt => opt.MapFrom(dto => dto.Lastname))
                .ForMember(s => s.Middlename, opt => opt.MapFrom(dto => dto.Middlename))
                .ForMember(s => s.StudentId, opt => opt.MapFrom(dto => dto.StudentId))
                .ForMember(s => s.Note, opt => opt.MapFrom(dto => dto.Note))
                .ForMember(s => s.Phone, opt => opt.MapFrom(dto => dto.Phone))
                .ForMember(s => s.Parents, opt => opt.MapFrom(dto => MapStudentsFamily(dto)));

            CreateMap<Students.Commands.UploadStudents.Parent, Parent>()
                           .ForMember(p => p.Firstname, opt => opt.MapFrom(dto => dto.Firstname))
                           .ForMember(p => p.Lastname, opt => opt.MapFrom(dto => dto.Lastname))
                           .ForMember(p => p.Phone, opt => opt.MapFrom(dto => dto.Phone));


        }

        private List<Parent> MapStudentsFamily(Students.Commands.InsertStudents.StudentDto dto)
        {
            var result = new List<Parent>();
            result.Add(new Parent() { Firstname = dto.Parent.Firstname, Lastname = dto.Parent.Lastname, Phone = dto.Parent.Phone });
            return result;
        }

    }
}
