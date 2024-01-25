using verificare_optional.Models.Base;

namespace verificare_optional.Models
{
    public class Autori : BaseE
    {
        public string? Nume {get;set;}
        public string? Prenume { get;set;}
        public int Varsta { get;set;}

        //relatie many-to-many cu Carti
        public ICollection<ModelsRelationAUCT> ModelsRelationsAUCT { get;set;}


        //relatie one-to-many cu Editura
        public Editura Editura { get;set;}
        public Guid EdituraId { get;set;}

    }
}
