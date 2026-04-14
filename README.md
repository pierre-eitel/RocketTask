# RocketTask API

API REST para gerenciamento de tarefas desenvolvida em C# com .NET, seguindo arquitetura em camadas e boas práticas de desenvolvimento.

## Funcionalidades

Criar uma nova tarefa  
Listar todas as tarefas  
Buscar tarefa por ID  
Atualizar tarefa  
Remover tarefa  
Validação de dados de entrada  
Uso correto de códigos de status HTTP  
Documentação com Swagger  

## Arquitetura

O projeto está estruturado utilizando arquitetura em camadas:

Controllers: responsáveis por lidar com as requisições HTTP (camada de comunicação)  
Services: responsáveis pelas regras de negócio e validações  

## Modelo de Tarefa

Id: GUID - Identificador único  
Name: string - Obrigatório (máx. 100 caracteres)  
Description: string - Opcional (máx. 500 caracteres)  
Priority: enum - High, Medium, Low  
DueDate: DateTime - Deve ser uma data futura  
Status: enum - Pending, InProgress, Completed  

## Endpoints

POST /api/tasks - Criar tarefa  
GET /api/tasks - Listar tarefas  
GET /api/tasks/{id} - Buscar tarefa por ID  
PUT /api/tasks/{id} - Atualizar tarefa  
DELETE /api/tasks/{id} - Remover tarefa  

## Códigos de Status

200 OK - Sucesso  
201 Created - Tarefa criada  
204 No Content - Tarefa removida  
400 Bad Request - Erro de validação  
404 Not Found - Tarefa não encontrada  

## Tecnologias

.NET  
C#  
ASP.NET Core  
Swagger  

## Como executar o projeto

Clone o repositório:

git clone [https://github.com/seu-usuario/seu-repositorio.git](https://github.com/pierre-eitel/RocketTask.git)

Acesse a pasta do projeto:

cd seu-repositorio

Execute a aplicação:

dotnet run

## Swagger

Após executar o projeto, acesse:

https://localhost:{porta}/swagger

## Sobre o projeto

Este projeto foi desenvolvido como parte de um desafio prático com o objetivo de reforçar conceitos de arquitetura limpa, construção de APIs REST, validação de dados e separação de responsabilidades.
