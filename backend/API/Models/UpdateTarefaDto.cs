using Domain.Enums;

namespace API.Models
{
    public record UpdateTarefaDto(
        string Titulo,
        string Descricao,
        Prioridade Prioridade,
        Status Status
    );
}
