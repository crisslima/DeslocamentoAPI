using DeslocamentoApp.Application.Clientes.Commands.CriarCliente;
using DeslocamentoApp.Application.Clientes.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebApi.Controllers
{
    public class ClienteController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync(
            [FromQuery] GetClienteQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarClienteCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }
    }
}
