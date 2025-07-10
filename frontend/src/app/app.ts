import { CommonModule } from '@angular/common';
import { Component, OnInit } from '@angular/core';
import { Tarefa } from './models/tarefa.model';
import { TarefaService } from './services/tarefa.service';
import { helper } from '../helper';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { Prioridade } from './enums/prioridade.enum';
import { Status } from './enums/status.enum';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.scss'
})
export class App implements OnInit {
  protected tarefas$ = new Observable<Tarefa[]>();
  protected tarefa$ = new Observable<Tarefa>();
  protected isCollapsed = false;
  protected helper = helper;
  protected prioridadeEnum = Object.keys(Prioridade).filter(k => !isNaN(Number(k)));
  protected statusEnum = Object.keys(Status).filter(k => !isNaN(Number(k)));

  titulo = '';
  descricao = '';
  prioridade = '';
  status = '';
  id = 0;

  constructor(private tarefaService: TarefaService) {}

  ngOnInit(): void {
    this.getTarefas();
  }

  toggleCollapse() {
    if (this.isCollapsed)
      this.limparVariables();

    this.isCollapsed = !this.isCollapsed;
  }

  getTarefas() {
    this.tarefas$ = this.tarefaService.getTarefas();
  }

  getTarefa(id: number) {
    this.tarefa$ = this.tarefaService.getTarefa(id);
  }

  salvarTarefa() {
    if (!this.titulo) {
      alert('Titulo é obrigatório');
      return;
    }
      
    if (!this.descricao) {
      alert('Descricao é obrigatório');
      return;
    }

    if (this.id === 0) {
      this.tarefaService.saveTarefa(this.titulo, this.descricao, +this.prioridade, +this.status)
        .subscribe(_ => {
          this.getTarefas();
          this.toggleCollapse();
        });
    }
    else {
      this.tarefaService.updateTarefa(this.id, this.titulo, this.descricao, +this.prioridade, +this.status)
        .subscribe(_ => {
          this.getTarefas();
          this.toggleCollapse();
        });
    }
  }

  editar(id: number) {
    this.tarefaService.getTarefa(id)
      .subscribe(tarefa => {
        this.id = tarefa.id;
        this.titulo = tarefa.titulo;
        this.descricao = tarefa.descricao;
        this.prioridade = String(tarefa.prioridade);
        this.status = String(tarefa.status);

        this.toggleCollapse();
    });
  }

  deletar(id: number) {
    this.tarefaService.deletar(id)
      .subscribe(_ => this.getTarefas());
  }

  limparVariables() {
    this.id = 0;
    this.titulo = '';
    this.descricao = '';
    this.prioridade = '';
    this.status = '';
  }
}
