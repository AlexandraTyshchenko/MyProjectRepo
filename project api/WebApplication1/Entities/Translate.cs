using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class Translate : BaseEntity
    {
        public int? OriginalID { get; set; }

        public int? TranslationID { get; set; }

        public SupportedLanguage Original { get; set; }

        public SupportedLanguage Translation { get; set; }
    }

}
