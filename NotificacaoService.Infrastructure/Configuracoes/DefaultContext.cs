using NotificacaoService.Domain.Templates;
using NotificacaoService.Infrastructure.Mapeamentos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificacaoService.Infrastructure.Configuracoes
{
    internal class DefaultContext : DbContext
    {
        private readonly string DbOptions;

        public DbSet<Template> Templates;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new TemplateBuilder());
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(
        //        @"Server=(localdb)\mssqllocaldb;Database=Blogging;Trusted_Connection=True");
        //}
    }
}
