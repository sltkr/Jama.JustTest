using Moq;
using NUnit.Framework;

namespace Jama.JustTest.SampleTests.Example
{
    public class WhenAValidRequestForLogInReceived : BaseTestFixture<LoginService>
    {
        private LoginRequest _lr;
        private bool _result;

        protected override void SetupDependencies()
        {
            var userService = AutoMocker.Get<IUserService>();
            Mock.Get(userService)
                .Setup(x => x.DoesUserExist(It.IsAny<string>()))
                .Returns(true);
        }

        protected override void Given()
        {
            _lr = new LoginRequest()
            {
                UserName = "sltkr",
                Password = "*****"
            };
        }

        protected override void When()
        {
            _result = SubjectUnderTest.CanProcessLogin(_lr);
        }

        [Then]
        public void TheResponseIsSuccessful()
        {
            Assert.IsTrue(_result);
        }
    }
}
