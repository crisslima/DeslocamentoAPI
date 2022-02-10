using DeslocamentoApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DeslocamentoApp.Data.Mapping
{
    public class CondutorConfiguration : IEntityTypeConfiguration<Condutor>
    {
        public void Configure(EntityTypeBuilder<Condutor> builder)
        {
            builder.HasKey(p => p.Id);

            builder.ToTable("Condutor");

            builder.Property(p => p.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(400);

            builder.Property(p => p.Email)
                .HasColumnName("Email")
                .HasMaxLength(100);
        }
    }
}
