using Microsoft.EntityFrameworkCore;
using WebApplication1.Entities;

namespace WebApplication1
{
    public class Context:DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }
        public DbSet<User> users { get; set; }
        public DbSet<Word> words { get; set; }
        public DbSet<Translate> languages { get; set; }
        public DbSet<WordCollection> wordsCollection { get; set; }
        public DbSet<SupportedLanguage> supportedLanguages { get; set; }
     
        public DbSet<WordAndWordCollection> WordAndWordCollection { get; set; }
    }
}
