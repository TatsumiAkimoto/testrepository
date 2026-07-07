using Microsoft.AspNetCore.Mvc;
using WordBookSystem.Services;
using WordBookSystem.ViewModels.Word;

namespace WordBookSystem.Controllers
{
    public class WordController : Controller
    {
        private readonly WordService wordService;

        public WordController(WordService wordService)
        {
            this.wordService = wordService;
        }

        [HttpGet]
        public IActionResult List(int wordBookId)
        {
            var wordBook = wordService.GetWordBook(wordBookId);

            if (wordBook == null)
            {
                return NotFound();
            }

            var Model = new WordList
            {
                WordBookId = wordBook.WordBookId,
                WordBookName = wordBook.WordBookName,
                Words = wordService.GetWords(wordBookId)
            };

            return View(Model);
        }
        [HttpPost]
        public IActionResult Create(int wordBookId, CreateWord createWord)
        {
            wordService.CreateWord(wordBookId, createWord);

            return RedirectToAction("List", new { wordBookId = wordBookId });
        }

        [HttpPost]
        public IActionResult Delete(int wordId, int wordBookId)
        {
            var result = wordService.DeleteWord(wordId);

            if (!result)
            {
                return NotFound();
            }

            TempData["SuccessMessage"] = "単語の削除が完了しました";

            return RedirectToAction("List", new { wordBookId });
        }
        /*
        [HttpGet]
        public IActionResult Edit(EditWord editWord)
        {
            
        }
        */
    }
}
