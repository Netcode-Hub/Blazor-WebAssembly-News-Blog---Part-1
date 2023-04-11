namespace DemoBlogForYoutube.Shared.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        //relationship : one to many
        public List<News>? News { get; set; }
    }
}
