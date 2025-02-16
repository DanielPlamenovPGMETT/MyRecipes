namespace MoiteRecepti.Web.ViewModels.Recipe
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class RecipeIngrediantImputModel
    {
        [Required]
        [MinLength(3)]
        public string IngredientName {get; set; }

        [Required]
        [MinLength(1)]
        public string Quantity { get; set; }
    }
}
