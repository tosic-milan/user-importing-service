using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserImportingService.Infrastructure.JSON
{
    public class JSONWriter : IJSONWriter
    {
        private readonly IConfiguration _configuration;
        private string _path;
        public JSONWriter(IConfiguration configuration)
        {
            _configuration = configuration;
            _path = _configuration.GetSection("JSONWriter").GetSection("Path").Value;
        }
        public void Write(string json)
        {
            var timestamp = DateTime.Now;
            File.WriteAllText(_path + timestamp.ToUniversalTime().Subtract(
                                                                    new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)
                                                                    ).TotalMilliseconds + ".json", json);
            
        }
    }
}
