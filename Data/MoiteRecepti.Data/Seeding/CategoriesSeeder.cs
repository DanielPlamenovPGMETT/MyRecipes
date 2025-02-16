namespace MoiteRecepti.Data.Seeding
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore.Internal;
    using MoiteRecepti.Data.Models;

    public class CategoriesSeeder : ISeeder
    {
       public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider erviceProvider)
        {
          if (dbContext.Categories.Any())
          {
           return;
          }

          await dbContext.Categories.AddAsync(new Models.Category { Name = "Tart" });
          await dbContext.Categories.AddAsync(new Models.Category { Name = "Keks" });
          await dbContext.Categories.AddAsync(new Models.Category { Name = "Pecheno Svinsko" });

          await dbContext.SaveChangesAsync();
        }
    }
}
