using System;
using System.ComponentModel.DataAnnotations;

namespace ViagemBella.Models
{
    public class Pacote
    {

        [Key]
        [Required]
        public int IdPacote {get; set;}
        [Required]
        public String Destino {get; set;}
        [Required]
        public String Diarias {get; set;}
        [Required]
        public decimal valor {get; set;}


    }
}