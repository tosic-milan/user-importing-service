using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Students.Commands.UploadStudents;

namespace UserImportingService.Infrastructure.CSV.Mappers
{
    public class PublicStudentMapper : CSVStudentMapper
    {
        //USERID, FIRSTNAME, MIDDLENAME, LASTNAME, ADDRESS, STUDENTID, PHONE, PARENTFIRSTNAME, PARENTLASTNAME, PARENTPHONE, NOTE
        public PublicStudentMapper()
        {
            
            Map(x => x.UserId).Index(0);
            Map(x => x.Firstname).Index(1);
            Map(x => x.Middlename).Index(2);
            Map(x => x.Lastname).Index(3);
            Map(x => x.Address).Index(4);
            Map(x => x.StudentId).Index(5);
            Map(x => x.Phone).Index(6);
            Map(x => x.Parents).Convert(row =>
            {
                var list = new List<Parent>();
                var iRow = row.Row;
                var parent1 = new Parent()
                {
                    Firstname = iRow.GetField(7),
                    Lastname = iRow.GetField(8),
                    Phone = iRow.GetField(9)
                };
                if (parent1.Firstname != null && parent1.Firstname.Trim().Length > 0)
                    list.Add(parent1);

                return list;
            });
            Map(x => x.Note).Index(10);
        }

        public override int CoulmnCount()
        {
            return 10;
        }
    }
}
