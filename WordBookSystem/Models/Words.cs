using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WordBookSystem.Models
{
    public class Words
    {
        [Key]
        public int WordId { get; set; }

        [ForeignKey(nameof(WordBooks))]
        public int WordBookId { get; set; }

        [StringLength(50)]
        public string WordName {  get; set; }

        [StringLength(100)]
        public string WordMeaning { get; set; }

        [StringLength(10)]
        public string? WordClass { get; set; }

        [StringLength(300)]
        public string? WordExample { get; set; }

        [StringLength(500)]
        public string? Memo { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }

        //ナビゲーションプロパティ
        public WordBooks WordBooks { get; set; }
    }
}
