namespace Domain
{
    public class Annonces
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int NombreKm { get; set; }

        public int NombreCV { get; set; }

        public string Energie { get; set; }

        public string Marque { get; set; }

        public string Modele { get; set; }

        public string Adresse { get; set; }

        public int Version { get; set; }

        public DateTime LastModificationDate { get; set; }
    }
}
