using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace RestaurantMVC.Models
{
    public class Product
    {

        public int ProductId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public int CategoryId { get; set; }

        [ValidateNever]
        public Category? Category { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        public string? ImageUrl { get; set; } = "https://placehold.co/150?text=no+photos+yet";

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }

        [ValidateNever]
        public ICollection<ProductIngredients> ?ProductIngredients { get; set; }

    }

}