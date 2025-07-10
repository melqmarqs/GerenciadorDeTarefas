# GerenciadorDeTarefas

Para rodar o backend:
Ao abrir a solution GerenciadorDeTarefas.sln, é nercessario alterar a ConnectionString, para persistir os dados.
Após a ConnectionString, sera necessario criar o banco de dados GerenciadorDeTarefas (se o seu banco tiver o mesmo nome do meu). Voce pode fazer isso pelo seu SGBD ou usando o EF.
Para usar o EF, voce vai precisar abrir o terminal do Visual Studio, navegar ate a pasta API e entao, a partir dela, rodar o comando: dotnet ef migrations add Initial --project ..\Infrastructure\ --startup-project .
Agora o backend esta pronto e funcionando. Voce pode verificar fazer rodando o projeto e na rota https://localhost:7048/swagger/index.html


Para rodar o frontend:
Ao abrir o projeto frontend, voce pode rodar o comando npm i no terminal, para garantir que todas as depencias serao instaladas e depois voce pode inicializar a aplicacao (comando ng serve ou npm start)
A aplicação deve inicializar na porta 4200 (http://localhost:4200/)
