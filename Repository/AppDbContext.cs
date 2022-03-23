using Core.Model;
using Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Repository
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<ProductFeature> ProductFeatures { get; set; }

        //CreatedData UpdateDate normal

        public override int SaveChanges()
        {
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityRefarence) //Referance type's meaning
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityRefarence.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {


                                entityRefarence.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChanges();
        }



        //CreatedData UpdatedDate async
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            //Take Entries with ChangeTracker
            foreach (var item in ChangeTracker.Entries())
            {
                if (item.Entity is BaseEntity entityRefarence) //Referance type's meaning
                {
                    switch (item.State)
                    {
                        case EntityState.Added:
                            {
                                entityRefarence.CreatedDate = DateTime.Now;
                                break;
                            }
                        case EntityState.Modified:
                            {
                                //Dont Change Created Date
                                Entry(entityRefarence).Property(x => x.CreatedDate).IsModified = false;


                                entityRefarence.UpdateDate = DateTime.Now;
                                break;
                            }
                    }
                }
            }


            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //FluentApi
            //modelBuilder.Entity<Category>().HasKey(x=>x.Id)

            //All
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //One class
            //modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
    }
}
