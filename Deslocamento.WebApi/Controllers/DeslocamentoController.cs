using DeslocamentoApp.Application.Deslocamentos.Commands.CriarDeslocamento;
using DeslocamentoApp.Application.Deslocamentos.Commands.EncerrarDeslocamento;
using DeslocamentoApp.Application.Deslocamentos.Queries;
using Microsoft.AspNetCore.Mvc;

namespace DeslocamentoApp.WebApi.Controllers
{
    public class DeslocamentoController : ApiController
    {

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] GetDeslocamentosQuery query)
        {
            var result = await Mediator.Send(query);

            return Ok(result);
        }

        [HttpGet("{deslocamentoId:long}")]
        public async Task<IActionResult> GetSync(long deslocamentoId)
        {
            var query = new GetDeslocamentoQuery() { DeslocamentoId = deslocamentoId };
            var result = await Mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] CriarDeslocamentoCommand command)
        {
            var result = await Mediator.Send(command);

            return Created($"id={result.Id}", result);
        }

        [HttpPut("{deslocamentoId:long}/encerrar_deslocamento")]
        public async Task<IActionResult> PutEncerrarDeslocamentoAsync(
            [FromRoute] long deslocamentoId,
            [FromBody] EncerrarDeslocamentoCommand command)
        {
            if (deslocamentoId != command.DeslocamentoId) return BadRequest();

            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}
