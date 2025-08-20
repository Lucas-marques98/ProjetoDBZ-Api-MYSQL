// Importação das bibliotecas necessárias
using Microsoft.EntityFrameworkCore;
using ProjetoDBZ.Data;
using ProjetoDBZ.Models;

// Cria uma nova instância do builder da aplicação web
var builder = WebApplication.CreateBuilder(args);

// Adiciona serviços ao container de injeção de dependência
// Configura o suporte a Controllers e Views MVC
builder.Services.AddControllersWithViews();
// Adiciona suporte a páginas Razor
builder.Services.AddRazorPages();

// Obtém a string de conexão do arquivo de configuração
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Configura o Entity Framework com MySQL
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString) // Detecta automaticamente a versão do servidor
    ));

// Constrói a aplicação
var app = builder.Build();

// Configura o pipeline de requisições HTTP
if (!app.Environment.IsDevelopment())
{
    // Em produção, redireciona erros para /Error
    app.UseExceptionHandler("/Error");
    // Habilita HSTS (HTTP Strict Transport Security)
    app.UseHsts();
}

// Middleware para redirecionar HTTP para HTTPS
app.UseHttpsRedirection();
// Middleware para servir arquivos estáticos
app.UseStaticFiles();
// Middleware para roteamento
app.UseRouting();
// Middleware para autorização
app.UseAuthorization();

// Configura a rota padrão para MVC
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
// Configura rotas para páginas Razor
app.MapRazorPages();

// Cria um escopo para acessar os serviços
using (var scope = app.Services.CreateScope())
{
    // Obtém o contexto do banco de dados
    var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    // Garante que o banco de dados existe
    context.Database.EnsureCreated();
    
    // Verifica se a tabela de personagens está vazia
    if (!context.Personagens.Any())
    {
        // Adiciona dados iniciais (seed data)
        context.Personagens.AddRange(
            // Cria o personagem Goku com suas transformações
            new Personagem
            {
                Nome = "Goku",
                Nivel = 9000,
                Raca = "Saiyajin",
                TecnicaEspecial = "Kamehameha",
                Transformacoes = new List<Transformacao>
                {
                    new Transformacao { Nome = "Super Saiyajin", MultiplicadorPoder = 50, Descricao = "Primeira transformação lendária" },
                    new Transformacao { Nome = "Super Saiyajin 3", MultiplicadorPoder = 400, Descricao = "Transformação de puro poder" }
                }
            },
            // Cria o personagem Vegeta com sua transformação
            new Personagem
            {
                Nome = "Vegeta",
                Nivel = 8500,
                Raca = "Saiyajin",
                TecnicaEspecial = "Final Flash",
                Transformacoes = new List<Transformacao>
                {
                    new Transformacao { Nome = "Super Saiyajin Blue", MultiplicadorPoder = 1000, Descricao = "Transformação divina" }
                }
            }
        );
        // Salva as alterações no banco de dados
        context.SaveChanges();
    }
}

// Inicia a aplicação
app.Run();