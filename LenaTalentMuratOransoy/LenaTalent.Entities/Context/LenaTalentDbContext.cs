using LenaTalent.Entities.Models.Entities;
using LenaTalent.Entities.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LenaTalent.Entities.Context
{
    public class LenaTalentDbContext : IdentityDbContext<User, Role, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=DESKTOP-KJMJB5S;Database=LenaTalentDB;User Id=sa;Password = 1234");


        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Form>()
                .HasMany(f => f.FormData)
                .WithOne(fd => fd.Form)
                .HasForeignKey(fd => fd.FormID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Field>()
                .HasOne(f => f.Form)
                .WithMany(f => f.Fields)
                .HasForeignKey(f => f.FormID)
                .OnDelete(DeleteBehavior.NoAction);

            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Form> Forms { get; set; }
        public DbSet<Field> Fields { get; set; }
        public DbSet<FormData> FormData { get; set; }


    }
}
