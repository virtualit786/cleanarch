using System;
using Domain.TodoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Persistence.Configurations
{
    public partial class EfContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public IConfiguration Configuration { get; }

        public EfContext(DbContextOptions<EfContext> options, IConfiguration configuration) : base(options)
        {
            Configuration = configuration;
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            OnModelCreatingPartial(builder);

            TodoModelConfig(builder);

            base.OnModelCreating(builder);
        }

        private void TodoModelConfig(ModelBuilder builder)
        {
            builder.Entity<Todo>().ToTable("Todo");
            builder.Entity<Todo>().HasKey(x => x.Id);
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.GetConnectionString("TodoDatabase"));
            }
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}