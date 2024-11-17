namespace SurvivorAPI.Model
{
    public class Category : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Competitor> Competitors { get; set; }
    }
}
