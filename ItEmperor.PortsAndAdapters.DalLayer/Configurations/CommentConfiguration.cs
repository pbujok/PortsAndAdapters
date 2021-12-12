using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ItEmperor.PortsAndAdapters.DalLayer.Configurations
{
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.OwnsOne(x => x.Author, b => b.Property(x => x.Name).HasColumnName("AuthorName"));

            builder.OwnsOne(x => x.Content, b => b.Property(x => x.Value).HasColumnName("Content"));
        }
    }
}