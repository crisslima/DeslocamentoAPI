using DeslocamentoApp.Application.Carros.Commands.CriarCarro;
using DeslocamentoApp.Application.Carros.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebApi.Controllers
{
    public class CarroController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetCarroQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarCarroCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
