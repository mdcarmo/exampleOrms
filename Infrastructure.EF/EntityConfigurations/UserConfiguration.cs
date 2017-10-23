using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.EF.EntityConfigurations
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            this.ToTable("Users");
            this.HasKey(p => p.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.Name).IsRequired().HasMaxLength(255);
            this.Property(p => p.CreatedDate).IsRequired();
        }
    }
}
