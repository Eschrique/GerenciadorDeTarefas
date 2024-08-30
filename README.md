Gerenciador de Tarefas
Este é um projeto de Gerenciador de Tarefas desenvolvido em .NET 8, seguindo os princípios da Clean Architecture. O objetivo do projeto é fornecer uma API para gerenciamento de tarefas e usuários, com suporte a operações CRUD (Create, Read, Update, Delete).

Estrutura do Projeto
O projeto é organizado nas seguintes camadas:

GerenciadorDeTarefas.Api: Camada de apresentação, responsável por expor os endpoints da API.
GerenciadorDeTarefas.Application: Contém as regras de negócio e os casos de uso do sistema.
GerenciadorDeTarefas.Domain: Define as entidades principais e interfaces do domínio.
GerenciadorDeTarefas.Infrastructure: Implementa os repositórios e a comunicação com o banco de dados.
GerenciadorDeTarefas.Tests: Conjunto de testes automatizados para garantir a qualidade do código.
Tecnologias Utilizadas
.NET 8
Entity Framework Core: Para comunicação com o banco de dados.
Swagger: Para documentação automática da API.
xUnit: Para testes automatizados.
Endpoints da API
Usuários
GET /api/Usuarios: Retorna a lista de todos os usuários.
GET /api/Usuarios/{id}: Retorna os detalhes de um usuário específico.
POST /api/Usuarios: Cria um novo usuário.
PUT /api/Usuarios/{id}: Atualiza um usuário existente.
DELETE /api/Usuarios/{id}: Exclui um usuário.
Tarefas
GET /api/Tarefas: Retorna a lista de todas as tarefas.
GET /api/Tarefas/{id}: Retorna os detalhes de uma tarefa específica.
POST /api/Tarefas: Cria uma nova tarefa.
PUT /api/Tarefas/{id}: Atualiza uma tarefa existente.
DELETE /api/Tarefas/{id}: Exclui uma tarefa.
Como Executar o Projeto
Pré-requisitos
.NET 8 SDK
PostgreSQL (utilizado para persistência dos dados)
Executando Localmente
Clone o repositório:
bash
Copiar código
git clone https://github.com/seu-usuario/gerenciador-de-tarefas.git
Navegue até o diretório do projeto:
bash
Copiar código
cd GerenciadorDeTarefas/GerenciadorDeTarefas.Api
Execute o projeto:
bash
Copiar código
dotnet run
Acessando a API
A API estará disponível em http://localhost:5000. A documentação Swagger pode ser acessada em http://localhost:5000/swagger.

Executando os Testes
Para executar os testes automatizados, utilize o seguinte comando na raiz do projeto:

bash
Copiar código
dotnet test
Configuração do Banco de Dados
O projeto utiliza PostgreSQL como banco de dados. Certifique-se de que o banco de dados esteja configurado corretamente no arquivo appsettings.json em GerenciadorDeTarefas.Api.

Contribuição
Sinta-se à vontade para abrir issues e pull requests. Contribuições são bem-vindas!

Licença
Este projeto é licenciado sob a MIT License.
