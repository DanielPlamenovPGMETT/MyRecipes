namespace MoiteRecepti.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using MoiteRecepti.Data.Common.Models;

    public class Ingredient : BaseDeletableModel<int>
    {
        public Ingredient()
        {
            this.Recipe = new HashSet<RecipeIngredient>();
        }

        public string Name { get; set; }

        public ICollection<RecipeIngredient> Recipe { get; set; }
    }
}
