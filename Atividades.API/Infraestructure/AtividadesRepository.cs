using Atividades.API.Data;
using Atividades.Domain.Interfaces;
using Atividades.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Atividades.API.Infraestructure;

public class AtividadesRepository : IAtividadesRepository
{
    private readonly AppDbContext _context;

    public AtividadesRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<Atividade>> GetAllAsync()
    {
        return await _context.Atividades.ToListAsync();
    }

    public async Task<Atividade?> GetAsync(int id)
    {
        return await _context.Atividades.FirstOrDefaultAsync(x => x.AtividadeId == id);
    }

    public async Task<Atividade> AddAsync(Atividade atividade)
    {
        await _context.Atividades.AddAsync(atividade);
        await _context.SaveChangesAsync();

        return atividade;
    }

    public async Task<Atividade> UpdateAsync(int id, Atividade atividade)
    {
        if (id != atividade.AtividadeId)
            throw new ArgumentException("Id informado não corresponde ao da atividade");
        
        var atividadeToUpdate = await _context.Atividades.AsNoTracking().FirstOrDefaultAsync(x => x.AtividadeId == id);
        if (atividadeToUpdate is null)
            throw new NullReferenceException("Atividade não encontrada");

        _context.Entry(atividadeToUpdate).State = EntityState.Detached;

        _context.Entry(atividade).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return atividade;
    }

    public async Task DeleteAsync(int id)
    {
        var atividade = await _context.Atividades.FirstOrDefaultAsync(x => x.AtividadeId == id);
        if (atividade is null)
            throw new NullReferenceException("Atividade não encontrada");

        _context.Atividades.Remove(atividade);
        await _context.SaveChangesAsync();
    }
}