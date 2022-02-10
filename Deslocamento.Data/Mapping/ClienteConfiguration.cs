using DeslocamentoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoApp.Data.Mapping
{
    public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Cliente");

            builder.Property(p => p.Cpf)
                .HasColumnName("Cpf")
                .HasMaxLength(11); 

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(400);
        }
    }
}
