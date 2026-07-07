using Microsoft.AspNetCore.Mvc;
using WordBookSystem.Services;
namespace WordBookSystem.Controllers
{
    public class WordBookController : Controller
    {
        private readonly WordBookService wordBook;

        public WordBookController(WordBookService wordBook)
        {
            this.wordBook = wordBook;
        }

        [HttpGet]
        public IActionResult Index()
        {
            int? userId = HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }
            var wordBooks = wordBook.GetWordBooks(userId.Value);

            return View(wordBooks);
        }
        /// <summary>
        /// 単語帳の作成
        /// </summary>
        /// <param name="wordBookName"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Create(string wordBookName)
        {
            int?userId=HttpContext.Session.GetInt32("UserId");
            if (userId == null)
            {
                return RedirectToAction("Login", "Account");
            }

            wordBook.CreateWordBook(userId.Value,wordBookName);
            return RedirectToAction("Index");

        }

        /// <summary>
        /// 単語帳の削除
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Delete(int WordBookId)
        {
            bool result=wordBook.DeleteWordBook(WordBookId);
            if (!result)
            {
                return NotFound();
            }
            TempData["SuccessMessage"] = "単語帳を削除しました。";

            return RedirectToAction("Index");
        }
    }
}
