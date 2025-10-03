namespace RestaurantMVC.Models
// a restaurantmvc.models nevtarteruletben taroljuk az osszes adatbazis modell osztalyt
// a productingredients osztaly az osszekapcsolo entitas a product es az ingredient kozott
{
    public class ProductIngredients
    // ez egy publikus productingredients osztaly
    // a szerepe, hogy megvalositsa a "tobb a tobbhoz" kapcsolatot a product es az ingredient kozott
    // vagyis: egy termeknek tobb hozzavaloja lehet, es egy hozzavalo tobb termekhez is tartozhat
    {
        public int ProductId { get; set; }
        // productid egy kulso kulcs (foreign key), amely a product entitasra hivatkozik
        // integer tipusu, megmondja melyik termekhez tartozik az adott hozzavalo

        public Product? Product { get; set; }
        // product egy navigacios tulajdonsag
        // lehetove teszi, hogy az adott rekordhoz kapcsolodo teljes product objektum elerheto legyen
        // nullable, tehat lehet null erteku is

        public int IngredientId { get; set; }
        // ingredientid egy kulso kulcs (foreign key), amely az ingredient entitasra hivatkozik
        // integer tipusu, megmondja melyik hozzavalohoz tartozik az adott termek

        public Ingredient Ingredient { get; set; }
        // ingredient egy navigacios tulajdonsag
        // lehetove teszi, hogy az adott rekordhoz kapcsolodo teljes ingredient objektum elerheto legyen
        // kotelezo (nincs kerdojel), tehat nem lehet null
    }
}