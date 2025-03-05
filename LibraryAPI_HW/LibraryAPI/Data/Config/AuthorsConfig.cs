using LibraryAPI.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryAPI.Data.Config;

public class AuthorsConfig : IEntityTypeConfiguration<Authors>
{
    public void Configure(EntityTypeBuilder<Authors> builder)
    {
        builder.ToTable("Authors");
        builder.HasKey(x => x.AuthorId);
        
        builder.Property(x => x.FullName)
            .HasMaxLength(50)
            .IsRequired();
            
        

    }
}