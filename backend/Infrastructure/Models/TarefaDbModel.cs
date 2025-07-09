using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Infrastructure.Models
{
    public class TarefaDbModel
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public Prioridade Prioridade { get; set; } = Prioridade.Media;
        public Status Status { get; set; } = Status.Em_Andamento;
        public DateOnly DataDeCriacao { get; set; }
        public bool IsDeleted { get; set; }
    }
}
