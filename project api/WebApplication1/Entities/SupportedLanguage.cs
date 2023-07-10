using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication1.Entities
{
    public class SupportedLanguage : BaseEntity
    {
        public string Language { get; set; }
        [InverseProperty("Original")]
        public ICollection<Translate> Originals { get; set; } = new List<Translate>();
        [InverseProperty("Translation")]
        public ICollection<Translate> Translations{ get; set; } = new List<Translate>();
    }

}
