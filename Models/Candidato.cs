using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.OpenApi.Models;

namespace apresentacao.Models
{
    [Table("candidatos")]
  public class Candidato
  {
    [Key]
    [Column ("id")]
    public int Id { get;set; }

    [Column("nome", TypeName = "varchar")]
    [MaxLength(100)]
    [Required]
    public string Nome { get;set; }
     

    [Column("cpf", TypeName = "varchar")]
    [MaxLength(14)]
    [Required]
    public string Cpf { get;set; }

    [Column("dtnascimento", TypeName = "varchar")]
    [MaxLength(14)]
    [Required]
    public string Dtanascimento { get;set; }

    [Column ("estadocivil", TypeName = "varchar")]
    [Required]
    public string Estadocivil { get;set; }
    
    [Column("email")]
    [MaxLength(100)]
    [Required]
    public string Email { get; set; }

    [Column("cep", TypeName = "varchar")]
    [MaxLength(10)]
    [Required]    
    public string Cep { get;set; }

    [Column("logadouro", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]    
    public string Logadouro { get;set; }

    [Column("numero", TypeName = "varchar")]
    [MaxLength(10)]
    [Required]
    public string Numero { get; set; }

    [Column("bairro", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]
    public string Bairro { get; set; }

    [Column("cidade", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]
    public string Cidade { get;set; }

    
    [Column("estado", TypeName = "varchar")]
    [MaxLength(10)]
    [Required]
    public string Estado { get;set; }

    [Column("telcontato", TypeName = "varchar")]
    [Required]
    public string telcontato { get;set; }

    [Column("id_profissao")]
    [Required]
    [ForeignKey ("vaga_id")]
    [JsonPropertyName("id_profissao")]
    public int VagaId { get;set; }

    [JsonIgnore]
    public Vaga Vaga { get; set; }

    
  }

}