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

        [HttpPost]
        [Route("AdicionarPessoa")]

        public async Task<ActionResult<String>> AdicionarPessoa([FromBody]Pessoa pessoa)
        {
            _context.Pessoas.Add(pessoa);
            _context.SaveChanges();

            return Ok("Pessoa Adicionada!!");
        }
      
       

        [HttpPut]
        [Route("AtualizarPessoa/{id}")]

        public async Task<ActionResult> AtualizarPessoa(Pessoa pessoa,int id)
        {

            if(id != pessoa.Id)
            {
                return BadRequest("Id não encontrado");
            }

          
            _context.Pessoas.Update(pessoa);
            _context.SaveChanges();

            return Ok("Atualizado com sucesso!");

        }

        [HttpDelete]
        [Route("DeletarPessoa/{id}")]

        public async Task<ActionResult<Pessoa>> DeletarPessoa(int id)
        {
            if (id == null)
            {
                return BadRequest("Id não encontrado!! ");
            }
            var buscarPessoaPorId = _context.Pessoas.Find(id);
            _context.Pessoas.Remove(buscarPessoaPorId);
            _context.SaveChanges();

            return Ok(buscarPessoaPorId);
        }

    }
}
