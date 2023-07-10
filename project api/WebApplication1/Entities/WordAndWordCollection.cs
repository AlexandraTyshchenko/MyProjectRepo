namespace WebApplication1.Entities
{
    public class WordAndWordCollection:BaseEntity
    {
            public int? WordId { get; set; }
            public Word Word { get; set; }

            public int? WordCollectionId { get; set; }
            public WordCollection WordCollection { get; set; }
    }
}
