using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using apresentacao.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apresentacao.Models
{

  [Table("vagas")]
  public class Vaga
  {
    
    [Key]
    [Column("vaga_id")]
    public int Id { get;set; }

    [Column("cargo", TypeName = "varchar")]
    [MaxLength(50)]
    [Required]
    public string Cargo { get;set; }

  
    
  }

}
