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
            int addend1;
            if (!int.TryParse(request.Addend1, out addend1))
            {
                ModelState.AddModelError(nameof(request.Addend1), $"Invalid integer, value:'{request.Addend1}'");
            }

            int addend2;
            if (!int.TryParse(request.Addend2, out addend2))
            {
                ModelState.AddModelError(nameof(request.Addend2), $"Invalid intger, value:'{request.Addend2}'");
            }

            if (!ModelState.IsValid) return BadRequest(ModelState);

            var response = new AddResponse();

            response.Sum = await Task.FromResult(addend1 + addend2);

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
