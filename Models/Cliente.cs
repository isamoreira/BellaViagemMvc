using System;
using System.ComponentModel.DataAnnotations;

namespace ViagemBella.Models
{
    public class Cliente
    {

        [Key]
        [Required]
        public int IdCliente {get; set;}
        [Required]
        public String Nome {get; set;}
        [Required]
        public String Cpf {get; set;}
        [Required]
        public String Email {get; set;}
       


    }
}