namespace WebApplication1.Entities
{
    public class WordCollection : BaseEntity
    {
        public string Title { get; set; }
        public ICollection<WordAndWordCollection> WordAndWordCollection { get; set; } = new List<WordAndWordCollection>();
        public int? UserID { get; set; }
        public User user;
    }
}
