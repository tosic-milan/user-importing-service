using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Enums;
using UserImportingService.Application.Common.Interfaces;
using UserImportingService.Application.Students.Commands.UploadStudents;
using UserImportingService.Domain.Models;
using UserImportingService.Infrastructure.CSV.Mappers;

namespace UserImportingService.Infrastructure.CSV
{
    public class StudentCSVParser : ICSVParser
    {
        private readonly IMapperProvider _mapperProvider;
        private readonly IConfiguration _configuration;
        private bool _useHeader = false;

        public StudentCSVParser(IMapperProvider mapperProvider, IConfiguration configuration)
        {
            _mapperProvider = mapperProvider;   
            _configuration = configuration;
            _useHeader = "true".Equals(_configuration.GetSection("CSVHelper").GetSection("UseHeader").Value) ? true : false;
        }

        List<StudentDto> ICSVParser.ParseCSV(Stream stream, SchoolType type)
        {
            var configuration = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                HasHeaderRecord = _useHeader,
                MissingFieldFound = null
            };
            configuration.TrimOptions = TrimOptions.Trim;
            List<StudentDto> students = null;
            using (var reader = new StreamReader(stream))
            {
                using (var csv = new CsvReader(reader, configuration))
                {
                    var mapper = _mapperProvider.ProvideMapper(type);
                    csv.Context.RegisterClassMap(mapper);    
                    students = csv.GetRecords<StudentDto>().ToList();

                }
            }
            return students;
        }
    }
}
