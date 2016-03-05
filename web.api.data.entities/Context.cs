using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web.api.data.entities.Products;

namespace web.api.data.access
{
    public class Context : DbContext
    {
        public Context() : base("name=ContextDbConnectionString")
        {

        }

        public DbSet<ProductEntity> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<Context>());

            base.OnModelCreating(modelBuilder);
        }
    }
}
