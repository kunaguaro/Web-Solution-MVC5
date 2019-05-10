

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using WebAppGen.Model.Entities;

namespace WebAppGen.Infrastructure
{

    public interface IContext
    {

        IDbSet<Country> Countries { get; set; }

        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();
    }

    public class WebAppContext : DbContext, IContext
    {

        public WebAppContext()
            : base("Name=MyConn")
        {
            //this.Configuration.LazyLoadingEnabled = false; 
        }


        public IDbSet<Country> Countries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Country>()
                .ToTable("Countries")
                .Property (c=>c.Name).HasColumnName("Nombre")
                ;

        }


    }
}
