namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;


    public class CategoriesSevice : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesSevice(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllKeyValuePairs()
        {
            return this.categoriesRepository.AllAsNoTracking()
                .Select(x => new
            {
                x.Name,
                x.Id,
            })
                .OrderBy(x => x.Name)
                .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }
    }
}
