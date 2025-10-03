using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
// ez a nevtarterulet tartalmazza a validacios attribútumokat
// pl. validate never, amely lehetove teszi, hogy bizonyos tulajdonsagokat ne vizsgaljon a model binding

namespace RestaurantMVC.Models
// itt egy restaurantmvc.models nevtarteruletet hozunk letre
// ebben taroljuk az alkalmazas modell osztalyait, amelyek az adatbazis entitasokat reprezentaljak
{
    public class Category
    // ez egy publikus category nevu osztaly
    // minden peldanya egy termekkategoriat reprezental az adatbazisban
    // a kategoriak segitsegevel logikai csoportokra lehet bontani a termekeket
    {
        public int CategoryId { get; set; }
        // categoryid az osztaly egyedi azonositója (primary key)
        // integer tipusu, altalaban autoinkremental

        public string? Name { get; set; }
        // name tulajdonsag a kategoria nevet tarolja
        // szoveges tipusu es lehet null is
        // pl. "levesek", "foetelek", "italok"

        public string? Description { get; set; }
        // description a kategoria rovid leirasat tarolja
        // szoveges tipusu es lehet null
        // pl. extra informacio arrol, hogy milyen etelek tartoznak a kategoriaba

        [ValidateNever]
        public ICollection<Product>? Products { get; set; }
        // products egy navigacios tulajdonsag
        // egy kategoriaban tobb termek is lehet, ezert icollection tipusu gyujtemeny
        // a kerdojel miatt null is lehet
        // validate never: az mvc model binding nem fogja validalni
        // ez egy "egy a tobbhoz" kapcsolat: egy kategoriaban sok product szerepelhet
    }
}