# 🕹️ Projeto Rolê

**Matéria:** Advanced Business Development with .NET  
**Prof:** Thiago Keller  
**Sprint 2 – Implementação da Camada Web (Web API)**  
**Integrantes:**  
- Adão Yuri Ferreira da Silva (RM 559223)  
- João Vitor Lopes Santana (RM 560781)

---

## 🎯 Objetivo do Projeto
O **Rolê** é uma plataforma colaborativa para criação e compartilhamento de eventos entre amigos.  
Permite que usuários cadastrem, busquem e gerenciem eventos com base em localização, data e preferências.

Nesta Sprint 2, o foco foi **implementar a camada Web (API REST)**, garantindo integração entre as camadas da Clean Architecture e a exposição dos endpoints via **Swagger UI**.

---

## 🧱 Arquitetura do Sistema

O projeto segue o padrão **Clean Architecture**, dividindo a aplicação em quatro camadas independentes:

- **Domain:** Entidades e regras de negócio (Usuario, Evento, Presenca).  
- **Application:** Serviços, interfaces e DTOs que isolam a lógica da API.  
- **Infrastructure:** Contexto do banco (EF Core InMemory) e repositórios concretos.  
- **API:** Controladores HTTP (UsuariosController e EventosController) que expõem os endpoints.

---

## ⚙️ Tecnologias Utilizadas

- .NET 8.0  
- ASP.NET Core Web API  
- Entity Framework Core (InMemory)  
- Swagger (Swashbuckle)  
- C# 12  
- Clean Architecture  

---

## 🚀 Como Executar o Projeto

1. **Clonar o repositório**
   ```bash
   git clone https://github.com/Yuri-t0/Role-App-dotnet.git
   cd Role-App-dotnet-Sprint2
Restaurar dependências

bash
Copy code
dotnet restore
Compilar

bash
Copy code
dotnet build Role.sln
Executar a API

bash
Copy code
dotnet run --project Role.API
Acessar o Swagger

bash
Copy code
http://localhost:5149/swagger
🔎 Endpoints Principais
👥 Usuários
Método	Endpoint	Descrição
GET	/api/Usuarios	Lista todos os usuários
GET	/api/Usuarios/{id}	Retorna um usuário específico
POST	/api/Usuarios	Cria um novo usuário
PUT	/api/Usuarios/{id}	Atualiza um usuário existente
DELETE	/api/Usuarios/{id}	Remove um usuário

Exemplo de JSON para criação:

json
Copy code
{
  "nome": "Yuri Ferreira",
  "email": "yuri@teste.com",
  "localizacao": "São Paulo"
}
🎉 Eventos
Método	Endpoint	Descrição
GET	/api/Eventos	Lista todos os eventos
GET	/api/Eventos/{id}	Retorna um evento específico
POST	/api/Eventos	Cria um novo evento
PUT	/api/Eventos/{id}	Atualiza um evento existente
DELETE	/api/Eventos/{id}	Remove um evento

Exemplo de JSON:

json
Copy code
{
  "nome": "Rolê no Ibirapuera",
  "data": "2025-12-10T18:00:00",
  "local": "Parque Ibirapuera",
  "latitude": -23.588,
  "longitude": -46.657,
  "criadorId": 1
}
🧠 Diferenciais da Sprint 2
Implementação completa dos Controllers com endpoints REST.

Persistência InMemory para testes rápidos.

Integração entre camadas via injeção de dependência (DI).

Documentação automática via Swagger.

Estrutura preparada para HATEOAS e rotas de busca.

✅ Status Atual
✔️ Projeto compila e executa com sucesso.
✔️ Endpoints testados via Swagger.
✔️ Estrutura pronta para próxima Sprint (implementação de buscas, paginação e HATEOAS).

📚 Referências
Documentação oficial .NET 8

Documentação Entity Framework Core

FIAP – Advanced Business Development with .NET