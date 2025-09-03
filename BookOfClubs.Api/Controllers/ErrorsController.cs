using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookOfClubs.Api.Controllers
{
    [Route("/error")]
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        [HttpPost]
        public IActionResult Error()
        {
            Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;
            return Problem(title: exception?.Message, statusCode: 403);
        }
    }
}
