using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace UserImportingService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class ApiControllerBase : ControllerBase
    {
        private IMediator _mediator = null!;

        protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<IMediator>();

        protected bool ValidateUploadFile(IFormFile file)
        {
            var fileName = file.FileName;
            if (fileName == null || !fileName.EndsWith(".csv"))
                return false;

            return true;
        }
    }
}
