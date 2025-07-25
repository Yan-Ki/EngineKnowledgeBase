using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EngineKnowledgeBase.DataAccess.Configurations
{
    public class ComponentConfigurations : IEntityTypeConfiguration<Models.Component>
    {
        public void Configure(EntityTypeBuilder<Models.Component> builder)
        {
            builder.HasKey(a=>a.ComponentId);
            builder.Property(c => c.Name).IsRequired(false);
            builder.Property(c => c.Simple).IsRequired(false);
            builder.Property(c => c.Description).IsRequired(false);
        }
    }
}
