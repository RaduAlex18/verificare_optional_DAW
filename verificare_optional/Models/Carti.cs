using verificare_optional.Models.Base;

namespace verificare_optional.Models
{
    public class Carti:BaseE
    {
        public string? NumeCarte { get; set; }

        public int Nr_pagini { get; set; }

        //relatie many-to-many cu Autori
        public ICollection<ModelsRelationAUCT> ModelsRelationsAUCT { get; set; }
    }
}
