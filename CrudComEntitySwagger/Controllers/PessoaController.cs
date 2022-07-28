using CrudComEntitySwagger.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CrudComEntitySwagger.Context;

namespace CrudComEntitySwagger.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : ControllerBase
    {
        private readonly PessoaContext _context;

        public PessoaController(PessoaContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("BuscarTodasPessoas")]

        public async Task <ActionResult<List<Pessoa>>> BuscarTodos()
        {
           var buscarTodos = _context.Pessoas.ToList();
            return Ok(buscarTodos);
        }

        [HttpGet]
        [Route("BuscarPessoaPorId/{id}")]

        public async Task<ActionResult<Pessoa>> BuscarPessoaPorId(int id)
        {
            var buscarPessoa =   _context.Pessoas.FirstOrDefault(p => p.Id == id);
            return Ok(buscarPessoa);
        }

      /*  [HttpPost]
        [Route("AdicionarPessoa")]

        public async Task<ActionResult> AdicionarPessoa([FromBody]Pessoa pessoa)
        {
           
        }

        [HttpDelete]
        [Route("DeletarPessoa")]

        public async Task DeletarPessoa(int id )
        {

        }

        [HttpPut]
        [Route("AtualizarPessoa")]

        public async Task AtualizarPessoa(int id)
        {

        }*/

    }
}
