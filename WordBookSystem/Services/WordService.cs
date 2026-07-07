using WordBookSystem.Data;
using WordBookSystem.Models;
using WordBookSystem.ViewModels.Word;

namespace WordBookSystem.Services
{
    public class WordService
    {
        private readonly AppDbContext context;

        public WordService(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 登録されている単語を表示するメソッド
        /// </summary>
        /// <param name="wordBookId"></param>
        /// <returns></returns>
        public List<Words> GetWords(int wordBookId)
        {
            return context.Words
                .Where(w => w.WordBookId == wordBookId)
                .OrderByDescending(w => w.UpdatedAt)
                .ToList();
        }


        /// <summary>
        /// 対象の単語帳を取得するメソッド
        /// </summary>
        /// <param name="wordBookId"></param>
        /// <returns></returns>
        public WordBooks? GetWordBook(int wordBookId)
        {
            return context.WordBooks
                .FirstOrDefault(w => w.WordBookId == wordBookId);
        }

        /// <summary>
        /// 単語を追加するメソッド
        /// </summary>
        /// <param name="wordBookId"></param>
        /// <param name="createWord"></param>
        public void CreateWord(int wordBookId, CreateWord createWord)
        {
            var word = new Words
            {
                WordBookId = wordBookId,
                WordName = createWord.WordName,
                WordMeaning = createWord.WordMeaning,
                WordClass = createWord.WordClass,
                WordExample = createWord.WordExample,
                Memo = createWord.Memo,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            context.Words.Add(word);
            context.SaveChanges();
        }

        /// <summary>
        /// 単語を削除するメソッド
        /// </summary>
        /// <param name="wordId"></param>
        public bool DeleteWord(int wordId)
        {
            var word=context.Words
                .FirstOrDefault(w=>w.WordId == wordId);
            if (word == null)
            {
                return false;
            }
            context.Remove(word);
            context.SaveChanges();
            return true;
        }

        public bool EditWord(EditWord editWord)
        {
            var word=context.Words
                .FirstOrDefault(w=>w.WordId == editWord.WordId);
            if (word == null)
            {
                return false;
            }
            return true;

        }
    }
}
