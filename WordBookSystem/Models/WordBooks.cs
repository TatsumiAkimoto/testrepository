using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordBookSystem.Models
{
    public class WordBooks
    {
        [Key]
        public int WordBookId {  get; set; }

        [ForeignKey(nameof(Users))]
        public int UserId { get; set; }

        [StringLength(30)]
        public string WordBookName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        //ナビゲーションプロパティ
        public Users Users { get; set; }
    }
}
