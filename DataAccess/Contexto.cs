using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Contexto :DbContext
    {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public Contexto() 
        { }
        public Contexto(DbContextOptions<Contexto> options) : base(options)
        { }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseSqlServer("Server=DESKTOP-BI33SL6;Database=Registro;Trusted_Connection=True;Trust Server Certificate=true;");
        }
    }
}
