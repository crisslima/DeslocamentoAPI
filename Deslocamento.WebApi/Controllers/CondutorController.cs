using DeslocamentoApp.Application.Condutores.Commands.CriarCondutor;
using DeslocamentoApp.Application.Condutores.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebApi.Controllers
{
    public class CondutorController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCondutorQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCondutorCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

    }
}
