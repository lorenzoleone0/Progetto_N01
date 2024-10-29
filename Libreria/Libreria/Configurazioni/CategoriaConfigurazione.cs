using Libreria.Entita;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Libreria.Configurazioni
{
    public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.ToTable("Categoria");
            builder.HasKey(c => c.Id_categoria); 

            builder.Property(c => c.Nome)
                .HasColumnName("Nome")
                .IsRequired(); 
        }
    }

}
