using WordBookSystem.Data;
using WordBookSystem.Models;
using WordBookSystem.ViewModels.Account;

namespace WordBookSystem.Services
{
    public class AccountService
    {
        private readonly AppDbContext context;

        public AccountService(AppDbContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// 入力されたユーザー情報とデータベースが一致するか確認するメソッド
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public Users? GetUser(Login login)
        {
            return context.Users.FirstOrDefault(u =>
                u.UserEmail == login.Email &&
                u.UserPassword == login.Password);
        }

        /// <summary>
        /// メールアドレスの重複チェック
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public bool IsDuplicateEmail(string email)
        {
            bool exists=context.Users.Any(u=>u.UserEmail==email);
            if (exists)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// user情報をDBに追加するメソッド
        /// </summary>
        /// <param name="login"></param>
        public void CreateUser(CreateUser createUser)
        {
            //userエンティティ生成
            var user = new Users
            {
                UserEmail = createUser.Email,
                UserPassword = createUser.Password,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now,
            };

            //DB登録
            context.Users.Add(user);
            context.SaveChanges();
        }
     
    }
}
