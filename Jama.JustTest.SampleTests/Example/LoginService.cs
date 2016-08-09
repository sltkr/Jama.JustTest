namespace Jama.JustTest.SampleTests.Example
{
    public class LoginService
    {
        private readonly IAuthenticateService _authService;
        private readonly IUserService _userService;

        public LoginService(IAuthenticateService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        public bool CanProcessLogin(LoginRequest lr)
        {
            if (_userService.DoesUserExist(lr.UserName))
            {
                if (lr.UserName == "sltkr" && lr.Password == "*****")
                {
                    return true;
                }
            }

            return false;
        }
    }
}