using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineKnowledgeBase.DataAccess.Configurations
{
    public class IncludedConfigurations : IEntityTypeConfiguration<Models.Included>
    {
        public void Configure(EntityTypeBuilder<Models.Included> builder)
        {
            builder.HasKey(a => a.IncludedId);
            
            builder.HasOne(i => i.Parent)
                 .WithMany(c => c.Children)
                 .HasForeignKey(i => i.ParentId)
                 .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(i => i.Child)
                  .WithMany(c => c.Parents)
                  .HasForeignKey(i => i.ChildId)
                  .OnDelete(DeleteBehavior.NoAction);      
        }
    }
}
