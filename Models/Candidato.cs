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

    [Column("nome", TypeName = "nvarchar")]
    [MaxLength(100)]
    [Required]
    public string Nome { get;set; }
     

    [Column("cpf", TypeName = "varchar")]
    [MaxLength(14)]
    [Required]
    public string Cpf { get;set; }

    [Column("dtnascimento", TypeName = "nvarchar")]
    [MaxLength(10)]
    [Required]
    public string Dtanascimento { get;set; }

      
    [Column("email" , TypeName = "nvarchar")]
    [MaxLength(50)]
    [Required]
    public string Email { get; set; }

    [Column("cep", TypeName = "nvarchar")]
    [MaxLength(9)]
    [Required]    
    public string Cep { get;set; }

    [Column("logradouro", TypeName = "nvarchar")]
    [MaxLength(100)]
    [Required]    
    public string Logadouro { get;set; }

    [Column("numero", TypeName = "nvarchar")]
    [MaxLength(10)]
    [Required]
    public string Numero { get; set; }

    [Column("bairro", TypeName = "nvarchar")]
    [MaxLength(150)]
    [Required]
    public string Bairro { get; set; }

    [Column("cidade", TypeName = "nvarchar")]
    [MaxLength(50)]
    [Required]
    public string Cidade { get;set; }

    
    [Column("estado", TypeName = "nvarchar")]
    [MaxLength(10)]
    [Required]
    public string Estado { get;set; }

    [Column("telefone", TypeName = "nvarchar")]
    [MaxLength(15)]
    [Required]
    public string Telefone { get;set; }

    [Column("id_profissao")]
    [ForeignKey ("vaga_id")]
    [Required]
    public int VagaId { get;set; }

    [JsonIgnore]
    public Vaga Vaga { get; set; }

    
  }

}