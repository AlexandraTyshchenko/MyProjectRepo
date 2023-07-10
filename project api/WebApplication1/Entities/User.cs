namespace WebApplication1.Entities
{
    public class User:BaseEntity
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICollection<WordCollection> wordCollections { get; set; }= new List<WordCollection>();
        //буде зв'язок 1 до багатьох а не багато до багатьох оскільки кожен юзер буде створювати свій збірник
        
    }
}
