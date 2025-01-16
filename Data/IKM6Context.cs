using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using IKM6.Models;
using Microsoft.Extensions.Hosting;

namespace IKM6.Data
{
    public class IKM6Context : DbContext
    {
        public IKM6Context (DbContextOptions<IKM6Context> options)
            : base(options)
        {
        }

        public DbSet<IKM6.Models.item> item { get; set; } = default!;
        public DbSet<IKM6.Models.property> property { get; set; } = default!;
        public DbSet<IKM6.Models.values> values { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<values>()
                .HasOne(e => e.property)
                .WithMany(e => e.values)
                .HasForeignKey(e => e.property_id)
                .IsRequired();

            modelBuilder.Entity<values>()
                .HasMany(e => e.Items)
                .WithMany(e => e.Values);
        }
        
    }
}
