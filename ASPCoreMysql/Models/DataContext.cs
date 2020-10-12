using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMysql.Models
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            var configurations = builder.Build();
            optionsBuilder.UseSqlServer(configurations["ConnectionStrings:DefaultConnection"]);
        }

        public DbSet<Usuario> Usuario { get; set;} 
    }
}
