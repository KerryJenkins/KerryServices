using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KerryServices.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class MathController : ControllerBase
    {
        [HttpPost]
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
    }
}
