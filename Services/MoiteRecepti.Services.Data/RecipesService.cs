namespace MoiteRecepti.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.Win32.SafeHandles;
    using MoiteRecepti.Data.Common.Repositories;
    using MoiteRecepti.Data.Models;
    using MoiteRecepti.Services.Mapping;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class RecipesService : IRecipesService
    {
        private readonly string [] AllowedExtensions = new[] { "jpeg", "png", "gif" };
        private readonly IDeletableEntityRepository<Recipe> recipeRepository;
        private readonly IDeletableEntityRepository<Ingredient> ingredientsRespository;
        private SafeFileHandle filePath;

        public RecipesService(
            IDeletableEntityRepository<Recipe> recipesRepository,
            IDeletableEntityRepository<Ingredient> ingredientRepository)
        {
            this.recipeRepository = recipesRepository;
            this.ingredientsRespository = ingredientRepository;
        }

        public async Task CreateAsync(CreateRecipeInputModel input, string userId, string imagePath)
        {
            var recipe = new Recipe
            {
                CategoryId = input.CategoryId,
                CookigTime = TimeSpan.FromMinutes(input.CookingTime),
                Instruction = input.Instructions,
                Name = input.Name,
                PortionCount = input.PortionsCount,
                PreparationTime = TimeSpan.FromMinutes(input.PreparationTime),
                AddedByUserId = userId,
            };

            foreach (var inputIngredient in input.Ingredients)
            {
                var ingredient = this.ingredientsRespository.All().FirstOrDefault(x => x.Name == inputIngredient.IngredientName);
                if (ingredient == null)
                {
                    ingredient = new Ingredient { Name = inputIngredient.IngredientName };
                }

                recipe.Ingredients.Add(new RecipeIngredient
                {
                    Ingredient = ingredient,
                    Quantity = inputIngredient.Quantity,
                });
            }

            Directory.CreateDirectory("{imagePath}/recipes/");
            foreach (var image in input.Images)
            {
                var extension = Path.GetExtension(image.FileName).TrimStart('.');
                if (!this.AllowedExtensions.Any(x => extension.EndsWith(x)))
                {
                    throw new Exception($"Invalid image extension {extension}");
                }

                var dbImages = new Image
                {
                    AddedByUserId = userId,
                    Extension = extension,
                };
                recipe.Images.Add(dbImages);

                var physicalPath = $"{imagePath}/recipes/{dbImages.Id}.{extension}";
                using Stream fileStream = new FileStream(physicalPath, FileMode.Create);
                await image.CopyToAsync(fileStream);
            }

            await this.recipeRepository.AddAsync(recipe);
            await this.recipeRepository.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll<T>(int page, int itemsPerPage = 12)
        {
            var recpies = this.recipeRepository.AllAsNoTracking()
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * itemsPerPage).Take(itemsPerPage)
                .To<T>()
                .ToList();
            return recpies;
        }

        public int GetCount()
        {
           return this.recipeRepository.All().Count();
        }
    }
}
