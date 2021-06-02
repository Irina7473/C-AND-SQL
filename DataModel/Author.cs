using System;

namespace DataModel
{
    public class Author
    {
        public int Id { get; set; }
        public string AuthorName { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime DeathDate { get; set; }
        public string BirthCountry { get; set; }

        public Author(int id, string authorName, DateTime birthDate, DateTime deathDate, string birthCountry)
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
