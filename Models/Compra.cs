using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ViagemBella.Models{

    public class Compra
    {

    [Key]
    [Required]
    public int IdCompra {get; set;}

    [Required]
    public String data {get; set;}

    [Required]
    public int FK_IdCliente {get; set;}
    public Cliente Cliente {get; set;}

     [Required]
    public int FK_IdPacote {get; set;}
    public Pacote Pacote {get; set;}


    }

}