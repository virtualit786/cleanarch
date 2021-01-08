using System;
using Domain.TodoAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;


namespace Infrastructure.Persistence.Configurations
{
    public class EfContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }

        public EfContext(DbContextOptions<EfContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            //OnModelCreatingPartial(builder);

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
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost,1433\\Catalog=todo;Database=todo;User=SA;Password=reallyStrongPwd123;");
            }
        }

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}