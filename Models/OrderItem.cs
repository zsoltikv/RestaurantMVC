namespace RestaurantMVC.Models
// itt a restaurantmvc.models nevtarteruletet hasznaljuk
// ebben taroljuk az alkalmazas modell osztalyait
// jelen esetben az orderitem az egyes rendelesek tetel sorait fogja reprezentalni
{
    public class OrderItem
    // ez egy publikus orderitem nevu osztaly
    // minden peldanya egy-egy tetelt jelent egy adott rendelésen belul
    {
        public int OrderItemId { get; set; }
        // ez a tulajdonsag az orderitem entitas egyedi azonositója (primary key)
        // integer tipusu, az adatbazisban altalaban autoinkremental

        public int OrderId { get; set; }
        // ez a tulajdonsag integer tipusu es az order entitas kulso kulcsat (foreign key) tarolja
        // ezzel kapcsoljuk ossze az orderitem-et egy adott order rekorddal
        // vagyis megmondja, hogy melyik rendeléshez tartozik a tetel

        public Order? Order { get; set; }
        // ez a tulajdonsag egy order tipusu objektum
        // navigacios tulajdonsag, amely lehetove teszi az ef core szamara,
        // hogy az orderitem es az order kozotti kapcsolatot letrehozza
        // a kerdojel miatt ez lehet null is
        // az orderid es az order kozott van a kapcsolat: foreign key - navigation property

        public int ProductId { get; set; }
        // ez a tulajdonsag a termek azonositojat tarolja (foreign key a product entitas fele)
        // integer tipusu, es megmondja, melyik termekhez tartozik a rendelestetel

        public Product? Product { get; set; }
        // ez a tulajdonsag egy product tipusu objektum
        // navigacios tulajdonsag, amely a termek teljes adatait hozza el az adott orderitem-hez
        // a product entitas valoszinuleg a termekek adatait (nev, ar, leiras) tartalmazza
        // a kerdojel miatt null erteke is lehet

        public int Quantity { get; set; }
        // ez a tulajdonsag azt adja meg, hogy a felhasznalo hany darabot rendelt az adott termekbol
        // integer tipusu, mindig 0-nal nagyobb kell legyen egy ervenyes rendelestetel eseten

        public decimal Price { get; set; }
        // ez a tulajdonsag decimal tipusu es az adott tetel egysegarat tarolja
        // a decimal tipus alkalmas penzugyi muveletekhez, mert pontosabb a lebegopontos szamoknal
        // a teljes tetel ara az orderitem szinten kiszamithato: price * quantity
    }
}