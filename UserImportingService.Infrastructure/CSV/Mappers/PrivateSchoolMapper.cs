using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Students.Commands.UploadStudents;

namespace UserImportingService.Infrastructure.CSV.Mappers
{
    public class PrivateSchoolMapper : CSVStudentMapper
    {
        public PrivateSchoolMapper()
        {
            //USERID, STUDENTFIRSTNAME, STUDENTMIDDLENAME, STUDENTLASTNAME, STUDENTADDRESS, STUDENTID, STUDENTPHONE, MOTHERFIRSTNAME,
            //MOTHERLASTNAME, MOTHERPHONE, FATHERFIRSTNAME, FATHERLASTNAME, FATHERPHONE, NOTE
            // Validate(field => field.Field != null && !string.Empty.Equals(field.Field));
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
                var parent2 = new Parent()
                {
                    Firstname = iRow.GetField(10),
                    Lastname = iRow.GetField(11),
                    Phone = iRow.GetField(12)
                };

                if (parent1.Firstname != null && parent1.Firstname.Trim().Length > 0)
                    list.Add(parent1);

                if (parent2.Firstname != null && parent2.Firstname.Trim().Length > 0)
                    list.Add(parent2);
                return list;
            });
            Map(x => x.Note).Index(13);
        }

        public override int CoulmnCount()
        {
            return 13;
        }
    }
}
