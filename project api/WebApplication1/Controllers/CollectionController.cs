using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entities;
using WebApplication1.Services.CollectionService;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private CollectionService _collectionService;
        public CollectionController(CollectionService collectionService)
        {
            _collectionService = collectionService;
        }

        [HttpPost]
        public ActionResult AddWordToCollection(int WordCollectionId, int WordId)
        {
            var result = _collectionService.AddWordToCollection(WordCollectionId, WordId);
            if (result)
            {
                return Ok();
            }
            return NotFound();
        }
        [HttpGet]
        public ActionResult<ICollection<WordCollection>> GetCollections(int userId)
        {
            var result= _collectionService.GetWordCollections(userId);
            return Ok(result);  
        }
        [HttpGet("wordsFromCollection")]
        public ActionResult<ICollection<Word>> GetWordsFromCollection(int WordsCollectionId)
        {
            var result = _collectionService.GetWordsFromCollections(WordsCollectionId);
            return Ok(result);
        }
        [HttpDelete]
        public ActionResult DeleteWordFromCollection(int WordCollectionId,int wordid)
        {
            var result=_collectionService.DeleteWordFromCollection(WordCollectionId,wordid);
            if(result)
            {
                return Ok();
            }
            return NotFound();

        }
        [HttpPut]
        public ActionResult UpdateTitleOfCollection(int WordCollectionId,string Title)
        {
            var result = _collectionService.UpdateTitleOfCollection(WordCollectionId, Title);
            if(result )
            {
                return Ok();
            }
            return NotFound();
        }
    }
}
