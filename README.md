# desafioMarlin
O projeto necessita de uma IDE que seja capaz de rodar projetos C#(.net), o mesmo foi desenvolvido utilizando o visual studio 2022.

Para abrir o projeto, basta abrir o arquivo DesafioMarlin.sln

Em seguida, após o visual studio ser aberto devemos realizar o build da aplicação.

Após, devemos abrir o Gerenciador de pacotes Nuget, e executar o comando: update-database

Esse comando irá criar o banco e as tabelas necessárias para a execução do projeto, o mesmo está configurado para utilização do banco express do SQL Server.

Caso queiram configuram outro banco, basta acessar o arquivo "appsettings.json" dentro da tag "ConnectionStrings".

Caso queriam gerar o script para executar manualmente, deve ser executar o comando "Script-Migration" dentro do gerenciador de pacotes nuget.

Para abrir o projeto basta executar o projeto "DesafioMarlin"
