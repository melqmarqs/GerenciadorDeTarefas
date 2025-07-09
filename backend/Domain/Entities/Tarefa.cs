using Domain.Enums;

namespace Domain.Entities
{
    public class Tarefa
    {
        public int Id { get; set; }
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public Prioridade Prioridade { get; private set; }
        public Status Status { get; private set; }
        public DateOnly DataDeCriacao { get; private set; }

        public Tarefa(
            string titulo,
            string descricao,
            Prioridade prioridade,
            Status status,
            DateOnly dataDeCriacao)
        {
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
            DataDeCriacao = dataDeCriacao;
        }

        public Tarefa(
            string titulo,
            string descricao,
            Prioridade prioridade,
            Status status)
        {
            Titulo = titulo;
            Descricao = descricao;
            Prioridade = prioridade;
            Status = status;
        }
    }
}
