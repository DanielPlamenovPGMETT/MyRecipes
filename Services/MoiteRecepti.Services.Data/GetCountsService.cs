﻿namespace MoiteRecepti.Services.Data
{
    using System.Linq;

    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Data.Models;
    using MoiteRecepti.Web.ViewModels.Home;

    public class GetCountsService : IGetCountsService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;
        private readonly IRepository<Image> imagesRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingrediantsRepository;
        private readonly IDeletableEntityRepository<Recipe> recipesRepository;

        public GetCountsService(
        IDeletableEntityRepository<Category> categoriesRepository,
        IRepository<Image> imagesRepository,
        IDeletableEntityRepository<Ingredient> ingrediantsRepository,
        IDeletableEntityRepository<Recipe> recipesRepository)
        {
            this.categoriesRepository = categoriesRepository;
            this.imagesRepository = imagesRepository;
            this.ingrediantsRepository = ingrediantsRepository;
            this.recipesRepository = recipesRepository;
        }

        public CountsDto GetCount()
        {
            var data = new CountsDto
            {
                CategoriesCount = this.categoriesRepository.All().Count(),
                ImagesCount = this.imagesRepository.All().Count(),
                IngredientsCount = this.ingrediantsRepository.All().Count(),
                RecipesCount = this.recipesRepository.All().Count(),
            };

            return data;
        }
    }
}
