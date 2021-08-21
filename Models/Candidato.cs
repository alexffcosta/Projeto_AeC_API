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
    public int Nome { get;set; }
     

    [Column("cpf", TypeName = "int")]
    [MaxLength(8)]
    public int Cpf { get;set; }

    [Column("dtnascimento", TypeName = "int")]
    [MaxLength(8)]
    [Required]
    public int Dtanascimento { get;set; }

    [Column ("estadocivil", TypeName = "varchar")]
    [Required]
    public int Estadocivil { get;set; }
    
    [Column("email")]
    [MaxLength(100)]
    [Required]
    public int Email { get; set; }

    [Column("cep", TypeName = "varchar")]
    [MaxLength(10)]
    [Required]
    public int Cep { get;set; }

    [Column("logadouro", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]    
    public string Logadouro { get;set; }

    [Column("numero")]
    [Required]
    [MaxLength(10)]
    public int Numero { get; set; }

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

    [Column("telcontato", TypeName = "int")]
    [MaxLength(12)]
    [Required]
    public int telcontato { get;set; }

    [Column("nomecontato", TypeName = "varchar")]
    [MaxLength(20)]
    [Required]
    public int Nomecontato { get;set; }

    [Column("id_profissao")]
    [Required]
    [ForeignKey ("vaga_id")]
    [JsonPropertyName("id_profissao")]
    public int ProfissaoId { get;set; }

    [JsonIgnore]
    public Vaga Vaga { get; set; }

    
  }

}