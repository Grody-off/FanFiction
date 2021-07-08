namespace FanFiction.Models
{
    public class Favorites
    {
        public bool Status { get; set; }
        public int Counter { get; set; }
        public int Id { get; set; }
        public string CompositionId { get; set; }
        public string UserId { get; set; }

        public Сomposition Сomposition { get; set; }
    }
}
