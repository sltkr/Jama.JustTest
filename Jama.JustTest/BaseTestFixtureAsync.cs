using System;
using System.Threading.Tasks;
using StructureMap.AutoMocking.Moq;

namespace Jama.JustTest
{
    /// <summary>
    /// An async runner - normally you shouldn't need this but if you see a bunch of
    /// unable-to-evaluate-expression-because-the-code-is-optimized-or-a-native-frame-is errors try this.
    /// 
    /// Please note this test fixture runs your async code synchronously.
    /// </summary>
    /// <typeparam name="TSubjectUnderTest"></typeparam>
    public abstract class BaseTestFixtureAsync<TSubjectUnderTest> where TSubjectUnderTest : class
    {
        protected MoqAutoMocker<TSubjectUnderTest> AutoMocker;

        protected TSubjectUnderTest SubjectUnderTest;
        protected Exception CaughtException;

        protected virtual void SetupDependencies() { }
#pragma warning disable CS1998 // disabled build warning for placeholder methods Given and When
        protected virtual async Task Given() { }

        protected virtual async Task When() { }
#pragma warning restore CS1998
        protected virtual void Finally() { }

        [Given]
        public void Setup()
        {
            BuildMocks();
            SetupDependencies();
            SubjectUnderTest = BuildSubjectUnderTest();

            Given().Wait();

            try
            {
                When().Wait();
            }
            catch (Exception exception)
            {
                CaughtException = exception;
            }
            finally
            {
                Finally();
            }
        }

        private void BuildMocks()
        {
            AutoMocker = new MoqAutoMocker<TSubjectUnderTest>();
        }

        private TSubjectUnderTest BuildSubjectUnderTest()
        {
            return AutoMocker.ClassUnderTest;
        }
    }
}