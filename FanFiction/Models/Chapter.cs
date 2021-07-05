namespace FanFiction.Models
{
    public class Chapter
    {
        public string Id { get; set; }
        public string CompositionId { get; set; }
        public Сomposition Сomposition { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
    }
}