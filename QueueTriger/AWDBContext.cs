using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueueTriger
{
    public class AWDBContext : DbContext
    {
        public AWDBContext()
        {
        }

        public AWDBContext(DbContextOptions<AWDBContext> options) : base(options)
        {
        }

        public DbSet<DocumentModel> DocumentModel { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
 //           modelBuilder.Entity<DocumentModel>(entity =>
 //{
 //    entity.ToTable("Address", "Person");

 //    entity.HasIndex(e => e.Rowguid)
 //        .HasName("AK_Address_rowguid")
 //        .IsUnique();

 //    entity.HasIndex(e => e.StateProvinceId);

 //    entity.HasIndex(e => new
 //    {
 //        e.AddressLine1,
 //        e.AddressLine2,
 //        e.City,
 //        e.StateProvinceId,
 //        e.PostalCode
 //    })
 //        .IsUnique();

 //    entity.Property(e => e.AddressId).HasColumnName("AddressID");

 //    entity.Property(e => e.AddressLine1)
 //                               .IsRequired()
 //                               .HasMaxLength(60);

 //    entity.Property(e => e.AddressLine2).HasMaxLength(60);

 //    entity.Property(e => e.City)
 //                               .IsRequired()
 //                               .HasMaxLength(30);

 //    entity.Property(e => e.ModifiedDate)
 //                               .HasColumnType("datetime")
 //                               .HasDefaultValueSql("(getdate())");

 //    entity.Property(e => e.PostalCode)
 //                               .IsRequired()
 //                               .HasMaxLength(15);

 //    entity.Property(e => e.Rowguid)
 //                               .HasColumnName("rowguid")
 //                               .HasDefaultValueSql("(newid())");

 //    entity.Property(e => e.StateProvinceId).HasColumnName("StateProvinceID");

 //    entity.HasOne(d => d.StateProvince)
 //                               .WithMany(p => p.Address)
 //                               .HasForeignKey(d => d.StateProvinceId)
 //                               .OnDelete(DeleteBehavior.ClientSetNull);
 //});
        }
    }
}
