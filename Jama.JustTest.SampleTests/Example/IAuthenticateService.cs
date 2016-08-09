namespace Jama.JustTest.SampleTests.Example
{
    public interface IAuthenticateService
    {
        bool AreUserCredentialsValid(string username, string password);
    }
}