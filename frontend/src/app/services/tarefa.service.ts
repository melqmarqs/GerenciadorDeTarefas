import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { environment } from "../../environments/environment";
import { Tarefa, TarefaDto } from "../models/tarefa.model";
import { Prioridade } from "../enums/prioridade.enum";
import { Status } from "../enums/status.enum";

@Injectable({
   providedIn: "root" 
})
export class TarefaService {
    private url = environment.api;
    private tarefasUrl = this.url + '/api/tarefas/';

    constructor(private httpClient: HttpClient) {}

    getTarefas() {
        return this.httpClient.get<Tarefa[]>(this.tarefasUrl);
    }

    getTarefa(id: number) {
        return this.httpClient.get<Tarefa>(this.tarefasUrl + id);
    }

    saveTarefa(titulo: string, descricao: string, prioridade: Prioridade, status: Status) {
        const tarefa: TarefaDto = {
            titulo,
            descricao,
            prioridade,
            status
        }
        return this.httpClient.post<void>(this.tarefasUrl, tarefa);
    }

    updateTarefa(id: number, titulo: string, descricao: string, prioridade: Prioridade, status: Status) {
        const tarefa: TarefaDto = {
            titulo,
            descricao,
            prioridade,
            status
        }
        return this.httpClient.put<void>(this.tarefasUrl + id, tarefa);
    }

    deletar(id: number) {
        return this.httpClient.delete<boolean>(this.tarefasUrl + id);
    }
}