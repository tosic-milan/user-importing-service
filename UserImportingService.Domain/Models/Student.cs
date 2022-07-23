using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserImportingService.Domain.Models
{
    public class Student
    {
        public string UserId { get; set; }
        public string Firstname { get; set; }
        public string Middlename { get; set; }
        public string Lastname { get; set; }
        public string StudentId { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public string Phone { get; set; }
        public List<Parent> Parents { get; set; }
    }
}
