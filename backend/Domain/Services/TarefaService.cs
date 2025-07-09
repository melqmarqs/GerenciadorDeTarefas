using Domain.Entities;
using Domain.Enums;
using Domain.Repositories;
using System.Collections;

namespace Domain.Services
{
    public class TarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        public async Task<Tarefa> CreateTarefaAsync(
            string titulo,
            string descricao,
            Prioridade prioridade,
            Status status,
            DateOnly data)
        {
            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentException("Titulo é um campo obrigatótio.");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentException("Descrição é um campo obrigatótio.");

            var tarefa = new Tarefa(
                titulo,
                descricao,
                prioridade,
                status,
                data);

            var createdTarefa = await _tarefaRepository.CreateAsync(tarefa);
            return createdTarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetAllTarefasAsync()
        {
            var tarefas = await _tarefaRepository.GetAllAsync();
            return tarefas;
        }

        public async Task<Tarefa?> GetTarefaByIdAsync(int id) =>
            await _tarefaRepository.GetByIdAsync(id);

        public async Task<Tarefa?> UpdateTarefaAsync(Tarefa tarefa) =>
            await _tarefaRepository.UpdateAsync(tarefa);

        public async Task<bool> DeleteTarefaAsync(int id) =>
            await _tarefaRepository.SoftDeleteAsync(id);
    }
}
