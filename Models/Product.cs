using System.ComponentModel.DataAnnotations.Schema;
// ez a nevtarterulet lehetove teszi az adatbazis mapping attribútumok hasznalatat
// pl. notmapped, column, table stb.

using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
// ez a nevtarterulet a model binding es validacio attribútumokat tartalmazza
// pl. validate never, required, range stb.

namespace RestaurantMVC.Models
// a restaurantmvc.models nevtarteruletben taroljuk az alkalmazas modell osztalyait
{
    public class Product
    // ez egy publikus product osztaly
    // minden peldanya egy termeket reprezental az alkalmazasban
    {
        public int ProductId { get; set; }
        // productid az egyedi azonositó (primary key) az adatbazisban
        // integer tipusu, altalaban autoinkremental

        public string? Name { get; set; }
        // name a termek neve, szoveges tipusu, lehet null
        // a felhasznalok es a rendelesek szamara ez az azonosito jellegu adat

        public string? Description { get; set; }
        // description a termek rovid leirasa, szoveges tipusu es lehet null
        // optionalis, pl. a felhasznaloknak adhat informaciot a termekrol

        public decimal Price { get; set; }
        // price decimal tipusu, a termek egysegarat tartalmazza
        // decimal hasznalatos penzugyi ertekekhez, mert pontosabb mint a float vagy double

        public int Stock { get; set; }
        // stock integer tipusu, tarolja a termek keszletet
        // segit nyilvantartani, hogy hany darab van raktaron

        public int CategoryId { get; set; }
        // categoryid integer, a termekhez tartozo kategoria kulso kulcs
        // ez osszekapcsolja a productot a category entitassal

        [ValidateNever]
        public Category? Category { get; set; }
        // category egy navigacios tulajdonsag, amely a termek teljes kategoriat hozza el
        // validate never: a model binding es validacio ne probalja ertekeket ellenorizni
        // nullable, vagyis lehet null is

        [NotMapped]
        public IFormFile ImageFile { get; set; }
        // imagefile egy IFormFile tipusu tulajdonsag, a feltoltott kepet tarolja
        // notmapped: nem kerul adatbazisba, csak a feltoltes soran hasznaljuk
        // pl. amikor a felhasznalo feltolti a termek kepet formrol

        public string? ImageUrl { get; set; } = "https://placehold.co/150?text=no+photos+yet";
        // imageurl tarolja a kep eleresi utjat, szoveges tipusu
        // default ertek: placeholder kep, ha nincs megadva valodi kep

        [ValidateNever]
        public ICollection<OrderItem>? OrderItems { get; set; }
        // orderitems egy gyujtemeny, amely az adott termekhez kapcsolodo rendelestetelek listajat tartalmazza
        // validate never: ne ellenorizze a model binding
        // nullable: lehet null

        [ValidateNever]
        public ICollection<ProductIngredients>? ProductIngredients { get; set; }
        // productingredients egy gyujtemeny, amely a termekhez tartozo hozzavalok listajat tartalmazza
        // nullable: lehet null
        // validate never: model binding ne ellenorizze
        public Product()
        {
            ProductIngredients = new List<ProductIngredients>();
        }
    }
}