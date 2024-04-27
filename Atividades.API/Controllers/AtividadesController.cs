using Atividades.API.Data;
using Atividades.Domain.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Atividades.API.Controllers
{
    [Route("api/[controller]")]
    public class AtividadesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AtividadesController(AppDbContext context)
        {
            _context = context;
        }

        // atividades
        [HttpGet]
        public ActionResult<IEnumerable<Atividade>> GetAll()
        {
            return _context.Atividades!;
        }

        // atividades/{id}
        [HttpGet("{id}")]
        public ActionResult<Atividade> Get(int id)
        {
            var atividade = _context.Atividades!.FirstOrDefault(x => x.AtividadeId == id);

            if (atividade is null) return NotFound();

            return atividade;
        }

        [HttpPost]
        public ActionResult<Atividade> Post(Atividade atividade)
        {
            try
            {
                _context.Add(atividade);
                _context.SaveChanges();

                return atividade;
            }
            catch (Exception ex)
            {
                return BadRequest("Houve um erro ao processar sua requisição. Erro: " + ex.Message);
            }
        }

        // atividade/{id}
        [HttpPut("{id}")]
        public ActionResult<Atividade> Put(int id, Atividade atividade)
        {
            if (id != atividade.AtividadeId)
                throw new ArgumentOutOfRangeException("O id informado não é o mesmo da ativada informada.");

            var ativadeToUpdate = _context.Atividades!.FirstOrDefault(x => x.AtividadeId == id);

            if (ativadeToUpdate is null)
                return NotFound("Atividade não encontrada.");

            ativadeToUpdate.Name = atividade.Name;
            ativadeToUpdate.Prioridade = atividade.Prioridade;
            ativadeToUpdate.Status = atividade.Status;

            try
            {
                _context.Atividades!.Update(ativadeToUpdate);
                _context.SaveChanges();

                return ativadeToUpdate;
            }
            catch (Exception ex)
            {
                return BadRequest("Houve um erro ao processar sua requisição. Erro: " + ex.Message);
            }

        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var atividade = _context.Atividades!.FirstOrDefault(x => x.AtividadeId == id);

            if (atividade is null)
                return NotFound();

            try
            {
                _context.Atividades!.Remove(atividade);
                _context.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return BadRequest("Houve um erro ao processar sua requisição. Erro: " + ex.Message);
            }
        }
    }
}

