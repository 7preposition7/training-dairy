using Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class DairyContext : IdentityDbContext<AppUser>
    {
        public DairyContext() : base()
        {

        }

        public DairyContext(DbContextOptions<DairyContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public new DbSet<AppUser> Users { get; set; }
        public DbSet<Training> Trainings { get; set; }
    }
}
