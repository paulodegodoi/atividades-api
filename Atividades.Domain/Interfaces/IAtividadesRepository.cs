using Atividades.Domain.Models;

namespace Atividades.Domain.Interfaces;

public interface IAtividadesRepository
{
    Task<List<Atividade>> GetAllAsync();
    Task<Atividade?> GetAsync(int id);
    Task<Atividade> AddAsync(Atividade atividade);
    Task<Atividade> UpdateAsync(int id, Atividade atividade);
    Task DeleteAsync(int id);
}