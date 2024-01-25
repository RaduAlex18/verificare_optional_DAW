namespace verificare_optional.Models
{
    public class ModelsRelationAUCT
    {
        public Guid AutorId { get; set; }
        public Autori Autori { get; set; }

        public Guid CarteId { get; set; }
        public Carti Carti { get; set; }
    }
}
