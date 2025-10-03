using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
// ez a nevtarterulet tartalmazza az identitydbcontext osztalyt
// ez egy kulonleges dbcontext, amely az asp.net identity rendszerhez elore beallitott adatbazis tablakat kezel
// pl. users, roles, userclaims, roleclaims stb.

using Microsoft.EntityFrameworkCore;
// ez a nevtarterulet tartalmazza az entity framework core osztalyait es metodusait
// pl. dbcontext, dbset, modelbuilder stb.

using Microsoft.Identity.Client;
// ez a nevtarterulet az azure identity klienshez hasznalatos (itt valoszinuleg nem szukseges, de importalva van)

using RestaurantMVC.Models;
// itt elerhetove tesszuk a models nevtarteruletet, hogy az adatbazis entitas osztalyokat felhasznaljuk
// pl. product, category, order, ingredient stb.

namespace RestaurantMVC.Data
// a restaurantmvc.data nevtarteruletben taroljuk az adatbazishoz kapcsolodo osztalyokat
// ide kerul az applicationdbcontext is, ami az ef core es az identity kozponti dbcontext-je lesz
{
    public class ApplicationDbContext : IdentityDbContext
    // applicationdbcontext osztaly az identitydbcontext-bol orokol
    // az identitydbcontext mar tartalmazza az identity rendszer alap tablait es beallitasait
    // mi itt bovitjuk ezt a sajat alkalmazasunk entitasaival
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        // a konstruktor dbcontextoptions tipust var, amely az adatbazis konfiguraciojat tartalmazza
        // pl. melyik adatbazishoz csatlakozzon (sql server, sqlite stb.)
        // ezt az options-t atadjuk a base (identitydbcontext) osztalynak

        public DbSet<Product> Products { get; set; }
        // dbset<product>: az ef core ezen keresztul hoz letre es kezel egy "products" nevu tablat az adatbazisban

        public DbSet<Category> Categories { get; set; }
        // dbset<category>: kategoriakat kezelo tabla az adatbazisban

        public DbSet<Order> Orders { get; set; }
        // dbset<order>: rendeleseket tarolo tabla

        public DbSet<OrderItem> OrderItems { get; set; }
        // dbset<orderitem>: rendelestetelek tablat tarolja

        public DbSet<Ingredient> Ingredients { get; set; }
        // dbset<ingredient>: hozzavalok tablat tarolja

        public DbSet<ProductIngredients> ProductIngredients { get; set; }
        // dbset<productingredients>: osszekapcsolo tabla a product es az ingredient kozott (many-to-many kapcsolat)

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        // itt konfiguraciokat adhatunk meg az ef core szamara, mielott az adatbazis tablakat letrehozza
        // pl. kulcsok, kapcsolatok, constraint-ek
        {
            base.OnModelCreating(modelBuilder);
            // az identity rendszer sajat konfiguraciojat is lefuttatjuk, hogy ne veszitse el az alap beallitasokat

            modelBuilder.Entity<ProductIngredients>()
                .HasKey(pi => new { pi.ProductId, pi.IngredientId });
            // itt beallitjuk, hogy a productingredients tabla osszetett kulcsot hasznaljon
            // a kulcs a productid es az ingredientid parosabol all ossze (composite key)

            modelBuilder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductIngredients)
                .HasForeignKey(pi => pi.ProductId);
            // beallitjuk a kapcsolatot a productingredients es a product kozott
            // egy productingredients sor egy producthoz tartozik (hasone)
            // egy producthoz tobb productingredients sor tartozhat (withmany)
            // a foreign key a productid lesz

            modelBuilder.Entity<ProductIngredients>()
                .HasOne(pi => pi.Ingredient)
                .WithMany(i => i.ProductIngredients)
                .HasForeignKey(pi => pi.IngredientId);
            // beallitjuk a kapcsolatot a productingredients es az ingredient kozott
            // egy productingredients sor egy ingredienthez tartozik (hasone)
            // egy ingredienthez tobb productingredients sor tartozhat (withmany)
            // a foreign key az ingredientid lesz
        }
    }
}