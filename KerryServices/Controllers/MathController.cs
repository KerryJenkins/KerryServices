using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KerryServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpPost]
        [Route("add")]
        [Authorize("math:add")]
        public async Task<ActionResult<AddResponse>> Add(AddRequest request)
        {
            int addIn1;
            if (!int.TryParse(request.AddIn1, out addIn1))
            {
                ModelState.AddModelError(nameof(request.AddIn1), $"Invalid integer, value:'{request.AddIn1}'");
            }

            int addIn2;
            if (!int.TryParse(request.AddIn2, out addIn2))
            {
                ModelState.AddModelError(nameof(request.AddIn2), $"Invalid intger, value:'{request.AddIn2}'");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = new AddResponse();

            response.Sum = await Task.FromResult(addIn1 + addIn2);

            return response;
        }

        [HttpPost]
        [Route("subtract")]
        [Authorize("math:subtract")]
        public async Task<ActionResult<SubtractResponse>> Subtract(SubtractRequest request)
        {
            int minuend;
            if (!int.TryParse(request.Minuend, out minuend))
            {
                ModelState.AddModelError(nameof(request.Minuend), $"Invalid integer, value:'{request.Minuend}'");
            }

            int subtrahend;
            if (!int.TryParse(request.Subtrahend, out subtrahend))
            {
                ModelState.AddModelError(nameof(request.Subtrahend), $"Invalid intger, value:'{request.Subtrahend}'");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = new SubtractResponse();

            response.Difference = await Task.FromResult(minuend - subtrahend);

            return response;
        }

    }
}
