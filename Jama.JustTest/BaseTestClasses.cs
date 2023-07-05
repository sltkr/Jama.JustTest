using System;
using NUnit.Framework;

namespace Jama.JustTest
{
    public class GivenAttribute : OneTimeSetUpAttribute { }

    public class ThenAttribute : TestAttribute { }

    public class ThereWasNoExceptionButOneWasExpectedException : Exception { }
}