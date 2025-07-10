import { Prioridade } from "./app/enums/prioridade.enum";
import { Status } from "./app/enums/status.enum";

export const helper = {
    useStatus(status: Status) {
        switch (status) {
            case Status.Pendente:
                return 'Pendente';
            case Status.Em_Andamento:
                return 'Em Andamento';
            case Status.Concluida:
                return 'Concluída';
        }
    },
    usePrioridade(prioridade: Prioridade) {
        switch (prioridade) {
            case Prioridade.Baixa:
                return 'Baixa';
            case Prioridade.Media:
                return 'Média';
            case Prioridade.Alta:
                return 'Alta';
        }
    }
}