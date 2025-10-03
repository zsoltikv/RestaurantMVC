using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
// ez a nevtarterulet tartalmazza a validacios attribútumokat
// pl. validate never, amely megmondja a model binding rendszernek,
// hogy egy adott tulajdonsagot ne probaljon automatikusan ellenorizni

namespace RestaurantMVC.Models
// itt egy restaurantmvc.models nevtarteruletet definialunk
// ebben helyezzuk el az adatbazis modell osztalyait
// jelen esetben az ingredient az etelekhez tartozo hozzavalokat reprezentalja
{
    public class Ingredient
    // ez egy publikus ingredient osztaly
    // minden peldanya egy-egy hozzavalot jelent (pl. "só", "liszt", "paradicsom")
    {
        public int IngredientId { get; set; }
        // ingredientid az osztaly egyedi azonositója (primary key)
        // integer tipusu, altalaban autoinkremental az adatbazisban

        public string Name { get; set; }
        // name a hozzavalo neve, szoveges tipusu
        // ez kotelezo mezo (nincs kerdojel), tehat nem lehet null
        // pl. "cukor", "vaj", "tej"

        [ValidateNever]
        public ICollection<ProductIngredients> ProductIngredients { get; set; }
        // productingredients egy navigacios tulajdonsag
        // a hozzavalo es a productingredients kozotti kapcsolatot reprezentalja
        // ez egy "tobb a tobbhoz" kapcsolatot jelent a product es az ingredient kozott,
        // amelyet a productingredients nevű osszekapcsolo tabla kezel
        // validate never: az mvc ne probalja ellenorizni vagy validalni ezt a kollekciot
    }
}