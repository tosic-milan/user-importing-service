using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using UserImportingService.Application.Common.Enums;
using UserImportingService.Application.Common.Interfaces;
using UserImportingService.Application.Students.Commands.InsertStudents;
using UserImportingService.Application.Students.Commands.UploadStudents;

namespace UserImportingService.API.Controllers
{
    public class PublicSchoolController : ApiControllerBase
    {
        private readonly ICSVParser _parser;
        public PublicSchoolController(ICSVParser parser)
        {
            _parser = parser;
        }

        [HttpPost]
        public async Task<ActionResult<int>> InserStudents([FromBody] InsertStudentsCommand command)
        {
                return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult<int>> UploadStudents( [Required] IFormFile formFile)
        {
            var response = -1;
            if (!ValidateUploadFile(formFile))
                return BadRequest();

            using (var stream = formFile.OpenReadStream())
            {
                response = await Mediator.Send(new UploadStudentsCommand() { Students = _parser.ParseCSV(stream, SchoolType.PUBLIC_SCHOOL) });
            }
            return response;
        }
    }
}
