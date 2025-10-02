using Microsoft.AspNetCore.Identity;

namespace RestaurantMVC.Models
{
    public class ApplicationUser : IdentityUser
    {

        public ICollection<Order>? Orders { get; set; }

    }

}
