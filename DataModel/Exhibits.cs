using System;

namespace DataModel
{
    public class ExhibitsModel
    {
        public int Id { get; set; }
        public string ExhibitsName { get; set; }
        public int IdAuthor { get; set; }
        public DateTime CreationDate { get; set; }
        public string ArtDirection { get; set; }
        public string ArtForm { get; set; }
        public string Materials { get; set; }

        public ExhibitsModel(int id, string exhibitsName, int idAuthor, DateTime creationDate, 
            string artDirection, string artForm, string materials)
        {
            Id = id;
            ExhibitsName = exhibitsName;
            IdAuthor = idAuthor;
            CreationDate = creationDate;
            ArtDirection = artDirection;
            ArtForm = artForm;
            Materials = materials;
        }
        public ExhibitsModel() { }
    }
}

