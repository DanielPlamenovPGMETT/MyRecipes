﻿namespace MoiteRecepti.Web.ViewModels.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Microsoft.AspNetCore.Http;
    using MoiteRecepti.Web.ViewModels.Recipe;

    public class CreateRecipeInputModel
    {
        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        [Required]
        [MinLength(100)]
        public string Instructions { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Preparation time (in minutes)")]
        public int PreparationTime { get; set; }

        [Range(0, 24 * 60)]
        [Display(Name = "Cooking time (in minutes)")]
        public int CookingTime { get; set; }

        [Range(1, 100)]
        public int PortionsCount { get; set; }

        public int CategoryId { get; set; }

        public IEnumerable<IFormFile> Images { get; set; }

        public IEnumerable<RecipeIngrediantImputModel> Ingredients { get; set; }

        public IEnumerable<KeyValuePair<string, string>> CategoriesItems { get; set; }
    }
}
