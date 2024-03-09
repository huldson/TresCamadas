using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Startup
    {
        public IConfiguration configuracao { get; set; }

        public Startup(IConfiguration configuracao)
        {
            this.configuracao = configuracao;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IRepository, Repository>();
            services.AddDbContext<Contexto>(options => options.UseSqlServer("Server=DESKTOP-BI33SL6;Database=Registro;Trusted_Connection=True;Trust Server Certificate=true;")
                );
        }
    }
}
