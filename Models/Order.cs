namespace RestaurantMVC.Models
// itt egy nevtarteruletet definialunk restaurantmvc.models neven
// a nevtarterulet logikai kontenerkent szolgál, es ebben taroljuk az alkalmazas modell osztalyait
// jelen esetben az order osztaly a rendelesekhez kapcsolodo adatokat fogja reprezentalni
{
    public class Order
    // itt deklaralunk egy order nevu publikus osztalyt
    // ez az osztaly a rendeles entitast irja le az alkalmazasban
    // minden peldanya egy-egy rendeles adatait fogja tartalmazni
    {
        public int OrderId { get; set; }
        // az orderid tulajdonsag egy egesz szam
        // ez lesz az adott rendeles egyedi azonositója az adatbazisban (primary key)
        // az ef core altalaban automatikusan kezeli az integer azonosito kulcsokat es autoinkremental

        public DateTime OrderDate { get; set; }
        // az orderdate tulajdonsag a rendeles datumot es idopontjat tarolja
        // datetime tipusu, igy pontos idobelyeget lehet hozza rendelni
        // ez segit kesobb sorrendbe tenni vagy szurni a rendeléseket datum alapjan

        public string? UserId { get; set; }
        // a userid egy szoveges tipusu tulajdonsag, amely null is lehet
        // ez tarolja a rendeleshez tartozo felhasznalo azonositojat
        // ez az azonosito az applicationuser entitas primary key ertekehez kapcsolodik
        // az identity rendszerben a felhasznalok id mezője string tipusu, ezert van itt is string

        public ApplicationUser User { get; set; }
        // a user tulajdonsag egy teljes applicationuser objektumot reprezental
        // ez a navigacios tulajdonsag, amely lehetove teszi,
        // hogy a rendelest osszekapcsoljuk a felhasznaloval az ef core relaciok segitsegevel
        // a userid es a user kozott kulcs-kulcs kapcsolat van (foreign key - navigation property)
        // ez egy "egy a tobbhoz" kapcsolatot jelent: egy felhasznalonak tobb rendelese is lehet

        public decimal TotalAmount { get; set; }
        // a totalamount tulajdonsag decimal tipusu
        // ez a rendeles teljes osszeget tarolja, osszesitve minden tetel arat
        // a decimal tipus kivalo penzugyi adatokhoz, mert pontosabb a lebegopontos szamoknal

        public ICollection<OrderItem>? OrderItems { get; set; }
        // az orderitems egy gyujtemeny (icollection), amely orderitem tipusu objektumokat tartalmaz
        // egy rendeleshez tobb tetel is tartozhat, ezert van kollekcioban tarolva
        // a kerdojel miatt a tulajdonsag lehet null is
        // az orderitem osztaly feltehetoleg a rendelesben szereplo egyes eteleket vagy termekeket reprezentalja
        // ez a kapcsolat egy "egy a tobbhoz" kapcsolat: egy rendeleshez tobb tetel tartozhat
    }
}