using System.ComponentModel.DataAnnotations;

namespace WordBookSystem.ViewModels.Account
{
    public class CreateUser
    {
        [Required(ErrorMessage = "メールアドレスを入力してください。")]
        [StringLength(124, ErrorMessage = "メールアドレスは124文字以内で入力してください。")]
        [EmailAddress(ErrorMessage = "メールアドレスを正しい値で入力してください。")]
        public string Email { get; set; }

        [Required(ErrorMessage = "パスワードを入力してください。")]
        [RegularExpression(
         @"^(?=.*[A-Za-z])(?=.*\d)[A-Za-z\d]{8,20}$",
         ErrorMessage = "パスワードは8～20文字の半角英数字で、英字と数字を両方含めてください。")]
        public string Password { get; set; }

        [Required(ErrorMessage = "確認用パスワードを入力してください。")]
        [Compare(nameof(Password), ErrorMessage = "パスワードが一致しません。")]
        public string ConfirmPassWord {  get; set; }
    }
}
