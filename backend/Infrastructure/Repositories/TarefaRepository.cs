using Domain.Entities;
using Domain.Repositories;
using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly GerenciadorDeTarefasDbContext _context;

        public TarefaRepository(GerenciadorDeTarefasDbContext context)
        {
            _context = context;
        }

        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            var dbTarefa = new TarefaDbModel
            {
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                Prioridade = tarefa.Prioridade,
                Status = tarefa.Status,
                DataDeCriacao = tarefa.DataDeCriacao,
            };

            _context.Tarefas.Add(dbTarefa);
            await _context.SaveChangesAsync();

            return MapToTarefa(dbTarefa);
        }

        public async Task<IEnumerable<Tarefa>> GetAllAsync()
        {
            var dbTarefas = await _context.Tarefas
                .Where(t => t.IsDeleted == false)
                .OrderBy(t => t.Id)
                .ToListAsync();

            return dbTarefas.Select(MapToTarefa);
        }

        public async Task<Tarefa?> GetByIdAsync(int id)
        {
            var dbTarefa = await _context.Tarefas
                .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);
                
            return dbTarefa != null ? MapToTarefa(dbTarefa) : null;
        }

        public async Task<bool> SoftDeleteAsync(int id)
        {
            var dbTarefa = await _context.Tarefas
                .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == id);

            if (dbTarefa == null)
                return false;

            dbTarefa.IsDeleted = true;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Tarefa?> UpdateAsync(Tarefa tarefa)
        {
            var dbTarefa = await _context.Tarefas
                .FirstOrDefaultAsync(t => t.IsDeleted == false && t.Id == tarefa.Id);

            if (dbTarefa == null)
                return null;

            dbTarefa.Titulo = tarefa.Titulo;
            dbTarefa.Descricao = tarefa.Descricao;
            dbTarefa.Prioridade = tarefa.Prioridade;
            dbTarefa.Status = tarefa.Status;

            await _context.SaveChangesAsync();
            return MapToTarefa(dbTarefa);
        }

        private Tarefa MapToTarefa(TarefaDbModel db)
        {
            return new Tarefa(
                db.Titulo,
                db.Descricao,
                db.Prioridade,
                db.Status,
                db.DataDeCriacao)
                { Id = db.Id };
        }
    }
}
