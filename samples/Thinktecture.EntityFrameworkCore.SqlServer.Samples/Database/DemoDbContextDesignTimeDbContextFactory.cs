using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Thinktecture.Database
{
   public class DemoDbContextDesignTimeDbContextFactory : IDesignTimeDbContextFactory<DemoDbContext>
   {
      [NotNull]
      public DemoDbContext CreateDbContext(string[] args)
      {
         var options = new DbContextOptionsBuilder<DemoDbContext>()
                       .UseSqlServer(SamplesContext.Instance.ConnectionString)
                       .AddSchemaAwareComponents()
                       .Options;

         return new DemoDbContext(options);
      }
   }
}
