namespace Jama.JustTest.SampleTests.Example
{
    public interface IUserService
    {
        bool DoesUserExist(string userName);
        bool IsUserActiveAndNotDisabled(string username);
    }
}