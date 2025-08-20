// Define o namespace do projeto onde as classes estão localizadas
namespace ProjetoDBZ.Models;

// Classe que representa um personagem de Dragon Ball Z
public class Personagem
{
    // Identificador único do personagem (chave primária)
    public int Id { get; set; }
    
    // Nome do personagem, inicializado como string vazia
    public string Nome { get; set; } = string.Empty;
    
    // Nível de poder do personagem
    public int Nivel { get; set; }
    
    // Raça do personagem (ex: Saiyajin, Humano, etc), inicializado como string vazia
    public string Raca { get; set; } = string.Empty;
    
    // Técnica especial do personagem (ex: Kamehameha), inicializado como string vazia
    public string TecnicaEspecial { get; set; } = string.Empty;
    
    // Data de criação do registro, inicializada com a data/hora atual
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    
    // Relacionamento 1:N - Um personagem pode ter várias transformações
    // Lista inicializada como uma nova lista vazia
    public List<Transformacao> Transformacoes { get; set; } = new();
}

// Classe que representa uma transformação de um personagem
public class Transformacao
{
    // Identificador único da transformação (chave primária)
    public int Id { get; set; }
    
    // Nome da transformação (ex: Super Saiyajin), inicializado como string vazia
    public string Nome { get; set; } = string.Empty;
    
    // Multiplicador de poder da transformação
    public int MultiplicadorPoder { get; set; }
    
    // Descrição detalhada da transformação, inicializado como string vazia
    public string Descricao { get; set; } = string.Empty;
    
    // Chave estrangeira - ID do personagem ao qual esta transformação pertence
    public int PersonagemId { get; set; }
    
    // Propriedade de navegação - Referência ao personagem relacionado
    // Nullable (?) indica que pode ser nulo
    public Personagem? Personagem { get; set; }
}