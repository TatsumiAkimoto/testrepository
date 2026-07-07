using WordBookSystem.Data;
using WordBookSystem.Models;

namespace WordBookSystem.Services
{
    public class WordBookService
    {
        private readonly AppDbContext context;

        public WordBookService(AppDbContext context)
        {
            this.context = context;
        }


        /// <summary>
        /// 登録済みの単語帳を取り出して表示するメソッド
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public List<WordBooks> GetWordBooks(int? userId)
        {
            return context.WordBooks
                .Where(w => w.UserId == userId)
                .OrderByDescending(w => w.UpdatedAt)
                .ToList();
        }

        /// <summary>
        /// 新規で単語帳を作るメソッド
        /// </summary>
        /// <param name="userId"></param>
        public void CreateWordBook(int userId, string wordBookName)
        {
            var wordBook = new WordBooks
            {
                UserId = userId,
                WordBookName = wordBookName,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            context.WordBooks.Add(wordBook);
            context.SaveChanges();
        }

        public bool ValidateWordBookId(int WordBookId, int UserId)
        {
            var wordBook = context.WordBooks
                .FirstOrDefault(w => w.WordBookId == WordBookId&&w.UserId==UserId);

            if (wordBook == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// 単語帳の削除
        /// </summary>
        /// <param name="WordBookId"></param>
        /// <returns></returns>
        public bool DeleteWordBook(int WordBookId) { 
            var wordBook = context.WordBooks
                .FirstOrDefault(w => w.WordBookId == WordBookId);

            if (wordBook == null)
            {
                return false;
            }
            context.Remove(wordBook);
            context.SaveChanges();
            return true;
        }

    }
}
