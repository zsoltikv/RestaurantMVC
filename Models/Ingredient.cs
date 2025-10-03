using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RestaurantMVC.Models
{
    public class Ingredient
    {

        public int IngredientId { get; set; }
        public string Name { get; set; }

        [ValidateNever]
        public ICollection<Product> ProductIngredients { get; set; }

    }

}