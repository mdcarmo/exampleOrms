using Model.Entities;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace Infrastructure.EF.EntityConfigurations
{
    public class CustomerConfiguration : EntityTypeConfiguration<Customer>
    {
        public CustomerConfiguration()
        {
            this.ToTable("Customers");
            this.HasKey(p => p.Id);
            this.Property(e => e.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(p => p.FirstName).IsRequired().HasMaxLength(255);
            this.Property(p => p.LastName).IsRequired().HasMaxLength(255);
            this.Property(p => p.IsActive).IsRequired();
        }
    }
}
