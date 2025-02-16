namespace MoiteRecepti.Data.Models
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Security.Cryptography.X509Certificates;

    using MoiteRecepti.Data.Common.Models;

    public class Recipe : BaseDeletableModel<int>
    {
        public Recipe()
        {
            this.Ingredients = new HashSet<RecipeIngredient>();
            this.Images = new HashSet<Image>();
        }

        public string Name { get; set; }

        public string Instruction { get; set; }

        public TimeSpan PreparationTime { get; set; }

        public TimeSpan CookigTime { get; set; }

        public int PortionCount { get; set; }

        public string AddedByUserId { get; set; }

        public virtual ApplicationUser AddedByUser { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<RecipeIngredient> Ingredients { get; set; }

        public virtual ICollection<Image> Images { get; set; }
    }
}
