# API Simples de CRUD de funcionários em C#

Este projeto é uma implementação básica de uma API CRUD (Create, Read, Update, Delete) usando C#. O objetivo é fornecer um exemplo simples e claro para aprender os fundamentos da programação em C# e desenvolvimento de APIs.

## Funcionalidades

- **Create**: Adicionar um novo funcionário ao banco de dados.
- **Read**: Recuperar funcionários do banco de dados.
  - Obter todos os funcionários.
  - Obter um único funcionário pelo seu ID.
- **Update**: Modificar um funcionário existente.
- **Delete**: Remover um funcionário do banco de dados.

## Tecnologias Utilizadas

- **C#**
- **ASP.NET Core**
- **Entity Framework Core** (EF Core) para gerenciamento do banco de dados
- **SQLite** para um banco de dados leve baseado em arquivo (pode ser substituído por outro banco de dados, se necessário)

## Pré-requisitos

- SDK do .NET instalado ([Baixar aqui](https://dotnet.microsoft.com/download))
- Um editor de código, como o [Visual Studio](https://visualstudio.microsoft.com/) ou o [Visual Studio Code](https://code.visualstudio.com/).

## Começando

### Clonar o Repositório
```bash
git clone https://github.com/Rezende-Fabio/employee-management-web.git
cd employee-management-api
```

### Configuração e Execução

1. **Restaurar Dependências**
   ```bash
   dotnet restore
   ```

2. **Aplicar Migrações**
   Certifique-se de que o banco de dados foi criado e as migrações foram aplicadas:
   ```bash
   dotnet ef database update
   ```

3. **Executar a Aplicação**
   ```bash
   dotnet run
   ```

4. **Acessar a API**
   A API estará disponível em `http://localhost:5052`. Use ferramentas como o [Postman](https://www.postman.com/), o [cURL](https://curl.se/), ou o projeto [front-end](https://github.com/Rezende-Fabio/employee-management-web) para testar os endpoints.

## Endpoints

Swagger `http://localhost:5052/swagger/index.html`

| Método | Endpoint             | Descrição               |
|--------|----------------------|-------------------------|
| GET    | `/v1/employees`         | Obter todos os funcionários   |
| GET    | `/v1/employees/{id}`    | Obter um funcionário específico |
| POST   | `/v1/employees`         | Criar um novo funcionário     |
| PUT    | `/v1/employees/{id}`    | Atualizar um funcionário existente |
| DELETE | `/v1/employees/{id}`    | Excluir um funcionário        |


## Objetivos de Aprendizado

- Entender a estrutura de um projeto de API ASP.NET Core.
- Aprender a configurar e usar o Entity Framework Core.
- Praticar a criação e o consumo de APIs RESTful.