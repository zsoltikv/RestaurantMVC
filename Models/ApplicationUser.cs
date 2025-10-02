using Microsoft.AspNetCore.Identity;
// itt betoltjuk a microsoft.aspnetcore.identity nevu nevtarteruletet
// ez a csomag felelos az autentikacioert es az autorizacioert
// tartalmazza azokat az osztalyokat es interfeszeket,
// amelyekkel felhasznaloi profilokat, jelszavakat, szerepkorokat es jogosultsagokat lehet kezelni

namespace RestaurantMVC.Models
// itt definialunk egy nevtarteruletet restaurantmvc.models neven
// a nevtarterulet egy logikai kontener, amelyben osztalyokat es egyeb tipokat tarolhatunk
// a nevtarterulet segit elkerulni a nevutkozest mas osztalyokkal vagy kulso konyvtarakkal
{
    public class ApplicationUser : IdentityUser
    // itt deklaralunk egy applicationuser nevu osztalyt
    // az osztaly az identityuser osztalybol orokol
    // az identityuser egy beepitett osztaly az asp.net identity rendszerben
    // az identityuser alapertelmezett tulajdonsagokat tartalmaz a felhasznalo kezelesere
    // ilyenek: id, username, email, phonenumber, passwordhash, securitystamp stb.
    // az applicationuser osztaly kibovitesevel sajat tulajdonsagokat adhatunk a felhasznalo entitasunkhoz
    {
        public ICollection<Order>? Orders { get; set; }
        // itt egy orders nevu tulajdonsagot hozunk letre
        // az orders egy icollection tipusu gyujtemeny, amely order tipusu objektumokat tartalmaz
        // ez a tulajdonsag optionalis, vagyis null erteket is felvehet (a kerdojel miatt)
        // az order osztaly feltehetoleg egy kulon definialt entitas a rendszerben,
        // amely a felhasznalo altal leadott rendeleseket reprezentalja
        // ezzel a tulajdonsaggal megteremtjuk a kapcsolatot az applicationuser es az order entitasok kozott
        // vagyis egy felhasznalohoz tobb rendeles is kapcsolodhat (egy a tobb kapcsolat)
    }
}