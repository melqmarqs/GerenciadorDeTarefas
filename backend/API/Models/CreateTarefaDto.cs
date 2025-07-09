using Domain.Enums;

namespace API.Models
{
    public record CreateTarefaDto(
        string Titulo,
        string Descricao,
        Prioridade Prioridade,
        Status Status,
        DateOnly DataDeCriacao
    );
}
