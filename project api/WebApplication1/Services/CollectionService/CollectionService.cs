using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.Text.Json;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Services.CollectionService
{
    public class CollectionService
    {
        private Context _context;
        public CollectionService(Context context)
        {
            _context = context;
        }
        public bool AddWordToCollection(int WordCollectionId, int WordId)
        {
            var WordCollection = _context.wordsCollection.FirstOrDefault(x => x.Id == WordCollectionId);
            var word = _context.words.FirstOrDefault(x => x.Id == WordId);
            if (WordCollection == null || word == null)
            {
                return false;
            }
            WordCollection.WordAndWordCollection.Add(new WordAndWordCollection { WordId= WordId ,WordCollectionId= WordCollectionId });
            _context.SaveChanges();
            return true;
        }
        public ICollection<WordCollection> GetWordCollections(int userid)
        {
           var result=_context.wordsCollection.Where(x=>x.UserID==userid)
                .ToList();
            return result;

        }
        public ICollection<Word> GetWordsFromCollections(int WordCollectionId)
        {
            var result = _context.WordAndWordCollection.Include(x=>x.Word).
                ThenInclude(x=>x.Language)
                .Where(x=>x.WordCollectionId==WordCollectionId).Select(x=>x.Word);
            return result.ToList();
        }

        public bool DeleteWordFromCollection(int WordCollectionId,int wordid)
        {
            var result = _context.WordAndWordCollection.Include(x => x.Word).FirstOrDefault(x => x.WordCollectionId ==
            WordCollectionId && x.WordId == wordid);
            if(result!=null)
            {
                _context.WordAndWordCollection.Remove(result);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
        public bool UpdateTitleOfCollection(int WordCollectionId,string Title)
        {
            var result = _context.wordsCollection.FirstOrDefault(x => x.Id == WordCollectionId);
            if(result!=null )
            {
                result.Title = Title;
                _context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
