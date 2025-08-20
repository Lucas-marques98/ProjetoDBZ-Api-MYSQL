# Projeto Dragon Ball Z - API com ASP.NET Core e MySQL

## 📋 Descrição
Este projeto é uma API desenvolvida em ASP.NET Core que gerencia personagens e transformações do universo Dragon Ball Z. Utiliza Entity Framework Core com MySQL para persistência de dados.

## 🚀 Tecnologias Utilizadas
- ASP.NET Core 6.0
- Entity Framework Core
- MySQL
- C#
- Razor Pages
- MVC Pattern

## ⚙️ Pré-requisitos
- .NET 6.0 SDK
- MySQL Server
- Visual Studio Code ou Visual Studio 2022
- Git

## 🔧 Instalação

1. Clone o repositório
```bash
git clone https://github.com/Lucas-marques98/ProjetoDBZ.git
```

2. Configure a string de conexão
No arquivo `appsettings.json`, ajuste a string de conexão:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=DragonBallZ;User=seu_usuario;Password=sua_senha;"
  }
}
```

3. Execute as migrações do banco de dados
```bash
dotnet ef database update
```

4. Execute o projeto
```bash
dotnet run
```

## 🏃‍♂️ Como Usar

### Endpoints da API

#### Personagens
- GET `/api/personagens` - Lista todos os personagens
- GET `/api/personagens/{id}` - Obtém um personagem específico
- POST `/api/personagens` - Cria um novo personagem
- PUT `/api/personagens/{id}` - Atualiza um personagem
- DELETE `/api/personagens/{id}` - Remove um personagem

#### Transformações
- GET `/api/transformacoes` - Lista todas as transformações
- GET `/api/transformacoes/{id}` - Obtém uma transformação específica
- POST `/api/transformacoes` - Cria uma nova transformação
- PUT `/api/transformacoes/{id}` - Atualiza uma transformação
- DELETE `/api/transformacoes/{id}` - Remove uma transformação

## 📦 Estrutura do Projeto

```
ProjetoDBZ/
├── Controllers/      # Controladores da API
├── Models/          # Classes de modelo
├── Data/            # Contexto do banco de dados
├── Views/           # Views Razor
└── Program.cs       # Configuração da aplicação
```

## 📝 Modelos de Dados

### Personagem
```csharp
public class Personagem
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int Nivel { get; set; }
    public string Raca { get; set; }
    public string TecnicaEspecial { get; set; }
    public DateTime DataCriacao { get; set; }
    public List<Transformacao> Transformacoes { get; set; }
}
```

### Transformação
```csharp
public class Transformacao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public int MultiplicadorPoder { get; set; }
    public string Descricao { get; set; }
    public int PersonagemId { get; set; }
    public Personagem Personagem { get; set; }
}
```

## 🔐 Segurança
- HTTPS habilitado por padrão
- HSTS configurado para ambiente de produção
- Validação de modelo automática

## 🤝 Contribuindo
1. Faça um fork do projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request

## 📄 Licença
Este projeto está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

## ✨ Dados Iniciais
O projeto inclui dados iniciais (seed) com os personagens Goku e Vegeta, incluindo suas transformações mais icônicas.

## 🐛 Problemas Conhecidos
Se encontrar algum problema, por favor, abra uma issue no repositório do projeto.

## 📫 Contato
Seu Nome - [seu-email@exemplo.com]

Link do Projeto: [https://github.com/Lucas-marques98/ProjetoDBZ](https://github.com/Lucas-marques98/ProjetoDBZ)

---
Feito com ❤️ Por: Lucas Marques
