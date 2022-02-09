using NotificacaoService.Domain.Templates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace NotificacaoService.Infrastructure.Mapeamentos
{
    public class TemplateBuilder : IEntityTypeConfiguration<Template>
    {
        public void Configure(EntityTypeBuilder<Template> builder)
        {
            builder.Property(a => a.Html).IsRequired();
            builder.Property(a => a.Linguagem).IsRequired();
            builder.Property(a => a.Nome).IsRequired();
            builder.Property(a => a.RemetenteNome).IsRequired();
            builder.Property(a => a.RemetenteEmail).IsRequired();
            builder.Property(a => a.Assunto).IsRequired();
            builder.Property(a => a.Conteudo).IsRequired();
            builder.Property(a => a.NomeProjeto).IsRequired();
        }
    }
}
