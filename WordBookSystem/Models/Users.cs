using System.ComponentModel.DataAnnotations;

namespace WordBookSystem.Models
{
    public class Users
    {
        [Key]
        public int UserId {  get; set; }

        [StringLength(124)]//最大124文字
        public string UserEmail {  get; set; }

        [StringLength(20)]//最大20文字
        public string UserPassword {  get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; } 
    }
}
