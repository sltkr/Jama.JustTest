using System;
using NUnit.Framework;

namespace Jama.JustTest
{
    public class GivenAttribute : TestFixtureSetUpAttribute { }

    public class ThenAttribute : TestAttribute { }

    public class ThereWasNoExceptonButOneWasExpectedException : Exception { }
}