# Challenger.API - Vision Integration

Este projeto é uma API em .NET 8 para integrar modelos de visão
computacional utilizando um endpoint externo.

## Estrutura do Projeto

    Challenger.API/
    │
    ├── Controllers/
    │   └── VisionController.cs   # Controller para chamar o modelo de visão
    │
    ├── Extensions/
    │   └── DependencyInjection.cs # Configuração de serviços e HttpClient
    │
    ├── Program.cs                 # Inicialização da aplicação
    ├── appsettings.json           # Configurações da aplicação
    ├── Challenger.API.csproj      # Projeto principal

## Pré-requisitos

-   [.NET 6 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
-   Visual Studio 2022 ou VS Code
-   Git

## Como rodar o projeto

1.  Clone o repositório e acesse a pasta do projeto:

    ``` bash
    git clone https://github.com/seu-repositorio/Challenger-API.git
    cd Challenger-API
    ```

2.  Restaure as dependências:

    ``` bash
    dotnet restore
    ```

3.  Compile o projeto:

    ``` bash
    dotnet build
    ```

4.  Rode a aplicação:

    ``` bash
    dotnet run --project Challenger.API
    ```

5.  Acesse o Swagger para testar os endpoints:

    Normalmente em:

    -   `https://localhost:5001/swagger`
    -   ou `http://localhost:5000/swagger`

    > Caso não abra, verifique no console o endereço que a aplicação
    > gerou ao iniciar.

## Testando com imagens artificiais

Caso queira usar imagens artificiais para testes, consulte o
repositório:

👉 [IOT-Mottu](https://github.com/Challenger-MOTTU/IOT-Mottu.git)

Este repositório possui gerador de placas sintéticas que podem ser
usadas como input para a API.

------------------------------------------------------------------------

### Autor

Equipe Challenge - Projeto MOTTU: 
Gabriel Gomes Mancera
Juliana de Andrade Sousa 
Victor Hugo Carvalho Pereira
