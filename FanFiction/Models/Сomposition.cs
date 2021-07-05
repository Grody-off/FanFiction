using System.Collections.Generic;

namespace FanFiction.Models
{
    public class Сomposition
    {
        public Сomposition()
        {
            Chapters = new List<Chapter>();
        }
        public string Id { get; set; }
        public string AuthorID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Fandom { get; set; }
        public string Tags { get; set; }

        public ICollection<Chapter> Chapters { get; set; }
    }
}
