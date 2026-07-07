using WordBookSystem.Models;

namespace WordBookSystem.ViewModels.Word
{
    public class WordList
    {
        public int WordBookId { get; set; }
        public string WordBookName { get; set; } = string.Empty;
        public List<Words> Words { get; set; } = new();
    }
}
