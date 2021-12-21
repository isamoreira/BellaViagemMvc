using System;
using Microsoft.EntityFrameworkCore;
using ViagemBella.Models;

namespace ViagemBella.Models 
{
    public class BancoDeDadosContext : DbContext 
    {
        public BancoDeDadosContext(DbContextOptions<BancoDeDadosContext> options) : base(options) {
            if (options is null)
            {
                throw new ArgumentNullException(nameof(options));
            }
        }   

        public DbSet<Cliente> Clientes {get; set;}
        public DbSet<Pacote> Pacotes {get; set;}
        public DbSet<Compra> Compras {get; set;}
    }
}