using Atividades.Domain.Interfaces;
using Atividades.Domain.Models;
using Atividades.Domain.Constants;
using Microsoft.AspNetCore.Mvc;

namespace Atividades.API.Controllers;

[Route("api/[controller]")]
public class AtividadesController : ControllerBase
{
    private readonly IAtividadesRepository _atividadesRepository;

    public AtividadesController(IAtividadesRepository atividadesRepository)
    {
        _atividadesRepository = atividadesRepository;
    }

    // atividades
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Atividade>>> GetAll()
    {
        return await _atividadesRepository.GetAllAsync();
    }

    // atividades/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Atividade>> Get(int id)
    {
        try
        {
            throw new Exception("t");
            var atividade = await _atividadesRepository.GetAsync(id);
            if (atividade is null) return NotFound();

            return Ok(atividade);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, Global.DEFAULT_ERROR_MESSAGE);
        }
    }

    // atividades
    [HttpPost]
    public async Task<ActionResult<Atividade>> Post(Atividade atividade)
    {
        try
        {
            var atv = await _atividadesRepository.AddAsync(atividade);
            return Created("Get", atv);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Houve um erro ao processar sua requisição. Erro: " + ex.Message);
        }
    }

    // atividades/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<Atividade>> Put(int id, Atividade atividade)
    {
        try
        {
            var ativadeToUpdate = await _atividadesRepository.GetAsync(id);

            if (ativadeToUpdate is null)
                return NotFound("Atividade não encontrada.");

            await _atividadesRepository.UpdateAsync(id, atividade);
            return Ok(atividade);
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Houve um erro ao processar sua requisição. Erro: " + ex.Message);
        }
    }

    // atividades/{id}
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        try
        {
            var atividade = await _atividadesRepository.GetAsync(id);
            if (atividade is null)
                return NotFound("Atividade não encontrada");
            
            await _atividadesRepository.DeleteAsync(id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Houve um erro ao processar sua requisição. Erro: " + ex.Message);
        }
    }
}