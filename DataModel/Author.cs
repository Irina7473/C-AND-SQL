using System;

namespace DataModel
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public string BirthDate { get; set; }
        public string DeathDate { get; set; }
        public string BirthCountry { get; set; }

        public Author(int id, string authorName, string birthDate, string deathDate, string birthCountry)
        {
            Id = id;
            AuthorName=authorName;
            BirthDate = birthDate;
            DeathDate = deathDate;
            BirthCountry = birthCountry;
        }
        public Author() { }
    }
}
