namespace WebApplication1.Entities
{
    public class Word:BaseEntity
    {
        public string OriginalWord { get; set; }
        public string TranslatedWord { get; set; }
        public string Explanation { get; set; }
        public Translate Language { get; set; }
        public ICollection<WordAndWordCollection> WordAndWordCollection { get; set; } = new List<WordAndWordCollection>();
    }

}

