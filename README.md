Jama.JustTest
=============

JustTest

A simple test fixture set up which provides convenient auto-mocking capabilities that allow you to write BDD style unit tests.

Dependencies
------------
- nUnit
- StructureMap.Automocker.Moq

Example Usage
-------------
```csharp
public class WhenAValidRequestForLogInRecieved : BaseTestFixture<LoginService>
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
```

The beauty of the Auto-mocker really shines as we only have to set up the dependency that the test is concerned with. All the other mumbo jumbo is automocked for us and we don't need to worry about it.

In this contrived example we only care about the IUserService and we set an expectation on it's DoesUserExist method call.


**Other Classes for reference**
```csharp
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
 public class LoginRequest
{
	public string UserName { get; set; }
	public string Password { get; set; }
}

public interface IUserService
{
	bool DoesUserExist(string userName);
	bool IsUserActiveAndNotDisabled(string username);
}

public interface IAuthenticateService
{
	bool AreUserCredentialsValid(string username, string password);
}
```
