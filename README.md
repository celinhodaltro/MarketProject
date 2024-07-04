# Blazor Hybrid App Base

Este repositório contém a base de um projeto Blazor Hybrid, que permite o desenvolvimento de um único código para aplicativos multiplataforma. A solução está organizada em três projetos principais:

- **Projeto Web:** Implementação da aplicação web usando Blazor.
- **Projeto Blazor Hybrid:** Implementação do aplicativo multiplataforma usando Blazor Hybrid com .NET MAUI.
- **Projeto de Páginas Compartilhadas:** Conjunto de páginas e componentes compartilhados entre o projeto Web e o projeto Blazor Hybrid.

## Estrutura do Projeto

```plaintext
BlazorHybridAppBase/
│
├── BlazorApp.Sln                     # Solution file
│
├── System.AppWeb/                    # Projeto Web Blazor
│   ├── wwwroot/                      # Arquivos estáticos
│   ├── Program.cs                    # Arquivo de inicialização do projeto web
│   └── BlazorHybridApp.Web.csproj    # Arquivo de projeto do Web
│
├── System.Base                       # Projeto Blazor Hybrid com .NET MAUI
│   ├── Platforms/                    # Código específico das plataformas
│   ├── Program.cs                    # Arquivo de inicialização do projeto híbrido
│   └── BlazorHybridApp.Hybrid.csproj # Arquivo de projeto do Hybrid
│
└── System.Pages/                     # Projeto de Páginas Compartilhadas
    ├── Pages/                        # Páginas compartilhadas entre Web e Hybrid
    └── System.Pages.csproj           # Arquivo de projeto do Shared
