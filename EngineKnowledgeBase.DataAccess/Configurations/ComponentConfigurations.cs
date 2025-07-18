using EngineKnowledgeBase.DataAccess.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
