using Microsoft.AspNetCore.Mvc;
using WordBookSystem.Services;
using WordBookSystem.ViewModels.Account;

namespace WordBookSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly AccountService accountService;

        public AccountController(AccountService accountService)
        {
            this.accountService = accountService;
        }
        /// <summary>
        /// ログイン画面表示
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        /// <summary>
        /// ログイン処理を行うメソッド
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Login(Login login)
        {
            var user = accountService.GetUser(login);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "メールアドレスまたはパスワードが正しくありません。");
                return View(login);
            }

            HttpContext.Session.SetInt32("UserId", user.UserId);

            return RedirectToAction("Index", "WordBook");
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(CreateUser createUser)
        {
            if (!ModelState.IsValid)
            {
                return View(createUser);
            }
            if (accountService.IsDuplicateEmail(createUser.Email))
            {
                ModelState.AddModelError("Email", "このメールアドレスは既に登録されています。");
                return View(createUser);
            }
            accountService.CreateUser(createUser);

            //登録後ログイン画面に戻す
            TempData["SuccessMessage"] = "ユーザー登録が完了しました。ログインしてください。";
            return RedirectToAction("Login", "Account");
        }
    }
}
