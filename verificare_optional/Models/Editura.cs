using verificare_optional.Models.Base;

namespace verificare_optional.Models
{
    public class Editura:BaseE
    {
        public string? NumeEditura { get; set; }

        public int nr_angajati  { get; set;}

        //relation one-to-many cu Autori
        public ICollection<Autori> Autorii { get; set; }
    }
}
