import { Prioridade } from "../enums/prioridade.enum";
import { Status } from "../enums/status.enum";

export type Tarefa = {
    id: number,
    titulo: string,
    descricao: string,
    prioridade: Prioridade,
    status: Status,
    dataDeCriacao: Date
}

export type TarefaDto = Omit<Tarefa, 'id' | 'dataDeCriacao'>