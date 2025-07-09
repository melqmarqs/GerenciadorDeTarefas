using Domain.Entities;

namespace Domain.Repositories
{
    public interface ITarefaRepository
    {
        //Create
        Task<Tarefa> CreateAsync(Tarefa tarefa);

        //Read
        Task<IEnumerable<Tarefa>> GetAllAsync();
        Task<Tarefa?> GetByIdAsync(int id);

        //Update
        Task<Tarefa?> UpdateAsync(Tarefa tarefa);

        //Delete
        Task<bool> SoftDeleteAsync(int id);
    }
}
